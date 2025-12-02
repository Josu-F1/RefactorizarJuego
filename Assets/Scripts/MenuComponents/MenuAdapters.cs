using UnityEngine;
using UnityEngine.UI;

namespace MenuSystem
{
    /// <summary>
    /// Adaptador para MainMenu existente
    /// Patrón: Adapter Pattern
    /// </summary>
    public class MainMenuAdapter : BaseMenu
    {
        [Header("MainMenu Adapter")]
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private Button playButton;
        [SerializeField] private Button exitButton;
        
        protected override void Awake()
        {
            menuName = "MainMenu";
            base.Awake();
        }
        
        protected override void Start()
        {
            base.Start();
            SetupButtons();
        }
        
        private void SetupButtons()
        {
            if (playButton != null)
            {
                playButton.onClick.AddListener(() => menuSystem.LoadScene("Game"));
            }
            
            if (exitButton != null)
            {
                exitButton.onClick.AddListener(() => menuSystem.QuitGame());
            }
        }
        
        public override void Show()
        {
            base.Show();
            OnShow();
        }
        
        public override void Hide()
        {
            base.Hide();
            OnHide();
        }
        
        protected virtual void OnShow()
        {
            if (mainMenuPanel != null)
            {
                mainMenuPanel.SetActive(true);
            }
        }
        
        protected virtual void OnHide()
        {
            if (mainMenuPanel != null)
            {
                mainMenuPanel.SetActive(false);
            }
        }
    }
    
    /// <summary>
    /// Adaptador para PauseMenu existente
    /// Patrón: Adapter Pattern
    /// </summary>
    public class PauseMenuAdapter : BaseMenu
    {
        [Header("PauseMenu Adapter")]
        [SerializeField] private GameObject pauseMenuPanel;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button exitButton;
        
        protected override void Awake()
        {
            menuName = "PauseMenu";
            pauseGameWhenVisible = true;
            base.Awake();
        }
        
        protected override void Start()
        {
            base.Start();
            SetupButtons();
        }
        
        private void SetupButtons()
        {
            if (resumeButton != null)
            {
                resumeButton.onClick.AddListener(() => {
                    menuSystem.ResumeGame();
                    Hide();
                });
            }
            
            if (mainMenuButton != null)
            {
                mainMenuButton.onClick.AddListener(() => menuSystem.LoadScene("MainMenu"));
            }
            
            if (exitButton != null)
            {
                exitButton.onClick.AddListener(() => menuSystem.QuitGame());
            }
        }
        
        public override void Show()
        {
            base.Show();
            OnShow();
        }
        
        public override void Hide()
        {
            base.Hide();
            OnHide();
        }
        
        protected virtual void OnShow()
        {
            if (pauseMenuPanel != null)
            {
                pauseMenuPanel.SetActive(true);
            }
        }
        
        protected virtual void OnHide()
        {
            if (pauseMenuPanel != null)
            {
                pauseMenuPanel.SetActive(false);
            }
        }
    }
    
    /// <summary>
    /// Adaptador para EndGameDisplay existente
    /// Patrón: Adapter Pattern
    /// </summary>
    public class EndGameDisplayAdapter : BaseMenu
    {
        [Header("EndGameDisplay Adapter")]
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button exitButton;
        
        protected override void Awake()
        {
            menuName = "EndGameDisplay";
            pauseGameWhenVisible = true;
            base.Awake();
        }
        
        protected override void Start()
        {
            base.Start();
            SetupButtons();
        }
        
        private void SetupButtons()
        {
            if (restartButton != null)
            {
                restartButton.onClick.AddListener(() => menuSystem.LoadScene("Game"));
            }
            
            if (mainMenuButton != null)
            {
                mainMenuButton.onClick.AddListener(() => menuSystem.LoadScene("MainMenu"));
            }
            
            if (exitButton != null)
            {
                exitButton.onClick.AddListener(() => menuSystem.QuitGame());
            }
        }
        
        public override void Show()
        {
            base.Show();
            OnShow();
        }
        
        public override void Hide()
        {
            base.Hide();
            OnHide();
        }
        
        protected virtual void OnShow()
        {
            if (endGamePanel != null)
            {
                endGamePanel.SetActive(true);
            }
        }
        
        protected virtual void OnHide()
        {
            if (endGamePanel != null)
            {
                endGamePanel.SetActive(false);
            }
        }
    }
    
    /// <summary>
    /// Adaptador para RegisterMenu existente
    /// Patrón: Adapter Pattern
    /// </summary>
    public class RegisterMenuAdapter : BaseMenu
    {
        [Header("RegisterMenu Adapter")]
        [SerializeField] private GameObject registerPanel;
        [SerializeField] private Button submitButton;
        [SerializeField] private Button cancelButton;
        [SerializeField] private InputField usernameInput;
        [SerializeField] private InputField passwordInput;
        
        protected override void Awake()
        {
            menuName = "RegisterMenu";
            base.Awake();
        }
        
        protected override void Start()
        {
            base.Start();
            SetupButtons();
        }
        
        private void SetupButtons()
        {
            if (submitButton != null)
            {
                submitButton.onClick.AddListener(OnSubmitRegister);
            }
            
            if (cancelButton != null)
            {
                cancelButton.onClick.AddListener(() => menuSystem.ShowMenu("MainMenu"));
            }
        }
        
        private void OnSubmitRegister()
        {
            string username = usernameInput?.text ?? "";
            string password = passwordInput?.text ?? "";
            
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                // Lógica de registro
                PlayerPrefs.SetString("RegisteredUser", username);
                PlayerPrefs.Save();
                
                menuSystem.ShowMenu("MainMenu");
            }
        }
        
        public override void Show()
        {
            base.Show();
            OnShow();
        }
        
        public override void Hide()
        {
            base.Hide();
            OnHide();
        }
        
        protected virtual void OnShow()
        {
            if (registerPanel != null)
            {
                registerPanel.SetActive(true);
            }
        }
        
        protected virtual void OnHide()
        {
            if (registerPanel != null)
            {
                registerPanel.SetActive(false);
            }
        }
    }
}

#region Obsolete Compatibility Bridge

/// <summary>
/// Puente de compatibilidad para MainMenu existente
/// OBSOLETO: Usar MenuSystemComposer en su lugar
/// </summary>
[System.Obsolete("Use MenuSystemComposer instead")]
public class MainMenuCompat : MonoBehaviour
{
    private void Start()
    {
        Debug.LogWarning("[OBSOLETE] MainMenu is deprecated. Use MenuSystemComposer instead.");
    }
    
    public void PlayGame()
    {
        if (MenuSystem.MenuSystemComposer.Instance != null)
            MenuSystem.MenuSystemComposer.Instance.LoadScene("Game");
    }
    
    public void ExitGame()
    {
        if (MenuSystem.MenuSystemComposer.Instance != null)
            MenuSystem.MenuSystemComposer.Instance.QuitGame();
    }
}

/// <summary>
/// Puente de compatibilidad para EndGameDisplay existente
/// OBSOLETO: Usar MenuSystemComposer en su lugar
/// </summary>
[System.Obsolete("Use MenuSystemComposer instead")]
public class EndGameDisplayCompat : MonoBehaviour
{
    private void Start()
    {
        Debug.LogWarning("[OBSOLETE] EndGameDisplay is deprecated. Use MenuSystemComposer instead.");
    }
    
    public void RestartGame()
    {
        if (MenuSystem.MenuSystemComposer.Instance != null)
            MenuSystem.MenuSystemComposer.Instance.LoadScene("Game");
    }
    
    public void GoToMainMenu()
    {
        if (MenuSystem.MenuSystemComposer.Instance != null)
            MenuSystem.MenuSystemComposer.Instance.LoadScene("MainMenu");
    }
    
    public void ExitGame()
    {
        if (MenuSystem.MenuSystemComposer.Instance != null)
            MenuSystem.MenuSystemComposer.Instance.QuitGame();
    }
}

#endregion