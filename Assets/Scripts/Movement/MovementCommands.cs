using UnityEngine;

/// <summary>
/// Comando de movimiento direccional
/// Patrón: Command Pattern - Encapsula la acción de moverse en una dirección
/// </summary>
public class DirectionalMoveCommand : IMovementCommand
{
    private Vector2 direction;
    
    public DirectionalMoveCommand(Vector2 direction)
    {
        this.direction = direction;
    }
    
    public void Execute(IMovementExecutor executor)
    {
        executor.Move(direction);
    }
}

/// <summary>
/// Comando para detener el movimiento
/// </summary>
public class StopMoveCommand : IMovementCommand
{
    public void Execute(IMovementExecutor executor)
    {
        executor.Move(Vector2.zero);
    }
}

/// <summary>
/// Comando compuesto para múltiples direcciones con prioridad
/// </summary>
public class PriorityMoveCommand : IMovementCommand
{
    private Vector2 priorityDirection;
    
    public PriorityMoveCommand(Vector2 priorityDirection)
    {
        this.priorityDirection = priorityDirection;
    }
    
    public void Execute(IMovementExecutor executor)
    {
        executor.Move(priorityDirection);
    }
}