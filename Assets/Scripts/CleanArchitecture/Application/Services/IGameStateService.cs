using System;

namespace CleanArchitecture.Application.Services
{
    /// <summary>
    /// Servicio que gestiona el estado general del juego
    /// Reemplaza las responsabilidades de victoria/derrota de GameManager
    /// </summary>
    public interface IGameStateService
    {
        /// <summary>
        /// Evento disparado cuando el jugador gana
        /// </summary>
        event Action OnVictory;

        /// <summary>
        /// Evento disparado cuando el jugador pierde
        /// </summary>
        event Action OnDefeat;

        /// <summary>
        /// Indica si el juego está activo
        /// </summary>
        bool IsPlaying { get; }

        /// <summary>
        /// Desencadena la victoria del jugador
        /// </summary>
        void TriggerVictory();

        /// <summary>
        /// Desencadena la derrota del jugador
        /// </summary>
        void TriggerDefeat();

        /// <summary>
        /// Reinicia el estado del juego
        /// </summary>
        void Reset();

        /// <summary>
        /// Pausa el juego
        /// </summary>
        void Pause();

        /// <summary>
        /// Reanuda el juego
        /// </summary>
        void Resume();
    }
}
