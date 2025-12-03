using CleanArchitecture.Domain.Enemy;
using UnityEngine;

/// <summary>
/// Proveedor de objetivo que devuelve la posición del Player singleton si existe.
/// No toca Player; solo lo lee.
/// </summary>
namespace CleanArchitecture.Infrastructure.Enemy
{
    public class PlayerTargetProvider : IEnemyTargetProvider
    {
        public Vector3 GetTargetPosition()
        {
            if (global::Player.Instance != null)
            {
                return global::Player.Instance.transform.position;
            }

            return Vector3.zero;
        }
    }
}
