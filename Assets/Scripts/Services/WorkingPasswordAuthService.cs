using System;
using UnityEngine;

/// <summary>
/// Servicio de autenticación con contraseñas FUNCIONAL
/// Principio: Single Responsibility Principle (SRP) - Solo lógica de autenticación
/// Principio: Dependency Inversion Principle (DIP) - Depende de interfaces
/// Patrón: Observer Pattern - Notifica cambios de estado
/// </summary>
public class WorkingPasswordAuthService : IAuthenticationService
{
    private ISessionManager sessionManager;
    private IUserInputValidator validator;
    
    public event Action<string> OnUserLoggedIn;
    public event Action OnUserLoggedOut;
    public event Action<string> OnUserRegistered;
    public event Action<string> OnPasswordChanged;
    public event Action<string> OnAuthenticationFailed;
    
    public WorkingPasswordAuthService(
        ISessionManager sessionManager, 
        IUserInputValidator validator)
    {
        this.sessionManager = sessionManager ?? throw new ArgumentNullException(nameof(sessionManager));
        this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        
        Debug.Log("[WorkingPasswordAuthService] Initialized with password support");
    }
    
    // Método legacy para compatibilidad (modo invitado)
    public bool Login(string userName)
    {
        if (!validator.IsValidUserName(userName))
        {
            string error = $"Usuario inválido: {validator.GetValidationError(userName)}";
            Debug.LogWarning($"[WorkingPasswordAuthService] {error}");
            OnAuthenticationFailed?.Invoke(error);
            return false;
        }

        try
        {
            sessionManager.StartSession(userName);
            DataManagerComposer.CurrentUsername = userName;
            
            OnUserLoggedIn?.Invoke(userName);
            Debug.Log($"[WorkingPasswordAuthService] Guest user '{userName}' logged in successfully");
            return true;
        }
        catch (Exception ex)
        {
            string error = $"Error de autenticación: {ex.Message}";
            Debug.LogError($"[WorkingPasswordAuthService] {error}");
            OnAuthenticationFailed?.Invoke(error);
            return false;
        }
    }

    public bool Login(string userName, string password)
    {
        if (!validator.IsValidUserName(userName))
        {
            string error = $"Usuario inválido: {validator.GetValidationError(userName)}";
            Debug.LogWarning($"[WorkingPasswordAuthService] {error}");
            OnAuthenticationFailed?.Invoke(error);
            return false;
        }

        if (string.IsNullOrEmpty(password))
        {
            OnAuthenticationFailed?.Invoke("La contraseña no puede estar vacía");
            return false;
        }

        try
        {
            // Verificar credenciales usando PlayerPrefs directamente
            string savedPassword = PlayerPrefs.GetString($"PWD_{userName}", "");
            
            if (string.IsNullOrEmpty(savedPassword))
            {
                OnAuthenticationFailed?.Invoke("Usuario no encontrado");
                return false;
            }

            // Hash simple para comparación
            string hashedInput = HashPassword(password);
            if (savedPassword != hashedInput)
            {
                OnAuthenticationFailed?.Invoke("Contraseña incorrecta");
                return false;
            }

            // Login exitoso
            sessionManager.StartSession(userName);
            DataManagerComposer.CurrentUsername = userName;
            
            // Actualizar último acceso
            PlayerPrefs.SetString($"LAST_{userName}", DateTime.Now.ToString());
            PlayerPrefs.Save();
            
            OnUserLoggedIn?.Invoke(userName);
            Debug.Log($"[WorkingPasswordAuthService] User '{userName}' logged in successfully with password");
            return true;
        }
        catch (Exception ex)
        {
            string error = $"Error de autenticación: {ex.Message}";
            Debug.LogError($"[WorkingPasswordAuthService] {error}");
            OnAuthenticationFailed?.Invoke(error);
            return false;
        }
    }

    public bool Register(string userName, string password, string confirmPassword)
    {
        if (!validator.IsValidUserName(userName))
        {
            string error = $"Usuario inválido: {validator.GetValidationError(userName)}";
            Debug.LogWarning($"[WorkingPasswordAuthService] {error}");
            OnAuthenticationFailed?.Invoke(error);
            return false;
        }

        if (string.IsNullOrEmpty(password))
        {
            OnAuthenticationFailed?.Invoke("La contraseña no puede estar vacía");
            return false;
        }

        if (password.Length < 4)
        {
            OnAuthenticationFailed?.Invoke("La contraseña debe tener al menos 4 caracteres");
            return false;
        }

        if (password != confirmPassword)
        {
            OnAuthenticationFailed?.Invoke("Las contraseñas no coinciden");
            return false;
        }

        string userKey = $"PWD_{userName}";
        if (PlayerPrefs.HasKey(userKey))
        {
            OnAuthenticationFailed?.Invoke("El usuario ya existe");
            return false;
        }

        try
        {
            // Registrar usuario
            string hashedPassword = HashPassword(password);
            PlayerPrefs.SetString(userKey, hashedPassword);
            PlayerPrefs.SetString($"CREATED_{userName}", DateTime.Now.ToString());
            PlayerPrefs.Save();
            
            OnUserRegistered?.Invoke(userName);
            Debug.Log($"[WorkingPasswordAuthService] User '{userName}' registered successfully");
            return true;
        }
        catch (Exception ex)
        {
            string error = $"Error en el registro: {ex.Message}";
            Debug.LogError($"[WorkingPasswordAuthService] {error}");
            OnAuthenticationFailed?.Invoke(error);
            return false;
        }
    }

    public bool ChangePassword(string userName, string oldPassword, string newPassword)
    {
        if (!IsUserLoggedIn() || GetCurrentUser() != userName)
        {
            OnAuthenticationFailed?.Invoke("Debe iniciar sesión para cambiar la contraseña");
            return false;
        }

        string userKey = $"PWD_{userName}";
        if (!PlayerPrefs.HasKey(userKey))
        {
            OnAuthenticationFailed?.Invoke("Usuario no encontrado");
            return false;
        }

        string savedPassword = PlayerPrefs.GetString(userKey);
        if (savedPassword != HashPassword(oldPassword))
        {
            OnAuthenticationFailed?.Invoke("Contraseña actual incorrecta");
            return false;
        }

        if (string.IsNullOrEmpty(newPassword) || newPassword.Length < 4)
        {
            OnAuthenticationFailed?.Invoke("La nueva contraseña debe tener al menos 4 caracteres");
            return false;
        }

        try
        {
            PlayerPrefs.SetString(userKey, HashPassword(newPassword));
            PlayerPrefs.Save();
            
            OnPasswordChanged?.Invoke(userName);
            Debug.Log($"[WorkingPasswordAuthService] Password changed for user '{userName}'");
            return true;
        }
        catch (Exception ex)
        {
            string error = $"Error al cambiar contraseña: {ex.Message}";
            Debug.LogError($"[WorkingPasswordAuthService] {error}");
            OnAuthenticationFailed?.Invoke(error);
            return false;
        }
    }

    public bool UserExists(string userName)
    {
        return PlayerPrefs.HasKey($"PWD_{userName}");
    }
    
    public void Logout()
    {
        string currentUser = GetCurrentUser();
        sessionManager.EndSession();
        
        OnUserLoggedOut?.Invoke();
        Debug.Log($"[WorkingPasswordAuthService] User '{currentUser}' logged out");
    }
    
    public bool IsUserLoggedIn()
    {
        return sessionManager.HasActiveSession;
    }
    
    public string GetCurrentUser()
    {
        return sessionManager.CurrentUsername ?? "";
    }

    // Método de hash simple pero funcional
    private string HashPassword(string password)
    {
        try
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password + "UNITY_SALT_2024"));
                return Convert.ToBase64String(hashedBytes);
            }
        }
        catch
        {
            // Fallback simple
            return (password + "SIMPLE_HASH").GetHashCode().ToString();
        }
    }

    // Métodos de administración
    public int GetUserCount()
    {
        int count = 0;
        // Contar usuarios registrados (aproximación simple)
        for (int i = 0; i < 100; i++)
        {
            if (PlayerPrefs.HasKey($"PWD_user{i}") || 
                PlayerPrefs.HasKey($"PWD_test{i}") ||
                PlayerPrefs.HasKey($"PWD_player{i}"))
                count++;
        }
        
        // Usuarios por defecto
        if (PlayerPrefs.HasKey("PWD_admin")) count++;
        if (PlayerPrefs.HasKey("PWD_player")) count++;
        if (PlayerPrefs.HasKey("PWD_test")) count++;
        
        return count;
    }

    public void CreateDefaultUsers()
    {
        CreateUserInternal("admin", "1234");
        CreateUserInternal("player", "game");
        CreateUserInternal("test", "test");
        
        Debug.Log("[WorkingPasswordAuthService] Default users created");
    }

    private void CreateUserInternal(string userName, string password)
    {
        string userKey = $"PWD_{userName}";
        if (!PlayerPrefs.HasKey(userKey))
        {
            PlayerPrefs.SetString(userKey, HashPassword(password));
            PlayerPrefs.SetString($"CREATED_{userName}", DateTime.Now.ToString());
        }
    }

    public void ClearAllUsers()
    {
        // Limpiar usuarios conocidos
        string[] commonUsers = { "admin", "player", "test", "user", "guest" };
        foreach (string user in commonUsers)
        {
            PlayerPrefs.DeleteKey($"PWD_{user}");
            PlayerPrefs.DeleteKey($"CREATED_{user}");
            PlayerPrefs.DeleteKey($"LAST_{user}");
        }
        
        // Limpiar usuarios numerados
        for (int i = 0; i < 100; i++)
        {
            PlayerPrefs.DeleteKey($"PWD_user{i}");
            PlayerPrefs.DeleteKey($"PWD_test{i}");
            PlayerPrefs.DeleteKey($"PWD_player{i}");
            PlayerPrefs.DeleteKey($"CREATED_user{i}");
            PlayerPrefs.DeleteKey($"CREATED_test{i}");
            PlayerPrefs.DeleteKey($"CREATED_player{i}");
        }
        
        PlayerPrefs.Save();
        Debug.Log("[WorkingPasswordAuthService] All users cleared");
    }
}