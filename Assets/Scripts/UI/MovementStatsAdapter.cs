using System;
using UnityEngine;

/// <summary>
/// Adaptador que convierte MoveComponent en IMovementStats
/// Patrón: Adapter Pattern para interface segregation
/// </summary>
[System.Serializable]
public class MovementStatsAdapter : IMovementStats
{
    private MoveComponent moveComponent;

    public MovementStatsAdapter(MoveComponent moveComponent)
    {
        this.moveComponent = moveComponent;
    }

    public float MoveSpeed => moveComponent.MoveSpeed;

    public event Action OnMoveSpeedChanged
    {
        add { moveComponent.OnMoveSpeedChanged += value; }
        remove { moveComponent.OnMoveSpeedChanged -= value; }
    }
}