using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/// <summary>
/// Navegador de UI aplicando Single Responsibility Principle
/// Principio: Single Responsibility Principle (SRP) - Solo navegación
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevos tipos de navegación
/// </summary>
public class UINavigator : IUINavigator
{
    private Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();
    
    public void RegisterPanel(string panelName, GameObject panel)
    {
        if (panel == null)
        {
            Debug.LogWarning($"[UINavigator] Cannot register null panel: {panelName}");
            return;
        }
        
        panels[panelName] = panel;
        Debug.Log($"[UINavigator] Panel '{panelName}' registered");
    }
    
    public void ShowPanel(string panelName)
    {
        if (panels.TryGetValue(panelName, out GameObject panel))
        {
            panel.SetActive(true);
            Debug.Log($"[UINavigator] Showing panel: {panelName}");
        }
        else
        {
            Debug.LogWarning($"[UINavigator] Panel not found: {panelName}");
        }
    }
    
    public void HidePanel(string panelName)
    {
        if (panels.TryGetValue(panelName, out GameObject panel))
        {
            panel.SetActive(false);
            Debug.Log($"[UINavigator] Hiding panel: {panelName}");
        }
        else
        {
            Debug.LogWarning($"[UINavigator] Panel not found: {panelName}");
        }
    }
    
    public void NavigateToScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("[UINavigator] Scene name is null or empty");
            return;
        }
        
        Debug.Log($"[UINavigator] Navigating to scene: {sceneName}");
        SceneManager.LoadScene(sceneName);
    }
    
    public void ShowOnlyPanel(string panelName)
    {
        // Ocultar todos los paneles
        foreach (var panel in panels.Values)
        {
            panel.SetActive(false);
        }
        
        // Mostrar solo el panel solicitado
        ShowPanel(panelName);
    }
}