using System.Collections.Generic;
using UnityEngine;
using Vector2Extensions;

/// <summary>
/// Gestor de posiciones de bombas usando lista
/// Principio: Single Responsibility Principle (SRP) - Solo gestiona posiciones
/// </summary>
public class ListBombPositionManager : IBombPositionManager
{
    private List<Vector2> bombPositions = new List<Vector2>();
    
    public int CurrentBombCount => bombPositions.Count;
    
    public bool CanPlaceBombAt(Vector2 position)
    {
        Vector2 cellCenterPos = position.ToCellCenter();
        return !bombPositions.Contains(cellCenterPos);
    }
    
    public void AddBombPosition(Vector2 position)
    {
        Vector2 cellCenterPos = position.ToCellCenter();
        if (!bombPositions.Contains(cellCenterPos))
        {
            bombPositions.Add(cellCenterPos);
        }
    }
    
    public void RemoveBombPosition(Vector2 position)
    {
        Vector2 cellCenterPos = position.ToCellCenter();
        bombPositions.Remove(cellCenterPos);
    }
    
    public bool HasReachedLimit(int bombLimit)
    {
        return bombPositions.Count >= bombLimit;
    }
}