using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject mainMenuPanel;
    public Text userNameText; // Asigna un Text en el menú principal para mostrar el usuario
    public Button logoutButton; // Asigna un botón para cerrar sesión

    void Start()
    {
        // Si no hay usuario registrado, mostrar login
        string userName = PlayerPrefs.GetString("CurrentUser", "");
        if (logoutButton != null) logoutButton.onClick.AddListener(OnLogout);
        if (string.IsNullOrEmpty(userName))
        {
            if (loginPanel != null) loginPanel.SetActive(true);
            if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        }
        else
        {
            if (loginPanel != null) loginPanel.SetActive(false);
            if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
            if (userNameText != null) userNameText.text = $"Bienvenido, {userName}";
        }
    }

    public void OnLogout()
    {
        PlayerPrefs.DeleteKey("CurrentUser");
        if (loginPanel != null) loginPanel.SetActive(true);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (userNameText != null) userNameText.text = "";
    }
}
