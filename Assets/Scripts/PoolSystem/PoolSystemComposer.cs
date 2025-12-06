using UnityEngine;
using System.Collections.Generic;
using PoolSystem.Interfaces;
using PoolSystem.Models;
using PoolSystem.Factories;
using PoolSystem.Repository;

#pragma warning disable CS0618 // Type or member is obsolete - Needed for legacy fallback compatibility

namespace PoolSystem
{

    /// <summary>
    /// Componente principal del Pool System refactorizado
    /// Patrón: Facade Pattern + Composite Pattern
    /// Principio: Single Responsibility Principle (SRP) - Orquestación del sistema
    /// </summary>
    [System.Obsolete("PoolSystemComposer is deprecated. Use IPoolService from ServiceLocator instead.")]
    public class PoolSystemComposer : MonoBehaviour
    {
        [Header("Pool System Configuration")]
        [SerializeField] private PoolSystemDatabase database;
        [SerializeField] private bool initializeOnAwake = true;
        [SerializeField] private bool enableStatisticsTracking = true;

        [Header("Strategy Configuration")]
        [SerializeField] private PoolStrategyFactory.StrategyType strategyType = PoolStrategyFactory.StrategyType.Standard;
        [SerializeField] private int prewarmCount = 5;
        [SerializeField] private float aggressiveThreshold = 0.8f;
        [SerializeField] private int conservativeMaxExpansion = 5;

        [Header("Performance Settings")]
        [SerializeField] private bool useOptimizedRepository = true;
        [SerializeField] private int fastCacheSize = 3;

        // Instancia estática para acceso global (compatible con patrón anterior)
        private static PoolSystemComposer instance;
        private static bool hasLoggedMissingInstance = false;
        
        public static PoolSystemComposer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<PoolSystemComposer>();
                    if (instance == null && !hasLoggedMissingInstance)
                    {
                        Debug.LogWarning("[PoolSystemComposer] No instance found in scene. Pool System will use legacy PoolManager if available.");
                        hasLoggedMissingInstance = true;
                    }
                }
                return instance;
            }
        }

        // Componentes del sistema
        private IPoolRepository poolRepository;
        private IPoolService poolService;
        private IPoolObjectFactory objectFactory;
        private IPoolStrategy poolStrategy;
        private PoolDebugObserver debugObserver;

        // Estado del sistema
        private bool isInitialized = false;

        #region Unity Lifecycle

        private void Awake()
        {
            // Configurar singleton
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Debug.LogWarning("[PoolSystemComposer] Multiple instances detected. Destroying duplicate.");
                Destroy(gameObject);
                return;
            }

            if (initializeOnAwake)
            {
                InitializeSystem();
            }
        }

        private void Start()
        {
            if (!isInitialized)
            {
                InitializeSystem();
            }
        }

        private void OnDestroy()
        {
            if (instance == this)
            {
                Cleanup();
                instance = null;
            }
        }

        #endregion

        #region System Initialization

        /// <summary>
        /// Inicializa todo el sistema de pools
        /// </summary>
        public void InitializeSystem()
        {
            if (isInitialized)
            {
                Debug.LogWarning("[PoolSystemComposer] System already initialized");
                return;
            }

            Debug.Log("[PoolSystemComposer] Initializing Pool System...");

            try
            {
                // Validar configuración
                if (!ValidateConfiguration())
                {
                    Debug.LogError("[PoolSystemComposer] Invalid configuration. System initialization failed.");
                    return;
                }

                // Crear componentes del sistema
                CreateSystemComponents();

                // Inicializar pools desde configuración
                InitializePools();

                // Configurar observadores
                SetupObservers();

                isInitialized = true;
                Debug.Log("[PoolSystemComposer] Pool System initialized successfully!");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[PoolSystemComposer] System initialization failed: {e.Message}");
                isInitialized = false;
            }
        }

        private bool ValidateConfiguration()
        {
            if (database == null)
            {
                Debug.LogError("[PoolSystemComposer] No database assigned");
                return false;
            }

            if (database.PoolConfigurations == null || database.PoolConfigurations.Length == 0)
            {
                Debug.LogError("[PoolSystemComposer] No pool configurations found in database");
                return false;
            }

            return true;
        }

        private void CreateSystemComponents()
        {
            // Crear factory
            objectFactory = new PoolObjectFactory(transform);

            // Crear estrategia según configuración
            poolStrategy = strategyType switch
            {
                PoolStrategyFactory.StrategyType.Prewarmed => new PrewarmedPoolStrategy(prewarmCount),
                PoolStrategyFactory.StrategyType.Aggressive => new AggressivePoolStrategy(aggressiveThreshold),
                PoolStrategyFactory.StrategyType.Conservative => new ConservativePoolStrategy(conservativeMaxExpansion),
                _ => new StandardPoolStrategy()
            };

            // Crear repositorio
            var baseRepository = new PoolRepository(objectFactory, poolStrategy, transform);
            
            if (useOptimizedRepository)
            {
                poolRepository = new OptimizedPoolRepository(baseRepository, fastCacheSize);
            }
            else
            {
                poolRepository = baseRepository;
            }

            // Crear servicio
            poolService = new PoolService(poolRepository, poolStrategy);

            Debug.Log($"[PoolSystemComposer] Created components - Strategy: {strategyType}, Optimized: {useOptimizedRepository}");
        }

        private void InitializePools()
        {
            foreach (var config in database.PoolConfigurations)
            {
                if (config != null && config.Prefab != null)
                {
                    poolRepository.InitializePool(config);
                }
                else
                {
                    Debug.LogWarning($"[PoolSystemComposer] Skipping invalid pool configuration");
                }
            }
        }

        private void SetupObservers()
        {
            if (enableStatisticsTracking && database.EnableDebugLogging)
            {
                debugObserver = new PoolDebugObserver(true);
                
                if (poolRepository is PoolRepository repo)
                {
                    repo.Subscribe(debugObserver);
                }
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Obtiene el servicio de pools principal
        /// </summary>
        public static IPoolService GetPoolService()
        {
            var composer = Instance;
            if (composer?.isInitialized == true)
            {
                return composer.poolService;
            }
            return null;
        }

        /// <summary>
        /// Obtiene un objeto del pool
        /// </summary>
        public static T GetPooledObject<T>(PoolObjectType type, Vector3 position) where T : class, IPoolable
        {
            var composer = Instance;
            if (composer?.isInitialized == true)
            {
                return composer.poolService?.Get<T>(type, position);
            }
            
            // Fallback al sistema legacy
            if (PoolManager.Instance != null)
            {
                var legacyObj = PoolManager.Instance.Get(type, position, Quaternion.identity);
                if (legacyObj != null)
                {
                    return legacyObj.GetComponent<T>();
                }
            }
            
            return null;
        }

        /// <summary>
        /// Devuelve un objeto al pool
        /// </summary>
        public static void ReturnToPool(IPoolable poolable)
        {
            var composer = Instance;
            if (composer?.isInitialized == true)
            {
                composer.poolService?.Return(poolable);
                return;
            }
            
            // CRITICAL FIX: No llamar a PoolManager.Instance para evitar ciclo infinito
            // Si no hay instancia, simplemente desactivar el objeto
            if (poolable is MonoBehaviour mb)
            {
                mb.gameObject.SetActive(false);
                Debug.LogWarning($"[PoolSystemComposer] No instance available. Object deactivated: {mb.name}");
            }
        }

        /// <summary>
        /// Spawn rápido de objeto
        /// </summary>
        public static void SpawnPooledObject(PoolObjectType type, Vector3 position, Color? color = null)
        {
            var composer = Instance;
            if (composer?.isInitialized == true)
            {
                composer.poolService?.Spawn(type, position, color);
                return;
            }
            
            // Fallback al sistema legacy
            if (PoolManager.Instance != null)
            {
                var legacyObj = PoolManager.Instance.Get(type, position, Quaternion.identity);
                if (legacyObj != null && color.HasValue)
                {
                    var sr = legacyObj.GetComponentInChildren<SpriteRenderer>();
                    if (sr != null) sr.color = color.Value;
                }
            }
        }

        /// <summary>
        /// Obtiene estadísticas de un pool
        /// </summary>
        public PoolSystem.Models.PoolStatistics GetPoolStatistics(PoolObjectType type)
        {
            return poolService?.GetStatistics(type) ?? default;
        }

        /// <summary>
        /// Pre-calienta un pool específico
        /// </summary>
        public void WarmupPool(PoolObjectType type, int count)
        {
            poolService?.WarmupPool(type, count);
        }

        #endregion

        #region Legacy Compatibility

        /// <summary>
        /// Componente de compatibilidad con ObjectPool legacy
        /// Patrón: Adapter Pattern
        /// </summary>
        [System.Serializable]
        public class LegacyPoolComponent
        {
            [SerializeField] private PoolObjectType type;
            [SerializeField] private Color color = Color.white;

            public GameObject Get(Vector3 position, Quaternion rotation)
            {
                var poolable = Instance?.poolService?.Get<IPoolable>(type, position, rotation);
                if (poolable is MonoBehaviour mb)
                {
                    mb.transform.rotation = rotation;
                    
                    // Aplicar color
                    var sr = mb.GetComponentInChildren<SpriteRenderer>();
                    if (sr != null) sr.color = color;
                    
                    return mb.gameObject;
                }
                return null;
            }

            public GameObject Get(Vector3 position) => Get(position, Quaternion.identity);
            public void Spawn(Vector3 position) => Get(position);
        }

        /// <summary>
        /// Adaptador estático para compatibilidad con PoolManager
        /// </summary>
        public static class PoolManagerCompat
        {
            public static GameObject Get(PoolObjectType type, Vector3 position, Quaternion rotation)
            {
                var poolable = GetPooledObject<IPoolable>(type, position);
                if (poolable is MonoBehaviour mb)
                {
                    mb.transform.rotation = rotation;
                    return mb.gameObject;
                }
                return null;
            }

            public static GameObject Get(PoolObjectType type, Vector3 position)
            {
                return Get(type, position, Quaternion.identity);
            }

            public static void ReturnToPool(PoolObjectType type, GameObject gameObject)
            {
                var poolable = gameObject.GetComponent<IPoolable>();
                if (poolable != null)
                {
                    PoolSystemComposer.ReturnToPool(poolable);
                }
            }
        }

        #endregion

        #region Debugging and Statistics

        /// <summary>
        /// Obtiene un reporte completo del estado de todos los pools
        /// </summary>
        [ContextMenu("Get Pool Report")]
        public void GetPoolReport()
        {
            if (!isInitialized)
            {
                Debug.Log("[PoolSystemComposer] System not initialized");
                return;
            }

            System.Text.StringBuilder report = new System.Text.StringBuilder();
            report.AppendLine("=== POOL SYSTEM REPORT ===");
            report.AppendLine($"Strategy: {strategyType}");
            report.AppendLine($"Optimized Repository: {useOptimizedRepository}");
            report.AppendLine("");

            foreach (var config in database.PoolConfigurations)
            {
                var stats = GetPoolStatistics(config.Type);
                report.AppendLine($"Pool: {config.Type}");
                report.AppendLine($"  Total Created: {stats.totalCreated}");
                report.AppendLine($"  Active: {stats.currentActive}");
                report.AppendLine($"  Inactive: {stats.currentInactive}");
                report.AppendLine($"  Utilization: {stats.utilizationRate:P1}");
                report.AppendLine($"  Can Expand: {stats.canExpand}");
                report.AppendLine("");
            }

            Debug.Log(report.ToString());
        }

        /// <summary>
        /// Limpia todas las estadísticas de debugging
        /// </summary>
        [ContextMenu("Reset Statistics")]
        public void ResetStatistics()
        {
            debugObserver?.ResetStatistics();
            Debug.Log("[PoolSystemComposer] Statistics reset");
        }

        #endregion

        #region Cleanup

        private void Cleanup()
        {
            if (poolRepository != null)
            {
                poolRepository.ClearAllPools();
            }

            if (debugObserver != null && poolRepository is PoolRepository repo)
            {
                repo.Unsubscribe(debugObserver);
            }

            isInitialized = false;
            Debug.Log("[PoolSystemComposer] Pool System cleaned up");
        }

        #endregion
    }

    /// <summary>
    /// Componente helper para uso directo en GameObjects
    /// Patrón: Component Pattern
    /// </summary>
    public class PoolComponent : MonoBehaviour
    {
        [SerializeField] private PoolObjectType poolType;
        [SerializeField] private Color objectColor = Color.white;

        /// <summary>
        /// Spawn un objeto de este pool
        /// </summary>
        public GameObject SpawnObject(Vector3 position)
        {
            return SpawnObject(position, Quaternion.identity);
        }

        public GameObject SpawnObject(Vector3 position, Quaternion rotation)
        {
            var poolable = PoolSystemComposer.GetPooledObject<IPoolable>(poolType, position);
            if (poolable is MonoBehaviour mb)
            {
                mb.transform.rotation = rotation;
                
                // Aplicar color
                var sr = mb.GetComponentInChildren<SpriteRenderer>();
                if (sr != null) sr.color = objectColor;
                
                return mb.gameObject;
            }
            return null;
        }

        /// <summary>
        /// Devolver objeto al pool
        /// </summary>
        public void ReturnObject(GameObject obj)
        {
            var poolable = obj.GetComponent<IPoolable>();
            if (poolable != null)
            {
                PoolSystemComposer.ReturnToPool(poolable);
            }
        }
    }
}