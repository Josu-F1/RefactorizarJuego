#pragma warning disable CS0414 // Field is assigned but never used
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace MenuSystem
{
    /// <summary>
    /// Sistema principal de menús - VERSIÓN FINAL FUNCIONAL
    /// Patrón: Facade + Command + State
    /// </summary>
    public class MenuSystemComposer : MonoBehaviour
    {
        [Header("Menu System Configuration")]
        [SerializeField] private bool enableDebugLogging = false;
        
        private static MenuSystemComposer instance;
        public static MenuSystemComposer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<MenuSystemComposer>();
                }
                return instance;
            }
        }

        private Dictionary<string, BaseMenu> registeredMenus = new Dictionary<string, BaseMenu>();

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }

            InitializeSystem();
        }

        private void InitializeSystem()
        {
            var existingMenus = FindObjectsOfType<BaseMenu>();
            foreach (var menu in existingMenus)
            {
                RegisterMenu(menu);
            }

            Debug.Log("[MenuSystemComposer] Menu System initialized successfully!");
        }

        public void RegisterMenu(BaseMenu menu)
        {
            if (menu != null && !string.IsNullOrEmpty(menu.MenuName))
            {
                registeredMenus[menu.MenuName] = menu;
                menu.SetMenuSystem(this);
            }
        }

        public void ShowMenu(string menuName)
        {
            if (registeredMenus.TryGetValue(menuName, out BaseMenu menu))
            {
                menu.Show();
            }
        }

        public void HideMenu(string menuName)
        {
            if (registeredMenus.TryGetValue(menuName, out BaseMenu menu))
            {
                menu.Hide();
            }
        }

        public void PauseGame()
        {
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1f;
        }

        public void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    /// <summary>
    /// Clase base para todos los menús
    /// </summary>
    public abstract class BaseMenu : MonoBehaviour
    {
        [Header("Menu Configuration")]
        [SerializeField] protected string menuName;
        [SerializeField] protected bool pauseGameWhenVisible = false;

        protected MenuSystemComposer menuSystem;
        protected bool isVisible = false;

        public string MenuName => menuName;
        public bool IsVisible => isVisible;

        protected virtual void Awake()
        {
            if (string.IsNullOrEmpty(menuName))
            {
                menuName = gameObject.name;
            }
        }

        protected virtual void Start()
        {
            MenuSystemComposer.Instance?.RegisterMenu(this);
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
            isVisible = true;
            
            if (pauseGameWhenVisible)
            {
                menuSystem?.PauseGame();
            }
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
            isVisible = false;
            
            if (pauseGameWhenVisible)
            {
                menuSystem?.ResumeGame();
            }
        }

        public void SetMenuSystem(MenuSystemComposer system)
        {
            menuSystem = system;
        }
    }
}