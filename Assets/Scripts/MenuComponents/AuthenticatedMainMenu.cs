using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Menú principal integrado con sistema de autenticación
/// Principio: Single Responsibility Principle (SRP) - Maneja solo la interfaz del menú principal con autenticación
/// Principio: Observer Pattern - Escucha eventos del sistema de autenticación
/// Principio: Dependency Inversion Principle (DIP) - Depende de abstracciones
/// </summary>
public class AuthenticatedMainMenu : MonoBehaviour
{
    [Header("Menu Panels")]
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private GameObject registerPanel;
    [SerializeField] private GameObject mainMenuPanel;
    
    [Header("Main Menu Components")]
    [SerializeField] private TextMeshProUGUI welcomeText;
    [SerializeField] private Button playButton;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private Button helpButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button logoutButton;
    [SerializeField] private Button showRegisterButton;
    [SerializeField] private Button showLoginButton;
    
    [Header("Authentication Components")]
    [SerializeField] private PasswordLoginComponent passwordLogin;
    [SerializeField] private UserRegistrationUI userRegistration;
    
    private IAuthenticationService authService;
    private ISessionManager sessionManager;
    
    void Start()
    {
        InitializeServices();
        SetupEventListeners();
        UpdateMenuState();
    }
    
    void OnDestroy()
    {
        CleanupEventListeners();
    }
    
    private void InitializeServices()
    {
        // Crear instancias de los servicios con dependencias
        sessionManager = new SessionManager();
        var validator = new UserInputValidator();
        authService = new WorkingPasswordAuthService(sessionManager, validator);
        
        Debug.Log("[AuthenticatedMainMenu] Services initialized successfully");
    }
    
    private void SetupEventListeners()
    {
        // Botones del menú principal
        if (playButton != null) playButton.onClick.AddListener(OnPlayClicked);
        if (tutorialButton != null) tutorialButton.onClick.AddListener(OnTutorialClicked);
        if (helpButton != null) helpButton.onClick.AddListener(OnHelpClicked);
        if (quitButton != null) quitButton.onClick.AddListener(OnQuitClicked);
        if (logoutButton != null) logoutButton.onClick.AddListener(OnLogoutClicked);
        
        // Botones de navegación entre paneles
        if (showRegisterButton != null) showRegisterButton.onClick.AddListener(ShowRegisterPanel);
        if (showLoginButton != null) showLoginButton.onClick.AddListener(ShowLoginPanel);
        
        // Eventos del sistema de autenticación
        if (authService != null)
        {
            authService.OnUserLoggedIn += OnAuthenticationSuccess;
            authService.OnAuthenticationFailed += OnAuthenticationFailed;
            authService.OnUserRegistered += OnRegistrationSuccess;
        }
    }
    
    private void CleanupEventListeners()
    {
        if (authService != null)
        {
            authService.OnUserLoggedIn -= OnAuthenticationSuccess;
            authService.OnAuthenticationFailed -= OnAuthenticationFailed;
            authService.OnUserRegistered -= OnRegistrationSuccess;
        }
    }
    
    private void UpdateMenuState()
    {
        bool hasActiveSession = sessionManager != null && sessionManager.HasActiveSession;
        
        if (hasActiveSession)
        {
            ShowMainMenu();
            if (welcomeText != null && sessionManager != null)
            {
                welcomeText.text = $"¡Bienvenido, {sessionManager.CurrentUsername}!";
            }
        }
        else
        {
            ShowLoginPanel();
        }
    }
    
    private void ShowLoginPanel()
    {
        SetPanelVisibility(loginPanel, true);
        SetPanelVisibility(registerPanel, false);
        SetPanelVisibility(mainMenuPanel, false);
    }
    
    private void ShowRegisterPanel()
    {
        SetPanelVisibility(loginPanel, false);
        SetPanelVisibility(registerPanel, true);
        SetPanelVisibility(mainMenuPanel, false);
    }
    
    private void ShowMainMenu()
    {
        SetPanelVisibility(loginPanel, false);
        SetPanelVisibility(registerPanel, false);
        SetPanelVisibility(mainMenuPanel, true);
    }
    
    private void SetPanelVisibility(GameObject panel, bool visible)
    {
        if (panel != null)
        {
            panel.SetActive(visible);
        }
    }
    
    // Event Handlers - Authentication
    private void OnAuthenticationSuccess(string username)
    {
        Debug.Log($"[AuthenticatedMainMenu] Login successful for user: {username}");
        ShowMainMenu();
        if (welcomeText != null)
        {
            welcomeText.text = $"¡Bienvenido, {username}!";
        }
    }
    
    private void OnAuthenticationFailed(string error)
    {
        Debug.LogWarning($"[AuthenticatedMainMenu] Authentication failed: {error}");
        // Mantener en panel de login
        ShowLoginPanel();
    }
    
    private void OnRegistrationSuccess(string username)
    {
        Debug.Log($"[AuthenticatedMainMenu] Registration successful for user: {username}");
        ShowMainMenu();
        if (welcomeText != null)
        {
            welcomeText.text = $"¡Bienvenido, {username}!";
        }
    }
    
    // Event Handlers - Main Menu Actions
    private void OnPlayClicked()
    {
        if (sessionManager != null && sessionManager.HasActiveSession)
        {
            Debug.Log("[AuthenticatedMainMenu] Starting game...");
            // Aquí cargarías la escena del juego
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameLevel");
        }
        else
        {
            Debug.LogWarning("[AuthenticatedMainMenu] Cannot start game - no active session");
            ShowLoginPanel();
        }
    }
    
    private void OnTutorialClicked()
    {
        Debug.Log("[AuthenticatedMainMenu] Opening tutorial...");
        // Aquí cargarías la escena del tutorial o mostrarías el panel de tutorial
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
    }
    
    private void OnHelpClicked()
    {
        Debug.Log("[AuthenticatedMainMenu] Opening help...");
        // Aquí mostrarías un panel de ayuda o cargarías una escena de ayuda
        // Por ejemplo: HelpPanel.SetActive(true);
    }
    
    private void OnQuitClicked()
    {
        Debug.Log("[AuthenticatedMainMenu] Quitting game...");
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    
    private void OnLogoutClicked()
    {
        Debug.Log("[AuthenticatedMainMenu] Logging out...");
        
        if (sessionManager != null)
        {
            sessionManager.EndSession();
        }
        
        if (welcomeText != null)
        {
            welcomeText.text = "";
        }
        
        ShowLoginPanel();
    }
}