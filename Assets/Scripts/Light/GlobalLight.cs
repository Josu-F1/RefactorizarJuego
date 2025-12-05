#if UNITY_2022_3_OR_NEWER
using UnityEngine.Rendering.Universal;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLight : MonoBehaviourSingleton<GlobalLight>
{
#if UNITY_2022_3_OR_NEWER
    private Light2D light2DComponent;
#else
    private Component lightComponent;
#endif
    
    protected override void Awake()
    {
        base.Awake();
        
#if UNITY_2022_3_OR_NEWER
        // En Unity 2022.3+, usar Light2D directamente
        light2DComponent = GetComponent<Light2D>();
        if (light2DComponent == null)
        {
            Debug.LogWarning("GlobalLight: No se encontró componente Light2D en el GameObject.");
        }
#else
        // Fallback usando reflexión para versiones anteriores
        System.Type light2DType = System.Type.GetType("UnityEngine.Rendering.Universal.Light2D, Unity.RenderPipelines.Universal.Runtime");
        if (light2DType == null)
        {
            light2DType = System.Type.GetType("UnityEngine.Experimental.Rendering.Universal.Light2D, Unity.RenderPipelines.Universal.Runtime");
        }

        if (light2DType != null)
        {
            lightComponent = GetComponent(light2DType);
            if (lightComponent == null)
            {
                Debug.LogWarning("GlobalLight: No se encontró componente Light2D en el GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("GlobalLight: Tipo Light2D no disponible. Asegúrate de que el paquete URP esté instalado.");
        }
#endif
    }
    
    public void TurnOff(float duration)
    {
        StartCoroutine(TurningOff(duration));
    }
    
    private IEnumerator TurningOff(float duration)
    {
        SetLightEnabled(false);
        yield return new WaitForSeconds(duration);
        SetLightEnabled(true);
    }
    
    private void SetLightEnabled(bool enabled)
    {
#if UNITY_2022_3_OR_NEWER
        if (light2DComponent != null)
        {
            light2DComponent.enabled = enabled;
        }
#else
        if (lightComponent != null)
        {
            // Usar reflexión para acceder a la propiedad enabled
            var enabledProperty = lightComponent.GetType().GetProperty("enabled");
            if (enabledProperty != null)
            {
                enabledProperty.SetValue(lightComponent, enabled);
            }
        }
#endif
    }
}
