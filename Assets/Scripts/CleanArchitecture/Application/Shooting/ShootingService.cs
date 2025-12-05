using System;
using CleanArchitecture.Domain.Shooting;
using UnityEngine;

namespace CleanArchitecture.Application.Shooting
{
    /// <summary>
    /// Caso de uso: dispara con dirección opcional, valida entradas.
    /// </summary>
    public class ShootingService
    {
        private readonly IShootingRepository repository;

        public ShootingService(IShootingRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void Shoot(Vector2 direction, float angleOffset = 0f)
        {
            if (direction == Vector2.zero)
            {
                repository.ShootDefault();
                return;
            }
            var req = new ShootingRequest(direction.normalized, angleOffset);
            repository.Shoot(req);
        }

        public void ShootDefault()
        {
            repository.ShootDefault();
        }
    }
}
