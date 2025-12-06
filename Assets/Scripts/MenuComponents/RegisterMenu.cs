using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Obsolete("Use MenuSystemComposer instead")]
public class RegisterMenu : MonoBehaviour
{
    [Space(15)]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button registerButton;
    public Button loginButton;

    // Nuevos elementos para mostrar mensajes
    public TMP_Text messageText;
    public float messageDisplayTime = 3f; // Tiempo en segundos que se muestra el mensaje
    private Coroutine messageCoroutine;

    public void Start()
    {
        // Silenciado: Sistema legacy en uso hasta completar migración

        usernameInput.onValueChanged.AddListener(OnChangeInput);
        passwordInput.onValueChanged.AddListener(OnChangeInput);
        registerButton.onClick.AddListener(OnRegisterButton);
        loginButton.onClick.AddListener(OnLoginButton);

        // Initialize buttons as non-interactable
        registerButton.interactable = false;
        loginButton.interactable = false;

        // Ocultar mensaje al inicio
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
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

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ShowMessage("Por favor complete todos los campos", Color.red);
            return;
        }

        UserProgress existingUser = UserProgressManager.LoadProgress(username);

        if (existingUser == null)
        {
            // Crear nuevo usuario
            UserProgress newUser = new UserProgress
            {
                userName = username,
                password = password,
                level = 1,
                points = 0
            };
            UserProgressManager.SaveProgress(newUser);
            ShowMessage($"Usuario {username} registrado con éxito", Color.green);
            LoginWithUsername(username);
        }
        else
        {
            ShowMessage("El nombre de usuario ya existe. Por favor inicie sesión.", Color.red);
        }
    }

    private void OnLoginButton()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ShowMessage("Por favor complete todos los campos", Color.red);
            return;
        }

        UserProgress user = UserProgressManager.LoadProgress(username);

        if (user != null)
        {
            // Verificar contraseña
            if (user.password == password)
            {
                ShowMessage($"Bienvenido {username}", Color.green);
                LoginWithUsername(username);
            }
            else
            {
                ShowMessage("Contraseña incorrecta", Color.red);
            }
        }
        else
        {
            ShowMessage("Usuario no encontrado. Por favor regístrese primero.", Color.red);
        }
    }

    private void LoginWithUsername(string username)
    {
        if (string.IsNullOrEmpty(username)) return;

        DataManagerComposer.CurrentUsername = username;
        DataManagerComposer.AddRecentUsername(username);
        SceneLoader.Load("Lobby");
    }

    // Método para mostrar mensajes en la UI
    private void ShowMessage(string message, Color color)
    {
        if (messageText == null) return;

        // Detener la corrutina anterior si existe
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }

        messageText.text = message;
        messageText.color = color;
        messageText.gameObject.SetActive(true);

        // Iniciar una nueva corrutina para ocultar el mensaje después de un tiempo
        messageCoroutine = StartCoroutine(HideMessageAfterDelay());
    }

    private System.Collections.IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDisplayTime);
        messageText.gameObject.SetActive(false);
        messageCoroutine = null;
    }
}