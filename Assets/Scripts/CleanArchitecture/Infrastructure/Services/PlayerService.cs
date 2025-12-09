using UnityEngine;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Infrastructure.Services
{
    /// <summary>
    /// Implementación del servicio de jugador
    /// </summary>
    public class PlayerService : IPlayerService
    {
        private GameObject _player;

        public Transform PlayerTransform => _player != null ? _player.transform : null;
        public GameObject PlayerObject => _player;
        public Vector3 PlayerPosition => _player != null ? _player.transform.position : Vector3.zero;
        public bool HasPlayer => _player != null;

        public void RegisterPlayer(GameObject player)
        {
            if (player == null)
            {
                Debug.LogWarning("[PlayerService] Intentando registrar un jugador null");
                return;
            }

            _player = player;
            Debug.Log($"[PlayerService] ✅ Jugador registrado: {player.name}");
        }

        public void UnregisterPlayer()
        {
            if (_player != null)
            {
                Debug.Log($"[PlayerService] Jugador {_player.name} desregistrado");
            }
            _player = null;
        }

        public void TeleportPlayer(Vector3 position)
        {
            if (_player == null)
            {
                Debug.LogWarning("[PlayerService] No hay jugador para teletransportar");
                return;
            }

            _player.transform.position = position;
            Debug.Log($"[PlayerService] 🚀 Jugador teletransportado a {position}");
        }

        public void SetPlayerActive(bool active)
        {
            if (_player == null)
            {
                Debug.LogWarning("[PlayerService] No hay jugador para activar/desactivar");
                return;
            }

            _player.SetActive(active);
            Debug.Log($"[PlayerService] Jugador {(active ? "activado" : "desactivado")}");
        }
    }
}
