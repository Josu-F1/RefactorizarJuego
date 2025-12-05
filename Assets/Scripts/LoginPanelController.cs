using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginPanelController : MonoBehaviour
{
    public InputField userNameInput;
    public Button loginButton;
    public GameObject loginPanel;
    public string nextSceneName = "MainMenu"; // Cambia esto si quieres ir a otra escena tras login

    void Start()
    {
        loginButton.onClick.AddListener(OnLogin);
        loginPanel.SetActive(true);
    }

    void OnLogin()
    {
        string userName = userNameInput.text.Trim();
        if (!string.IsNullOrEmpty(userName))
        {
            PlayerPrefs.SetString("CurrentUser", userName);
            loginPanel.SetActive(false);
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
