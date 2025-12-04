using System;
using UnityEngine;

/// <summary>
/// Estados del sistema de menús
/// Patrón: State Pattern - Diferentes comportamientos según el estado del menú
/// Principio: Single Responsibility Principle (SRP) - Cada estado maneja su propio comportamiento
/// Principio: Open/Closed Principle (OCP) - Fácil agregar nuevos estados
/// </summary>
/// 
namespace MenuSystem.States
{
    // Contexto del estado del menú
    public interface IMenuStateContext
    {
        void ChangeState(IMenuState newState);
        void ShowPanel(GameObject panel);
        void HidePanel(GameObject panel);
        void UpdateWelcomeText(string text);
    }

    // Interfaz base para estados de menú
    public interface IMenuState
    {
        void EnterState(IMenuStateContext context);
        void ExitState(IMenuStateContext context);
        void HandleInput(IMenuStateContext context, string inputType);
        void Update(IMenuStateContext context);
        string StateName { get; }
    }

    // Estado base abstracto
    public abstract class BaseMenuState : IMenuState
    {
        public abstract string StateName { get; }
        
        public virtual void EnterState(IMenuStateContext context)
        {
            Debug.Log($"[MenuState] Entering {StateName} state");
        }
        
        public virtual void ExitState(IMenuStateContext context)
        {
            Debug.Log($"[MenuState] Exiting {StateName} state");
        }
        
        public abstract void HandleInput(IMenuStateContext context, string inputType);
        
        public virtual void Update(IMenuStateContext context)
        {
            // Override in derived classes if needed
        }
    }

    // Estado: No autenticado (mostrando login)
    public class UnauthenticatedState : BaseMenuState
    {
        public override string StateName => "Unauthenticated";
        
        public override void EnterState(IMenuStateContext context)
        {
            base.EnterState(context);
            
            // Usar el método del context que maneja los paneles asignados
            // El RefactoredMainMenu ya tiene referencias a los paneles
            if (context is RefactoredMainMenu menu)
            {
                // Mostrar login panel
                if (menu.LoginPanel != null) 
                {
                    context.ShowPanel(menu.LoginPanel);
                    Debug.Log("[UnauthenticatedState] Showing LoginPanel");
                }
                
                // Ocultar otros paneles ESPECÍFICOS, no MainMenuCanvas completo
                // Buscar elementos específicos dentro del Canvas
                var background = GameObject.Find("Background");
                var gameName = GameObject.Find("GameName");
                var playButton = GameObject.Find("PlayButton");
                var tutorialButton = GameObject.Find("TutorialButton");
                var helpButton = GameObject.Find("HelpButton");
                var quitButton = GameObject.Find("QuitButton");
                
                // Ocultar elementos del menú principal
                if (background != null) background.SetActive(false);
                if (gameName != null) gameName.SetActive(false);
                if (playButton != null) playButton.SetActive(false);
                if (tutorialButton != null) tutorialButton.SetActive(false);
                if (helpButton != null) helpButton.SetActive(false);
                if (quitButton != null) quitButton.SetActive(false);
                
                // Ocultar otros paneles
                if (menu.RegisterPanel != null) context.HidePanel(menu.RegisterPanel);
                if (menu.HelpPanel != null) context.HidePanel(menu.HelpPanel);
                if (menu.LoadingPanel != null) context.HidePanel(menu.LoadingPanel);
            }
            
            context.UpdateWelcomeText("");
        }
        
        public override void HandleInput(IMenuStateContext context, string inputType)
        {
            switch (inputType.ToLower())
            {
                case "login_success":
                    // Después del login exitoso, ir al menú principal autenticado
                    context.ChangeState(new AuthenticatedState());
                    break;
                case "show_register":
                    Debug.Log("[UnauthenticatedState] Switching to RegisteringState");
                    context.ChangeState(new RegisteringState());
                    break;
                case "back":
                case "cancel":
                    // Volver al menú principal
                    context.ChangeState(new MainMenuState());
                    break;
                case "quit":
                    // Permitir salir sin autenticación
                    Application.Quit();
                    break;
                default:
                    Debug.LogWarning($"[UnauthenticatedState] Unhandled input: {inputType}");
                    break;
            }
        }
    }

    // Estado: Registrándose
    public class RegisteringState : BaseMenuState
    {
        public override string StateName => "Registering";
        
        public override void EnterState(IMenuStateContext context)
        {
            base.EnterState(context);
            
            if (context is RefactoredMainMenu menu)
            {
                Debug.Log("[RegisteringState] Hiding LoginPanel");
                if (menu.LoginPanel != null) context.HidePanel(menu.LoginPanel);
                
                Debug.Log($"[RegisteringState] RegisterPanel is: {(menu.RegisterPanel != null ? menu.RegisterPanel.name : "NULL")}");
                if (menu.RegisterPanel != null) 
                {
                    Debug.Log("[RegisteringState] Showing RegisterPanel");
                    context.ShowPanel(menu.RegisterPanel);
                }
                else
                {
                    Debug.LogError("[RegisteringState] RegisterPanel is NULL!");
                }
                
                if (menu.MainMenuPanel != null) context.HidePanel(menu.MainMenuPanel);
                if (menu.HelpPanel != null) context.HidePanel(menu.HelpPanel);
                if (menu.LoadingPanel != null) context.HidePanel(menu.LoadingPanel);
            }
        }
        
        public override void HandleInput(IMenuStateContext context, string inputType)
        {
            switch (inputType.ToLower())
            {
                case "registration_success":
                    // Después del registro exitoso, ir al menú principal autenticado
                    context.ChangeState(new AuthenticatedState());
                    break;
                case "show_login":
                case "cancel_registration":
                    context.ChangeState(new UnauthenticatedState());
                    break;
                case "back":
                case "cancel":
                    // Volver al menú principal
                    context.ChangeState(new MainMenuState());
                    break;
                default:
                    Debug.LogWarning($"[RegisteringState] Unhandled input: {inputType}");
                    break;
            }
        }
    }

    // Estado: Menú principal (sin autenticar aún)
    public class MainMenuState : BaseMenuState
    {
        public override string StateName => "MainMenu";
        
        public override void EnterState(IMenuStateContext context)
        {
            base.EnterState(context);
            
            if (context is RefactoredMainMenu menu)
            {
                if (menu.LoginPanel != null) context.HidePanel(menu.LoginPanel);
                if (menu.RegisterPanel != null) context.HidePanel(menu.RegisterPanel);
                if (menu.MainMenuPanel != null) context.ShowPanel(menu.MainMenuPanel);
                if (menu.HelpPanel != null) context.HidePanel(menu.HelpPanel);
                if (menu.LoadingPanel != null) context.HidePanel(menu.LoadingPanel);
            }
            
            context.UpdateWelcomeText("¡Bienvenido a Boom Master!");
        }
        
        public override void HandleInput(IMenuStateContext context, string inputType)
        {
            switch (inputType.ToLower())
            {
                case "play":
                    // Al hacer clic en Play, ir al login
                    context.ChangeState(new UnauthenticatedState());
                    break;
                case "tutorial":
                    context.ChangeState(new LoadingTutorialState());
                    break;
                case "help":
                    context.ChangeState(new HelpState());
                    break;
                case "quit":
                    Application.Quit();
                    break;
                default:
                    Debug.LogWarning($"[MainMenuState] Unhandled input: {inputType}");
                    break;
            }
        }
    }

    // Estado: Autenticado (menú principal disponible)
    public class AuthenticatedState : BaseMenuState
    {
        public override string StateName => "Authenticated";
        
        public override void EnterState(IMenuStateContext context)
        {
            base.EnterState(context);
            
            if (context is RefactoredMainMenu menu)
            {
                // Ocultar paneles de autenticación
                if (menu.LoginPanel != null) context.HidePanel(menu.LoginPanel);
                if (menu.RegisterPanel != null) context.HidePanel(menu.RegisterPanel);
                if (menu.HelpPanel != null) context.HidePanel(menu.HelpPanel);
                if (menu.LoadingPanel != null) context.HidePanel(menu.LoadingPanel);
                
                // Mostrar menú principal
                if (menu.MainMenuPanel != null) context.ShowPanel(menu.MainMenuPanel);
            }
            
            // Actualizar texto de bienvenida
            var sessionManager = new SessionManager();
            if (sessionManager != null && sessionManager.HasActiveSession)
            {
                context.UpdateWelcomeText($"¡Bienvenido, {sessionManager.CurrentUsername}!");
            }
            else
            {
                context.UpdateWelcomeText("¡Bienvenido a Boom Master!");
            }
        }
        
        public override void HandleInput(IMenuStateContext context, string inputType)
        {
            switch (inputType.ToLower())
            {
                case "play":
                    context.ChangeState(new LoadingGameState());
                    break;
                case "tutorial":
                    context.ChangeState(new LoadingTutorialState());
                    break;
                case "help":
                    context.ChangeState(new HelpState());
                    break;
                case "logout":
                    context.ChangeState(new UnauthenticatedState());
                    break;
                case "quit":
                    Application.Quit();
                    break;
                default:
                    Debug.LogWarning($"[AuthenticatedState] Unhandled input: {inputType}");
                    break;
            }
        }
    }

    // Estado: Cargando juego
    public class LoadingGameState : BaseMenuState
    {
        public override string StateName => "LoadingGame";
        
        public override void EnterState(IMenuStateContext context)
        {
            base.EnterState(context);
            
            // Mostrar indicador de carga si existe
            var loadingPanel = GameObject.Find("LoadingPanel");
            if (loadingPanel != null) context.ShowPanel(loadingPanel);
            
            context.UpdateWelcomeText("Cargando juego...");
            
            // Cargar escena del juego
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameLevel");
        }
        
        public override void HandleInput(IMenuStateContext context, string inputType)
        {
            // Durante la carga, generalmente no se aceptan inputs
            Debug.Log($"[LoadingGameState] Input ignored during loading: {inputType}");
        }
    }

    // Estado: Cargando tutorial  
    public class LoadingTutorialState : BaseMenuState
    {
        public override string StateName => "LoadingTutorial";
        
        public override void EnterState(IMenuStateContext context)
        {
            base.EnterState(context);
            
            context.UpdateWelcomeText("Cargando tutorial...");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
        }
        
        public override void HandleInput(IMenuStateContext context, string inputType)
        {
            Debug.Log($"[LoadingTutorialState] Input ignored during loading: {inputType}");
        }
    }

    // Estado: Mostrando ayuda
    public class HelpState : BaseMenuState
    {
        public override string StateName => "Help";
        
        public override void EnterState(IMenuStateContext context)
        {
            base.EnterState(context);
            
            var helpPanel = GameObject.Find("HelpPanel");
            if (helpPanel != null) 
            {
                context.ShowPanel(helpPanel);
            }
            else
            {
                Debug.LogWarning("[HelpState] HelpPanel not found, returning to authenticated state");
                context.ChangeState(new AuthenticatedState());
            }
        }
        
        public override void HandleInput(IMenuStateContext context, string inputType)
        {
            switch (inputType.ToLower())
            {
                case "close_help":
                case "back":
                    context.ChangeState(new AuthenticatedState());
                    break;
                default:
                    Debug.LogWarning($"[HelpState] Unhandled input: {inputType}");
                    break;
            }
        }
    }
}