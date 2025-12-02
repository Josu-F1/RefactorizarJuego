using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using LightSystem.Interfaces;

namespace LightSystem.Model
{
    // ============= LIGHT DATA IMPLEMENTATION =============
    [System.Serializable]
    public class LightData : ILightData
    {
        [SerializeField] private float intensity;
        [SerializeField] private Color lightColor;
        [SerializeField] private bool isEnabled;
        [SerializeField] private CustomLightType lightType;
        [SerializeField] private float range;

        public float Intensity => intensity;
        public Color LightColor => lightColor;
        public bool IsEnabled => isEnabled;
        public CustomLightType LightType => lightType;
        public float Range => range;

        public LightData(float intensity = 1f, Color color = default, bool enabled = true, 
                        CustomLightType type = CustomLightType.Global, float range = 10f)
        {
            this.intensity = intensity;
            this.lightColor = color == default ? Color.white : color;
            this.isEnabled = enabled;
            this.lightType = type;
            this.range = range;
        }

        public void UpdateData(float newIntensity, Color newColor, bool newEnabled)
        {
            intensity = newIntensity;
            lightColor = newColor;
            isEnabled = newEnabled;
        }

        public void SetIntensity(float newIntensity)
        {
            intensity = Mathf.Clamp01(newIntensity);
        }

        public void SetColor(Color newColor)
        {
            lightColor = newColor;
        }

        public void SetEnabled(bool enabled)
        {
            isEnabled = enabled;
        }
    }

    // ============= LIGHT CONFIGURATION =============
    [System.Serializable]
    public class LightConfiguration : ILightConfiguration
    {
        [SerializeField] private float defaultIntensity = 1f;
        [SerializeField] private Color defaultColor = Color.white;
        [SerializeField] private float fadeSpeed = 1f;
        [SerializeField] private float blinkSpeed = 2f;
        [SerializeField] private bool autoRestore = true;

        public float DefaultIntensity => defaultIntensity;
        public Color DefaultColor => defaultColor;
        public float FadeSpeed => fadeSpeed;
        public float BlinkSpeed => blinkSpeed;
        public bool AutoRestore => autoRestore;

        public LightConfiguration(LightConfigurationData data)
        {
            defaultIntensity = data.defaultIntensity;
            defaultColor = data.defaultColor;
            fadeSpeed = data.fadeSpeed;
            blinkSpeed = data.blinkSpeed;
            autoRestore = data.autoRestore;
        }

        public LightConfiguration(float intensity = 1f, Color color = default, float fade = 1f, float blink = 2f, bool restore = true)
        {
            defaultIntensity = intensity;
            defaultColor = color == default ? Color.white : color;
            fadeSpeed = fade;
            blinkSpeed = blink;
            autoRestore = restore;
        }
    }

    // ============= LIGHT SUBJECT (OBSERVER PATTERN) =============
    [System.Serializable]
    public class LightSubject : ILightSubject
    {
        private readonly List<ILightObserver> observers;
        private readonly ILightData lightData;

        public LightSubject(ILightData data)
        {
            observers = new List<ILightObserver>();
            lightData = data ?? throw new System.ArgumentNullException(nameof(data));
        }

        public void Subscribe(ILightObserver observer)
        {
            if (observer == null) return;
            
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                // Sort by priority for ordered notifications
                observers.Sort((a, b) => b.Priority.CompareTo(a.Priority));
            }
        }

        public void Unsubscribe(ILightObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyLightChanged()
        {
            foreach (var observer in observers)
            {
                try
                {
                    observer.OnLightChanged(lightData);
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"Light observer error in OnLightChanged: {e.Message}");
                }
            }
        }

        public void NotifyLightEnabled()
        {
            foreach (var observer in observers)
            {
                try
                {
                    observer.OnLightEnabled(lightData);
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"Light observer error in OnLightEnabled: {e.Message}");
                }
            }
        }

        public void NotifyLightDisabled()
        {
            foreach (var observer in observers)
            {
                try
                {
                    observer.OnLightDisabled(lightData);
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"Light observer error in OnLightDisabled: {e.Message}");
                }
            }
        }

        public void NotifyIntensityChanged(float oldIntensity, float newIntensity)
        {
            foreach (var observer in observers)
            {
                try
                {
                    observer.OnLightIntensityChanged(oldIntensity, newIntensity);
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"Light observer error in OnLightIntensityChanged: {e.Message}");
                }
            }
        }

        public void ClearObservers()
        {
            observers.Clear();
        }

        public int ObserverCount => observers.Count;
    }

    // ============= LIGHT RENDERER IMPLEMENTATIONS =============
    [System.Serializable]
    public class Light2DRenderer : ILightRenderer
    {
#if UNITY_2022_3_OR_NEWER
        private UnityEngine.Rendering.Universal.Light2D light2DComponent;
#else
        private Component light2DComponent;
#endif
        private bool isLightSupported;

        public bool IsLightSupported => isLightSupported;

        public void Initialize(GameObject lightObject)
        {
#if UNITY_2022_3_OR_NEWER
            light2DComponent = lightObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
            isLightSupported = light2DComponent != null;
#else
            // Fallback using reflection for older versions
            System.Type light2DType = System.Type.GetType("UnityEngine.Rendering.Universal.Light2D, Unity.RenderPipelines.Universal.Runtime");
            if (light2DType == null)
            {
                light2DType = System.Type.GetType("UnityEngine.Experimental.Rendering.Universal.Light2D, Unity.RenderPipelines.Universal.Runtime");
            }

            if (light2DType != null)
            {
                light2DComponent = lightObject.GetComponent(light2DType);
                isLightSupported = light2DComponent != null;
            }
            else
            {
                isLightSupported = false;
                Debug.LogWarning("Light2DRenderer: Light2D type not available. Make sure URP package is installed.");
            }
#endif

            if (!isLightSupported)
            {
                Debug.LogWarning($"Light2DRenderer: No Light2D component found on {lightObject.name}");
            }
        }

        public void ApplyLightData(ILightData lightData)
        {
            if (!isLightSupported) return;

            SetLightEnabled(lightData.IsEnabled);
            SetLightIntensity(lightData.Intensity);
            SetLightColor(lightData.LightColor);
        }

        public void SetLightEnabled(bool enabled)
        {
            if (!isLightSupported) return;

#if UNITY_2022_3_OR_NEWER
            if (light2DComponent != null)
                light2DComponent.enabled = enabled;
#else
            if (light2DComponent != null)
            {
                var enabledProperty = light2DComponent.GetType().GetProperty("enabled");
                enabledProperty?.SetValue(light2DComponent, enabled);
            }
#endif
        }

        public void SetLightIntensity(float intensity)
        {
            if (!isLightSupported) return;

#if UNITY_2022_3_OR_NEWER
            if (light2DComponent != null)
                light2DComponent.intensity = intensity;
#else
            if (light2DComponent != null)
            {
                var intensityProperty = light2DComponent.GetType().GetProperty("intensity");
                intensityProperty?.SetValue(light2DComponent, intensity);
            }
#endif
        }

        public void SetLightColor(Color color)
        {
            if (!isLightSupported) return;

#if UNITY_2022_3_OR_NEWER
            if (light2DComponent != null)
                light2DComponent.color = color;
#else
            if (light2DComponent != null)
            {
                var colorProperty = light2DComponent.GetType().GetProperty("color");
                colorProperty?.SetValue(light2DComponent, color);
            }
#endif
        }
    }

    // ============= FALLBACK RENDERER =============
    [System.Serializable]
    public class FallbackLightRenderer : ILightRenderer
    {
        private Light lightComponent;
        private bool isLightSupported;

        public bool IsLightSupported => isLightSupported;

        public void Initialize(GameObject lightObject)
        {
            lightComponent = lightObject.GetComponent<Light>();
            isLightSupported = lightComponent != null;

            if (!isLightSupported)
            {
                Debug.LogWarning($"FallbackLightRenderer: No Light component found on {lightObject.name}");
            }
        }

        public void ApplyLightData(ILightData lightData)
        {
            if (!isLightSupported) return;

            SetLightEnabled(lightData.IsEnabled);
            SetLightIntensity(lightData.Intensity);
            SetLightColor(lightData.LightColor);
        }

        public void SetLightEnabled(bool enabled)
        {
            if (isLightSupported && lightComponent != null)
                lightComponent.enabled = enabled;
        }

        public void SetLightIntensity(float intensity)
        {
            if (isLightSupported && lightComponent != null)
                lightComponent.intensity = intensity;
        }

        public void SetLightColor(Color color)
        {
            if (isLightSupported && lightComponent != null)
                lightComponent.color = color;
        }
    }
}