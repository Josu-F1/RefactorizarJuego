using UnityEngine;

namespace CleanArchitecture.Domain.Targeting
{
    /// <summary>
    /// Contrato de dominio para obtener posición objetivo.
    /// </summary>
    public interface ITargetProvider
    {
        Vector3 GetTargetPosition();
    }
}
