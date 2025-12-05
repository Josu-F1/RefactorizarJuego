using UnityEngine;

namespace CleanArchitecture.Domain.Enemy
{
    /// <summary>
    /// Contrato para obtener la posición del objetivo (ej: jugador).
    /// </summary>
    public interface IEnemyTargetProvider
    {
        Vector3 GetTargetPosition();
    }
}
