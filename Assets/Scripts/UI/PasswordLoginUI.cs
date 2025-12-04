using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// UI para login con contraseña aplicando principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo maneja UI de login con contraseña
/// Principio: Dependency Inversion Principle (DIP) - Depende de IAuthenticationService
/// Patrón: Observer Pattern - Reacciona a eventos del servicio de autenticación
/// </summary>
public class PasswordLoginUI : MonoBehaviour
{
    [Header("Input Fields")]
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private TMP_InputField confirmPasswordInput;

    [Header("Buttons")]
    [SerializeField] private Button loginButton;
    [SerializeField] private Button registerButton;
    [SerializeField] private Button guestLoginButton;
    [SerializeField] private Button toggleModeButton;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private TextMeshProUGUI modeText;
    [SerializeField] private GameObject registrationPanel;
    [SerializeField] private GameObject loginPanel;

    [Header("Configuration")]
    [SerializeField] private bool allowGuestMode = true;
    [SerializeField] private Color successColor = Color.green;
    [SerializeField] private Color errorColor = Color.red;
    [SerializeField] private Color warningColor = Color.yellow;

    // Dependencies
    private IAuthenticationService authService;
    private bool isRegisterMode = false;

    // Events
    public event Action<string> OnLoginSuccess;
    public event Action OnLoginFailed;

    private void Awake()
    {
        SetupUI();
    }

    private void Start()
    {
        // El servicio se inyectará desde el LoginSystemComposer
        UpdateUI();
    }

    public void Initialize(IAuthenticationService authService)
    {
        this.authService = authService ?? throw new ArgumentNullException(nameof(authService));
        
        // Suscribirse a eventos
        this.authService.OnUserLoggedIn += HandleLoginSuccess;
        this.authService.OnUserRegistered += HandleRegistrationSuccess;
        this.authService.OnAuthenticationFailed += HandleAuthenticationFailed;
        
        Debug.Log("[PasswordLoginUI] Initialized with authentication service");
    }

    private void SetupUI()
    {
        // Configurar botones
        if (loginButton != null)
            loginButton.onClick.AddListener(OnLoginButtonClick);
        
        if (registerButton != null)
            registerButton.onClick.AddListener(OnRegisterButtonClick);
        
        if (guestLoginButton != null)
        {
            guestLoginButton.onClick.AddListener(OnGuestLoginClick);
            guestLoginButton.gameObject.SetActive(allowGuestMode);
        }
        
        if (toggleModeButton != null)
            toggleModeButton.onClick.AddListener(OnToggleModeClick);

        // Configurar input fields
        if (passwordInput != null)
        {
            passwordInput.contentType = TMP_InputField.ContentType.Password;
        }
        
        if (confirmPasswordInput != null)
        {
            confirmPasswordInput.contentType = TMP_InputField.ContentType.Password;
        }

        // Configurar placeholders
        SetupPlaceholders();
        
        // Configurar Enter key support
        SetupEnterKeySupport();
    }

    private void SetupPlaceholders()
    {
        if (usernameInput?.placeholder != null)
        {
            ((TextMeshProUGUI)usernameInput.placeholder).text = "Ingresa tu usuario...";
        }
        
        if (passwordInput?.placeholder != null)
        {
            ((TextMeshProUGUI)passwordInput.placeholder).text = "Ingresa tu contraseña...";
        }
        
        if (confirmPasswordInput?.placeholder != null)
        {
            ((TextMeshProUGUI)confirmPasswordInput.placeholder).text = "Confirma tu contraseña...";
        }
    }

    private void SetupEnterKeySupport()
    {
        if (usernameInput != null)
        {
            usernameInput.onSubmit.AddListener((_) => FocusNextField());
        }
        
        if (passwordInput != null)
        {
            passwordInput.onSubmit.AddListener((_) => 
            {
                if (isRegisterMode && confirmPasswordInput != null)
                    confirmPasswordInput.Select();
                else
                    OnLoginButtonClick();
            });
        }
        
        if (confirmPasswordInput != null)
        {
            confirmPasswordInput.onSubmit.AddListener((_) => OnRegisterButtonClick());
        }
    }

    private void FocusNextField()
    {
        if (passwordInput != null)
        {
            passwordInput.Select();
        }
    }

    public void OnLoginButtonClick()
    {
        if (authService == null)
        {
            ShowStatus("Servicio de autenticación no disponible", errorColor);
            return;
        }

        string username = GetUsername();
        string password = GetPassword();

        if (string.IsNullOrEmpty(username))
        {
            ShowStatus("Por favor ingresa tu usuario", warningColor);
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            ShowStatus("Por favor ingresa tu contraseña", warningColor);
            return;
        }

        ShowStatus("Iniciando sesión...", Color.white);
        SetButtonsInteractable(false);

        // Intentar login con contraseña
        bool success = authService.Login(username, password);
        
        if (!success)
        {
            SetButtonsInteractable(true);
        }
    }

    public void OnRegisterButtonClick()
    {
        if (authService == null)
        {
            ShowStatus("Servicio de autenticación no disponible", errorColor);
            return;
        }

        string username = GetUsername();
        string password = GetPassword();
        string confirmPassword = GetConfirmPassword();

        if (string.IsNullOrEmpty(username))
        {
            ShowStatus("Por favor ingresa un usuario", warningColor);
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            ShowStatus("Por favor ingresa una contraseña", warningColor);
            return;
        }

        if (string.IsNullOrEmpty(confirmPassword))
        {
            ShowStatus("Por favor confirma tu contraseña", warningColor);
            return;
        }

        ShowStatus("Registrando usuario...", Color.white);
        SetButtonsInteractable(false);

        // Intentar registro
        bool success = authService.Register(username, password, confirmPassword);
        
        if (!success)
        {
            SetButtonsInteractable(true);
        }
    }

    public void OnGuestLoginClick()
    {
        if (!allowGuestMode || authService == null)
            return;

        string username = GetUsername();
        if (string.IsNullOrEmpty(username))
        {
            ShowStatus("Por favor ingresa un nombre de usuario para modo invitado", warningColor);
            return;
        }

        ShowStatus("Entrando como invitado...", Color.white);
        SetButtonsInteractable(false);

        // Login sin contraseña (modo invitado)
        bool success = authService.Login(username);
        
        if (!success)
        {
            SetButtonsInteractable(true);
        }
    }

    public void OnToggleModeClick()
    {
        isRegisterMode = !isRegisterMode;
        UpdateUI();
        ClearInputs();
    }

    private void UpdateUI()
    {
        if (modeText != null)
        {
            modeText.text = isRegisterMode ? "Registro" : "Iniciar Sesión";
        }

        if (toggleModeButton != null)
        {
            var buttonText = toggleModeButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = isRegisterMode ? "¿Ya tienes cuenta?" : "¿Nuevo usuario?";
            }
        }

        // Mostrar/ocultar campos según el modo
        if (confirmPasswordInput != null)
        {
            confirmPasswordInput.gameObject.SetActive(isRegisterMode);
        }

        if (registrationPanel != null)
        {
            registrationPanel.SetActive(isRegisterMode);
        }

        if (loginPanel != null)
        {
            loginPanel.SetActive(!isRegisterMode);
        }

        // Actualizar botones
        if (loginButton != null)
        {
            loginButton.gameObject.SetActive(!isRegisterMode);
        }

        if (registerButton != null)
        {
            registerButton.gameObject.SetActive(isRegisterMode);
        }
    }

    private void HandleLoginSuccess(string username)
    {
        ShowStatus($"¡Bienvenido, {username}!", successColor);
        OnLoginSuccess?.Invoke(username);
        
        // Limpiar campos por seguridad
        ClearPasswordFields();
    }

    private void HandleRegistrationSuccess(string username)
    {
        ShowStatus($"Usuario '{username}' registrado exitosamente. Ahora puedes iniciar sesión.", successColor);
        
        // Cambiar a modo login después del registro exitoso
        isRegisterMode = false;
        UpdateUI();
        ClearPasswordFields();
        SetButtonsInteractable(true);
    }

    private void HandleAuthenticationFailed(string error)
    {
        ShowStatus(error, errorColor);
        OnLoginFailed?.Invoke();
        SetButtonsInteractable(true);
    }

    private void ShowStatus(string message, Color color)
    {
        if (statusText != null)
        {
            statusText.text = message;
            statusText.color = color;
        }
        Debug.Log($"[PasswordLoginUI] Status: {message}");
    }

    private void SetButtonsInteractable(bool interactable)
    {
        if (loginButton != null)
            loginButton.interactable = interactable;
        if (registerButton != null)
            registerButton.interactable = interactable;
        if (guestLoginButton != null)
            guestLoginButton.interactable = interactable;
        if (toggleModeButton != null)
            toggleModeButton.interactable = interactable;
    }

    private void ClearInputs()
    {
        ClearPasswordFields();
        if (usernameInput != null)
            usernameInput.text = "";
    }

    private void ClearPasswordFields()
    {
        if (passwordInput != null)
            passwordInput.text = "";
        if (confirmPasswordInput != null)
            confirmPasswordInput.text = "";
    }

    private string GetUsername()
    {
        return usernameInput?.text?.Trim() ?? "";
    }

    private string GetPassword()
    {
        return passwordInput?.text ?? "";
    }

    private string GetConfirmPassword()
    {
        return confirmPasswordInput?.text ?? "";
    }

    public void SetGuestModeEnabled(bool enabled)
    {
        allowGuestMode = enabled;
        if (guestLoginButton != null)
        {
            guestLoginButton.gameObject.SetActive(enabled);
        }
    }

    private void OnDestroy()
    {
        // Desuscribirse de eventos
        if (authService != null)
        {
            authService.OnUserLoggedIn -= HandleLoginSuccess;
            authService.OnUserRegistered -= HandleRegistrationSuccess;
            authService.OnAuthenticationFailed -= HandleAuthenticationFailed;
        }

        // Limpiar listeners de botones
        if (loginButton != null)
            loginButton.onClick.RemoveAllListeners();
        if (registerButton != null)
            registerButton.onClick.RemoveAllListeners();
        if (guestLoginButton != null)
            guestLoginButton.onClick.RemoveAllListeners();
        if (toggleModeButton != null)
            toggleModeButton.onClick.RemoveAllListeners();
    }
}