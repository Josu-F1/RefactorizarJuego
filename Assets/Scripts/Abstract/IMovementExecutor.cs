using UnityEngine;

/// <summary>
/// Interface para ejecutores de movimiento
/// Principio: Dependency Inversion Principle (DIP)
/// </summary>
public interface IMovementExecutor
{
    void Move(Vector2 direction);
}