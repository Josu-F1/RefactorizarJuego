using UnityEditor;
using UnityEngine;

/// <summary>
/// Configuración automática del editor para evitar conexiones inseguras
/// </summary>
[InitializeOnLoad]
public class EditorSecuritySettings
{
    static EditorSecuritySettings()
    {
        // Configurar el editor para evitar verificaciones de actualizaciones automáticas
        ConfigureEditorSettings();
    }
    
    static void ConfigureEditorSettings()
    {
        // Deshabilitar verificaciones automáticas que puedan causar conexiones HTTP
        EditorPrefs.SetBool("AstarDisableUpdateChecks", true);
        
        // Configurar la última verificación para evitar nuevos intentos
        EditorPrefs.SetString("AstarLastUpdateCheck", System.DateTime.UtcNow.AddYears(1).ToString(System.Globalization.CultureInfo.InvariantCulture));
        
        Debug.Log("EditorSecuritySettings: Configuración aplicada para evitar conexiones inseguras.");
    }
    
    [MenuItem("Tools/Security/Disable Insecure Connections")]
    static void DisableInsecureConnectionsManually()
    {
        ConfigureEditorSettings();
        Debug.Log("Configuración de seguridad aplicada manualmente.");
    }
}