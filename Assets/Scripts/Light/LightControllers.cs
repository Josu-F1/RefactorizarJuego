using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LightSystem.Interfaces;
using LightSystem.Model;
using LightSystem.Commands;
using LightSystem.Behaviors;
using CustomLightType = LightSystem.Interfaces.CustomLightType;

namespace LightSystem.Controllers
{
    // ============= LIGHT CONTROLLER =============
    [System.Serializable]
    public class LightController : ILightController
    {
        private readonly LightData lightData;
        private readonly ILightConfiguration configuration;
        private readonly ILightRenderer renderer;
        private readonly ILightSubject lightSubject;
        private readonly MonoBehaviour coroutineRunner;
        
        private ILightBehavior currentBehavior;
        private Coroutine currentOperation;

        public ILightData CurrentLightData => lightData;
        public bool IsOperationInProgress => currentOperation != null || (currentBehavior?.IsActive == true);

        public LightController(MonoBehaviour runner, ILightRenderer lightRenderer, 
                              ILightConfiguration config, ILightData initialData = null)
        {
            coroutineRunner = runner ?? throw new System.ArgumentNullException(nameof(runner));
            renderer = lightRenderer ?? throw new System.ArgumentNullException(nameof(lightRenderer));
            configuration = config ?? throw new System.ArgumentNullException(nameof(config));
            
            // Initialize light data
            if (initialData != null)
            {
                lightData = new LightData(initialData.Intensity, initialData.LightColor, 
                                        initialData.IsEnabled);
            }
            else
            {
                lightData = new LightData(config.DefaultIntensity, config.DefaultColor, true);
            }

            // Initialize subject for observer pattern
            lightSubject = new LightSubject(lightData);

            // Apply initial state to renderer
            renderer.ApplyLightData(lightData);
        }

        // ============= BASIC LIGHT OPERATIONS =============
        public void SetEnabled(bool enabled)
        {
            if (lightData.IsEnabled == enabled) return;

            bool wasEnabled = lightData.IsEnabled;
            lightData.SetEnabled(enabled);
            renderer.SetLightEnabled(enabled);

            // Notify observers
            if (enabled)
                lightSubject.NotifyLightEnabled();
            else
                lightSubject.NotifyLightDisabled();
            
            lightSubject.NotifyLightChanged();
        }

        public void SetIntensity(float intensity)
        {
            float clampedIntensity = Mathf.Clamp01(intensity);
            if (Mathf.Approximately(lightData.Intensity, clampedIntensity)) return;

            float oldIntensity = lightData.Intensity;
            lightData.SetIntensity(clampedIntensity);
            renderer.SetLightIntensity(clampedIntensity);

            // Notify observers
            lightSubject.NotifyIntensityChanged(oldIntensity, clampedIntensity);
            lightSubject.NotifyLightChanged();
        }

        public void SetColor(Color color)
        {
            if (lightData.LightColor == color) return;

            lightData.SetColor(color);
            renderer.SetLightColor(color);
            lightSubject.NotifyLightChanged();
        }

        // ============= ADVANCED OPERATIONS =============
        public void TurnOff(float duration)
        {
            if (currentOperation != null)
            {
                coroutineRunner.StopCoroutine(currentOperation);
            }

            currentOperation = coroutineRunner.StartCoroutine(TurnOffCoroutine(duration));
        }

        public void FadeIn(float duration)
        {
            var fadeBehavior = new FadeLightBehavior(configuration.DefaultIntensity);
            StartBehavior(fadeBehavior, duration);
        }

        public void FadeOut(float duration)
        {
            var fadeBehavior = new FadeLightBehavior(0f);
            StartBehavior(fadeBehavior, duration);
        }

        public void Blink(float duration, float interval)
        {
            var blinkBehavior = new BlinkLightBehavior(interval);
            StartBehavior(blinkBehavior, duration);
        }

        // ============= BEHAVIOR MANAGEMENT =============
        public void StartBehavior(ILightBehavior behavior, float duration)
        {
            StopCurrentBehavior();
            
            currentBehavior = behavior;
            if (currentBehavior != null)
            {
                currentBehavior.StartBehavior(this, duration);
                currentOperation = coroutineRunner.StartCoroutine(UpdateBehaviorCoroutine());
            }
        }

        public void StopCurrentBehavior()
        {
            if (currentOperation != null)
            {
                coroutineRunner.StopCoroutine(currentOperation);
                currentOperation = null;
            }

            currentBehavior?.StopBehavior();
            currentBehavior = null;
        }

        // ============= OBSERVER MANAGEMENT =============
        public void Subscribe(ILightObserver observer)
        {
            lightSubject.Subscribe(observer);
        }

        public void Unsubscribe(ILightObserver observer)
        {
            lightSubject.Unsubscribe(observer);
        }

        // ============= COROUTINES =============
        private IEnumerator TurnOffCoroutine(float duration)
        {
            SetEnabled(false);
            yield return new WaitForSeconds(duration);
            
            if (configuration.AutoRestore)
            {
                SetEnabled(true);
            }
            
            currentOperation = null;
        }

        private IEnumerator UpdateBehaviorCoroutine()
        {
            while (currentBehavior != null && currentBehavior.IsActive)
            {
                currentBehavior.UpdateBehavior(Time.deltaTime);
                yield return null;
            }

            currentBehavior = null;
            currentOperation = null;
        }

        // ============= CLEANUP =============
        public void Cleanup()
        {
            StopCurrentBehavior();
            if (lightSubject is LightSubject subject)
            {
                subject.ClearObservers();
            }
        }
    }

    // ============= LIGHT SERVICE =============
    [System.Serializable]
    public class LightService : ILightService
    {
        private readonly List<ILightController> registeredLights;

        public int RegisteredLightsCount => registeredLights.Count;

        public LightService()
        {
            registeredLights = new List<ILightController>();
        }

        public void RegisterLight(ILightController lightController)
        {
            if (lightController != null && !registeredLights.Contains(lightController))
            {
                registeredLights.Add(lightController);
            }
        }

        public void UnregisterLight(ILightController lightController)
        {
            registeredLights.Remove(lightController);
        }

        public void TurnOffAllLights(float duration)
        {
            foreach (var light in registeredLights)
            {
                light.TurnOff(duration);
            }
        }

        public void TurnOnAllLights()
        {
            foreach (var light in registeredLights)
            {
                light.SetEnabled(true);
            }
        }

        public void SetGlobalIntensity(float intensity)
        {
            float clampedIntensity = Mathf.Clamp01(intensity);
            foreach (var light in registeredLights)
            {
                light.SetIntensity(clampedIntensity);
            }
        }

        public void ApplyGlobalEffect(ILightEffect effect)
        {
            // Implementation would depend on ILightEffect interface
            // For now, placeholder
            Debug.Log($"Applied global effect: {effect?.EffectName}");
        }

        public ILightController[] GetAllLights()
        {
            return registeredLights.ToArray();
        }

        public void ClearAllLights()
        {
            registeredLights.Clear();
        }
    }

    // ============= LIGHT FACTORY =============
    [System.Serializable]
    public class LightFactory : ILightFactory
    {
        private readonly Dictionary<string, System.Func<ILightBehavior>> behaviorCreators;
        private readonly Dictionary<string, System.Func<ILightController, object[], ILightCommand>> commandCreators;

        public LightFactory()
        {
            behaviorCreators = new Dictionary<string, System.Func<ILightBehavior>>
            {
                { "Fade", () => new FadeLightBehavior() },
                { "FadeOut", () => new FadeLightBehavior(0f) },
                { "FadeIn", () => new FadeLightBehavior(1f) },
                { "Blink", () => new BlinkLightBehavior() },
                { "Pulse", () => new PulseLightBehavior() },
                { "Flicker", () => new FlickerLightBehavior() }
            };

            commandCreators = new Dictionary<string, System.Func<ILightController, object[], ILightCommand>>
            {
                { "SetEnabled", (controller, args) => new SetLightEnabledCommand(controller, (bool)args[0]) },
                { "SetIntensity", (controller, args) => new SetLightIntensityCommand(controller, (float)args[0]) },
                { "SetColor", (controller, args) => new SetLightColorCommand(controller, (Color)args[0]) },
                { "TurnOff", (controller, args) => new TurnOffLightCommand(controller, (float)args[0]) }
            };
        }

        public ILightController CreateLightController(GameObject lightObject, ILightConfiguration config)
        {
            if (lightObject == null || config == null) return null;

            // Create appropriate renderer
            ILightRenderer renderer = CreateRenderer(lightObject);
            if (renderer == null) return null;

            // Create controller
            var monoBehaviour = lightObject.GetComponent<MonoBehaviour>();
            if (monoBehaviour == null)
            {
                Debug.LogError($"LightFactory: GameObject {lightObject.name} needs a MonoBehaviour component for coroutines");
                return null;
            }

            return new LightController(monoBehaviour, renderer, config);
        }

        public ILightCommand CreateLightCommand(string commandType, ILightController controller, params object[] parameters)
        {
            if (commandCreators.ContainsKey(commandType))
            {
                try
                {
                    return commandCreators[commandType](controller, parameters);
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"LightFactory: Failed to create command {commandType}: {e.Message}");
                    return null;
                }
            }

            Debug.LogWarning($"LightFactory: Unknown command type: {commandType}");
            return null;
        }

        public ILightBehavior CreateLightBehavior(string behaviorType)
        {
            if (behaviorCreators.ContainsKey(behaviorType))
            {
                return behaviorCreators[behaviorType]();
            }

            Debug.LogWarning($"LightFactory: Unknown behavior type: {behaviorType}. Using Fade as default.");
            return new FadeLightBehavior();
        }

        public ILightEffect CreateLightEffect(string effectType, float duration)
        {
            // Placeholder - would create specific light effects
            Debug.LogWarning($"LightFactory: Light effects not yet implemented for {effectType}");
            return null;
        }

        private ILightRenderer CreateRenderer(GameObject lightObject)
        {
            // Try Light2D first
            var light2DRenderer = new Light2DRenderer();
            light2DRenderer.Initialize(lightObject);
            if (light2DRenderer.IsLightSupported)
                return light2DRenderer;

            // Fallback to regular Light
            var fallbackRenderer = new FallbackLightRenderer();
            fallbackRenderer.Initialize(lightObject);
            if (fallbackRenderer.IsLightSupported)
                return fallbackRenderer;

            Debug.LogError($"LightFactory: No supported light component found on {lightObject.name}");
            return null;
        }

        public void RegisterBehaviorType(string behaviorType, System.Func<ILightBehavior> creator)
        {
            behaviorCreators[behaviorType] = creator;
        }

        public void RegisterCommandType(string commandType, System.Func<ILightController, object[], ILightCommand> creator)
        {
            commandCreators[commandType] = creator;
        }
    }
}