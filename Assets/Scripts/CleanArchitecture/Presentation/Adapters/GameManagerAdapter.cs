using UnityEngine;
using CleanArchitecture.Infrastructure.DependencyInjection;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Presentation.Adapters
{
    /// <summary>
    /// Adapter para mantener compatibilidad con código legacy que usa GameManager
    /// Este componente actúa como puente entre el viejo sistema y Clean Architecture
    /// TEMPORAL: Eliminar cuando todo el código use directamente los servicios
    /// </summary>
    [RequireComponent(typeof(GameManager))]
    public class GameManagerAdapter : MonoBehaviour
    {
        private GameManager _legacyGameManager;
        private IGameStateService _gameStateService;
        private IScoreService _scoreService;

        private void Awake()
        {
            _legacyGameManager = GetComponent<GameManager>();
            
            // Obtener servicios del ServiceLocator
            _gameStateService = ServiceLocator.Instance.Get<IGameStateService>();
            _scoreService = ServiceLocator.Instance.Get<IScoreService>();

            if (_gameStateService == null || _scoreService == null)
            {
                Debug.LogError("[GameManagerAdapter] ❌ Servicios no encontrados. ¿GameBootstrapper está en la escena?");
                return;
            }

            SetupBridge();
        }

        private void SetupBridge()
        {
            // Puente: eventos del servicio → eventos legacy
            _gameStateService.OnVictory += () => _legacyGameManager.OnVictory?.Invoke();
            _gameStateService.OnDefeat += () => _legacyGameManager.OnDefeat?.Invoke();
            _scoreService.OnScoreChanged += _ => _legacyGameManager.OnScoreUpdated?.Invoke();

            // Sincronizar valores iniciales
            _scoreService.SetRequiredScore(_legacyGameManager.RequiredScore);

            Debug.Log("[GameManagerAdapter] ✅ Puente legacy activado");
        }

        private void Update()
        {
            // Mantener sincronizados los valores para código legacy que lee directamente
            // Esto permite que HealthBar y otros componentes sigan funcionando
            if (_scoreService != null)
            {
                // Usar reflection para actualizar valores privados del GameManager
                var currentScoreField = typeof(GameManager).GetField("currentScore", 
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                
                if (currentScoreField != null)
                {
                    currentScoreField.SetValue(_legacyGameManager, _scoreService.CurrentScore);
                }
            }

            if (_gameStateService != null)
            {
                // Sincronizar estado isPlaying
                var isPlayingField = typeof(GameManager).GetField("isPlaying", 
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                
                if (isPlayingField != null)
                {
                    isPlayingField.SetValue(_legacyGameManager, _gameStateService.IsPlaying);
                }
            }
        }

        private void OnDestroy()
        {
            // Limpiar suscripciones
            if (_gameStateService != null)
            {
                _gameStateService.OnVictory -= () => _legacyGameManager.OnVictory?.Invoke();
                _gameStateService.OnDefeat -= () => _legacyGameManager.OnDefeat?.Invoke();
            }

            if (_scoreService != null)
            {
                _scoreService.OnScoreChanged -= _ => _legacyGameManager.OnScoreUpdated?.Invoke();
            }
        }

        /// <summary>
        /// Helper para acceder a los valores desde el inspector (debug)
        /// </summary>
        public int CurrentScore => _scoreService?.CurrentScore ?? 0;
        public int RequiredScore => _scoreService?.RequiredScore ?? 0;
        public float Progress => _scoreService?.Progress ?? 0f;
        public bool IsPlaying => _gameStateService?.IsPlaying ?? true;
    }
}
