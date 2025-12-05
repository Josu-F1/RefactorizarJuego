using UnityEngine;

namespace CleanArchitecture.Domain.Pool
{
    /// <summary>
    /// Contrato de dominio para obtener objetos de un pool.
    /// Implementaciones viven en infraestructura.
    /// </summary>
    public interface IPoolRepository
    {
        GameObject Get(PoolItem item);
    }
}
