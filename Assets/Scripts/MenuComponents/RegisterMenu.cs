using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegisterMenu : MonoBehaviour
{
    [Space(15)]
    public TMP_InputField usernameInput;
    public Button registerButton;
    
    [Space(15)]
    [Header("Recent Users")]
    public Button recentUser1Button;
    public Button recentUser2Button;
    public Button recentUser3Button;
    public TextMeshProUGUI recentUsersTitle;

    private Button[] recentUserButtons;

    public void Start()
    {
        usernameInput.onValueChanged.AddListener(OnChangeInput);
        registerButton.onClick.AddListener(OnContinueButton);
        
        // Inicializar botones de usuarios recientes
        recentUserButtons = new Button[] { recentUser1Button, recentUser2Button, recentUser3Button };
        
        SetupRecentUsers();
    }

    private void OnChangeInput(string input)
    {
        usernameInput.text = input.ToUpper();
        registerButton.interactable = !string.IsNullOrEmpty(input);
    }

    private void OnContinueButton()
    {
        LoginWithUsername(usernameInput.text);
    }
    
    private void LoginWithUsername(string username)
    {
        if (string.IsNullOrEmpty(username)) return;

        DataManagerComposer.CurrentUsername = username;

        if (!DataManagerComposer.UsernameExists(username))
        {
            DataManagerComposer.SaveUsername(username);
        }
        else
        {
            // Si el usuario ya existe, agregarlo a recientes
            DataManagerComposer.AddRecentUsername(username);
        }

        SceneLoader.Load("Lobby");
    }
    
    private void SetupRecentUsers()
    {
        string[] recentUsers = DataManagerComposer.GetRecentUsernames(3);
        
        // Mostrar/ocultar título si hay usuarios recientes
        if (recentUsersTitle != null)
        {
            recentUsersTitle.gameObject.SetActive(recentUsers.Length > 0);
        }
        
        for (int i = 0; i < recentUserButtons.Length; i++)
        {
            if (recentUserButtons[i] != null)
            {
                if (i < recentUsers.Length && !string.IsNullOrEmpty(recentUsers[i]))
                {
                    // Configurar botón con nombre de usuario
                    recentUserButtons[i].gameObject.SetActive(true);
                    
                    // Actualizar texto del botón
                    TextMeshProUGUI buttonText = recentUserButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                    if (buttonText != null)
                    {
                        buttonText.text = recentUsers[i];
                    }
                    
                    // Configurar callback (capturar variable local)
                    string userToLogin = recentUsers[i];
                    recentUserButtons[i].onClick.RemoveAllListeners();
                    recentUserButtons[i].onClick.AddListener(() => OnRecentUserSelected(userToLogin));
                }
                else
                {
                    // Ocultar botón si no hay usuario
                    recentUserButtons[i].gameObject.SetActive(false);
                }
            }
        }
    }
    
    private void OnRecentUserSelected(string username)
    {
        LoginWithUsername(username);
    }
}
