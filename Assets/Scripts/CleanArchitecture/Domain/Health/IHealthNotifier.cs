using System;

namespace CleanArchitecture.Domain.Health
{
    /// <summary>
    /// Contrato opcional para notificar efectos secundarios de muerte o cambio de salud (ej: puntuación).
    /// Mantiene la capa de aplicación limpia de dependencias Unity.
    /// </summary>
    public interface IHealthNotifier
    {
        void OnHealthChanged(HealthSnapshot snapshot);
        void OnDeath();
    }
}
