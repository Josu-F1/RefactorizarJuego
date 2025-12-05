/// <summary>
/// Interface para gestión de sesión de usuario
/// Principio: Single Responsibility Principle (SRP) - Solo maneja sesión actual
/// </summary>
public interface ISessionManager
{
    string CurrentUsername { get; set; }
    bool HasActiveSession { get; }
    void StartSession(string username);
    void EndSession();
}