using UnityEngine;

/// <summary>
/// Composer que integra el sistema de login refactorizado
/// Patrón: Facade Pattern - Simplifica el acceso a múltiples subsistemas
/// Principio: Dependency Inversion Principle (DIP) - Usa interfaces
/// Principio: Single Responsibility Principle (SRP) - Solo coordina componentes
/// </summary>
public class LoginSystemComposer : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private GameObject progressPanel;
    [SerializeField] private LoginPanelUI loginPanelUI;
    [SerializeField] private ProgressDisplayComposer progressDisplay;
    
    // Sistemas SOLID
    private IAuthenticationService authService;
    private ISessionManager sessionManager;
    private IUserInputValidator validator;
    private UINavigator uiNavigator;
    
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
        // Crear dependencias (aplicando DIP)
        sessionManager = new SessionManager();
        validator = new UserInputValidator(minLength: 2, maxLength: 15, allowSpaces: false);
        authService = new AuthenticationService(sessionManager, validator);
        uiNavigator = new UINavigator();
        
        // Registrar paneles en el navegador
        if (loginPanel != null)
            uiNavigator.RegisterPanel("login", loginPanel);
        if (progressPanel != null)
            uiNavigator.RegisterPanel("progress", progressPanel);
        
        Debug.Log("[LoginSystemComposer] Sistema de autenticación inicializado");
    }
    
    private void SetupUI()
    {
        // Inicializar UI con servicios
        if (loginPanelUI != null)
        {
            loginPanelUI.Initialize(authService, validator);
            loginPanelUI.OnLoginAttempt += HandleLoginAttempt;
        }
        
        // Configurar eventos de autenticación
        if (authService != null)
        {
            authService.OnUserLoggedIn += OnUserLoggedIn;
            authService.OnUserLoggedOut += OnUserLoggedOut;
        }
        
        // Estado inicial
        ShowLoginPanel();
    }
    
    private void HandleLoginAttempt(string userName)
    {
        Debug.Log($"[LoginSystemComposer] Attempting login for: {userName}");
        
        bool success = authService.Login(userName);
        if (!success)
        {
            Debug.LogWarning($"[LoginSystemComposer] Login failed for: {userName}");
        }
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
        ShowLoginPanel();
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
    
    void OnDestroy()
    {
        if (loginPanelUI != null)
        {
            loginPanelUI.OnLoginAttempt -= HandleLoginAttempt;
        }
        
        if (authService != null)
        {
            authService.OnUserLoggedIn -= OnUserLoggedIn;
            authService.OnUserLoggedOut -= OnUserLoggedOut;
        }
    }
}