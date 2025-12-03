using UnityEngine;

namespace CleanArchitecture.Domain.Enemy
{
    /// <summary>
    /// Contrato de navegación; implementaciones viven en infraestructura (ej: A* Pathfinding Project).
    /// </summary>
    public interface IEnemyNavigator
    {
        void SetDestination(Vector3 position);
        void EnableMovement(bool enabled);
    }
}
