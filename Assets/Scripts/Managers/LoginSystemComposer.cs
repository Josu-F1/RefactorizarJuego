using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// Composer que integra el sistema de login con contraseña refactorizado
/// Patrón: Facade Pattern - Simplifica el acceso a múltiples subsistemas
/// Principio: Dependency Inversion Principle (DIP) - Usa interfaces
/// Principio: Single Responsibility Principle (SRP) - Solo coordina componentes
/// </summary>
public class LoginSystemComposer : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private GameObject progressPanel;
    [SerializeField] private SimplePasswordLoginUI passwordLoginUI;
    [SerializeField] private ProgressDisplayComposer progressDisplay;
    
    [Header("Input Fields - Fallback")]
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private Button loginButton;
    [SerializeField] private Button registerButton;
    [SerializeField] private Button guestButton;
    [SerializeField] private TextMeshProUGUI statusText;
    
    [Header("Configuration")]
    [SerializeField] private bool usePasswordAuthentication = true;
    [SerializeField] private bool allowGuestMode = true;
    
    // Sistemas SOLID
    private IAuthenticationService authService;
    private ISessionManager sessionManager;
    private IUserInputValidator validator;
    private UINavigator uiNavigator;
    
    // Estado
    private bool isInitialized = false;
    
    void Awake()
    {
        InitializeSystem();
    }
    
    void Start()
    {
        SetupUI();
    }
    
    private void InitializeSystem()
    {
        if (isInitialized) return;
        
        try
        {
            // Crear dependencias (aplicando DIP)
            sessionManager = new SessionManager();
            validator = new UserInputValidator(minLength: 2, maxLength: 15, allowSpaces: false);
            
            // Elegir el tipo de servicio de autenticación
            if (usePasswordAuthentication)
            {
                authService = CreatePasswordAuthenticationService();
                Debug.Log("[LoginSystemComposer] Using Password Authentication");
            }
            else
            {
                authService = new AuthenticationService(sessionManager, validator);
                Debug.Log("[LoginSystemComposer] Using Simple Authentication");
            }
            
            uiNavigator = new UINavigator();
            
            // Registrar paneles en el navegador
            if (loginPanel != null)
                uiNavigator.RegisterPanel("login", loginPanel);
            if (progressPanel != null)
                uiNavigator.RegisterPanel("progress", progressPanel);
            
            isInitialized = true;
            Debug.Log("[LoginSystemComposer] Sistema de autenticación con contraseña inicializado");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"[LoginSystemComposer] Error initializing system: {ex.Message}");
        }
    }
    
    private IAuthenticationService CreatePasswordAuthenticationService()
    {
        // Crear servicio de autenticación con contraseña funcional
        var authService = new WorkingPasswordAuthService(sessionManager, validator);
        
        // Crear usuarios por defecto si no existen
        if (!PlayerPrefs.HasKey("PWD_admin"))
        {
            authService.CreateDefaultUsers();
            Debug.Log("[LoginSystemComposer] Default users created: admin/1234, player/game, test/test");
        }
        
        return authService;
    }
    
    private void SetupUI()
    {
        if (!isInitialized)
        {
            Debug.LogWarning("[LoginSystemComposer] System not initialized yet");
            return;
        }
        
        // Inicializar UI con servicios
        if (passwordLoginUI != null)
        {
            passwordLoginUI.Initialize(authService);
        }
        else
        {
            // Fallback a controles individuales
            SetupFallbackUI();
        }
        
        // Configurar eventos de autenticación
        if (authService != null)
        {
            authService.OnUserLoggedIn += OnUserLoggedIn;
            authService.OnUserLoggedOut += OnUserLoggedOut;
            
            // Eventos adicionales para autenticación con contraseña
            if (authService is IAuthenticationService passwordAuth)
            {
                passwordAuth.OnUserRegistered += OnUserRegistered;
                passwordAuth.OnAuthenticationFailed += OnAuthenticationFailed;
            }
        }
        
        // Estado inicial
        ShowLoginPanel();
    }
    
    private void SetupFallbackUI()
    {
        // Configurar botones individuales si no hay PasswordLoginUI
        if (loginButton != null)
            loginButton.onClick.AddListener(() => OnDirectLogin());
        if (registerButton != null)
            registerButton.onClick.AddListener(() => OnDirectRegister());
        if (guestButton != null)
        {
            guestButton.onClick.AddListener(() => OnDirectGuestLogin());
            guestButton.gameObject.SetActive(allowGuestMode);
        }
        
        // Configurar placeholders
        if (usernameInput != null && usernameInput.placeholder != null)
        {
            ((TextMeshProUGUI)usernameInput.placeholder).text = "Usuario...";
        }
        if (passwordInput != null)
        {
            passwordInput.contentType = TMP_InputField.ContentType.Password;
            if (passwordInput.placeholder != null)
            {
                ((TextMeshProUGUI)passwordInput.placeholder).text = "Contraseña...";
            }
        }
    }
    
    private void OnDirectLogin()
    {
        if (authService == null || usernameInput == null || passwordInput == null)
        {
            ShowStatus("Sistema no configurado correctamente", Color.red);
            return;
        }
        
        string username = usernameInput.text.Trim();
        string password = passwordInput.text;
        
        if (string.IsNullOrEmpty(username))
        {
            ShowStatus("Ingresa tu usuario", Color.yellow);
            return;
        }
        
        if (string.IsNullOrEmpty(password))
        {
            ShowStatus("Ingresa tu contraseña", Color.yellow);
            return;
        }
        
        // Intentar login con contraseña
        if (authService is WorkingPasswordAuthService passwordAuth)
        {
            bool success = passwordAuth.Login(username, password);
            if (!success)
            {
                ShowStatus("Credenciales incorrectas", Color.red);
            }
        }
        else
        {
            // Fallback a login simple
            bool success = authService.Login(username);
            if (!success)
            {
                ShowStatus("Error de autenticación", Color.red);
            }
        }
    }
    
    private void OnDirectRegister()
    {
        if (authService == null || usernameInput == null || passwordInput == null)
        {
            ShowStatus("Sistema no configurado correctamente", Color.red);
            return;
        }
        
        string username = usernameInput.text.Trim();
        string password = passwordInput.text;
        
        if (string.IsNullOrEmpty(username))
        {
            ShowStatus("Ingresa un usuario", Color.yellow);
            return;
        }
        
        if (string.IsNullOrEmpty(password))
        {
            ShowStatus("Ingresa una contraseña", Color.yellow);
            return;
        }
        
        // Intentar registro
        if (authService is WorkingPasswordAuthService passwordAuth)
        {
            bool success = passwordAuth.Register(username, password, password);
            if (!success)
            {
                ShowStatus("Error en el registro", Color.red);
            }
        }
        else
        {
            ShowStatus("Registro no disponible", Color.red);
        }
    }
    
    private void OnDirectGuestLogin()
    {
        if (authService == null || usernameInput == null)
        {
            ShowStatus("Sistema no configurado correctamente", Color.red);
            return;
        }
        
        string username = usernameInput.text.Trim();
        
        if (string.IsNullOrEmpty(username))
        {
            ShowStatus("Ingresa un nombre de usuario", Color.yellow);
            return;
        }
        
        bool success = authService.Login(username);
        if (!success)
        {
            ShowStatus("Error en modo invitado", Color.red);
        }
    }
    
    private void ShowStatus(string message, Color color)
    {
        if (statusText != null)
        {
            statusText.text = message;
            statusText.color = color;
        }
        Debug.Log($"[LoginSystemComposer] Status: {message}");
    }
    
    private void OnUserLoggedIn(string userName)
    {
        Debug.Log($"[LoginSystemComposer] User logged in: {userName}");
        
        // Cambiar a panel de progreso
        uiNavigator.HidePanel("login");
        uiNavigator.ShowPanel("progress");
        
        // Cargar progreso del usuario en el sistema refactorizado
        if (progressDisplay != null)
        {
            progressDisplay.LoadUser(userName);
        }
    }
    
    private void OnUserLoggedOut()
    {
        Debug.Log("[LoginSystemComposer] User logged out");
        ClearInputs();
        ShowStatus("Sesión cerrada", Color.white);
        ShowLoginPanel();
    }
    
    private void OnUserRegistered(string userName)
    {
        Debug.Log($"[LoginSystemComposer] User registered: {userName}");
        ShowStatus($"Usuario '{userName}' registrado exitosamente", Color.green);
        ClearInputs();
    }
    
    private void OnAuthenticationFailed(string error)
    {
        Debug.LogWarning($"[LoginSystemComposer] Authentication failed: {error}");
        ShowStatus(error, Color.red);
    }
    
    private void ClearInputs()
    {
        if (usernameInput != null)
            usernameInput.text = "";
        if (passwordInput != null)
            passwordInput.text = "";
    }
    
    private void ShowLoginPanel()
    {
        uiNavigator.HidePanel("progress");
        uiNavigator.ShowPanel("login");
    }
    
    // Métodos públicos para compatibilidad
    public void Logout()
    {
        authService?.Logout();
    }
    
    public bool IsLoggedIn()
    {
        return authService?.IsUserLoggedIn() ?? false;
    }
    
    public string GetCurrentUser()
    {
        return authService?.GetCurrentUser() ?? "";
    }
    
    // Métodos públicos adicionales
    public void TogglePasswordMode()
    {
        usePasswordAuthentication = !usePasswordAuthentication;
        
        // Reinicializar sistema
        isInitialized = false;
        InitializeSystem();
        SetupUI();
        
        Debug.Log($"[LoginSystemComposer] Password authentication: {usePasswordAuthentication}");
    }
    
    public void SetGuestModeEnabled(bool enabled)
    {
        allowGuestMode = enabled;
        if (guestButton != null)
        {
            guestButton.gameObject.SetActive(enabled);
        }
        if (passwordLoginUI != null)
        {
            passwordLoginUI.SetGuestModeEnabled(enabled);
        }
    }
    
    void OnDestroy()
    {
        if (authService != null)
        {
            authService.OnUserLoggedIn -= OnUserLoggedIn;
            authService.OnUserLoggedOut -= OnUserLoggedOut;
            
            if (authService is WorkingPasswordAuthService passwordAuth)
            {
                passwordAuth.OnUserRegistered -= OnUserRegistered;
                passwordAuth.OnAuthenticationFailed -= OnAuthenticationFailed;
            }
        }
        
        // Limpiar botones
        if (loginButton != null)
            loginButton.onClick.RemoveAllListeners();
        if (registerButton != null)
            registerButton.onClick.RemoveAllListeners();
        if (guestButton != null)
            guestButton.onClick.RemoveAllListeners();
    }
}