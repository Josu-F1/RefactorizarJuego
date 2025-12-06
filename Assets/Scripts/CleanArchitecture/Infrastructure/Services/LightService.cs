using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Infrastructure.Services
{
    /// <summary>
    /// Servicio de sistema de iluminación - Clean Architecture
    /// Migrado desde LightSystemComposer
    /// </summary>
    public class LightService : ILightService
    {
        private readonly List<object> registeredLights;
        private float globalIntensity = 1f;
        private Color globalColor = Color.white;
        private bool allLightsEnabled = true;
        private readonly MonoBehaviour coroutineRunner;

        public int RegisteredLightCount => registeredLights.Count;

        public LightService(MonoBehaviour runner)
        {
            registeredLights = new List<object>();
            coroutineRunner = runner;
        }

        public void RegisterLight(object lightController)
        {
            if (lightController != null && !registeredLights.Contains(lightController))
            {
                registeredLights.Add(lightController);
                Debug.Log($"[LightService] Light registered. Total: {registeredLights.Count}");
            }
        }

        public void UnregisterLight(object lightController)
        {
            if (registeredLights.Remove(lightController))
            {
                Debug.Log($"[LightService] Light unregistered. Total: {registeredLights.Count}");
            }
        }

        public void SetGlobalIntensity(float intensity)
        {
            globalIntensity = Mathf.Clamp01(intensity);
            
            foreach (var light in registeredLights)
            {
                try
                {
                    var method = light.GetType().GetMethod("SetIntensity");
                    method?.Invoke(light, new object[] { globalIntensity });
                }
                catch (System.Exception ex)
                {
                    Debug.LogWarning($"[LightService] Error setting intensity: {ex.Message}");
                }
            }
            
            Debug.Log($"[LightService] Global intensity set to {globalIntensity}");
        }

        public void SetGlobalColor(Color color)
        {
            globalColor = color;
            
            foreach (var light in registeredLights)
            {
                try
                {
                    var method = light.GetType().GetMethod("SetColor");
                    method?.Invoke(light, new object[] { color });
                }
                catch (System.Exception ex)
                {
                    Debug.LogWarning($"[LightService] Error setting color: {ex.Message}");
                }
            }
            
            Debug.Log($"[LightService] Global color set to {color}");
        }

        public void SetAllLightsEnabled(bool enabled)
        {
            allLightsEnabled = enabled;
            
            foreach (var light in registeredLights)
            {
                try
                {
                    var method = light.GetType().GetMethod("SetEnabled");
                    method?.Invoke(light, new object[] { enabled });
                }
                catch (System.Exception ex)
                {
                    Debug.LogWarning($"[LightService] Error setting enabled state: {ex.Message}");
                }
            }
            
            Debug.Log($"[LightService] All lights enabled = {enabled}");
        }

        public void FadeGlobalIntensity(float targetIntensity, float duration)
        {
            if (coroutineRunner != null)
            {
                coroutineRunner.StartCoroutine(FadeIntensityCoroutine(targetIntensity, duration));
            }
        }

        private IEnumerator FadeIntensityCoroutine(float targetIntensity, float duration)
        {
            float startIntensity = globalIntensity;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duration;
                float currentIntensity = Mathf.Lerp(startIntensity, targetIntensity, t);
                SetGlobalIntensity(currentIntensity);
                yield return null;
            }

            SetGlobalIntensity(targetIntensity);
        }

        public void ClearAllLights()
        {
            registeredLights.Clear();
            Debug.Log("[LightService] All lights cleared");
        }
    }
}
