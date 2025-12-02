/// <summary>
/// Gestor de sesión de usuario
/// Principio: Single Responsibility Principle (SRP) - Solo maneja sesión actual
/// </summary>
public class SessionManager : ISessionManager
{
    private string currentUsername;
    
    public string CurrentUsername 
    { 
        get => currentUsername; 
        set => currentUsername = value; 
    }
    
    public bool HasActiveSession => !string.IsNullOrEmpty(currentUsername);
    
    public void StartSession(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            UnityEngine.Debug.LogWarning("SessionManager: Cannot start session with empty username");
            return;
        }
        
        currentUsername = username;
        UnityEngine.Debug.Log($"SessionManager: Session started for user '{username}'");
    }
    
    public void EndSession()
    {
        if (HasActiveSession)
        {
            UnityEngine.Debug.Log($"SessionManager: Session ended for user '{currentUsername}'");
            currentUsername = null;
        }
    }
}