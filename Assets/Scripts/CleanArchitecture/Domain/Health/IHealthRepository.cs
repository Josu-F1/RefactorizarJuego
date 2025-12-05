using System;

namespace CleanArchitecture.Domain.Health
{
    /// <summary>
    /// Contrato para cargar/persistir estado de salud desde infraestructura/legado.
    /// </summary>
    public interface IHealthRepository
    {
        HealthAggregate Load(float maxHp);
        void Save(HealthAggregate aggregate);
    }
}
