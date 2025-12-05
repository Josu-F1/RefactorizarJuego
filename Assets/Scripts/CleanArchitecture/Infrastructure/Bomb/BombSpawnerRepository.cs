using System;
using UnityEngine;
using CleanArchitecture.Domain.Bomb;

/// <summary>
/// Adaptador que envuelve un BombSpawner o BombSpawnerComposer legacy.
/// </summary>
namespace CleanArchitecture.Infrastructure.Bomb
{
    public class BombSpawnerRepository : IBombRepository
    {
        private readonly MonoBehaviour spawnerBehaviour;
        private readonly IBombSpawnerReference bombReference;

        public BombSpawnerRepository(MonoBehaviour spawnerBehaviour)
        {
            this.spawnerBehaviour = spawnerBehaviour ?? throw new ArgumentNullException(nameof(spawnerBehaviour));
            bombReference = spawnerBehaviour as IBombSpawnerReference ?? throw new ArgumentException("Spawner must implement IBombSpawnerReference");
        }

        public void PlaceBomb(BombRequest request)
        {
            // Intentar mapear a API legacy.
            // BombSpawnerComposer expone PlaceBomb/ThrowBomb; BombSpawner expone PlaceBomb/ThrowBomb.
            // Uso de reflexión ligera para no romper si métodos faltan.
            var type = spawnerBehaviour.GetType();
            if (request.IsThrowable)
            {
                var throwMethod = type.GetMethod("ThrowBomb");
                if (throwMethod != null)
                {
                    throwMethod.Invoke(spawnerBehaviour, new object[] { request.Destination.Value, request.ThrowSpeed });
                    return;
                }
            }

            var placeMethod = type.GetMethod("PlaceBomb", new Type[] { typeof(Vector2) });
            if (placeMethod != null)
            {
                placeMethod.Invoke(spawnerBehaviour, new object[] { request.Position });
            }
            else
            {
                var placeNoArg = type.GetMethod("PlaceBomb", Type.EmptyTypes);
                placeNoArg?.Invoke(spawnerBehaviour, null);
            }
        }
    }
}
