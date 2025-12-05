using UnityEngine;

/// <summary>
/// Interface para comandos de movimiento
/// Patrón: Command Pattern - Encapsula acciones como objetos
/// </summary>
public interface IMovementCommand
{
    void Execute(IMovementExecutor executor);
}