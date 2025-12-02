using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface para gestión de posiciones de bombas
/// Principio: Single Responsibility Principle (SRP) - Solo maneja posiciones
/// </summary>
public interface IBombPositionManager
{
    bool CanPlaceBombAt(Vector2 position);
    void AddBombPosition(Vector2 position);
    void RemoveBombPosition(Vector2 position);
    int CurrentBombCount { get; }
    bool HasReachedLimit(int bombLimit);
}