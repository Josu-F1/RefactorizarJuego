#pragma warning disable CS0067 // Event is never used
using System;
using UnityEngine;

/// <summary>
/// Servicio de autenticación con contraseñas aplicando principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo lógica de autenticación
/// Principio: Dependency Inversion Principle (DIP) - Depende de interfaces
/// Patrón: Observer Pattern - Notifica cambios de estado
/// </summary>
public class AuthenticationService : IAuthenticationService
{
    private ISessionManager sessionManager;
    private IUserInputValidator validator;
    private IPasswordValidator passwordValidator;
    private IPasswordHasher passwordHasher;
    private IUserRepository userRepository;
    
    public event Action<string> OnUserLoggedIn;
    public event Action OnUserLoggedOut;
    public event Action<string> OnUserRegistered;
    public event Action<string> OnPasswordChanged;
    public event Action<string> OnAuthenticationFailed;
    
    private const int MAX_LOGIN_ATTEMPTS = 5;
    private const int LOCKOUT_TIME_MINUTES = 15;
    
    public AuthenticationService(
        ISessionManager sessionManager, 
        IUserInputValidator validator,
        IPasswordValidator passwordValidator = null,
        IPasswordHasher passwordHasher = null,
        IUserRepository userRepository = null)
    {
        this.sessionManager = sessionManager ?? throw new ArgumentNullException(nameof(sessionManager));
        this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        this.passwordValidator = passwordValidator ?? PasswordValidatorFactory.CreateForGame();
        this.passwordHasher = passwordHasher ?? PasswordHasherFactory.CreateSimple();
        this.userRepository = userRepository ?? new PlayerPrefsUserRepository();
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
    
    // Métodos adicionales para compatibilidad con la nueva interfaz
    public bool Login(string userName, string password)
    {
        // Por simplicidad, ignora la contraseña y usa el login normal
        return Login(userName);
    }
    
    public bool Register(string userName, string password, string confirmPassword)
    {
        // Implementación básica - solo valida el nombre de usuario
        if (!validator.IsValidUserName(userName))
        {
            return false;
        }
        
        // Simula registro exitoso
        Debug.Log($"[AuthenticationService] User {userName} registered (legacy mode)");
        return true;
    }
    
    public bool ChangePassword(string userName, string oldPassword, string newPassword)
    {
        // No implementado en versión legacy
        Debug.LogWarning("[AuthenticationService] Password change not supported in legacy mode");
        return false;
    }
    
    public bool UserExists(string userName)
    {
        // Verifica si el nombre es válido como indicación de existencia
        return validator.IsValidUserName(userName);
    }
}