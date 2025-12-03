using UnityEngine;
using CleanArchitecture.Application.Bomb;
using CleanArchitecture.Domain.Bomb;
using CleanArchitecture.Infrastructure.Bomb;

namespace CleanArchitecture.Presentation.Bomb
{
    /// <summary>
    /// MonoBehaviour opcional para exponer BombService sin tocar prefabs legacy.
    /// </summary>
    public class BombServiceAdapter : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour bombSpawnerLegacy; // BombSpawner o BombSpawnerComposer
        [SerializeField] private float damage = 20f;
        [SerializeField] private int length = 2;
        [SerializeField] private float lifetime = 2f;
        [SerializeField] private float throwSpeed = 10f;

        private BombService service;

        private void Awake()
        {
            if (bombSpawnerLegacy == null) return;

            var repo = new BombSpawnerRepository(bombSpawnerLegacy);

            // Proveedor de solicitud por defecto (coloca en posición actual)
            BombRequest Provider() => new BombRequest((Vector2)transform.position, damage, length, lifetime, CharacterType.Player);
            service = new BombService(repo, Provider);
        }

        public void PlaceBombHere()
        {
            service?.PlaceBomb();
        }

        public void ThrowBomb(Vector2 destination)
        {
            var req = new BombRequest((Vector2)transform.position, destination, throwSpeed, damage, length, lifetime, CharacterType.Player);
            service?.PlaceBomb(req);
        }
    }
}
