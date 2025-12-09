using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// Script temporal para diagnosticar problemas de rendering
/// </summary>
public class URPDebugChecker : MonoBehaviour
{
    private void Start()
    {
        CheckRenderPipeline();
        CheckCamera();
        CheckLights();
    }

    private void CheckRenderPipeline()
    {
        var currentPipeline = GraphicsSettings.currentRenderPipeline;
        if (currentPipeline == null)
        {
            Debug.LogError("[URPDebug] ❌ NO hay Render Pipeline configurado! Ve a Project Settings → Graphics");
        }
        else
        {
            Debug.Log($"[URPDebug] ✅ Render Pipeline activo: {currentPipeline.name}");
        }
    }

    private void CheckCamera()
    {
        var mainCam = Camera.main;
        if (mainCam == null)
        {
            Debug.LogError("[URPDebug] ❌ NO hay Camera.main en la escena!");
        }
        else
        {
            Debug.Log($"[URPDebug] ✅ Camera encontrada: {mainCam.name}");
            Debug.Log($"[URPDebug]    - Clear Flags: {mainCam.clearFlags}");
            Debug.Log($"[URPDebug]    - Background: {mainCam.backgroundColor}");
            Debug.Log($"[URPDebug]    - Culling Mask: {mainCam.cullingMask}");
        }
    }

    private void CheckLights()
    {
        var lights = FindObjectsOfType<Light>();
        Debug.Log($"[URPDebug] Luces encontradas: {lights.Length}");
        
#if UNITY_2022_3_OR_NEWER
        var lights2D = FindObjectsOfType<UnityEngine.Rendering.Universal.Light2D>();
        Debug.Log($"[URPDebug] Light2D encontradas: {lights2D.Length}");
        
        if (lights2D.Length == 0)
        {
            Debug.LogWarning("[URPDebug] ⚠️ NO hay luces 2D en la escena. La escena estará oscura.");
        }
#endif
    }
}
