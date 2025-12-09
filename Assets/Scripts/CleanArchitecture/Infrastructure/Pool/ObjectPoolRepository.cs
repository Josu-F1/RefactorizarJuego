#pragma warning disable CS0618 // Type or member is obsolete
using System;
using UnityEngine;
using CleanArchitecture.Domain.Pool;

/// <summary>
/// Adaptador de infraestructura que envuelve el ObjectPool legacy.
/// No modifica el sistema antiguo; solo delega las peticiones.
/// </summary>
namespace CleanArchitecture.Infrastructure.Pool
{
    public class ObjectPoolRepository : IPoolRepository
    {
        private readonly ObjectPool objectPool;

        public ObjectPoolRepository(ObjectPool objectPool)
        {
            this.objectPool = objectPool ?? throw new ArgumentNullException(nameof(objectPool));
        }

        public GameObject Get(PoolItem item)
        {
            return objectPool.Get(item.Position, item.Rotation);
        }
    }
}
