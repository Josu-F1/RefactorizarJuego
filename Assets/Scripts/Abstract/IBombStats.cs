using System;

/// <summary>
/// Interface para estadísticas de bomba que pueden ser mostradas en UI
/// Principio: Dependency Inversion Principle (DIP)
/// </summary>
public interface IBombStats
{
    int BombLimit { get; }
    float Damage { get; }
    int Length { get; }
    
    event Action OnBombLimitChanged;
    event Action OnDamageChanged; 
    event Action OnLengthChanged;
}