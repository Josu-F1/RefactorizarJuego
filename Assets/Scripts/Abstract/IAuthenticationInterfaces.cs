using System;

/// <summary>
/// Interfaz para operaciones de autenticación
/// Principio: Single Responsibility Principle (SRP) - Solo autenticación
/// Principio: Interface Segregation Principle (ISP) - Interfaz específica
/// </summary>
public interface IAuthenticationService
{
    bool Login(string userName);
    void Logout();
    bool IsUserLoggedIn();
    string GetCurrentUser();
    event Action<string> OnUserLoggedIn;
    event Action OnUserLoggedOut;
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

// ISessionManager ya existe en el sistema - usando la interfaz existente