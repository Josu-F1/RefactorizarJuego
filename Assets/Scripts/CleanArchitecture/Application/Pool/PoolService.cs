using System;
using UnityEngine;
using CleanArchitecture.Domain.Pool;

namespace CleanArchitecture.Application.Pool
{
    /// <summary>
    /// Caso de uso: solicita instancias de pool y expone callback para inicialización.
    /// </summary>
    public class PoolService
    {
        private readonly IPoolRepository repository;

        public event Action<GameObject> OnSpawned;

        public PoolService(IPoolRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public GameObject Spawn(PoolObjectType type, Vector3 position, Quaternion rotation)
        {
            var go = repository.Get(new PoolItem(type, position, rotation));
            if (go != null)
            {
                OnSpawned?.Invoke(go);
            }
            return go;
        }

        public GameObject Spawn(PoolObjectType type, Vector3 position)
        {
            return Spawn(type, position, Quaternion.identity);
        }
    }
}
