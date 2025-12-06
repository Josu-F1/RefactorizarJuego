using UnityEngine;
using UnityEngine.UI;
using MenuSystem;

/// <summary>
/// ✅ Clean Architecture - Main Menu usando MenuSystemComposer
/// </summary>
public class MainMenu : BaseMenu
{
    public GameObject loginPanel;
    public GameObject mainMenuPanel;
    public Text userNameText;
    public Button logoutButton;

    protected override void Awake()
    {
        base.Awake();
        menuName = "MainMenu";
    }

    protected override void Start()
    {
        base.Start(); // ✅ Register with MenuSystemComposer
        
        if (logoutButton != null) 
            logoutButton.onClick.AddListener(OnLogout);
        
        string userName = PlayerPrefs.GetString("CurrentUser", "");
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
        
        Debug.Log("[MainMenu] ✅ Using MenuSystemComposer (Clean Architecture)");
    }

    public void OnLogout()
    {
        PlayerPrefs.DeleteKey("CurrentUser");
        if (loginPanel != null) loginPanel.SetActive(true);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (userNameText != null) userNameText.text = "";
    }
}
