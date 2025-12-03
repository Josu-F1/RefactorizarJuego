using UnityEngine;
using CleanArchitecture.Application.Shooting;
using CleanArchitecture.Infrastructure.Shooting;

namespace CleanArchitecture.Presentation.Shooting
{
    /// <summary>
    /// MonoBehaviour opcional para disparar vía ShootingService sin tocar scripts legacy.
    /// </summary>
    public class ShootingServiceAdapter : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour shooterBehaviour; // ShootComponent o ShooterComponent

        private ShootingService service;

        private void Awake()
        {
            if (shooterBehaviour == null) return;

            var repo = new ShootComponentRepository(shooterBehaviour);
            service = new ShootingService(repo);
        }

        public void Shoot(Vector2 direction)
        {
            service?.Shoot(direction);
        }

        public void ShootDefault()
        {
            service?.ShootDefault();
        }
    }
}
