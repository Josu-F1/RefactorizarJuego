using UnityEngine;
using CleanArchitecture.Infrastructure.DependencyInjection;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Presentation.Adapters
{
    /// <summary>
    /// Conecta el evento Player.OnPlayerDead al GameStateService
    /// Reemplaza la lógica de GameManager que escuchaba este evento
    /// </summary>
    public class PlayerDeathConnector : MonoBehaviour
    {
        private IGameStateService _gameStateService;

        private void Awake()
        {
            _gameStateService = ServiceLocator.Instance.Get<IGameStateService>();

            if (_gameStateService == null)
            {
                Debug.LogError("[PlayerDeathConnector] ❌ GameStateService no encontrado");
                return;
            }

            Debug.Log("[PlayerDeathConnector] ✅ Esperando Player.Instance...");
        }

        private void Start()
        {
            // Esperar a que Player esté listo
            ConnectToPlayer();
        }

        private void ConnectToPlayer()
        {
            if (global::Player.Instance != null)
            {
                global::Player.Instance.OnPlayerDead += OnPlayerDead;
                Debug.Log("[PlayerDeathConnector] ✅ Conectado a Player.OnPlayerDead");
            }
            else
            {
                Debug.LogWarning("[PlayerDeathConnector] ⚠️ Player.Instance no encontrado");
            }
        }

        private void OnPlayerDead()
        {
            Debug.Log("[PlayerDeathConnector] 💀 Player muerto, disparando derrota...");
            _gameStateService?.TriggerDefeat();
        }

        private void OnDestroy()
        {
            // Limpiar suscripción
            if (global::Player.Instance != null)
            {
                global::Player.Instance.OnPlayerDead -= OnPlayerDead;
            }
        }
    }
}
