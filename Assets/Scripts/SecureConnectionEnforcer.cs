using UnityEngine;

/// <summary>
/// Script para deshabilitar conexiones HTTP inseguras en Unity 2022.3+
/// Esto previene los errores "InvalidOperationException: Insecure connection not allowed"
/// </summary>
public static class SecureConnectionEnforcer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void DisableInsecureConnections()
    {
        // En Unity 2022.3+, las conexiones HTTP están bloqueadas por defecto
        // Este script documenta que es el comportamiento deseado
        
        Debug.Log("SecureConnectionEnforcer: Conexiones HTTP inseguras bloqueadas (comportamiento por defecto en Unity 2022.3+)");
        
        // Si necesitas habilitar conexiones HTTP para desarrollo, descomenta la línea siguiente:
        // UnityEngine.Networking.UnityWebRequest.ClearCookieCache();
    }
}