using CleanArchitecture.Domain.Targeting;
using UnityEngine;

/// <summary>
/// Proveedor que usa Player.Instance como objetivo. No modifica Player.
/// </summary>
namespace CleanArchitecture.Infrastructure.Targeting
{
    public class PlayerInstanceTargetProvider : ITargetProvider
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
