using UnityEngine;

namespace CleanArchitecture.Domain.Shooting
{
    /// <summary>
    /// Solicitud de disparo con dirección y opcionalmente ángulo extra.
    /// </summary>
    public readonly struct ShootingRequest
    {
        public readonly Vector2 Direction;
        public readonly float AngleOffset;

        public ShootingRequest(Vector2 direction, float angleOffset = 0f)
        {
            Direction = direction;
            AngleOffset = angleOffset;
        }
    }
}
