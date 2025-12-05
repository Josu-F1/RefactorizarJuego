using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// UI simple para login con contraseña
/// Principio: Single Responsibility Principle (SRP) - Solo maneja UI de login
/// </summary>
public class SimplePasswordLoginUI : MonoBehaviour
{
    [Header("Input Fields")]
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;

    [Header("Buttons")]
    [SerializeField] private Button loginButton;
    [SerializeField] private Button registerButton;
    [SerializeField] private Button guestLoginButton;
    [SerializeField] private Button toggleModeButton;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private TextMeshProUGUI modeText;

    [Header("Configuration")]
    [SerializeField] private bool allowGuestMode = true;

    // Dependencies
    private IAuthenticationService authService;
    private bool isRegisterMode = false;

    // Events
    public event System.Action<string> OnLoginSuccess;
    public event System.Action OnLoginFailed;

    private void Awake()
    {
        SetupUI();
    }

    public void Initialize(IAuthenticationService authService)
    {
        this.authService = authService;
        
        if (this.authService != null)
        {
            this.authService.OnUserLoggedIn += HandleLoginSuccess;
            this.authService.OnUserRegistered += HandleRegistrationSuccess;
            this.authService.OnAuthenticationFailed += HandleAuthenticationFailed;
        }
        
        Debug.Log("[SimplePasswordLoginUI] Initialized with authentication service");
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

        // Configurar placeholders
        SetupPlaceholders();
        
        // Estado inicial
        UpdateUI();
    }

    private void SetupPlaceholders()
    {
        if (usernameInput != null && usernameInput.placeholder != null)
        {
            ((TextMeshProUGUI)usernameInput.placeholder).text = "Usuario...";
        }
        
        if (passwordInput != null && passwordInput.placeholder != null)
        {
            ((TextMeshProUGUI)passwordInput.placeholder).text = "Contraseña...";
        }
    }

    public void OnLoginButtonClick()
    {
        if (authService == null)
        {
            ShowStatus("Servicio no disponible", Color.red);
            return;
        }

        string username = GetUsername();
        string password = GetPassword();

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

        ShowStatus("Iniciando sesión...", Color.white);
        SetButtonsInteractable(false);

        // Intentar login con contraseña
        if (authService is WorkingPasswordAuthService workingAuth)
        {
            workingAuth.Login(username, password);
        }
        else if (authService is SimplePasswordAuthService simpleAuth)
        {
            simpleAuth.Login(username, password);
        }
        else
        {
            authService.Login(username);
        }
    }

    public void OnRegisterButtonClick()
    {
        if (authService == null)
        {
            ShowStatus("Servicio no disponible", Color.red);
            return;
        }

        string username = GetUsername();
        string password = GetPassword();

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

        ShowStatus("Registrando usuario...", Color.white);
        SetButtonsInteractable(false);

        // Intentar registro
        if (authService is WorkingPasswordAuthService workingAuth)
        {
            workingAuth.Register(username, password, password);
        }
        else if (authService is SimplePasswordAuthService simpleAuth)
        {
            simpleAuth.Register(username, password, password);
        }
        else
        {
            ShowStatus("Registro no disponible", Color.red);
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
            ShowStatus("Ingresa un nombre para modo invitado", Color.yellow);
            return;
        }

        ShowStatus("Entrando como invitado...", Color.white);
        SetButtonsInteractable(false);

        // Login sin contraseña
        authService.Login(username);
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

        // Mostrar/ocultar botones según el modo
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
        ShowStatus($"¡Bienvenido, {username}!", Color.green);
        OnLoginSuccess?.Invoke(username);
        ClearPasswordField();
    }

    private void HandleRegistrationSuccess(string username)
    {
        ShowStatus($"Usuario '{username}' registrado. Ahora puedes iniciar sesión.", Color.green);
        
        // Cambiar a modo login después del registro
        isRegisterMode = false;
        UpdateUI();
        ClearPasswordField();
        SetButtonsInteractable(true);
    }

    private void HandleAuthenticationFailed(string error)
    {
        ShowStatus(error, Color.red);
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
        Debug.Log($"[SimplePasswordLoginUI] Status: {message}");
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
        ClearPasswordField();
        if (usernameInput != null)
            usernameInput.text = "";
    }

    private void ClearPasswordField()
    {
        if (passwordInput != null)
            passwordInput.text = "";
    }

    private string GetUsername()
    {
        return usernameInput?.text?.Trim() ?? "";
    }

    private string GetPassword()
    {
        return passwordInput?.text ?? "";
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

        // Limpiar listeners
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