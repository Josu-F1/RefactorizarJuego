using UnityEngine;
using CleanArchitecture.Infrastructure.DependencyInjection;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Presentation.Adapters
{
    /// <summary>
    /// Conecta el evento Enemy.OnAnyEnemyKilled al ScoreService
    /// Reemplaza la lógica de GameManager que escuchaba este evento
    /// </summary>
    public class EnemyScoreConnector : MonoBehaviour
    {
        private IScoreService _scoreService;
        private IGameStateService _gameStateService;

        private void Awake()
        {
            // Obtener servicios
            _scoreService = ServiceLocator.Instance.Get<IScoreService>();
            _gameStateService = ServiceLocator.Instance.Get<IGameStateService>();

            if (_scoreService == null)
            {
                Debug.LogError("[EnemyScoreConnector] ❌ ScoreService no encontrado. ¿GameBootstrapper está en la escena?");
                return;
            }

            // Conectar evento legacy al servicio
            global::Enemy.OnAnyEnemyKilled += OnEnemyKilled;

            Debug.Log("[EnemyScoreConnector] ✅ Conectado a Enemy.OnAnyEnemyKilled");
        }

        private void OnEnemyKilled(int score)
        {
            // Solo agregar puntos si el juego está activo
            if (_gameStateService != null && !_gameStateService.IsPlaying)
                return;

            _scoreService?.AddScore(score);
        }

        private void OnDestroy()
        {
            // Limpiar suscripción
            global::Enemy.OnAnyEnemyKilled -= OnEnemyKilled;
        }
    }
}
