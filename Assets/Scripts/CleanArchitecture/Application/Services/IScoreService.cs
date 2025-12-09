using System;

namespace CleanArchitecture.Application.Services
{
    /// <summary>
    /// Servicio que gestiona la puntuación del juego
    /// Reemplaza las responsabilidades de score de GameManager
    /// </summary>
    public interface IScoreService
    {
        /// <summary>
        /// Evento disparado cuando cambia la puntuación
        /// </summary>
        event Action<int> OnScoreChanged;

        /// <summary>
        /// Evento disparado cuando se alcanza el objetivo
        /// </summary>
        event Action OnGoalReached;

        /// <summary>
        /// Puntuación actual
        /// </summary>
        int CurrentScore { get; }

        /// <summary>
        /// Puntuación requerida para ganar
        /// </summary>
        int RequiredScore { get; }

        /// <summary>
        /// Progreso hacia el objetivo (0-1)
        /// </summary>
        float Progress { get; }

        /// <summary>
        /// Añade puntos a la puntuación actual
        /// </summary>
        void AddScore(int points);

        /// <summary>
        /// Establece la puntuación requerida
        /// </summary>
        void SetRequiredScore(int score);

        /// <summary>
        /// Reinicia la puntuación
        /// </summary>
        void Reset();
    }
}
