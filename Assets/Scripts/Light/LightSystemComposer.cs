#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;
using System.Collections.Generic;
using LightSystem.Interfaces;
using LightSystem.Model;
using LightSystem.Controllers;
using LightSystem.Commands;
using CustomLightType = LightSystem.Interfaces.CustomLightType;

namespace LightSystem
{
    // ============= LIGHT SYSTEM DATABASE =============
    [CreateAssetMenu(fileName = "LightSystemDatabase", menuName = "Light System/Database")]
    public class LightSystemDatabase : ScriptableObject
    {
        [Header("Default Configurations")]
        [SerializeField] private LightConfigurationData[] lightConfigurations;
        
        [Header("Global Settings")]
        [SerializeField] private float globalFadeSpeed = 1f;
        [SerializeField] private float globalBlinkSpeed = 2f;
        [SerializeField] private bool enableGlobalControls = true;
        [SerializeField] private bool autoRegisterLights = true;

        public LightConfigurationData[] LightConfigurations => lightConfigurations;
        public float GlobalFadeSpeed => globalFadeSpeed;
        public float GlobalBlinkSpeed => globalBlinkSpeed;
        public bool EnableGlobalControls => enableGlobalControls;
        public bool AutoRegisterLights => autoRegisterLights;
    }

    // ============= LIGHT COMPONENT =============
    public class LightComponent : MonoBehaviour
    {
        [Header("Light Configuration")]
        [SerializeField] private LightConfigurationData configurationData;
        [SerializeField] private bool autoRegister = true;
        [SerializeField] private CustomLightType lightType = CustomLightType.Global;

        [Header("Initial State")]
        [SerializeField] private float initialIntensity = 1f;
        [SerializeField] private Color initialColor = Color.white;
        [SerializeField] private bool startEnabled = true;

        private ILightController lightController;
        private LightSystemComposer systemComposer;

        public ILightController LightController => lightController;

        private void Awake()
        {
            systemComposer = FindObjectOfType<LightSystemComposer>();
            if (systemComposer == null)
            {
                Debug.LogError($"LightComponent ({gameObject.name}): No LightSystemComposer found in scene!");
                return;
            }

            InitializeLightController();
        }

        private void Start()
        {
            if (autoRegister && systemComposer != null && lightController != null)
            {
                systemComposer.LightService.RegisterLight(lightController);
            }
        }

        private void OnDestroy()
        {
            if (systemComposer?.LightService != null && lightController != null)
            {
                systemComposer.LightService.UnregisterLight(lightController);
            }

            if (lightController is LightController controller)
            {
                controller.Cleanup();
            }
        }

        private void InitializeLightController()
        {
            if (systemComposer?.LightFactory == null) return;

            // Create configuration
            var config = new LightConfiguration(configurationData);
            
            // Create initial light data
            var initialData = new LightData(initialIntensity, initialColor, startEnabled, lightType);

            // Create controller through factory
            lightController = systemComposer.LightFactory.CreateLightController(gameObject, config);
            
            if (lightController != null)
            {
                // Apply initial state
                lightController.SetIntensity(initialIntensity);
                lightController.SetColor(initialColor);
                lightController.SetEnabled(startEnabled);
            }
        }

        // ============= PUBLIC API =============
        public void TurnOff(float duration = 0f)
        {
            if (duration > 0f)
                lightController?.TurnOff(duration);
            else
                lightController?.SetEnabled(false);
        }

        public void TurnOn()
        {
            lightController?.SetEnabled(true);
        }

        public void SetIntensity(float intensity)
        {
            lightController?.SetIntensity(intensity);
        }

        public void SetColor(Color color)
        {
            lightController?.SetColor(color);
        }

        public void FadeIn(float duration)
        {
            lightController?.FadeIn(duration);
        }

        public void FadeOut(float duration)
        {
            lightController?.FadeOut(duration);
        }

        public void Blink(float duration, float interval = 0.5f)
        {
            lightController?.Blink(duration, interval);
        }

        public void Subscribe(ILightObserver observer)
        {
            if (lightController is LightController controller)
            {
                controller.Subscribe(observer);
            }
        }

        public void Unsubscribe(ILightObserver observer)
        {
            if (lightController is LightController controller)
            {
                controller.Unsubscribe(observer);
            }
        }
    }

    // ============= MAIN LIGHT SYSTEM COMPOSER =============
    [System.Obsolete("LightSystemComposer is deprecated. Use ILightService from ServiceLocator instead.")]
    public class LightSystemComposer : MonoBehaviour, ILightSystemComposer
    {
        [Header("System Configuration")]
        [SerializeField] private LightSystemDatabase systemDatabase;

        [Header("Global Controls")]
        [SerializeField] private KeyCode globalToggleKey = KeyCode.L;
        [SerializeField] private KeyCode globalDimKey = KeyCode.LeftShift;

        // ============= SYSTEM COMPONENTS =============
        private LightFactory lightFactory;
        private LightService lightService;
        private LightCommandInvoker commandInvoker;

        // ============= INTERFACE PROPERTIES =============
        public ILightService LightService => lightService;
        public ILightFactory LightFactory => lightFactory;
        public ILightCommandInvoker CommandInvoker => commandInvoker;

        // ============= UNITY LIFECYCLE =============
        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            HandleGlobalInput();
        }

        private void OnDestroy()
        {
            Cleanup();
        }

        // ============= INITIALIZATION =============
        public void Initialize()
        {
            if (!ValidateConfiguration())
                return;

            // Create core components
            lightFactory = new LightFactory();
            lightService = new LightService();
            commandInvoker = new LightCommandInvoker();

            // Auto-register existing lights if enabled
            if (systemDatabase.AutoRegisterLights)
            {
                AutoRegisterExistingLights();
            }

            Debug.Log("LightSystemComposer initialized successfully with Observer + Command Pattern");
        }

        public void Cleanup()
        {
            lightService?.ClearAllLights();
            commandInvoker?.ClearHistory();
            
            lightFactory = null;
            lightService = null;
            commandInvoker = null;
        }

        // ============= VALIDATION =============
        private bool ValidateConfiguration()
        {
            if (systemDatabase == null)
            {
                Debug.LogError("LightSystemComposer: systemDatabase is null!");
                return false;
            }

            return true;
        }

        // ============= AUTO REGISTRATION =============
        private void AutoRegisterExistingLights()
        {
            var lightComponents = FindObjectsOfType<LightComponent>();
            foreach (var lightComp in lightComponents)
            {
                if (lightComp.LightController != null)
                {
                    lightService.RegisterLight(lightComp.LightController);
                }
            }

            Debug.Log($"Auto-registered {lightComponents.Length} light components");
        }

        // ============= GLOBAL INPUT HANDLING =============
        private void HandleGlobalInput()
        {
            if (!systemDatabase.EnableGlobalControls) return;

            if (Input.GetKeyDown(globalToggleKey))
            {
                ToggleAllLights();
            }

            if (Input.GetKey(globalDimKey))
            {
                DimAllLights();
            }
            else if (Input.GetKeyUp(globalDimKey))
            {
                RestoreAllLights();
            }
        }

        // ============= GLOBAL LIGHT OPERATIONS =============
        public void ToggleAllLights()
        {
            var lights = lightService.GetAllLights();
            foreach (var light in lights)
            {
                bool newState = !light.CurrentLightData.IsEnabled;
                var command = lightFactory.CreateLightCommand("SetEnabled", light, newState);
                commandInvoker.ExecuteCommand(command);
            }
        }

        public void TurnOffAllLights(float duration = 0f)
        {
            if (duration > 0f)
            {
                lightService.TurnOffAllLights(duration);
            }
            else
            {
                var command = lightFactory.CreateLightCommand("SetEnabled", null, false);
                // Would need batch commands for multiple lights
                lightService.TurnOffAllLights(0f);
            }
        }

        public void TurnOnAllLights()
        {
            lightService.TurnOnAllLights();
        }

        public void DimAllLights(float dimLevel = 0.3f)
        {
            lightService.SetGlobalIntensity(dimLevel);
        }

        public void RestoreAllLights()
        {
            lightService.SetGlobalIntensity(1f);
        }

        public void FadeAllLights(float duration, float targetIntensity = 0f)
        {
            var lights = lightService.GetAllLights();
            foreach (var light in lights)
            {
                if (targetIntensity <= 0f)
                    light.FadeOut(duration);
                else
                {
                    light.SetIntensity(targetIntensity);
                    light.FadeIn(duration);
                }
            }
        }

        // ============= PUBLIC API =============
        public ILightController CreateLight(GameObject lightObject, LightConfigurationData configData)
        {
            var config = new LightConfiguration(configData);
            var lightController = lightFactory.CreateLightController(lightObject, config);
            
            if (lightController != null)
            {
                lightService.RegisterLight(lightController);
            }
            
            return lightController;
        }

        public void ExecuteLightCommand(ILightCommand command)
        {
            commandInvoker.ExecuteCommand(command);
        }

        public void UndoLastLightCommand()
        {
            commandInvoker.UndoLastCommand();
        }

        // ============= EDITOR SUPPORT =============
        [ContextMenu("Validate Setup")]
        private void ValidateSetup()
        {
            bool isValid = ValidateConfiguration();
            Debug.Log($"LightSystemComposer setup validation: {(isValid ? "PASSED" : "FAILED")}");
        }

        [ContextMenu("Show Registered Lights")]
        private void ShowRegisteredLights()
        {
            if (lightService != null)
            {
                Debug.Log($"Registered lights: {lightService.RegisteredLightsCount}");
                var lights = lightService.GetAllLights();
                foreach (var light in lights)
                {
                    Debug.Log($"- Light: Enabled={light.CurrentLightData.IsEnabled}, Intensity={light.CurrentLightData.Intensity}");
                }
            }
        }

        [ContextMenu("Turn Off All Lights")]
        private void TurnOffAllLightsEditor()
        {
            TurnOffAllLights();
        }

        [ContextMenu("Turn On All Lights")]
        private void TurnOnAllLightsEditor()
        {
            TurnOnAllLights();
        }
    }

    // ============= COMPATIBILITY BRIDGE =============
    [System.Obsolete("GlobalLight is deprecated. Use LightSystemComposer with LightComponent instead.")]
    public class GlobalLightCompat : MonoBehaviour
    {
        private LightSystemComposer composer;
        private LightComponent lightComponent;

        private void Awake()
        {
            composer = FindObjectOfType<LightSystemComposer>();
            if (composer == null)
            {
                Debug.LogError("GlobalLightCompat: No LightSystemComposer found in scene!");
                return;
            }

            // Add LightComponent if it doesn't exist
            lightComponent = GetComponent<LightComponent>();
            if (lightComponent == null)
            {
                lightComponent = gameObject.AddComponent<LightComponent>();
            }
        }

        public void TurnOff(float duration)
        {
            lightComponent?.TurnOff(duration);
        }
    }
}