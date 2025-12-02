using UnityEngine;
using System.Collections.Generic;
using PoolSystem.Interfaces;
using PoolSystem.Models;
using PoolSystem.Factories;

namespace PoolSystem.Repository
{
    /// <summary>
    /// Repositorio principal de pools
    /// Patrón: Repository Pattern
    /// Principio: Single Responsibility Principle (SRP) - Solo gestión de almacenamiento
    /// </summary>
    public class PoolRepository : IPoolRepository
    {
        private Dictionary<PoolObjectType, PoolData> pools;
        private IPoolObjectFactory objectFactory;
        private IPoolStrategy poolStrategy;
        private IPoolSubject poolSubject;
        private Transform containerParent;

        public PoolRepository(IPoolObjectFactory factory, IPoolStrategy strategy, Transform parent = null)
        {
            pools = new Dictionary<PoolObjectType, PoolData>();
            objectFactory = factory ?? new PoolObjectFactory(parent);
            poolStrategy = strategy ?? new StandardPoolStrategy();
            poolSubject = new PoolSubject();
            containerParent = parent;
        }

        public void InitializePool(IPoolConfiguration config)
        {
            if (config == null)
            {
                Debug.LogError("[PoolRepository] Cannot initialize pool: null configuration");
                return;
            }

            if (pools.ContainsKey(config.Type))
            {
                Debug.LogWarning($"[PoolRepository] Pool {config.Type} already initialized");
                return;
            }

            var poolData = new PoolData(config, containerParent);
            pools[config.Type] = poolData;

            // Pre-poblar con objetos iniciales
            for (int i = 0; i < config.InitialCount; i++)
            {
                CreateAndReturnToPool(config);
            }

            Debug.Log($"[PoolRepository] Initialized pool {config.Type} with {config.InitialCount} objects");
        }

        public IPoolable Get(PoolObjectType type, Vector3 position, Quaternion rotation)
        {
            if (!pools.TryGetValue(type, out PoolData poolData))
            {
                Debug.LogError($"[PoolRepository] Pool {type} not found. Initialize it first.");
                return null;
            }

            IPoolable poolable = null;

            // Intentar obtener del pool
            if (poolData.AvailableObjects.Count > 0)
            {
                poolable = poolData.AvailableObjects.Dequeue();
            }
            else if (poolStrategy.CanExpand(poolData.Configuration, poolData.TotalCreated))
            {
                // Crear nuevo objeto si se puede expandir
                poolable = CreateNewPoolObject(poolData.Configuration);
                if (poolable != null)
                {
                    poolData.TotalCreated++;
                    poolSubject.NotifyPoolExpanded(type, poolData.TotalCreated);
                }
            }

            if (poolable != null)
            {
                // Configurar posición y rotación
                if (poolable is MonoBehaviour mb)
                {
                    mb.transform.position = position;
                    mb.transform.rotation = rotation;
                }

                // Activar objeto
                poolable.OnGetFromPool();
                poolData.ActiveObjects.Add(poolable);
                
                poolSubject.NotifyObjectRetrieved(type, poolable);
                return poolable;
            }

            Debug.LogWarning($"[PoolRepository] Could not provide {type} object - pool exhausted and cannot expand");
            return null;
        }

        public void Return(IPoolable poolable)
        {
            if (poolable == null) return;

            PoolObjectType type = poolable.Type;
            
            if (!pools.TryGetValue(type, out PoolData poolData))
            {
                Debug.LogError($"[PoolRepository] Cannot return {type} object - pool not found");
                return;
            }

            if (!poolData.ActiveObjects.Remove(poolable))
            {
                Debug.LogWarning($"[PoolRepository] Object {type} was not active in pool");
                return;
            }

            // Desactivar objeto
            poolable.OnReturnToPool();

            // Mover al contenedor del pool
            if (poolable is MonoBehaviour mb)
            {
                mb.transform.SetParent(poolData.Container.transform);
            }

            // Devolver al pool
            poolData.AvailableObjects.Enqueue(poolable);
            poolSubject.NotifyObjectReturned(type, poolable);
        }

        public PoolSystem.Models.PoolStatistics GetPoolStatistics(PoolObjectType type)
        {
            if (!pools.TryGetValue(type, out PoolData poolData))
            {
                return new PoolSystem.Models.PoolStatistics(type, 0, 0, 0, 0, false);
            }

            return new PoolSystem.Models.PoolStatistics(
                type,
                poolData.TotalCreated,
                poolData.ActiveObjects.Count,
                poolData.AvailableObjects.Count,
                poolData.Configuration.MaxCount,
                poolData.Configuration.AutoExpand
            );
        }

        public void ClearAllPools()
        {
            foreach (var kvp in pools)
            {
                kvp.Value.Cleanup();
            }
            pools.Clear();
            Debug.Log("[PoolRepository] All pools cleared");
        }

        public bool HasPool(PoolObjectType type)
        {
            return pools.ContainsKey(type);
        }

        private IPoolable CreateNewPoolObject(IPoolConfiguration config)
        {
            var poolable = objectFactory.CreatePoolObject(config);
            if (poolable != null)
            {
                poolSubject.NotifyObjectCreated(config.Type, poolable);
            }
            return poolable;
        }

        private void CreateAndReturnToPool(IPoolConfiguration config)
        {
            var poolable = CreateNewPoolObject(config);
            if (poolable != null)
            {
                var poolData = pools[config.Type];
                poolData.TotalCreated++;
                
                // Configurar y devolver inmediatamente
                poolable.OnReturnToPool();
                if (poolable is MonoBehaviour mb)
                {
                    mb.transform.SetParent(poolData.Container.transform);
                }
                poolData.AvailableObjects.Enqueue(poolable);
            }
        }

        /// <summary>
        /// Suscribir observador para eventos de pool
        /// </summary>
        public void Subscribe(IPoolObserver observer)
        {
            poolSubject.Subscribe(observer);
        }

        /// <summary>
        /// Desuscribir observador
        /// </summary>
        public void Unsubscribe(IPoolObserver observer)
        {
            poolSubject.Unsubscribe(observer);
        }
    }

    /// <summary>
    /// Servicio de pools con API simplificada
    /// Patrón: Facade Pattern
    /// Principio: Interface Segregation Principle (ISP) - API específica para uso común
    /// </summary>
    public class PoolService : IPoolService
    {
        private IPoolRepository repository;
        private IPoolStrategy strategy;

        public PoolService(IPoolRepository repository, IPoolStrategy strategy = null)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
            this.strategy = strategy ?? new StandardPoolStrategy();
        }

        public T Get<T>(PoolObjectType type, Vector3 position) where T : class, IPoolable
        {
            return Get<T>(type, position, Quaternion.identity);
        }

        public T Get<T>(PoolObjectType type, Vector3 position, Quaternion rotation) where T : class, IPoolable
        {
            var poolable = repository.Get(type, position, rotation);
            return poolable as T;
        }

        public void Return(IPoolable poolable)
        {
            strategy.ReturnToPool(repository, poolable);
        }

        public void Spawn(PoolObjectType type, Vector3 position, Color? color = null)
        {
            var poolable = repository.Get(type, position, Quaternion.identity);
            if (poolable != null && color.HasValue)
            {
                // Aplicar color si se especifica
                if (poolable is MonoBehaviour mb)
                {
                    var sr = mb.GetComponentInChildren<SpriteRenderer>();
                    if (sr != null)
                    {
                        sr.color = color.Value;
                    }
                }
            }
        }

        public void WarmupPool(PoolObjectType type, int count)
        {
            if (!repository.HasPool(type))
            {
                Debug.LogWarning($"[PoolService] Cannot warmup {type} - pool not initialized");
                return;
            }

            var createdObjects = new List<IPoolable>();
            
            // Crear objetos temporalmente
            for (int i = 0; i < count; i++)
            {
                var obj = repository.Get(type, Vector3.zero, Quaternion.identity);
                if (obj != null)
                {
                    createdObjects.Add(obj);
                }
                else
                {
                    break; // No se pueden crear más
                }
            }

            // Devolverlos todos al pool
            foreach (var obj in createdObjects)
            {
                repository.Return(obj);
            }

            Debug.Log($"[PoolService] Warmed up {type} pool with {createdObjects.Count} objects");
        }

        public PoolSystem.Models.PoolStatistics GetStatistics(PoolObjectType type)
        {
            return repository.GetPoolStatistics(type);
        }
    }

    /// <summary>
    /// Repositorio especializado con optimizaciones adicionales
    /// Patrón: Decorator Pattern
    /// Principio: Open/Closed Principle (OCP) - Extensión del repositorio base
    /// </summary>
    public class OptimizedPoolRepository : IPoolRepository
    {
        private IPoolRepository baseRepository;
        private Dictionary<PoolObjectType, Queue<IPoolable>> fastCache;
        private int cacheSize;

        public OptimizedPoolRepository(IPoolRepository baseRepository, int cacheSize = 3)
        {
            this.baseRepository = baseRepository;
            this.cacheSize = cacheSize;
            fastCache = new Dictionary<PoolObjectType, Queue<IPoolable>>();
        }

        public void InitializePool(IPoolConfiguration config)
        {
            baseRepository.InitializePool(config);
            fastCache[config.Type] = new Queue<IPoolable>();
        }

        public IPoolable Get(PoolObjectType type, Vector3 position, Quaternion rotation)
        {
            // Intentar desde cache rápido primero
            if (fastCache.TryGetValue(type, out var cache) && cache.Count > 0)
            {
                var cached = cache.Dequeue();
                
                // Configurar posición
                if (cached is MonoBehaviour mb)
                {
                    mb.transform.position = position;
                    mb.transform.rotation = rotation;
                }
                
                cached.OnGetFromPool();
                return cached;
            }

            // Fallback al repositorio base
            return baseRepository.Get(type, position, rotation);
        }

        public void Return(IPoolable poolable)
        {
            if (poolable == null) return;

            // Intentar almacenar en cache rápido
            if (fastCache.TryGetValue(poolable.Type, out var cache) && cache.Count < cacheSize)
            {
                poolable.OnReturnToPool();
                cache.Enqueue(poolable);
                return;
            }

            // Fallback al repositorio base
            baseRepository.Return(poolable);
        }

        public PoolSystem.Models.PoolStatistics GetPoolStatistics(PoolObjectType type)
        {
            var baseStats = baseRepository.GetPoolStatistics(type);
            
            // Ajustar estadísticas considerando el cache rápido
            if (fastCache.TryGetValue(type, out var cache))
            {
                return new PoolSystem.Models.PoolStatistics(
                    baseStats.type,
                    baseStats.totalCreated,
                    baseStats.currentActive,
                    baseStats.currentInactive + cache.Count,
                    baseStats.maxCapacity,
                    baseStats.canExpand
                );
            }
            
            return baseStats;
        }

        public void ClearAllPools()
        {
            fastCache.Clear();
            baseRepository.ClearAllPools();
        }

        public bool HasPool(PoolObjectType type)
        {
            return baseRepository.HasPool(type);
        }
    }
}