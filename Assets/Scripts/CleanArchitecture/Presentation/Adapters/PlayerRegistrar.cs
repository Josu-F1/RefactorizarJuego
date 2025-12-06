using UnityEngine;
using CleanArchitecture.Infrastructure.DependencyInjection;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Presentation.Adapters
{
    /// <summary>
    /// Adapter que registra automáticamente al Player en el PlayerService
    /// Añadir este componente al GameObject del Player
    /// </summary>
    public class PlayerRegistrar : MonoBehaviour
    {
        private IPlayerService _playerService;

        private void Awake()
        {
            _playerService = ServiceLocator.Instance.Get<IPlayerService>();

            if (_playerService == null)
            {
                Debug.LogError("[PlayerRegistrar] ❌ PlayerService no encontrado");
                return;
            }

            // Registrar este GameObject como el jugador
            _playerService.RegisterPlayer(gameObject);
        }

        private void OnDestroy()
        {
            // Desregistrar al destruirse
            _playerService?.UnregisterPlayer();
        }
    }
}
