using UnityEngine;

// Script simple para Unity 2022.3+ que no usa APIs problemáticas
public class DisableUnityServices
{
    // Este script existe principalmente para documentar que los servicios
    // de Unity están deshabilitados via UnityConnectSettings.asset
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void DisableRuntimeServices()
    {
        // Los servicios ya están deshabilitados en UnityConnectSettings.asset
        Debug.Log("Servicios de Unity configurados para estar deshabilitados.");
    }
}