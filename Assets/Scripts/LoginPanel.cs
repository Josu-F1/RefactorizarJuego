using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// OBSOLETO: Esta clase viola principios SOLID
/// Usar LoginSystemComposer con sistema refactorizado
/// - Viola SRP: Mezcla UI, autenticación, navegación y persistencia
/// - Viola DIP: Depende de implementaciones concretas (PlayerPrefs, ProgressDisplay)
/// - Viola OCP: Difícil de extender sin modificar
/// - Alto acoplamiento: Muchas responsabilidades en una clase
/// </summary>
[System.Obsolete("Use LoginSystemComposer instead. This class violates SOLID principles.")]
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
