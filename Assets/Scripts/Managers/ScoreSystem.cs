using System;
using UnityEngine;

/// <summary>
/// Sistema de puntuación basico del juego
/// Principio: Single Responsibility Principle (SRP) - Solo maneja puntuación
/// </summary>
[System.Serializable]
public class ScoreSystem : IScoreSystem
{
    [SerializeField] private int currentScore = 0;
    [SerializeField] private int requiredScore = 200;
    
    public int CurrentScore => currentScore;
    public int RequiredScore => requiredScore;
    public float Progress => requiredScore > 0 ? (float)currentScore / (float)requiredScore : 0f;
    
    public event Action OnScoreUpdated;
    public event Action OnScoreGoalReached;
    
    public ScoreSystem(int requiredScore = 200)
    {
        this.requiredScore = requiredScore;
    }
    
    public void AddScore(int points)
    {
        if (points <= 0) return;
        
        int previousScore = currentScore;
        currentScore += points;
        
        OnScoreUpdated?.Invoke();
        
        // Verificar si se alcanzó la meta
        if (previousScore < requiredScore && currentScore >= requiredScore)
        {
            OnScoreGoalReached?.Invoke();
        }
    }
    
    public void ResetScore()
    {
        currentScore = 0;
        OnScoreUpdated?.Invoke();
    }
}