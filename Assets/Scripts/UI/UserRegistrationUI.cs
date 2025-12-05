using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Componente dedicado al registro de usuarios con validaciones avanzadas
/// Principio: Single Responsibility Principle (SRP) - Solo maneja registro
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevas validaciones
/// </summary>
public class UserRegistrationUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_InputField usernameField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private TMP_InputField confirmPasswordField;
    [SerializeField] private Button registerButton;
    [SerializeField] private Button backButton;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private TextMeshProUGUI requirementsText;

    [Header("Validation Rules")]
    [SerializeField] private int minUsernameLength = 3;
    [SerializeField] private int maxUsernameLength = 15;
    [SerializeField] private int minPasswordLength = 4;
    [SerializeField] private bool requireNumberInPassword = true;

    [Header("Visual Feedback")]
    [SerializeField] private Color validColor = Color.green;
    [SerializeField] private Color invalidColor = Color.red;
    [SerializeField] private Color neutralColor = Color.white;

    // Events
    public System.Action<string> OnUserRegistered;
    public System.Action OnRegistrationCancelled;

    private void Start()
    {
        SetupUI();
        DisplayRequirements();
    }

    private void SetupUI()
    {
        if (registerButton != null)
            registerButton.onClick.AddListener(AttemptRegistration);

        if (backButton != null)
            backButton.onClick.AddListener(CancelRegistration);

        // Validación en tiempo real
        if (usernameField != null)
            usernameField.onValueChanged.AddListener(OnUsernameChanged);

        if (passwordField != null)
            passwordField.onValueChanged.AddListener(OnPasswordChanged);

        if (confirmPasswordField != null)
            confirmPasswordField.onValueChanged.AddListener(OnConfirmPasswordChanged);

        // Configurar campos
        if (passwordField != null)
            passwordField.contentType = TMP_InputField.ContentType.Password;

        if (confirmPasswordField != null)
            confirmPasswordField.contentType = TMP_InputField.ContentType.Password;

        // Placeholders
        SetupPlaceholders();
    }

    private void SetupPlaceholders()
    {
        if (usernameField?.placeholder != null)
            ((TextMeshProUGUI)usernameField.placeholder).text = "Elige tu nombre de usuario...";

        if (passwordField?.placeholder != null)
            ((TextMeshProUGUI)passwordField.placeholder).text = "Crea una contraseña...";

        if (confirmPasswordField?.placeholder != null)
            ((TextMeshProUGUI)confirmPasswordField.placeholder).text = "Confirma tu contraseña...";
    }

    private void DisplayRequirements()
    {
        if (requirementsText != null)
        {
            string requirements = "📋 <b>Requisitos:</b>\n";
            requirements += $"• Usuario: {minUsernameLength}-{maxUsernameLength} caracteres\n";
            requirements += $"• Contraseña: mínimo {minPasswordLength} caracteres\n";
            if (requireNumberInPassword)
                requirements += "• Debe incluir al menos un número\n";
            requirements += "• Las contraseñas deben coincidir";

            requirementsText.text = requirements;
            requirementsText.color = neutralColor;
        }
    }

    private void OnUsernameChanged(string value)
    {
        ValidateUsername(value, true);
    }

    private void OnPasswordChanged(string value)
    {
        ValidatePassword(value, true);
        if (!string.IsNullOrEmpty(confirmPasswordField?.text))
        {
            ValidatePasswordMatch();
        }
    }

    private void OnConfirmPasswordChanged(string value)
    {
        ValidatePasswordMatch();
    }

    private bool ValidateUsername(string username, bool showFeedback = false)
    {
        if (string.IsNullOrEmpty(username))
        {
            if (showFeedback) ShowStatus("⏳ Ingresa un nombre de usuario", neutralColor);
            return false;
        }

        if (username.Length < minUsernameLength)
        {
            if (showFeedback) ShowStatus($"❌ Usuario muy corto (mín. {minUsernameLength})", invalidColor);
            return false;
        }

        if (username.Length > maxUsernameLength)
        {
            if (showFeedback) ShowStatus($"❌ Usuario muy largo (máx. {maxUsernameLength})", invalidColor);
            return false;
        }

        if (PlayerPrefs.HasKey($"User_{username}"))
        {
            if (showFeedback) ShowStatus("❌ El usuario ya existe", invalidColor);
            return false;
        }

        if (showFeedback) ShowStatus("✅ Nombre de usuario disponible", validColor);
        return true;
    }

    private bool ValidatePassword(string password, bool showFeedback = false)
    {
        if (string.IsNullOrEmpty(password))
        {
            if (showFeedback) ShowStatus("⏳ Ingresa una contraseña", neutralColor);
            return false;
        }

        if (password.Length < minPasswordLength)
        {
            if (showFeedback) ShowStatus($"❌ Contraseña muy corta (mín. {minPasswordLength})", invalidColor);
            return false;
        }

        if (requireNumberInPassword && !HasNumber(password))
        {
            if (showFeedback) ShowStatus("❌ La contraseña debe incluir un número", invalidColor);
            return false;
        }

        if (showFeedback) ShowStatus("✅ Contraseña válida", validColor);
        return true;
    }

    private bool ValidatePasswordMatch()
    {
        string password = passwordField?.text ?? "";
        string confirmPassword = confirmPasswordField?.text ?? "";

        if (string.IsNullOrEmpty(confirmPassword))
        {
            ShowStatus("⏳ Confirma tu contraseña", neutralColor);
            return false;
        }

        if (password != confirmPassword)
        {
            ShowStatus("❌ Las contraseñas no coinciden", invalidColor);
            return false;
        }

        ShowStatus("✅ Las contraseñas coinciden", validColor);
        return true;
    }

    private bool HasNumber(string text)
    {
        foreach (char c in text)
        {
            if (char.IsDigit(c))
                return true;
        }
        return false;
    }

    public void AttemptRegistration()
    {
        string username = usernameField?.text?.Trim() ?? "";
        string password = passwordField?.text ?? "";
        string confirmPassword = confirmPasswordField?.text ?? "";

        // Validaciones finales
        if (!ValidateUsername(username))
        {
            ValidateUsername(username, true);
            return;
        }

        if (!ValidatePassword(password))
        {
            ValidatePassword(password, true);
            return;
        }

        if (password != confirmPassword)
        {
            ShowStatus("❌ Las contraseñas no coinciden", invalidColor);
            return;
        }

        // Registrar usuario
        RegisterUser(username, password);
    }

    private void RegisterUser(string username, string password)
    {
        try
        {
            ShowStatus("🔄 Creando cuenta...", Color.yellow);

            // Guardar credenciales
            PlayerPrefs.SetString($"User_{username}", password);
            PlayerPrefs.SetString($"UserCreated_{username}", System.DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            PlayerPrefs.Save();

            ShowStatus($"🎉 ¡Cuenta creada exitosamente!", validColor);
            
            // Notificar éxito
            OnUserRegistered?.Invoke(username);

            Debug.Log($"[UserRegistrationUI] User '{username}' registered successfully");

            // Limpiar campos después de un breve delay
            Invoke(nameof(ClearFields), 2f);
        }
        catch (System.Exception ex)
        {
            ShowStatus("❌ Error al crear la cuenta", invalidColor);
            Debug.LogError($"[UserRegistrationUI] Registration error: {ex.Message}");
        }
    }

    public void CancelRegistration()
    {
        ClearFields();
        OnRegistrationCancelled?.Invoke();
    }

    private void ClearFields()
    {
        if (usernameField != null) usernameField.text = "";
        if (passwordField != null) passwordField.text = "";
        if (confirmPasswordField != null) confirmPasswordField.text = "";
        ShowStatus("📝 Completa los campos para registrarte", neutralColor);
    }

    private void ShowStatus(string message, Color color)
    {
        if (statusText != null)
        {
            statusText.text = message;
            statusText.color = color;
        }
    }

    // Métodos públicos de utilidad
    public void SetValidationRules(int minUsername, int maxUsername, int minPassword, bool requireNumber)
    {
        minUsernameLength = minUsername;
        maxUsernameLength = maxUsername;
        minPasswordLength = minPassword;
        requireNumberInPassword = requireNumber;
        DisplayRequirements();
    }

    public bool HasValidInput()
    {
        string username = usernameField?.text?.Trim() ?? "";
        string password = passwordField?.text ?? "";
        string confirmPassword = confirmPasswordField?.text ?? "";

        return ValidateUsername(username) && 
               ValidatePassword(password) && 
               password == confirmPassword;
    }

    private void OnDestroy()
    {
        // Limpiar listeners
        if (registerButton != null)
            registerButton.onClick.RemoveAllListeners();
        if (backButton != null)
            backButton.onClick.RemoveAllListeners();
        if (usernameField != null)
            usernameField.onValueChanged.RemoveAllListeners();
        if (passwordField != null)
            passwordField.onValueChanged.RemoveAllListeners();
        if (confirmPasswordField != null)
            confirmPasswordField.onValueChanged.RemoveAllListeners();
    }
}