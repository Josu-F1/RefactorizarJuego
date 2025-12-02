using System;

/// <summary>
/// Interface para manejar estados del juego (victoria/derrota)
/// Principio: Single Responsibility Principle (SRP)
/// </summary>
public interface IGameStateManager
{
    bool IsPlaying { get; }
    
    event Action OnVictory;
    event Action OnDefeat;
    event Action OnGameStateChanged;
    
    void TriggerVictory();
    void TriggerDefeat();
    void ResetGameState();
}