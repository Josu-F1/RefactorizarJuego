using UnityEngine;

namespace CleanArchitecture.Domain.Pool
{
    /// <summary>
    /// Entidad simple que describe una solicitud de spawn en pool.
    /// </summary>
    public readonly struct PoolItem
    {
        public readonly PoolObjectType Type;
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;

        public PoolItem(PoolObjectType type, Vector3 position, Quaternion rotation)
        {
            Type = type;
            Position = position;
            Rotation = rotation;
        }
    }
}
