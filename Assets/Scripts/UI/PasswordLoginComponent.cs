using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Componente mejorado de Login con contraseñas aplicando principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo maneja UI de login
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevos tipos de login
/// Patrón: Observer Pattern - Reacciona a cambios de estado
/// </summary>
public class PasswordLoginComponent : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_InputField usernameField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private Button loginButton;
    [SerializeField] private Button registerButton;
    [SerializeField] private Button guestButton;
    [SerializeField] private TextMeshProUGUI statusLabel;
    [SerializeField] private Toggle showPasswordToggle;

    [Header("Configuration")]
    [SerializeField] private bool enableGuestLogin = true;
    [SerializeField] private int minPasswordLength = 4;

    // Estado
    private bool isRegistering = false;

    private void Start()
    {
        SetupUI();
        InitializeDefaultCredentials();
    }

    private void SetupUI()
    {
        // Configurar botones
        if (loginButton != null)
            loginButton.onClick.AddListener(OnLoginClick);

        if (registerButton != null)
            registerButton.onClick.AddListener(OnRegisterClick);

        if (guestButton != null)
        {
            guestButton.onClick.AddListener(OnGuestLoginClick);
            guestButton.gameObject.SetActive(enableGuestLogin);
        }

        if (showPasswordToggle != null)
            showPasswordToggle.onValueChanged.AddListener(OnTogglePasswordVisibility);

        // Configurar input fields
        if (passwordField != null)
        {
            passwordField.contentType = TMP_InputField.ContentType.Password;
        }

        // Placeholders
        SetupPlaceholders();

        ShowStatus("¡Bienvenido! Ingresa tus credenciales", Color.white);
    }

    private void SetupPlaceholders()
    {
        if (usernameField?.placeholder != null)
            ((TextMeshProUGUI)usernameField.placeholder).text = "Ingresa tu usuario...";

        if (passwordField?.placeholder != null)
            ((TextMeshProUGUI)passwordField.placeholder).text = "Ingresa tu contraseña...";
    }

    private void InitializeDefaultCredentials()
    {
        // Crear usuarios por defecto si no existen
        string defaultUsers = PlayerPrefs.GetString("DefaultUsersCreated", "false");
        if (defaultUsers != "true")
        {
            CreateDefaultUser("admin", "1234");
            CreateDefaultUser("player", "game");
            CreateDefaultUser("test", "test");
            PlayerPrefs.SetString("DefaultUsersCreated", "true");
            PlayerPrefs.Save();
            
            ShowStatus("Usuarios por defecto creados: admin/1234, player/game, test/test", Color.cyan);
        }
    }

    private void CreateDefaultUser(string username, string password)
    {
        PlayerPrefs.SetString($"User_{username}", password);
    }

    public void OnLoginClick()
    {
        string username = usernameField?.text?.Trim() ?? "";
        string password = passwordField?.text ?? "";

        if (string.IsNullOrEmpty(username))
        {
            ShowStatus("❌ Por favor ingresa tu usuario", Color.red);
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            ShowStatus("❌ Por favor ingresa tu contraseña", Color.red);
            return;
        }

        AttemptLogin(username, password);
    }

    public void OnRegisterClick()
    {
        if (!isRegistering)
        {
            // Cambiar a modo registro
            isRegistering = true;
            UpdateUIForRegistration();
            return;
        }

        // Procesar registro
        string username = usernameField?.text?.Trim() ?? "";
        string password = passwordField?.text ?? "";

        if (string.IsNullOrEmpty(username))
        {
            ShowStatus("❌ Por favor ingresa un usuario", Color.red);
            return;
        }

        if (password.Length < minPasswordLength)
        {
            ShowStatus($"❌ La contraseña debe tener al menos {minPasswordLength} caracteres", Color.red);
            return;
        }

        AttemptRegister(username, password);
    }

    public void OnGuestLoginClick()
    {
        string username = usernameField?.text?.Trim() ?? "";
        
        if (string.IsNullOrEmpty(username))
        {
            username = "Invitado_" + Random.Range(1000, 9999);
        }

        AttemptGuestLogin(username);
    }

    private void AttemptLogin(string username, string password)
    {
        ShowStatus("🔄 Verificando credenciales...", Color.yellow);

        // Verificar credenciales guardadas
        string savedPassword = PlayerPrefs.GetString($"User_{username}", "");
        
        if (string.IsNullOrEmpty(savedPassword))
        {
            ShowStatus($"❌ Usuario '{username}' no encontrado. ¿Quieres registrarte?", Color.red);
            return;
        }

        if (savedPassword != password)
        {
            ShowStatus("❌ Contraseña incorrecta. Verifica e inténtalo de nuevo.", Color.red);
            return;
        }

        // Actualizar último acceso
        PlayerPrefs.SetString($"LastLogin_{username}", System.DateTime.Now.ToString());
        PlayerPrefs.Save();

        // Login exitoso
        ShowStatus($"✅ ¡Bienvenido de vuelta, {username}!", Color.green);
        StartSession(username);
    }

    private void AttemptRegister(string username, string password)
    {
        ShowStatus("🔄 Creando usuario...", Color.yellow);

        // Verificar si el usuario ya existe
        if (PlayerPrefs.HasKey($"User_{username}"))
        {
            ShowStatus("❌ El usuario ya existe", Color.red);
            return;
        }

        // Validaciones adicionales
        if (username.Length < 2)
        {
            ShowStatus("❌ El usuario debe tener al menos 2 caracteres", Color.red);
            return;
        }

        // Crear usuario
        PlayerPrefs.SetString($"User_{username}", password);
        PlayerPrefs.SetString($"UserCreated_{username}", System.DateTime.Now.ToString());
        PlayerPrefs.Save();

        ShowStatus($"✅ Usuario '{username}' registrado exitosamente!", Color.green);
        
        // Auto-login después del registro exitoso
        Invoke(nameof(AutoLoginAfterRegister), 1.5f);
    }
    
    private void AutoLoginAfterRegister()
    {
        string username = usernameField?.text?.Trim() ?? "";
        string password = passwordField?.text ?? "";
        
        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            ShowStatus("🚀 Iniciando sesión automáticamente...", Color.cyan);
            AttemptLogin(username, password);
        }
        
        // Volver a modo login
        isRegistering = false;
        UpdateUIForLogin();
    }

    private void AttemptGuestLogin(string username)
    {
        ShowStatus($"🔄 Entrando como invitado: {username}", Color.yellow);
        StartSession(username);
    }

    private void StartSession(string username)
    {
        try
        {
            // Integrar con el sistema existente
            var loginComposer = FindObjectOfType<LoginSystemComposer>();
            if (loginComposer != null)
            {
                var authService = loginComposer.GetComponent<AuthenticationService>();
                if (authService != null)
                {
                    bool success = authService.Login(username);
                    if (success)
                    {
                        Debug.Log($"[PasswordLoginComponent] Session started via LoginComposer for: {username}");
                        ClearPasswordField();
                        ActivateGameAfterLogin();
                        return;
                    }
                }
            }

            // Fallback: usar DataManagerComposer directamente
            DataManagerComposer.CurrentUsername = username;
            Debug.Log($"[PasswordLoginComponent] Session started (direct) for: {username}");
            
            ClearPasswordField();
            ActivateGameAfterLogin();
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"[PasswordLoginComponent] Error starting session: {ex.Message}");
            ShowStatus("❌ Error al iniciar sesión", Color.red);
        }
    }

    private void ActivateGameAfterLogin()
    {
        // Buscar y activar el panel de progreso
        var progressDisplay = FindObjectOfType<ProgressDisplayComposer>();
        if (progressDisplay != null)
        {
            progressDisplay.gameObject.SetActive(true);
            progressDisplay.LoadUser(DataManagerComposer.CurrentUsername);
        }

        // Ocultar panel de login
        if (transform.parent != null)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    private void UpdateUIForRegistration()
    {
        if (registerButton != null)
        {
            var buttonText = registerButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
                buttonText.text = "Crear Usuario";
        }

        ShowStatus("🆕 Modo Registro: Ingresa usuario y contraseña", Color.cyan);
    }

    private void UpdateUIForLogin()
    {
        if (registerButton != null)
        {
            var buttonText = registerButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
                buttonText.text = "Registrar";
        }

        ShowStatus("🔑 Modo Login: Ingresa tus credenciales", Color.white);
    }

    private void OnTogglePasswordVisibility(bool show)
    {
        if (passwordField != null)
        {
            passwordField.contentType = show ? 
                TMP_InputField.ContentType.Standard : 
                TMP_InputField.ContentType.Password;
            passwordField.ForceLabelUpdate();
        }
    }

    private void ShowStatus(string message, Color color)
    {
        if (statusLabel != null)
        {
            statusLabel.text = message;
            statusLabel.color = color;
        }

        Debug.Log($"[PasswordLoginComponent] {message}");
    }

    private void ClearPasswordField()
    {
        if (passwordField != null)
            passwordField.text = "";
    }

    // Métodos públicos para configuración
    public void SetGuestModeEnabled(bool enabled)
    {
        enableGuestLogin = enabled;
        if (guestButton != null)
        {
            guestButton.gameObject.SetActive(enabled);
        }
    }

    public void SetMinPasswordLength(int length)
    {
        minPasswordLength = Mathf.Max(1, length);
    }

    // Métodos públicos para administración y testing
    
    [ContextMenu("Clear All Users")]
    public void ClearAllUsers()
    {
        var keys = new System.Collections.Generic.List<string>();
        
        // Buscar todas las keys de usuarios
        for (int i = 0; i < 1000; i++)
        {
            string userKey = $"User_test{i}";
            string createdKey = $"UserCreated_test{i}";
            string loginKey = $"LastLogin_test{i}";
            
            if (PlayerPrefs.HasKey(userKey)) keys.Add(userKey);
            if (PlayerPrefs.HasKey(createdKey)) keys.Add(createdKey);
            if (PlayerPrefs.HasKey(loginKey)) keys.Add(loginKey);
        }

        // Usuarios comunes
        string[] commonUsers = { "admin", "player", "test", "user", "guest" };
        foreach (string user in commonUsers)
        {
            string userKey = $"User_{user}";
            string createdKey = $"UserCreated_{user}";
            string loginKey = $"LastLogin_{user}";
            
            if (PlayerPrefs.HasKey(userKey)) keys.Add(userKey);
            if (PlayerPrefs.HasKey(createdKey)) keys.Add(createdKey);
            if (PlayerPrefs.HasKey(loginKey)) keys.Add(loginKey);
        }

        // Eliminar keys
        foreach (string key in keys)
        {
            PlayerPrefs.DeleteKey(key);
        }

        PlayerPrefs.DeleteKey("DefaultUsersCreated");
        PlayerPrefs.Save();

        ShowStatus($"🗑️ {keys.Count} registros de usuarios eliminados", Color.yellow);
        Debug.Log($"[PasswordLoginComponent] Cleared {keys.Count} user records");
    }
    
    [ContextMenu("Show User Stats")]
    public void ShowUserStats()
    {
        int userCount = 0;
        string[] commonUsers = { "admin", "player", "test", "user", "guest" };
        
        foreach (string user in commonUsers)
        {
            if (PlayerPrefs.HasKey($"User_{user}"))
            {
                userCount++;
                string created = PlayerPrefs.GetString($"UserCreated_{user}", "Desconocido");
                string lastLogin = PlayerPrefs.GetString($"LastLogin_{user}", "Nunca");
                Debug.Log($"Usuario: {user} | Creado: {created} | Último acceso: {lastLogin}");
            }
        }
        
        ShowStatus($"📊 {userCount} usuarios registrados", Color.cyan);
    }
    
    public bool HasRegisteredUsers()
    {
        return PlayerPrefs.GetString("DefaultUsersCreated", "false") == "true";
    }
    
    public void ForceCreateDefaultUsers()
    {
        CreateDefaultUser("admin", "1234");
        CreateDefaultUser("player", "game");
        CreateDefaultUser("test", "test");
        PlayerPrefs.SetString("DefaultUsersCreated", "true");
        PlayerPrefs.Save();
        
        ShowStatus("👥 Usuarios por defecto recreados", Color.green);
    }

    private void OnDestroy()
    {
        // Limpiar listeners
        if (loginButton != null)
            loginButton.onClick.RemoveAllListeners();
        if (registerButton != null)
            registerButton.onClick.RemoveAllListeners();
        if (guestButton != null)
            guestButton.onClick.RemoveAllListeners();
        if (showPasswordToggle != null)
            showPasswordToggle.onValueChanged.RemoveAllListeners();
    }
}