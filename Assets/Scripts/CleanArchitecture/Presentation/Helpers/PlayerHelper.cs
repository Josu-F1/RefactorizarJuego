using UnityEngine;
using CleanArchitecture.Infrastructure.DependencyInjection;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Presentation.Helpers
{
    /// <summary>
    /// Helper estático para facilitar la migración de Player.Instance a PlayerService
    /// Proporciona acceso unificado al jugador desde ambos sistemas
    /// </summary>
    public static class PlayerHelper
    {
        /// <summary>
        /// Obtiene el Transform del jugador (usa PlayerService si está disponible, sino Player.Instance)
        /// </summary>
        public static Transform GetPlayerTransform()
        {
            // Prioridad 1: PlayerService (Clean Architecture)
            var playerService = ServiceLocator.Instance?.Get<IPlayerService>();
            if (playerService != null && playerService.HasPlayer)
            {
                return playerService.PlayerTransform;
            }

            // Prioridad 2: Player.Instance (Legacy)
            if (global::Player.Instance != null)
            {
                return global::Player.Instance.transform;
            }

            return null;
        }

        /// <summary>
        /// Obtiene la posición del jugador
        /// </summary>
        public static Vector3 GetPlayerPosition()
        {
            var playerService = ServiceLocator.Instance?.Get<IPlayerService>();
            if (playerService != null && playerService.HasPlayer)
            {
                return playerService.PlayerPosition;
            }

            if (global::Player.Instance != null)
            {
                return global::Player.Instance.transform.position;
            }

            return Vector3.zero;
        }

        /// <summary>
        /// Obtiene el GameObject del jugador
        /// </summary>
        public static GameObject GetPlayerObject()
        {
            var playerService = ServiceLocator.Instance?.Get<IPlayerService>();
            if (playerService != null && playerService.HasPlayer)
            {
                return playerService.PlayerObject;
            }

            if (global::Player.Instance != null)
            {
                return global::Player.Instance.gameObject;
            }

            return null;
        }

        /// <summary>
        /// Verifica si hay un jugador disponible
        /// </summary>
        public static bool HasPlayer()
        {
            var playerService = ServiceLocator.Instance?.Get<IPlayerService>();
            if (playerService != null)
            {
                return playerService.HasPlayer;
            }

            return global::Player.Instance != null;
        }

        /// <summary>
        /// Teletransporta al jugador a una posición
        /// </summary>
        public static void TeleportPlayer(Vector3 position)
        {
            var playerService = ServiceLocator.Instance?.Get<IPlayerService>();
            if (playerService != null && playerService.HasPlayer)
            {
                playerService.TeleportPlayer(position);
                return;
            }

            if (global::Player.Instance != null)
            {
                global::Player.Instance.transform.position = position;
            }
        }
    }
}
