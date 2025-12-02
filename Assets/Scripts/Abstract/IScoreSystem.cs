using System;

/// <summary>
/// Interface para el sistema de puntuación del juego
/// Principio: Single Responsibility Principle (SRP)
/// </summary>
public interface IScoreSystem
{
    int CurrentScore { get; }
    int RequiredScore { get; }
    float Progress { get; }
    
    event Action OnScoreUpdated;
    event Action OnScoreGoalReached;
    
    void AddScore(int points);
    void ResetScore();
}