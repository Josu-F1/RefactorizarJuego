using System.Collections.Generic;
using UnityEngine;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Infrastructure.Services
{
    /// <summary>
    /// Implementación del servicio de Object Pooling
    /// Gestiona pools de GameObjects reutilizables
    /// </summary>
    public class PoolService : IPoolService
    {
        private class Pool
        {
            public GameObject Prefab;
            public Queue<GameObject> Available = new Queue<GameObject>();
            public HashSet<GameObject> Active = new HashSet<GameObject>();
            public Transform Container;
        }

        private readonly Dictionary<GameObject, Pool> _pools = new Dictionary<GameObject, Pool>();
        private readonly Transform _poolRoot;

        public PoolService(Transform poolRoot = null)
        {
            if (poolRoot == null)
            {
                var go = new GameObject("[PoolService]");
                Object.DontDestroyOnLoad(go);
                _poolRoot = go.transform;
            }
            else
            {
                _poolRoot = poolRoot;
            }

            Debug.Log("[PoolService] ✅ Servicio de pooling inicializado");
        }

        public GameObject Get(GameObject prefab)
        {
            return Get(prefab, Vector3.zero, Quaternion.identity);
        }

        public GameObject Get(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            if (prefab == null)
            {
                Debug.LogError("[PoolService] Prefab es null");
                return null;
            }

            var pool = GetOrCreatePool(prefab);

            GameObject obj;
            if (pool.Available.Count > 0)
            {
                obj = pool.Available.Dequeue();
            }
            else
            {
                obj = CreateNewInstance(prefab, pool);
            }

            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            pool.Active.Add(obj);

            return obj;
        }

        public void Release(GameObject obj)
        {
            if (obj == null) return;

            // Buscar el pool al que pertenece
            Pool pool = FindPoolForObject(obj);
            
            if (pool == null)
            {
                Debug.LogWarning($"[PoolService] Objeto {obj.name} no pertenece a ningún pool. Destruyendo.");
                Object.Destroy(obj);
                return;
            }

            if (!pool.Active.Remove(obj))
            {
                Debug.LogWarning($"[PoolService] Objeto {obj.name} no estaba activo en el pool");
            }

            obj.SetActive(false);
            obj.transform.SetParent(pool.Container);
            pool.Available.Enqueue(obj);
        }

        public void Warmup(GameObject prefab, int count)
        {
            if (prefab == null || count <= 0) return;

            var pool = GetOrCreatePool(prefab);

            for (int i = 0; i < count; i++)
            {
                var obj = CreateNewInstance(prefab, pool);
                obj.SetActive(false);
                pool.Available.Enqueue(obj);
            }

            Debug.Log($"[PoolService] Pool de {prefab.name} precalentado con {count} instancias");
        }

        public void Clear()
        {
            foreach (var pool in _pools.Values)
            {
                ClearPool(pool);
            }

            _pools.Clear();
            Debug.Log("[PoolService] Todos los pools limpiados");
        }

        public void ClearPool(GameObject prefab)
        {
            if (prefab == null || !_pools.ContainsKey(prefab)) return;

            var pool = _pools[prefab];
            ClearPool(pool);
            _pools.Remove(prefab);

            Debug.Log($"[PoolService] Pool de {prefab.name} limpiado");
        }

        private Pool GetOrCreatePool(GameObject prefab)
        {
            if (!_pools.ContainsKey(prefab))
            {
                var container = new GameObject($"Pool_{prefab.name}");
                container.transform.SetParent(_poolRoot);

                _pools[prefab] = new Pool
                {
                    Prefab = prefab,
                    Container = container.transform
                };

                Debug.Log($"[PoolService] Pool creado para {prefab.name}");
            }

            return _pools[prefab];
        }

        private GameObject CreateNewInstance(GameObject prefab, Pool pool)
        {
            var obj = Object.Instantiate(prefab, pool.Container);
            obj.name = prefab.name;
            
            // Añadir componente marcador para tracking
            var marker = obj.GetComponent<PooledObjectMarker>();
            if (marker == null)
            {
                marker = obj.AddComponent<PooledObjectMarker>();
            }
            marker.OriginalPrefab = prefab;

            return obj;
        }

        private Pool FindPoolForObject(GameObject obj)
        {
            var marker = obj.GetComponent<PooledObjectMarker>();
            if (marker != null && marker.OriginalPrefab != null)
            {
                if (_pools.TryGetValue(marker.OriginalPrefab, out var pool))
                {
                    return pool;
                }
            }

            // Fallback: buscar en todos los pools
            foreach (var pool in _pools.Values)
            {
                if (pool.Active.Contains(obj) || pool.Available.Contains(obj))
                {
                    return pool;
                }
            }

            return null;
        }

        private void ClearPool(Pool pool)
        {
            // Destruir objetos activos
            foreach (var obj in pool.Active)
            {
                if (obj != null)
                    Object.Destroy(obj);
            }

            // Destruir objetos disponibles
            while (pool.Available.Count > 0)
            {
                var obj = pool.Available.Dequeue();
                if (obj != null)
                    Object.Destroy(obj);
            }

            // Destruir contenedor
            if (pool.Container != null)
                Object.Destroy(pool.Container.gameObject);

            pool.Active.Clear();
        }
    }

    /// <summary>
    /// Componente marcador para rastrear el prefab original
    /// </summary>
    internal class PooledObjectMarker : MonoBehaviour
    {
        public GameObject OriginalPrefab { get; set; }
    }
}
