#pragma warning disable CS0618 // Type or member is obsolete
using System;
using UnityEngine;
using CleanArchitecture.Domain.Shooting;

/// <summary>
/// Adaptador para usar ShootComponent legacy con el contrato de dominio.
/// </summary>
namespace CleanArchitecture.Infrastructure.Shooting
{
    public class ShootComponentRepository : IShootingRepository
    {
        private readonly ShootComponent shootComponent;
        private readonly ShootingSystem.Controllers.ShooterComponent shooterComponent;

        public ShootComponentRepository(MonoBehaviour behaviour)
        {
            // Acepta ShootComponent (legacy) o ShooterComponent (refactor previo del proyecto)
            shootComponent = behaviour as ShootComponent;
            shooterComponent = behaviour as ShootingSystem.Controllers.ShooterComponent;

            if (shootComponent == null && shooterComponent == null)
            {
                throw new ArgumentException("Behaviour must be ShootComponent or ShooterComponent");
            }
        }

        public void Shoot(ShootingRequest request)
        {
            if (shootComponent != null)
            {
                shootComponent.Shoot(request.Direction, request.AngleOffset);
            }
            else if (shooterComponent != null)
            {
                shooterComponent.ShooterController?.Shoot(request.Direction, request.AngleOffset);
            }
        }

        public void ShootDefault()
        {
            if (shootComponent != null)
            {
                shootComponent.Shoot();
            }
            else if (shooterComponent != null)
            {
                shooterComponent.ShooterController?.Shoot();
            }
        }
    }
}
