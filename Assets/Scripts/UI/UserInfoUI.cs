using TMPro;
using UnityEngine;

/// <summary>
/// Componente UI responsable ÚNICAMENTE de mostrar información del usuario
/// Principio: Single Responsibility Principle (SRP)
/// </summary>
public class UserInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI usernameText;
    
    private IUserInfo userInfo;

    public void Initialize(IUserInfo userInfo)
    {
        this.userInfo = userInfo;
        UpdateUsernameText();
    }

    private void UpdateUsernameText()
    {
        if (usernameText != null && userInfo != null)
            usernameText.text = userInfo.Username;
    }
}