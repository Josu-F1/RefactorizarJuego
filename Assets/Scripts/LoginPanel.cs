using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginPanel : MonoBehaviour
{
    public InputField userNameInput;
    public Button loginButton;
    public GameObject panel;
    public GameObject progressUI; // Asigna el panel de progreso principal aquí
    public ProgressDisplay progressDisplay; // Asigna el script de progreso principal aquí

    void Start()
    {
        loginButton.onClick.AddListener(OnLogin);
        panel.SetActive(true);
        if (progressUI != null) progressUI.SetActive(false);
    }

    void OnLogin()
    {
        string userName = userNameInput.text.Trim();
        if (!string.IsNullOrEmpty(userName))
        {
            PlayerPrefs.SetString("CurrentUser", userName);
            panel.SetActive(false);
            if (progressUI != null) progressUI.SetActive(true);
            if (progressDisplay != null)
            {
                progressDisplay.LoadUser(userName);
            }
        }
    }
}
