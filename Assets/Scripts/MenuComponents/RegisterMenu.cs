using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegisterMenu : MonoBehaviour
{
    [Space(15)]
    public TMP_InputField usernameInput;

    public Button registerButton;

    public void Start()
    {
        usernameInput.onValueChanged.AddListener(OnChangeInput);
        registerButton.onClick.AddListener(OnContinueButton);
    }

    private void OnChangeInput(string input)
    {
        usernameInput.text = input.ToUpper();
        registerButton.interactable = !string.IsNullOrEmpty(input);
    }

    private void OnContinueButton()
    {
        string username = usernameInput.text;

        DataManager.CurrentUsername = username;

        if (!DataManager.UsernameExists(username))
        {
            DataManager.SaveUsername(username);
        }

        SceneLoader.Load("Lobby");
    }
}
