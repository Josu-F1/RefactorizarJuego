using System;
using UnityEngine;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Infrastructure.Services
{
    /// <summary>
    /// Implementación del servicio de estado del juego
    /// </summary>
    public class GameStateService : IGameStateService
    {
        public event Action OnVictory;
        public event Action OnDefeat;

        public bool IsPlaying { get; private set; } = true;

        private readonly float _endGameDelay;

        public GameStateService(float endGameDelay = 2f)
        {
            _endGameDelay = endGameDelay;
        }

        public void TriggerVictory()
        {
            if (!IsPlaying) return;

            Debug.Log("[GameStateService] 🎉 Victoria!");
            IsPlaying = false;

            // Invocar después de un delay
            CoroutineRunner.Instance.DelayedAction(_endGameDelay, () =>
            {
                OnVictory?.Invoke();
                Pause();
            });
        }

        public void TriggerDefeat()
        {
            if (!IsPlaying) return;

            Debug.Log("[GameStateService] 💀 Derrota");
            IsPlaying = false;

            CoroutineRunner.Instance.DelayedAction(_endGameDelay, () =>
            {
                OnDefeat?.Invoke();
                Pause();
            });
        }

        public void Reset()
        {
            IsPlaying = true;
            Resume();
            Debug.Log("[GameStateService] ♻️ Estado reiniciado");
        }

        public void Pause()
        {
            Time.timeScale = 0f;
            Debug.Log("[GameStateService] ⏸️ Juego pausado");
        }

        public void Resume()
        {
            Time.timeScale = 1f;
            Debug.Log("[GameStateService] ▶️ Juego reanudado");
        }
    }
}
