using UnityEngine;

namespace CleanArchitecture.Application.Services
{
    /// <summary>
    /// Servicio que gestiona la referencia al jugador
    /// Reemplaza el uso de Player.Instance
    /// </summary>
    public interface IPlayerService
    {
        /// <summary>
        /// Transform del jugador actual
        /// </summary>
        Transform PlayerTransform { get; }

        /// <summary>
        /// GameObject del jugador actual
        /// </summary>
        GameObject PlayerObject { get; }

        /// <summary>
        /// Posición del jugador
        /// </summary>
        Vector3 PlayerPosition { get; }

        /// <summary>
        /// Verifica si hay un jugador activo
        /// </summary>
        bool HasPlayer { get; }

        /// <summary>
        /// Registra el jugador actual
        /// </summary>
        void RegisterPlayer(GameObject player);

        /// <summary>
        /// Desregistra el jugador
        /// </summary>
        void UnregisterPlayer();

        /// <summary>
        /// Teletransporta al jugador a una posición
        /// </summary>
        void TeleportPlayer(Vector3 position);

        /// <summary>
        /// Activa/desactiva al jugador
        /// </summary>
        void SetPlayerActive(bool active);
    }
}
