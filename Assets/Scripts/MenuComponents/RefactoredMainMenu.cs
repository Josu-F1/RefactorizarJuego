using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MenuSystem.Commands;
using MenuSystem.States;

/// <summary>
/// Menú principal refactorizado aplicando SOLID y patrones de diseño
/// Patrón: State Pattern - Para manejar diferentes estados del menú
/// Patrón: Command Pattern - Para encapsular acciones del menú
/// Patrón: Observer Pattern - Para reaccionar a cambios de autenticación
/// Principio: Single Responsibility Principle (SRP) - Se enfoca solo en coordinar el menú principal
/// Principio: Open/Closed Principle (OCP) - Fácil agregar nuevos estados y comandos
/// Principio: Dependency Inversion Principle (DIP) - Depende de abstracciones
/// </summary>
public class RefactoredMainMenu : MonoBehaviour, IMenuStateContext
{
    [Header("Menu Panels")]
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private GameObject registerPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject helpPanel;
    [SerializeField] private GameObject loadingPanel;
    
    // Propiedades públicas para que los estados puedan acceder a los paneles
    public GameObject LoginPanel => loginPanel;
    public GameObject RegisterPanel => registerPanel;
    public GameObject MainMenuPanel => mainMenuPanel;
    public GameObject HelpPanel => helpPanel;
    public GameObject LoadingPanel => loadingPanel;
    
    [Header("Main Menu UI Components")]
    [SerializeField] private TextMeshProUGUI welcomeText;
    [SerializeField] private Button playButton;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private Button helpButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button logoutButton;
    
    [Header("Navigation Buttons")]
    [SerializeField] private Button showRegisterButton;
    [SerializeField] private Button showLoginButton;
    [SerializeField] private Button closeHelpButton;
    
    [Header("Authentication Components")]
    [SerializeField] private PasswordLoginComponent passwordLogin;
    [SerializeField] private UserRegistrationUI userRegistration;
    
    [Header("Initial State Configuration")]
    [SerializeField] private bool startWithLogin = true; // AHORA empezar con login directamente
    [SerializeField] private bool clearSessionOnStart = true; // Limpiar sesión al iniciar
    
    // System components
    private IMenuState currentState;
    private MenuCommandInvoker commandInvoker;
    private ISessionManager sessionManager;
    private IAuthenticationService authService;
    
    // Events (Observer Pattern)
    public System.Action<string> OnStateChanged;
    public System.Action<string> OnCommandExecuted;
    
    void Start()
    {
        InitializeSystem();
        SetupEventListeners();
        ConfigureInitialPanels();
        SetInitialState();
    }
    
    private void ConfigureInitialPanels()
    {
        // ACTIVAR MainMenuCanvas primero (por si LoginPanel está dentro)
        var mainCanvas = GameObject.Find("MainMenuCanvas");
        if (mainCanvas != null) 
        {
            mainCanvas.SetActive(true);
            Debug.Log("[RefactoredMainMenu] MainMenuCanvas activated");
        }
        
        // Ocultar TODOS los paneles primero
        if (loginPanel != null) loginPanel.SetActive(false);
        if (registerPanel != null) registerPanel.SetActive(false);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (helpPanel != null) helpPanel.SetActive(false);
        if (loadingPanel != null) loadingPanel.SetActive(false);
        
        // Luego mostrar el panel correcto según la configuración
        if (startWithLogin)
        {
            // Mostrar directamente login
            if (loginPanel != null) 
            {
                loginPanel.SetActive(true);
                Debug.Log($"[RefactoredMainMenu] LoginPanel activated: {loginPanel.name}");
                Debug.Log($"[RefactoredMainMenu] LoginPanel active in hierarchy: {loginPanel.activeInHierarchy}");
            }
            else
            {
                // Si el LoginPanel no existe, mostrar MainMenu como fallback
                Debug.LogWarning("[RefactoredMainMenu] LoginPanel is null, showing MainMenu as fallback");
                if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
            }
        }
        else
        {
            // Mostrar menú principal primero
            if (mainMenuPanel != null) 
            {
                mainMenuPanel.SetActive(true);
                Debug.Log("[RefactoredMainMenu] MainMenuPanel activated");
            }
        }
        
        Debug.Log("[RefactoredMainMenu] Initial panels configured");
    }
    
    void OnDestroy()
    {
        CleanupEventListeners();
    }
    
    private void InitializeSystem()
    {
        // Inicializar command invoker
        commandInvoker = new MenuCommandInvoker();
        
        // Crear instancias de servicios
        sessionManager = new SessionManager();
        var validator = new UserInputValidator();
        authService = new WorkingPasswordAuthService(sessionManager, validator);
        
        Debug.Log("[RefactoredMainMenu] Services initialized successfully");
        
        Debug.Log("[RefactoredMainMenu] System initialized successfully");
    }
    
    private void SetupEventListeners()
    {
        // Main menu buttons
        if (playButton != null) 
            playButton.onClick.AddListener(() => HandleInput("play"));
        if (tutorialButton != null) 
            tutorialButton.onClick.AddListener(() => HandleInput("tutorial"));
        if (helpButton != null) 
            helpButton.onClick.AddListener(() => HandleInput("help"));
        if (quitButton != null) 
            quitButton.onClick.AddListener(() => HandleInput("quit"));
        if (logoutButton != null) 
            logoutButton.onClick.AddListener(() => ExecuteLogoutCommand());
        
        // Navigation buttons
        if (showRegisterButton != null) 
            showRegisterButton.onClick.AddListener(() => HandleInput("show_register"));
        if (showLoginButton != null) 
            showLoginButton.onClick.AddListener(() => HandleInput("show_login"));
        if (closeHelpButton != null) 
            closeHelpButton.onClick.AddListener(() => HandleInput("close_help"));
        
        // Authentication events
        if (authService != null)
        {
            authService.OnUserLoggedIn += OnLoginSuccess;
            authService.OnAuthenticationFailed += OnLoginFailed;
            authService.OnUserRegistered += OnRegistrationSuccess;
        }
    }
    
    private void CleanupEventListeners()
    {
        var authService = new WorkingPasswordAuthService(sessionManager, new UserInputValidator());
        if (authService != null)
        {
            authService.OnUserLoggedIn -= OnLoginSuccess;
            authService.OnAuthenticationFailed -= OnLoginFailed;
            authService.OnUserRegistered -= OnRegistrationSuccess;
        }
    }
    
    private void SetInitialState()
    {
        // Limpiar sesión si está configurado
        if (clearSessionOnStart && sessionManager != null)
        {
            sessionManager.EndSession();
        }
        
        IMenuState initialState;
        
        if (startWithLogin)
        {
            // EMPEZAR DIRECTAMENTE EN LOGIN
            initialState = new MenuSystem.States.UnauthenticatedState();
            Debug.Log("[RefactoredMainMenu] Initial state: UnauthenticatedState (Login visible)");
        }
        else
        {
            // Empezar en menú principal (comportamiento original)
            initialState = new MenuSystem.States.MainMenuState();
            Debug.Log("[RefactoredMainMenu] Initial state: MainMenuState (Menu principal visible)");
        }
            
        ChangeState(initialState);
    }
    
    // IMenuStateContext implementation
    public void ChangeState(IMenuState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState?.EnterState(this);
        
        OnStateChanged?.Invoke(currentState.StateName);
        Debug.Log($"[RefactoredMainMenu] Changed to state: {currentState.StateName}");
    }
    
    public void ShowPanel(GameObject panel)
    {
        if (panel != null)
        {
            // Activar el panel
            panel.SetActive(true);
            
            // También activar todos los padres hasta llegar al Canvas raíz
            Transform parent = panel.transform.parent;
            while (parent != null)
            {
                if (parent.gameObject != null)
                {
                    parent.gameObject.SetActive(true);
                    Debug.Log($"[RefactoredMainMenu] Parent activated: {parent.gameObject.name}");
                }
                parent = parent.parent;
            }
            
            Debug.Log($"[RefactoredMainMenu] Panel shown: {panel.name}");
            Debug.Log($"[RefactoredMainMenu] Panel active in hierarchy: {panel.activeInHierarchy}");
        }
        else
        {
            Debug.LogWarning("[RefactoredMainMenu] Trying to show null panel");
        }
    }
    
    public void HidePanel(GameObject panel)
    {
        if (panel != null)
        {
            // Método directo y simple para ocultar el panel
            panel.SetActive(false);
            Debug.Log($"[RefactoredMainMenu] Panel hidden: {panel.name}");
        }
        else
        {
            Debug.LogWarning("[RefactoredMainMenu] Trying to hide null panel");
        }
    }
    
    public void UpdateWelcomeText(string text)
    {
        if (welcomeText != null)
        {
            welcomeText.text = text;
        }
    }
    
    // Input handling
    private void HandleInput(string inputType)
    {
        currentState?.HandleInput(this, inputType);
        OnCommandExecuted?.Invoke(inputType);
    }
    
    // Command execution methods
    private void ExecuteLogoutCommand()
    {
        if (sessionManager != null)
        {
            var logoutCommand = new LogoutCommand(sessionManager, () => {
                HandleInput("logout");
            });
            commandInvoker.ExecuteCommand(logoutCommand);
        }
    }
    
    // Authentication event handlers (Observer Pattern)
    private void OnLoginSuccess(string username)
    {
        Debug.Log($"[RefactoredMainMenu] Login successful for: {username}");
        HandleInput("login_success");
    }
    
    private void OnLoginFailed(string error)
    {
        Debug.LogWarning($"[RefactoredMainMenu] Login failed: {error}");
        // Mantener en estado actual, el componente de login muestra el error
    }
    
    private void OnRegistrationSuccess(string username)
    {
        Debug.Log($"[RefactoredMainMenu] Registration successful for: {username}");
        HandleInput("registration_success");
    }
    
    private void OnRegistrationFailed(string error)
    {
        Debug.LogWarning($"[RefactoredMainMenu] Registration failed: {error}");
        // Mantener en estado actual, el componente de registro muestra el error
    }
    
    // Public methods for external access
    public string CurrentStateName => currentState?.StateName ?? "None";
    
    public void UndoLastAction()
    {
        commandInvoker.UndoLastCommand();
    }
    
    public int CommandHistoryCount => commandInvoker.HistoryCount;
    
    // Debug methods
    [ContextMenu("Force Login State")]
    public void DebugForceLoginState()
    {
        ChangeState(new UnauthenticatedState());
    }
    
    [ContextMenu("Force Main Menu State")]
    public void DebugForceMainMenuState()
    {
        ChangeState(new AuthenticatedState());
    }
    
    [ContextMenu("Clear Command History")]
    public void DebugClearCommandHistory()
    {
        commandInvoker.ClearHistory();
        Debug.Log("[RefactoredMainMenu] Command history cleared");
    }
}