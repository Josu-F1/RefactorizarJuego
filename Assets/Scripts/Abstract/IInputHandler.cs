/// <summary>
/// Interface para sistemas de input
/// Principio: Single Responsibility Principle (SRP) - Solo captura input
/// </summary>
public interface IInputHandler
{
    IMovementCommand GetMovementCommand();
    bool IsInputActive();
}