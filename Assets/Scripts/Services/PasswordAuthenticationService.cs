using System;
using UnityEngine;

/// <summary>
/// Servicio de autenticación con contraseñas aplicando principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo lógica de autenticación
/// Principio: Dependency Inversion Principle (DIP) - Depende de interfaces
/// Patrón: Observer Pattern - Notifica cambios de estado
/// </summary>
public class PasswordAuthenticationService : IAuthenticationService
{
    private ISessionManager sessionManager;
    private IUserInputValidator validator;
    private IPasswordValidator passwordValidator;
    private IPasswordHasher passwordHasher;
    private PlayerPrefsUserRepository userRepository;
    
    public event Action<string> OnUserLoggedIn;
    public event Action OnUserLoggedOut;
    public event Action<string> OnUserRegistered;
    public event Action<string> OnPasswordChanged;
    public event Action<string> OnAuthenticationFailed;
    
    private const int MAX_LOGIN_ATTEMPTS = 5;
    private const int LOCKOUT_TIME_MINUTES = 15;
    
    public PasswordAuthenticationService(
        ISessionManager sessionManager, 
        IUserInputValidator validator)
    {
        this.sessionManager = sessionManager ?? throw new ArgumentNullException(nameof(sessionManager));
        this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        
        // Crear implementaciones por defecto
        this.passwordValidator = new PasswordValidator(minLength: 4, maxLength: 20, requireNumbers: true);
        this.passwordHasher = new SimplePasswordHasher();
        this.userRepository = new PlayerPrefsUserRepository();
        
        Debug.Log("[PasswordAuthenticationService] Initialized with password support");
    }
    
    // Método legacy para compatibilidad (modo invitado)
    public bool Login(string userName)
    {
        if (!validator.IsValidUserName(userName))
        {
            Debug.LogWarning($"[PasswordAuthenticationService] Invalid username: {validator.GetValidationError(userName)}");
            OnAuthenticationFailed?.Invoke($"Usuario inválido: {validator.GetValidationError(userName)}");
            return false;
        }

        try
        {
            // Login en modo invitado (sin contraseña)
            sessionManager.StartSession(userName);
            DataManagerComposer.CurrentUsername = userName;
            
            OnUserLoggedIn?.Invoke(userName);
            Debug.Log($"[PasswordAuthenticationService] Guest user '{userName}' logged in successfully");
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PasswordAuthenticationService] Login failed: {ex.Message}");
            OnAuthenticationFailed?.Invoke($"Error de autenticación: {ex.Message}");
            return false;
        }
    }

    public bool Login(string userName, string password)
    {
        if (!validator.IsValidUserName(userName))
        {
            Debug.LogWarning($"[PasswordAuthenticationService] Invalid username: {validator.GetValidationError(userName)}");
            OnAuthenticationFailed?.Invoke($"Usuario inválido: {validator.GetValidationError(userName)}");
            return false;
        }

        if (!passwordValidator.IsValidPassword(password))
        {
            Debug.LogWarning($"[PasswordAuthenticationService] Invalid password format");
            OnAuthenticationFailed?.Invoke("Formato de contraseña inválido");
            return false;
        }

        try
        {
            // Verificar si el usuario existe
            UserCredentials user = userRepository.GetUser(userName);
            if (user == null)
            {
                Debug.LogWarning($"[PasswordAuthenticationService] User '{userName}' not found");
                OnAuthenticationFailed?.Invoke("Usuario no encontrado");
                return false;
            }

            // Verificar si la cuenta está bloqueada
            if (IsAccountLocked(user))
            {
                Debug.LogWarning($"[PasswordAuthenticationService] Account '{userName}' is locked");
                OnAuthenticationFailed?.Invoke("Cuenta bloqueada por intentos fallidos");
                return false;
            }

            // Verificar contraseña
            if (!passwordHasher.VerifyPassword(password, user.HashedPassword))
            {
                HandleFailedLogin(user);
                Debug.LogWarning($"[PasswordAuthenticationService] Invalid password for user '{userName}'");
                OnAuthenticationFailed?.Invoke("Contraseña incorrecta");
                return false;
            }

            // Login exitoso
            ResetLoginAttempts(user);
            user.LastLoginDate = DateTime.Now;
            userRepository.UpdateUser(user);

            sessionManager.StartSession(userName);
            DataManagerComposer.CurrentUsername = userName;
            
            OnUserLoggedIn?.Invoke(userName);
            Debug.Log($"[PasswordAuthenticationService] User '{userName}' logged in successfully with password");
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PasswordAuthenticationService] Login failed: {ex.Message}");
            OnAuthenticationFailed?.Invoke($"Error de autenticación: {ex.Message}");
            return false;
        }
    }

    public bool Register(string userName, string password, string confirmPassword)
    {
        if (!validator.IsValidUserName(userName))
        {
            Debug.LogWarning($"[PasswordAuthenticationService] Invalid username: {validator.GetValidationError(userName)}");
            OnAuthenticationFailed?.Invoke($"Usuario inválido: {validator.GetValidationError(userName)}");
            return false;
        }

        if (!passwordValidator.IsValidPassword(password))
        {
            string error = passwordValidator.GetPasswordValidationError(password);
            Debug.LogWarning($"[PasswordAuthenticationService] Invalid password: {error}");
            OnAuthenticationFailed?.Invoke(error);
            return false;
        }

        if (!passwordValidator.PasswordsMatch(password, confirmPassword))
        {
            Debug.LogWarning($"[PasswordAuthenticationService] Passwords do not match");
            OnAuthenticationFailed?.Invoke("Las contraseñas no coinciden");
            return false;
        }

        if (userRepository.UserExists(userName))
        {
            Debug.LogWarning($"[PasswordAuthenticationService] User '{userName}' already exists");
            OnAuthenticationFailed?.Invoke("El usuario ya existe");
            return false;
        }

        try
        {
            // Crear nuevo usuario
            string hashedPassword = passwordHasher.HashPassword(password);
            UserCredentials newUser = new UserCredentials(userName, hashedPassword);
            
            userRepository.SaveUser(newUser);
            OnUserRegistered?.Invoke(userName);
            
            Debug.Log($"[PasswordAuthenticationService] User '{userName}' registered successfully");
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PasswordAuthenticationService] Registration failed: {ex.Message}");
            OnAuthenticationFailed?.Invoke($"Error en el registro: {ex.Message}");
            return false;
        }
    }

    public bool ChangePassword(string userName, string oldPassword, string newPassword)
    {
        if (!IsUserLoggedIn() || GetCurrentUser() != userName)
        {
            Debug.LogWarning($"[PasswordAuthenticationService] User must be logged in to change password");
            OnAuthenticationFailed?.Invoke("Debe iniciar sesión para cambiar la contraseña");
            return false;
        }

        if (!passwordValidator.IsValidPassword(newPassword))
        {
            string error = passwordValidator.GetPasswordValidationError(newPassword);
            Debug.LogWarning($"[PasswordAuthenticationService] Invalid new password: {error}");
            OnAuthenticationFailed?.Invoke(error);
            return false;
        }

        try
        {
            UserCredentials user = userRepository.GetUser(userName);
            if (user == null)
            {
                OnAuthenticationFailed?.Invoke("Usuario no encontrado");
                return false;
            }

            if (!passwordHasher.VerifyPassword(oldPassword, user.HashedPassword))
            {
                OnAuthenticationFailed?.Invoke("Contraseña actual incorrecta");
                return false;
            }

            user.HashedPassword = passwordHasher.HashPassword(newPassword);
            userRepository.UpdateUser(user);
            
            OnPasswordChanged?.Invoke(userName);
            Debug.Log($"[PasswordAuthenticationService] Password changed for user '{userName}'");
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PasswordAuthenticationService] Password change failed: {ex.Message}");
            OnAuthenticationFailed?.Invoke($"Error al cambiar contraseña: {ex.Message}");
            return false;
        }
    }

    public bool UserExists(string userName)
    {
        return userRepository.UserExists(userName);
    }
    
    public void Logout()
    {
        string currentUser = GetCurrentUser();
        sessionManager.EndSession();
        
        Debug.Log($"[PasswordAuthenticationService] User '{currentUser}' logged out");
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

    // Métodos auxiliares privados
    private bool IsAccountLocked(UserCredentials user)
    {
        if (user.LoginAttempts < MAX_LOGIN_ATTEMPTS)
            return false;

        TimeSpan timeSinceLastAttempt = DateTime.Now - user.LastAttemptDate;
        return timeSinceLastAttempt.TotalMinutes < LOCKOUT_TIME_MINUTES;
    }

    private void HandleFailedLogin(UserCredentials user)
    {
        user.LoginAttempts++;
        user.LastAttemptDate = DateTime.Now;
        userRepository.UpdateUser(user);
        
        if (user.LoginAttempts >= MAX_LOGIN_ATTEMPTS)
        {
            Debug.LogWarning($"[PasswordAuthenticationService] Account '{user.UserName}' locked due to failed attempts");
        }
    }

    private void ResetLoginAttempts(UserCredentials user)
    {
        user.LoginAttempts = 0;
        user.LastAttemptDate = DateTime.MinValue;
        userRepository.UpdateUser(user);
    }

    // Métodos adicionales para administración
    public void UnlockUser(string userName)
    {
        try
        {
            UserCredentials user = userRepository.GetUser(userName);
            if (user != null)
            {
                ResetLoginAttempts(user);
                Debug.Log($"[PasswordAuthenticationService] User '{userName}' unlocked");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PasswordAuthenticationService] Error unlocking user: {ex.Message}");
        }
    }

    public int GetLoginAttempts(string userName)
    {
        try
        {
            UserCredentials user = userRepository.GetUser(userName);
            return user?.LoginAttempts ?? 0;
        }
        catch
        {
            return 0;
        }
    }

    public bool IsUserLocked(string userName)
    {
        try
        {
            UserCredentials user = userRepository.GetUser(userName);
            return user != null && IsAccountLocked(user);
        }
        catch
        {
            return false;
        }
    }
}