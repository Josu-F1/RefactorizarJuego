using System;

/// <summary>
/// Interface para estadísticas de movimiento que pueden ser mostradas en UI
/// Principio: Dependency Inversion Principle (DIP)
/// </summary>
public interface IMovementStats
{
    float MoveSpeed { get; }
    
    event Action OnMoveSpeedChanged;
}