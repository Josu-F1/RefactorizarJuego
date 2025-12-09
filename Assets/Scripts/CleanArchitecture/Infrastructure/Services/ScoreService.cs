using System;
using UnityEngine;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Infrastructure.Services
{
    /// <summary>
    /// Implementación del servicio de puntuación
    /// </summary>
    public class ScoreService : IScoreService
    {
        public event Action<int> OnScoreChanged;
        public event Action OnGoalReached;

        public int CurrentScore { get; private set; }
        public int RequiredScore { get; private set; }
        public float Progress => RequiredScore > 0 ? (float)CurrentScore / RequiredScore : 0f;

        public ScoreService(int requiredScore = 200)
        {
            RequiredScore = requiredScore;
            CurrentScore = 0;
        }

        public void AddScore(int points)
        {
            if (points <= 0) return;

            CurrentScore += points;
            Debug.Log($"[ScoreService] +{points} puntos. Total: {CurrentScore}/{RequiredScore}");

            OnScoreChanged?.Invoke(CurrentScore);

            if (CurrentScore >= RequiredScore)
            {
                Debug.Log("[ScoreService] 🎯 ¡Objetivo alcanzado!");
                OnGoalReached?.Invoke();
            }
        }

        public void SetRequiredScore(int score)
        {
            if (score < 0) score = 0;
            RequiredScore = score;
            Debug.Log($"[ScoreService] Objetivo establecido: {RequiredScore}");
        }

        public void Reset()
        {
            CurrentScore = 0;
            Debug.Log("[ScoreService] ♻️ Puntuación reiniciada");
            OnScoreChanged?.Invoke(CurrentScore);
        }
    }
}
