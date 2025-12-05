using System;
using CleanArchitecture.Application.Enemy;
using CleanArchitecture.Domain.Enemy;
using Pathfinding;
using UnityEngine;

/// <summary>
/// Adaptador de navegación que envuelve AIPath del paquete A* Pathfinding Project.
/// No modifica scripts viejos; se limita a configurar AIPath.
/// </summary>
namespace CleanArchitecture.Infrastructure.Enemy
{
    [RequireComponent(typeof(AIPath))]
    public class AstarNavigatorAdapter : MonoBehaviour, IEnemyNavigator, IEnemyNavigatorWithPosition
    {
        private AIPath aiPath;

        private void Awake()
        {
            aiPath = GetComponent<AIPath>();
        }

        public void SetDestination(Vector3 position)
        {
            if (aiPath == null) return;
            aiPath.destination = position;
        }

        public void EnableMovement(bool enabled)
        {
            if (aiPath == null) return;
            aiPath.canMove = enabled;
        }

        public float DistanceTo(Vector3 position)
        {
            return aiPath == null ? float.MaxValue : Vector3.Distance(transform.position, position);
        }
    }
}
