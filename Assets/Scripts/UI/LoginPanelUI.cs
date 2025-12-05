using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Componente UI para login refactorizado con principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo manejo de UI de login
/// Principio: Dependency Inversion Principle (DIP) - Depende de interfaces
/// Patrón: Observer Pattern - Responde a eventos de autenticación
/// </summary>
public class LoginPanelUI : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private InputField userNameInput;
    [SerializeField] private Button loginButton;
    [SerializeField] private Text errorMessageText;
    [SerializeField] private Text validationText;
    
    private IAuthenticationService authService;
    private IUserInputValidator validator;
    
    public System.Action<string> OnLoginAttempt;
    public System.Action OnValidationError;
    
    void Start()
    {
        SetupUI();
    }
    
    private void SetupUI()
    {
        if (loginButton != null)
        {
            loginButton.onClick.AddListener(HandleLoginClick);
        }
        
        if (userNameInput != null)
        {
            userNameInput.onValueChanged.AddListener(OnInputChanged);
        }
        
        UpdateLoginButtonState();
    }
    
    public void Initialize(IAuthenticationService authService, IUserInputValidator validator)
    {
        this.authService = authService;
        this.validator = validator;
        
        // Suscribirse a eventos de autenticación
        if (authService != null)
        {
            authService.OnUserLoggedIn += OnLoginSuccess;
        }
    }
    
    private void HandleLoginClick()
    {
        string userName = userNameInput?.text?.Trim() ?? "";
        
        if (validator != null && !validator.IsValidUserName(userName))
        {
            ShowError(validator.GetValidationError(userName));
            OnValidationError?.Invoke();
            return;
        }
        
        ClearError();
        OnLoginAttempt?.Invoke(userName);
    }
    
    private void OnInputChanged(string input)
    {
        UpdateLoginButtonState();
        
        if (validator != null && !string.IsNullOrEmpty(input))
        {
            if (!validator.IsValidUserName(input))
            {
                ShowValidation(validator.GetValidationError(input));
            }
            else
            {
                ClearValidation();
            }
        }
    }
    
    private void UpdateLoginButtonState()
    {
        if (loginButton != null && userNameInput != null)
        {
            loginButton.interactable = !string.IsNullOrEmpty(userNameInput.text.Trim());
        }
    }
    
    private void OnLoginSuccess(string userName)
    {
        ClearError();
        ClearInput();
        Debug.Log($"[LoginPanelUI] Login successful for: {userName}");
    }
    
    private void ShowError(string message)
    {
        if (errorMessageText != null)
        {
            errorMessageText.text = message;
            errorMessageText.gameObject.SetActive(true);
        }
    }
    
    private void ClearError()
    {
        if (errorMessageText != null)
        {
            errorMessageText.gameObject.SetActive(false);
        }
    }
    
    private void ShowValidation(string message)
    {
        if (validationText != null)
        {
            validationText.text = message;
            validationText.gameObject.SetActive(true);
        }
    }
    
    private void ClearValidation()
    {
        if (validationText != null)
        {
            validationText.gameObject.SetActive(false);
        }
    }
    
    private void ClearInput()
    {
        if (userNameInput != null)
        {
            userNameInput.text = "";
        }
    }
    
    void OnDestroy()
    {
        if (authService != null)
        {
            authService.OnUserLoggedIn -= OnLoginSuccess;
        }
    }
}