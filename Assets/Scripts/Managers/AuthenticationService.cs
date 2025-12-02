using System;
using UnityEngine;

/// <summary>
/// Servicio de autenticación aplicando principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo lógica de autenticación
/// Principio: Dependency Inversion Principle (DIP) - Depende de ISessionManager
/// Patrón: Observer Pattern - Notifica cambios de estado
/// </summary>
public class AuthenticationService : IAuthenticationService
{
    private ISessionManager sessionManager;
    private IUserInputValidator validator;
    
    public event Action<string> OnUserLoggedIn;
    public event Action OnUserLoggedOut;
    
    public AuthenticationService(ISessionManager sessionManager, IUserInputValidator validator)
    {
        this.sessionManager = sessionManager ?? throw new ArgumentNullException(nameof(sessionManager));
        this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }
    
    public bool Login(string userName)
    {
        if (!validator.IsValidUserName(userName))
        {
            Debug.LogWarning($"[AuthenticationService] Invalid username: {validator.GetValidationError(userName)}");
            return false;
        }
        
        try
        {
            sessionManager.StartSession(userName);
            
            // Integración con el sistema DataManagerComposer refactorizado
            DataManagerComposer.CurrentUsername = userName;
            
            Debug.Log($"[AuthenticationService] User '{userName}' logged in successfully");
            OnUserLoggedIn?.Invoke(userName);
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"[AuthenticationService] Login failed: {ex.Message}");
            return false;
        }
    }
    
    public void Logout()
    {
        string currentUser = GetCurrentUser();
        sessionManager.EndSession();
        
        Debug.Log($"[AuthenticationService] User '{currentUser}' logged out");
        OnUserLoggedOut?.Invoke();
    }
    
    public bool IsUserLoggedIn()
    {
        return sessionManager.HasActiveSession;
    }
    
    public string GetCurrentUser()
    {
        return sessionManager.CurrentUsername ?? "";
    }
}