using UnityEngine;
using CleanArchitecture.Infrastructure.DependencyInjection;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Presentation.Adapters
{
    /// <summary>
    /// Adapter que permite usar PoolObjectType legacy con el nuevo PoolService
    /// Mapea tipos de pool a prefabs
    /// </summary>
    public class LegacyPoolAdapter : MonoBehaviour
    {
        [System.Serializable]
        public class PoolMapping
        {
            public PoolObjectType type;
            public GameObject prefab;
            [Min(0)]
            public int prewarmCount = 5;
        }

        [Header("Mapeo de Pools Legacy")]
        [SerializeField] private PoolMapping[] poolMappings;

        [Header("Configuración")]
        [SerializeField] private bool prewarmOnStart = true;

        private IPoolService _poolService;

        private void Awake()
        {
            _poolService = ServiceLocator.Instance.Get<IPoolService>();

            if (_poolService == null)
            {
                Debug.LogError("[LegacyPoolAdapter] ❌ PoolService no encontrado");
            }
            else
            {
                Debug.Log("[LegacyPoolAdapter] ✅ Conectado al PoolService");
            }
        }

        private void Start()
        {
            if (prewarmOnStart && _poolService != null)
            {
                PrewarmPools();
            }
        }

        /// <summary>
        /// Obtiene un objeto del pool usando el tipo legacy
        /// </summary>
        public GameObject Get(PoolObjectType type, Vector3 position, Quaternion rotation)
        {
            if (_poolService == null) return null;

            var mapping = GetMapping(type);
            if (mapping != null)
            {
                return _poolService.Get(mapping.prefab, position, rotation);
            }
            else
            {
                Debug.LogWarning($"[LegacyPoolAdapter] Tipo {type} no mapeado");
                return null;
            }
        }

        /// <summary>
        /// Obtiene un objeto del pool (sin rotación)
        /// </summary>
        public GameObject Get(PoolObjectType type, Vector3 position)
        {
            return Get(type, position, Quaternion.identity);
        }

        /// <summary>
        /// Devuelve un objeto al pool
        /// </summary>
        public void ReturnToPool(PoolObjectType type, GameObject obj)
        {
            if (_poolService == null || obj == null) return;
            _poolService.Release(obj);
        }

        /// <summary>
        /// Precalienta todos los pools configurados
        /// </summary>
        private void PrewarmPools()
        {
            foreach (var mapping in poolMappings)
            {
                if (mapping.prefab != null && mapping.prewarmCount > 0)
                {
                    _poolService.Warmup(mapping.prefab, mapping.prewarmCount);
                }
            }

            Debug.Log($"[LegacyPoolAdapter] {poolMappings.Length} pools precalentados");
        }

        private PoolMapping GetMapping(PoolObjectType type)
        {
            foreach (var mapping in poolMappings)
            {
                if (mapping.type == type)
                    return mapping;
            }
            return null;
        }

        /// <summary>
        /// Instancia estática para acceso global (compatibilidad)
        /// </summary>
        private static LegacyPoolAdapter _instance;
        public static LegacyPoolAdapter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<LegacyPoolAdapter>();
                }
                return _instance;
            }
        }
    }
}
