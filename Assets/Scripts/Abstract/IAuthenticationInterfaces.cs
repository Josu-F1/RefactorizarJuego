using System;

/// <summary>
/// Interfaz para operaciones de autenticación con contraseña
/// Principio: Single Responsibility Principle (SRP) - Solo autenticación
/// Principio: Interface Segregation Principle (ISP) - Interfaz específica
/// </summary>
public interface IAuthenticationService
{
    // Métodos legacy para compatibilidad
    bool Login(string userName);
    
    // Nuevos métodos con contraseña
    bool Login(string userName, string password);
    bool Register(string userName, string password, string confirmPassword);
    bool ChangePassword(string userName, string oldPassword, string newPassword);
    
    void Logout();
    bool IsUserLoggedIn();
    string GetCurrentUser();
    bool UserExists(string userName);
    
    // Eventos
    event Action<string> OnUserLoggedIn;
    event Action OnUserLoggedOut;
    event Action<string> OnUserRegistered;
    event Action<string> OnPasswordChanged;
    event Action<string> OnAuthenticationFailed;
}

/// <summary>
/// Interfaz para validación de entrada de usuario
/// Principio: Single Responsibility Principle (SRP) - Solo validación
/// </summary>
public interface IUserInputValidator
{
    bool IsValidUserName(string userName);
    string GetValidationError(string userName);
}

/// <summary>
/// Interfaz para navegación entre paneles
/// Principio: Single Responsibility Principle (SRP) - Solo navegación
/// </summary>
public interface IUINavigator
{
    void ShowPanel(string panelName);
    void HidePanel(string panelName);
    void NavigateToScene(string sceneName);
}

/// <summary>
/// Interfaz para validación de contraseñas
/// Principio: Single Responsibility Principle (SRP) - Solo validación de contraseñas
/// </summary>
public interface IPasswordValidator
{
    bool IsValidPassword(string password);
    string GetPasswordValidationError(string password);
    bool PasswordsMatch(string password, string confirmPassword);
}

/// <summary>
/// Interfaz para manejo seguro de contraseñas
/// Principio: Single Responsibility Principle (SRP) - Solo operaciones de hash
/// </summary>
public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}

// IUserRepository ya existe en IUserRepository.cs - usando esa definición

/// <summary>
/// Modelo de datos para credenciales de usuario
/// </summary>
[System.Serializable]
public class UserCredentials
{
    public string UserName;
    public string HashedPassword;
    public System.DateTime CreatedDate;
    public System.DateTime LastLoginDate;
    public bool IsActive = true;
    public int LoginAttempts = 0;
    public System.DateTime LastAttemptDate;
    
    public UserCredentials(string userName, string hashedPassword)
    {
        UserName = userName;
        HashedPassword = hashedPassword;
        CreatedDate = System.DateTime.Now;
        LastLoginDate = System.DateTime.MinValue;
    }
}

// ISessionManager ya existe en el sistema - usando la interfaz existente