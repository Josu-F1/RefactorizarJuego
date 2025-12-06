namespace CleanArchitecture.Application.Services
{
    /// <summary>
    /// Servicio de gestión general del juego
    /// Coordina otros servicios y maneja el flujo del juego
    /// </summary>
    public interface IGameManagementService
    {
        /// <summary>
        /// Inicia el juego
        /// </summary>
        void StartGame();

        /// <summary>
        /// Pausa el juego
        /// </summary>
        void PauseGame();

        /// <summary>
        /// Reanuda el juego
        /// </summary>
        void ResumeGame();

        /// <summary>
        /// Reinicia el juego
        /// </summary>
        void RestartGame();

        /// <summary>
        /// Carga un nivel
        /// </summary>
        void LoadLevel(int levelNumber);

        /// <summary>
        /// Guarda el progreso actual
        /// </summary>
        void SaveProgress();

        /// <summary>
        /// Estado actual del juego
        /// </summary>
        bool IsPlaying { get; }

        /// <summary>
        /// Nivel actual
        /// </summary>
        int CurrentLevel { get; }

        /// <summary>
        /// Progreso actual (0-1)
        /// </summary>
        float GameProgress { get; }
    }
}
