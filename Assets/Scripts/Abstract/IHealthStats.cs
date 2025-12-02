using System;

/// <summary>
/// Interface para estadísticas de salud
/// Principio: Single Responsibility Principle (SRP) - Solo datos de salud
/// </summary>
public interface IHealthStats
{
    float CurrentHP { get; }
    float MaxHP { get; }
    float Percentage { get; }
    bool IsFull { get; }
    bool IsDead { get; }
    
    event Action<float> OnHealthChanged;
    event Action OnDead;
}