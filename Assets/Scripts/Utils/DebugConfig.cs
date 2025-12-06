using UnityEngine;

/// <summary>
/// Configuración centralizada para debugging
/// Permite deshabilitar logs en producción
/// </summary>
public static class DebugConfig
{
    // Cambiar a false para deshabilitar todos los logs de debug
    public const bool EnableDebugLogs = false;
    
    // Categorías específicas de logs
    public const bool EnableCharacterLogs = false;
    public const bool EnableVFXLogs = false;
    public const bool EnableAudioLogs = false;
    public const bool EnablePickupLogs = false;
    public const bool EnableMenuLogs = false;
    
    /// <summary>
    /// Log condicional que solo muestra en modo debug
    /// </summary>
    public static void Log(string message, LogCategory category = LogCategory.General)
    {
        #pragma warning disable CS0162 // Unreachable code detected
        if (!EnableDebugLogs) return;
        
        bool shouldLog = GetShouldLog(category);
        
        if (shouldLog)
        {
            Debug.Log(message);
        }
        #pragma warning restore CS0162
    }
    
    private static bool GetShouldLog(LogCategory category)
    {
        return category switch
        {
            LogCategory.Character => EnableCharacterLogs,
            LogCategory.VFX => EnableVFXLogs,
            LogCategory.Audio => EnableAudioLogs,
            LogCategory.Pickup => EnablePickupLogs,
            LogCategory.Menu => EnableMenuLogs,
            _ => true
        };
    }
    
    /// <summary>
    /// Log de warnings - siempre se muestra
    /// </summary>
    public static void LogWarning(string message)
    {
        Debug.LogWarning(message);
    }
    
    /// <summary>
    /// Log de errores - siempre se muestra
    /// </summary>
    public static void LogError(string message)
    {
        Debug.LogError(message);
    }
}

public enum LogCategory
{
    General,
    Character,
    VFX,
    Audio,
    Pickup,
    Menu,
    System
}
