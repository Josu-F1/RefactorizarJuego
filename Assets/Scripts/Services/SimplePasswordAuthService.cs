using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Servicio simple de autenticación con contraseñas
/// Principio: Single Responsibility Principle (SRP) - Solo maneja autenticación
/// Principio: Dependency Inversion Principle (DIP) - Usa interfaces
/// Patrón: Observer Pattern - Notifica eventos de autenticación
/// </summary>
public class SimplePasswordAuthService : IAuthenticationService
{
    private ISessionManager sessionManager;
    private IUserInputValidator validator;
    private Dictionary<string, string> userDatabase; // Usuario -> Contraseña (simple)
    
    public event Action<string> OnUserLoggedIn;
    public event Action OnUserLoggedOut;
    public event Action<string> OnUserRegistered;
    public event Action<string> OnPasswordChanged;
    public event Action<string> OnAuthenticationFailed;
    
    public SimplePasswordAuthService(ISessionManager sessionManager, IUserInputValidator validator)
    {
        this.sessionManager = sessionManager ?? throw new ArgumentNullException(nameof(sessionManager));
        this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        
        userDatabase = new Dictionary<string, string>();
        LoadUserDatabase();
        
        Debug.Log("[SimplePasswordAuthService] Sistema de autenticación con contraseña inicializado");
    }
    
    // Método legacy para compatibilidad (modo invitado)
    public bool Login(string userName)
    {
        if (!validator.IsValidUserName(userName))
        {
            string error = $"Usuario inválido: {validator.GetValidationError(userName)}";
            Debug.LogWarning($"[SimplePasswordAuthService] {error}");
            OnAuthenticationFailed?.Invoke(error);
            return false;
        }

        try
        {
            sessionManager.StartSession(userName);
            DataManagerComposer.CurrentUsername = userName;
            
            OnUserLoggedIn?.Invoke(userName);
            Debug.Log($"[SimplePasswordAuthService] Guest user '{userName}' logged in successfully");
            return true;
        }
        catch (Exception ex)
        {
            string error = $"Error de autenticación: {ex.Message}";
            Debug.LogError($"[SimplePasswordAuthService] {error}");
            OnAuthenticationFailed?.Invoke(error);
            return false;
        }
    }

    public bool Login(string userName, string password)
    {
        if (!validator.IsValidUserName(userName))
        {
            string error = $"Usuario inválido: {validator.GetValidationError(userName)}";
            Debug.LogWarning($"[SimplePasswordAuthService] {error}");
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
            // Verificar credenciales
            if (!userDatabase.ContainsKey(userName.ToLower()))
            {
                OnAuthenticationFailed?.Invoke("Usuario no encontrado");
                return false;
            }

            if (userDatabase[userName.ToLower()] != password)
            {
                OnAuthenticationFailed?.Invoke("Contraseña incorrecta");
                return false;
            }

            // Login exitoso
            sessionManager.StartSession(userName);
            DataManagerComposer.CurrentUsername = userName;
            
            OnUserLoggedIn?.Invoke(userName);
            Debug.Log($"[SimplePasswordAuthService] User '{userName}' logged in successfully with password");
            return true;
        }
        catch (Exception ex)
        {
            string error = $"Error de autenticación: {ex.Message}";
            Debug.LogError($"[SimplePasswordAuthService] {error}");
            OnAuthenticationFailed?.Invoke(error);
            return false;
        }
    }

    public bool Register(string userName, string password, string confirmPassword)
    {
        if (!validator.IsValidUserName(userName))
        {
            string error = $"Usuario inválido: {validator.GetValidationError(userName)}";
            Debug.LogWarning($"[SimplePasswordAuthService] {error}");
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

        if (userDatabase.ContainsKey(userName.ToLower()))
        {
            OnAuthenticationFailed?.Invoke("El usuario ya existe");
            return false;
        }

        try
        {
            // Registrar usuario
            userDatabase[userName.ToLower()] = password;
            SaveUserDatabase();
            
            OnUserRegistered?.Invoke(userName);
            Debug.Log($"[SimplePasswordAuthService] User '{userName}' registered successfully");
            return true;
        }
        catch (Exception ex)
        {
            string error = $"Error en el registro: {ex.Message}";
            Debug.LogError($"[SimplePasswordAuthService] {error}");
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

        if (!userDatabase.ContainsKey(userName.ToLower()))
        {
            OnAuthenticationFailed?.Invoke("Usuario no encontrado");
            return false;
        }

        if (userDatabase[userName.ToLower()] != oldPassword)
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
            userDatabase[userName.ToLower()] = newPassword;
            SaveUserDatabase();
            
            OnPasswordChanged?.Invoke(userName);
            Debug.Log($"[SimplePasswordAuthService] Password changed for user '{userName}'");
            return true;
        }
        catch (Exception ex)
        {
            string error = $"Error al cambiar contraseña: {ex.Message}";
            Debug.LogError($"[SimplePasswordAuthService] {error}");
            OnAuthenticationFailed?.Invoke(error);
            return false;
        }
    }

    public bool UserExists(string userName)
    {
        return userDatabase.ContainsKey(userName.ToLower());
    }
    
    public void Logout()
    {
        string currentUser = GetCurrentUser();
        sessionManager.EndSession();
        
        OnUserLoggedOut?.Invoke();
        Debug.Log($"[SimplePasswordAuthService] User '{currentUser}' logged out");
    }
    
    public bool IsUserLoggedIn()
    {
        return sessionManager.HasActiveSession;
    }
    
    public string GetCurrentUser()
    {
        return sessionManager.CurrentUsername ?? "";
    }

    // Métodos auxiliares
    private void LoadUserDatabase()
    {
        try
        {
            string userListJson = PlayerPrefs.GetString("SimpleUserDB", "");
            if (!string.IsNullOrEmpty(userListJson))
            {
                SimpleUserDatabase db = JsonUtility.FromJson<SimpleUserDatabase>(userListJson);
                if (db?.users != null)
                {
                    userDatabase.Clear();
                    foreach (var user in db.users)
                    {
                        userDatabase[user.username.ToLower()] = user.password;
                    }
                    Debug.Log($"[SimplePasswordAuthService] Loaded {userDatabase.Count} users from database");
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"[SimplePasswordAuthService] Error loading user database: {ex.Message}");
        }
    }

    private void SaveUserDatabase()
    {
        try
        {
            SimpleUserDatabase db = new SimpleUserDatabase();
            db.users = new List<SimpleUserData>();
            
            foreach (var kvp in userDatabase)
            {
                db.users.Add(new SimpleUserData 
                { 
                    username = kvp.Key, 
                    password = kvp.Value 
                });
            }
            
            string json = JsonUtility.ToJson(db);
            PlayerPrefs.SetString("SimpleUserDB", json);
            PlayerPrefs.Save();
            
            Debug.Log($"[SimplePasswordAuthService] Saved {userDatabase.Count} users to database");
        }
        catch (Exception ex)
        {
            Debug.LogError($"[SimplePasswordAuthService] Error saving user database: {ex.Message}");
        }
    }

    // Métodos de administración
    public int GetUserCount()
    {
        return userDatabase.Count;
    }

    public void ClearAllUsers()
    {
        userDatabase.Clear();
        PlayerPrefs.DeleteKey("SimpleUserDB");
        PlayerPrefs.Save();
        Debug.Log("[SimplePasswordAuthService] All users cleared");
    }

    public bool DeleteUser(string userName)
    {
        if (userDatabase.Remove(userName.ToLower()))
        {
            SaveUserDatabase();
            Debug.Log($"[SimplePasswordAuthService] User '{userName}' deleted");
            return true;
        }
        return false;
    }
}

/// <summary>
/// Clases de datos para la persistencia simple
/// </summary>
[System.Serializable]
public class SimpleUserDatabase
{
    public List<SimpleUserData> users = new List<SimpleUserData>();
}

[System.Serializable]
public class SimpleUserData
{
    public string username;
    public string password;
}