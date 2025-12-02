using UnityEngine;
using System.Collections.Generic;
using PoolSystem.Interfaces;
using PoolSystem.Models;

namespace PoolSystem.Factories
{
    /// <summary>
    /// Fábrica principal de objetos pooled
    /// Patrón: Factory Pattern
    /// Principio: Single Responsibility Principle (SRP) - Solo creación de objetos
    /// </summary>
    public class PoolObjectFactory : IPoolObjectFactory
    {
        private Transform parentTransform;

        public PoolObjectFactory(Transform parent = null)
        {
            parentTransform = parent;
        }

        public IPoolable CreatePoolObject(IPoolConfiguration config)
        {
            if (config?.Prefab == null)
            {
                Debug.LogError("[PoolObjectFactory] Cannot create object: null prefab in configuration");
                return null;
            }

            if (!CanCreateFrom(config.Prefab))
            {
                Debug.LogError($"[PoolObjectFactory] Prefab {config.Prefab.name} cannot be pooled - missing IPoolable component");
                return null;
            }

            GameObject instance = Object.Instantiate(config.Prefab, parentTransform);
            IPoolable poolable = GetPoolableComponent(instance);

            if (poolable != null)
            {
                ConfigurePoolObject(poolable, config);
                return poolable;
            }

            // Fallback: agregar componente PoolableObject si no existe
            var poolableComponent = instance.AddComponent<Core.PoolableObject>();
            ConfigurePoolObject(poolableComponent, config);
            return poolableComponent;
        }

        public void ConfigurePoolObject(IPoolable poolable, IPoolConfiguration config)
        {
            if (poolable == null || config == null) return;

            // Configurar tipo
            poolable.Type = config.Type;

            // Configurar color si tiene SpriteRenderer
            if (poolable is MonoBehaviour mb)
            {
                var spriteRenderer = mb.GetComponentInChildren<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = config.DefaultColor;
                }
            }

            // Reiniciar estado
            poolable.ResetState();
        }

        public bool CanCreateFrom(GameObject prefab)
        {
            if (prefab == null) return false;

            // Verificar si tiene componente IPoolable o PoolObject legacy
            return GetPoolableComponent(prefab) != null || 
                   prefab.GetComponent<PoolObject>() != null;
        }

        private IPoolable GetPoolableComponent(GameObject obj)
        {
            // Buscar IPoolable directo
            var poolable = obj.GetComponent<IPoolable>();
            if (poolable != null) return poolable;

            // Buscar en componentes (por si IPoolable está en otro MonoBehaviour)
            var components = obj.GetComponents<MonoBehaviour>();
            foreach (var component in components)
            {
                if (component is IPoolable p) return p;
            }

            return null;
        }
    }

    /// <summary>
    /// Estrategia estándar de pooling
    /// Patrón: Strategy Pattern
    /// Principio: Single Responsibility Principle (SRP) - Solo lógica de pooling
    /// </summary>
    public class StandardPoolStrategy : IPoolStrategy
    {
        public IPoolable GetFromPool(IPoolRepository repository, PoolObjectType type)
        {
            if (repository == null || !repository.HasPool(type))
            {
                Debug.LogWarning($"[StandardPoolStrategy] No pool found for type {type}");
                return null;
            }

            return repository.Get(type, Vector3.zero, Quaternion.identity);
        }

        public void ReturnToPool(IPoolRepository repository, IPoolable poolable)
        {
            if (repository == null || poolable == null) return;

            // Resetear antes de devolver
            poolable.ResetState();
            repository.Return(poolable);
        }

        public bool CanExpand(IPoolConfiguration config, int currentCount)
        {
            if (config == null) return false;
            return config.AutoExpand && currentCount < config.MaxCount;
        }
    }

    /// <summary>
    /// Estrategia de pooling con pre-calentamiento agresivo
    /// Patrón: Strategy Pattern
    /// Principio: Open/Closed Principle (OCP) - Nueva estrategia sin modificar existentes
    /// </summary>
    public class PrewarmedPoolStrategy : IPoolStrategy
    {
        private int prewarmCount;

        public PrewarmedPoolStrategy(int prewarmCount = 5)
        {
            this.prewarmCount = prewarmCount;
        }

        public IPoolable GetFromPool(IPoolRepository repository, PoolObjectType type)
        {
            if (repository == null || !repository.HasPool(type))
            {
                Debug.LogWarning($"[PrewarmedPoolStrategy] No pool found for type {type}");
                return null;
            }

            var obj = repository.Get(type, Vector3.zero, Quaternion.identity);
            
            // Pre-calentar si el pool está bajo
            var stats = repository.GetPoolStatistics(type);
            if (stats.currentInactive < prewarmCount && stats.canExpand)
            {
                // Crear objetos adicionales en background
                PrewarmPool(repository, type, prewarmCount - stats.currentInactive);
            }

            return obj;
        }

        public void ReturnToPool(IPoolRepository repository, IPoolable poolable)
        {
            if (repository == null || poolable == null) return;

            poolable.ResetState();
            repository.Return(poolable);
        }

        public bool CanExpand(IPoolConfiguration config, int currentCount)
        {
            if (config == null) return false;
            return config.AutoExpand && currentCount < config.MaxCount;
        }

        private void PrewarmPool(IPoolRepository repository, PoolObjectType type, int count)
        {
            // Crear objetos adicionales y devolverlos inmediatamente al pool
            for (int i = 0; i < count; i++)
            {
                var obj = repository.Get(type, Vector3.zero, Quaternion.identity);
                if (obj != null)
                {
                    repository.Return(obj);
                }
                else
                {
                    break; // No se pueden crear más
                }
            }
        }
    }

    /// <summary>
    /// Factory para diferentes estrategias de pooling
    /// Patrón: Factory Method Pattern
    /// Principio: Open/Closed Principle (OCP) - Extensible para nuevas estrategias
    /// </summary>
    public static class PoolStrategyFactory
    {
        public enum StrategyType
        {
            Standard,
            Prewarmed,
            Aggressive,
            Conservative
        }

        public static IPoolStrategy CreateStrategy(StrategyType type, params object[] parameters)
        {
            return type switch
            {
                StrategyType.Standard => new StandardPoolStrategy(),
                StrategyType.Prewarmed => new PrewarmedPoolStrategy(
                    parameters.Length > 0 && parameters[0] is int prewarm ? prewarm : 5),
                StrategyType.Aggressive => new AggressivePoolStrategy(
                    parameters.Length > 0 && parameters[0] is float threshold ? threshold : 0.8f),
                StrategyType.Conservative => new ConservativePoolStrategy(
                    parameters.Length > 0 && parameters[0] is int max ? max : 10),
                _ => new StandardPoolStrategy()
            };
        }
    }

    /// <summary>
    /// Estrategia agresiva que expande rápidamente
    /// Patrón: Strategy Pattern
    /// </summary>
    public class AggressivePoolStrategy : IPoolStrategy
    {
        private float expansionThreshold;

        public AggressivePoolStrategy(float threshold = 0.8f)
        {
            expansionThreshold = Mathf.Clamp01(threshold);
        }

        public IPoolable GetFromPool(IPoolRepository repository, PoolObjectType type)
        {
            if (repository == null || !repository.HasPool(type)) return null;

            var stats = repository.GetPoolStatistics(type);
            
            // Expandir agresivamente si utilización es alta
            if (stats.utilizationRate > expansionThreshold && stats.canExpand)
            {
                // Crear múltiples objetos de una vez
                int expansionCount = Mathf.Min(3, stats.maxCapacity - stats.totalCreated);
                for (int i = 0; i < expansionCount; i++)
                {
                    var extraObj = repository.Get(type, Vector3.zero, Quaternion.identity);
                    if (extraObj != null)
                    {
                        repository.Return(extraObj);
                    }
                }
            }

            return repository.Get(type, Vector3.zero, Quaternion.identity);
        }

        public void ReturnToPool(IPoolRepository repository, IPoolable poolable)
        {
            if (repository == null || poolable == null) return;
            
            poolable.ResetState();
            repository.Return(poolable);
        }

        public bool CanExpand(IPoolConfiguration config, int currentCount)
        {
            if (config == null) return false;
            return config.AutoExpand && currentCount < config.MaxCount;
        }
    }

    /// <summary>
    /// Estrategia conservadora que limita expansión
    /// Patrón: Strategy Pattern
    /// </summary>
    public class ConservativePoolStrategy : IPoolStrategy
    {
        private int maxAllowedExpansion;

        public ConservativePoolStrategy(int maxExpansion = 5)
        {
            maxAllowedExpansion = maxExpansion;
        }

        public IPoolable GetFromPool(IPoolRepository repository, PoolObjectType type)
        {
            if (repository == null || !repository.HasPool(type)) return null;
            return repository.Get(type, Vector3.zero, Quaternion.identity);
        }

        public void ReturnToPool(IPoolRepository repository, IPoolable poolable)
        {
            if (repository == null || poolable == null) return;
            
            poolable.ResetState();
            repository.Return(poolable);
        }

        public bool CanExpand(IPoolConfiguration config, int currentCount)
        {
            if (config == null) return false;
            
            int allowedTotal = config.InitialCount + maxAllowedExpansion;
            return config.AutoExpand && 
                   currentCount < config.MaxCount && 
                   currentCount < allowedTotal;
        }
    }
}