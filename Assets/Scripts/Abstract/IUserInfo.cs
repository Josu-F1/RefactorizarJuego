/// <summary>
/// Interface para información del usuario que puede ser mostrada en UI
/// Principio: Single Responsibility Principle (SRP) - Separar responsabilidades
/// </summary>
public interface IUserInfo
{
    string Username { get; }
}