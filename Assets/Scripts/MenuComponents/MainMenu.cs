using UnityEngine;
using UnityEngine.UI;

[System.Obsolete("Use MenuSystemComposer instead")]
public class MainMenu : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject mainMenuPanel;
    public Text userNameText;
    public Button logoutButton;

    void Start()
    {
        Debug.LogWarning("[OBSOLETE] MainMenu is deprecated. Use MenuSystemComposer instead.");
        
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
