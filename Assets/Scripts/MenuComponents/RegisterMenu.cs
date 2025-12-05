using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Obsolete("Use MenuSystemComposer instead")]
public class RegisterMenu : MonoBehaviour
{
    [Space(15)]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput; // Nuevo campo para el input de contraseña
    public Button registerButton;
    public Button loginButton;

    public void Start()
    {
        Debug.LogWarning("[OBSOLETE] RegisterMenu is deprecated. Use MenuSystemComposer instead.");

        usernameInput.onValueChanged.AddListener(OnChangeInput);
        passwordInput.onValueChanged.AddListener(OnChangeInput);
        registerButton.onClick.AddListener(OnRegisterButton);
        loginButton.onClick.AddListener(OnLoginButton);

        // Initialize buttons as non-interactable
        registerButton.interactable = false;
        loginButton.interactable = false;
    }

    private void OnChangeInput(string input)
    {
        // Normalizar el username sin disparar eventos
        usernameInput.SetTextWithoutNotify(usernameInput.text.ToUpper());

        bool hasInput =
            !string.IsNullOrEmpty(usernameInput.text) &&
            !string.IsNullOrEmpty(passwordInput.text);

        registerButton.interactable = hasInput;
        loginButton.interactable = hasInput;
    }


    private void OnRegisterButton()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return;

        UserProgress existingUser = UserProgressManager.LoadProgress(username);

        if (existingUser == null)
        {
            // Crear nuevo usuario
            UserProgress newUser = new UserProgress
            {
                userName = username,
                password = password, // Guardar contraseña en texto plano (NO RECOMENDADO para producción)
                level = 1,
                points = 0
            };
            UserProgressManager.SaveProgress(newUser);
            LoginWithUsername(username);
        }
        else
        {
            Debug.Log("Username already exists. Please use Login instead.");
        }
    }

    private void OnLoginButton()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return;

        UserProgress user = UserProgressManager.LoadProgress(username);

        if (user != null)
        {
            // Verificar contraseña (comparación directa sin hash)
            if (user.password == password)
            {
                LoginWithUsername(username);
            }
            else
            {
                Debug.Log("Incorrect password.");
            }
        }
        else
        {
            Debug.Log("Username not found. Please register first.");
        }
    }

    private void LoginWithUsername(string username)
    {
        if (string.IsNullOrEmpty(username)) return;

        DataManagerComposer.CurrentUsername = username;
        DataManagerComposer.AddRecentUsername(username);
        SceneLoader.Load("Lobby");
    }
}