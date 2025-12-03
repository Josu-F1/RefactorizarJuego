using System;

namespace CleanArchitecture.Domain.Score
{
    /// <summary>
    /// Contrato para obtener y persistir puntajes dentro de casos de uso.
    /// Implementaciones viven en Infrastructure.
    /// </summary>
    public interface IScoreRepository
    {
        /// <summary>
        /// Carga el estado de puntaje actual. Implementaciones deben devolver un Score válido.
        /// </summary>
        Score Load(int requiredScore);

        /// <summary>
        /// Persiste el estado actual de Score (ej: sincronizar con sistemas legados).
        /// </summary>
        void Save(Score score);
    }
}
