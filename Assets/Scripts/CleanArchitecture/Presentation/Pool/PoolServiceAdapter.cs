using UnityEngine;
using CleanArchitecture.Application.Pool;
using CleanArchitecture.Domain.Pool;
using CleanArchitecture.Infrastructure.Pool;

namespace CleanArchitecture.Presentation.Pool
{
    /// <summary>
    /// MonoBehaviour opcional para exponer PoolService en Unity sin tocar prefabs existentes.
    /// </summary>
    public class PoolServiceAdapter : MonoBehaviour
    {
        [SerializeField] private ObjectPool legacyPool;
        private PoolService service;

        private void Awake()
        {
            if (legacyPool == null) return;

            var repo = new ObjectPoolRepository(legacyPool);
            service = new PoolService(repo);
        }

        public GameObject Spawn(PoolObjectType type, Vector3 position, Quaternion rotation)
        {
            return service?.Spawn(type, position, rotation);
        }

        public GameObject Spawn(PoolObjectType type, Vector3 position)
        {
            return service?.Spawn(type, position);
        }
    }
}
