using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sistema de comandos para menús
/// Patrón: Command Pattern - Encapsula acciones del menú como objetos
/// Principio: Single Responsibility Principle (SRP) - Cada comando tiene una responsabilidad
/// Principio: Open/Closed Principle (OCP) - Fácil agregar nuevos comandos sin modificar existentes
/// </summary>

namespace MenuSystem.Commands
{
    // Interfaz base para comandos de menú
    public interface IMenuCommand
    {
        void Execute();
        void Undo();
        bool CanExecute();
    }

    // Comando base abstracto
    public abstract class BaseMenuCommand : IMenuCommand
    {
        protected bool executed = false;
        
        public abstract void Execute();
        public abstract void Undo();
        public virtual bool CanExecute() => true;
    }

    // Comando para cargar escena
    public class LoadSceneCommand : BaseMenuCommand
    {
        private readonly string sceneName;
        private readonly Action<string> onSceneLoad;
        
        public LoadSceneCommand(string sceneName, Action<string> onSceneLoad = null)
        {
            this.sceneName = sceneName;
            this.onSceneLoad = onSceneLoad;
        }
        
        public override void Execute()
        {
            if (!CanExecute()) return;
            
            try
            {
                onSceneLoad?.Invoke(sceneName);
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
                executed = true;
                Debug.Log($"[LoadSceneCommand] Loading scene: {sceneName}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"[LoadSceneCommand] Error loading scene {sceneName}: {ex.Message}");
            }
        }
        
        public override void Undo()
        {
            // No se puede deshacer la carga de escena de forma directa
            Debug.LogWarning("[LoadSceneCommand] Scene load cannot be undone");
        }
        
        public override bool CanExecute()
        {
            return !string.IsNullOrEmpty(sceneName);
        }
    }

    // Comando para mostrar/ocultar panel
    public class TogglePanelCommand : BaseMenuCommand
    {
        private readonly GameObject panel;
        private readonly bool targetState;
        private bool previousState;
        
        public TogglePanelCommand(GameObject panel, bool show)
        {
            this.panel = panel;
            this.targetState = show;
        }
        
        public override void Execute()
        {
            if (!CanExecute()) return;
            
            previousState = panel.activeInHierarchy;
            panel.SetActive(targetState);
            executed = true;
            Debug.Log($"[TogglePanelCommand] Panel {panel.name} set to: {targetState}");
        }
        
        public override void Undo()
        {
            if (executed && panel != null)
            {
                panel.SetActive(previousState);
                executed = false;
                Debug.Log($"[TogglePanelCommand] Panel {panel.name} restored to: {previousState}");
            }
        }
        
        public override bool CanExecute()
        {
            return panel != null;
        }
    }

    // Comando para logout
    public class LogoutCommand : BaseMenuCommand
    {
        private readonly ISessionManager sessionManager;
        private readonly Action onLogoutComplete;
        private string previousUsername;
        
        public LogoutCommand(ISessionManager sessionManager, Action onLogoutComplete = null)
        {
            this.sessionManager = sessionManager;
            this.onLogoutComplete = onLogoutComplete;
        }
        
        public override void Execute()
        {
            if (!CanExecute()) return;
            
            previousUsername = sessionManager.CurrentUsername;
            sessionManager.EndSession();
            onLogoutComplete?.Invoke();
            executed = true;
            Debug.Log($"[LogoutCommand] User {previousUsername} logged out");
        }
        
        public override void Undo()
        {
            if (executed && !string.IsNullOrEmpty(previousUsername))
            {
                // En un sistema real, esto requeriría re-autenticación
                Debug.LogWarning("[LogoutCommand] Logout cannot be undone - requires re-authentication");
            }
        }
        
        public override bool CanExecute()
        {
            return sessionManager != null && sessionManager.HasActiveSession;
        }
    }

    // Comando para salir de la aplicación
    public class QuitApplicationCommand : BaseMenuCommand
    {
        private readonly Action onQuitRequested;
        
        public QuitApplicationCommand(Action onQuitRequested = null)
        {
            this.onQuitRequested = onQuitRequested;
        }
        
        public override void Execute()
        {
            if (!CanExecute()) return;
            
            onQuitRequested?.Invoke();
            executed = true;
            Debug.Log("[QuitApplicationCommand] Quitting application");
            
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
        
        public override void Undo()
        {
            Debug.LogWarning("[QuitApplicationCommand] Application quit cannot be undone");
        }
        
        public override bool CanExecute()
        {
            return true;
        }
    }

    // Invoker - Ejecutor de comandos con historial
    public class MenuCommandInvoker
    {
        private readonly Stack<IMenuCommand> commandHistory = new Stack<IMenuCommand>();
        private readonly int maxHistorySize = 10;
        
        public void ExecuteCommand(IMenuCommand command)
        {
            if (command != null && command.CanExecute())
            {
                command.Execute();
                
                // Mantener historial limitado
                if (commandHistory.Count >= maxHistorySize)
                {
                    var oldCommands = new IMenuCommand[maxHistorySize - 1];
                    for (int i = 0; i < maxHistorySize - 1; i++)
                    {
                        oldCommands[i] = commandHistory.Pop();
                    }
                    commandHistory.Clear();
                    for (int i = maxHistorySize - 2; i >= 0; i--)
                    {
                        commandHistory.Push(oldCommands[i]);
                    }
                }
                
                commandHistory.Push(command);
            }
        }
        
        public void UndoLastCommand()
        {
            if (commandHistory.Count > 0)
            {
                var lastCommand = commandHistory.Pop();
                lastCommand.Undo();
            }
        }
        
        public void ClearHistory()
        {
            commandHistory.Clear();
        }
        
        public int HistoryCount => commandHistory.Count;
    }
}