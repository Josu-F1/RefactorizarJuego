using UnityEngine;
using UnityLightType = UnityEngine.LightType;

namespace LightSystem.Interfaces
{
    // ============= LIGHT DATA INTERFACES =============
    public interface ILightData
    {
        float Intensity { get; }
        Color LightColor { get; }
        bool IsEnabled { get; }
        CustomLightType LightType { get; }
        float Range { get; }
    }

    public interface ILightConfiguration
    {
        float DefaultIntensity { get; }
        Color DefaultColor { get; }
        float FadeSpeed { get; }
        float BlinkSpeed { get; }
        bool AutoRestore { get; }
    }

    // ============= OBSERVER PATTERN INTERFACES =============
    public interface ILightObserver
    {
        void OnLightChanged(ILightData lightData);
        void OnLightEnabled(ILightData lightData);
        void OnLightDisabled(ILightData lightData);
        void OnLightIntensityChanged(float oldIntensity, float newIntensity);
        int Priority { get; } // For ordered notifications
    }

    public interface ILightSubject
    {
        void Subscribe(ILightObserver observer);
        void Unsubscribe(ILightObserver observer);
        void NotifyLightChanged();
        void NotifyLightEnabled();
        void NotifyLightDisabled();
        void NotifyIntensityChanged(float oldIntensity, float newIntensity);
    }

    // ============= LIGHT CONTROLLER INTERFACES =============
    public interface ILightController
    {
        void SetEnabled(bool enabled);
        void SetIntensity(float intensity);
        void SetColor(Color color);
        void TurnOff(float duration);
        void FadeIn(float duration);
        void FadeOut(float duration);
        void Blink(float duration, float interval);
        ILightData CurrentLightData { get; }
        bool IsOperationInProgress { get; }
    }

    public interface ILightRenderer
    {
        void ApplyLightData(ILightData lightData);
        void SetLightEnabled(bool enabled);
        void SetLightIntensity(float intensity);
        void SetLightColor(Color color);
        bool IsLightSupported { get; }
    }

    // ============= COMMAND PATTERN INTERFACES =============
    public interface ILightCommand
    {
        void Execute();
        void Undo();
        bool CanExecute();
        string CommandName { get; }
    }

    public interface ILightCommandInvoker
    {
        void ExecuteCommand(ILightCommand command);
        void UndoLastCommand();
        bool CanUndo();
        void ClearHistory();
    }

    // ============= STRATEGY INTERFACES =============
    public interface ILightBehavior
    {
        void StartBehavior(ILightController controller, float duration);
        void UpdateBehavior(float deltaTime);
        void StopBehavior();
        bool IsActive { get; }
        string BehaviorName { get; }
    }

    public interface ILightEffect
    {
        void ApplyEffect(ILightController controller, float progress);
        float Duration { get; }
        string EffectName { get; }
    }

    // ============= SERVICE INTERFACES =============
    public interface ILightService
    {
        void RegisterLight(ILightController lightController);
        void UnregisterLight(ILightController lightController);
        void TurnOffAllLights(float duration);
        void TurnOnAllLights();
        void SetGlobalIntensity(float intensity);
        void ApplyGlobalEffect(ILightEffect effect);
        ILightController[] GetAllLights();
        int RegisteredLightsCount { get; }
    }

    public interface ILightFactory
    {
        ILightController CreateLightController(GameObject lightObject, ILightConfiguration config);
        ILightCommand CreateLightCommand(string commandType, ILightController controller, params object[] parameters);
        ILightBehavior CreateLightBehavior(string behaviorType);
        ILightEffect CreateLightEffect(string effectType, float duration);
    }

    // ============= COMPOSER INTERFACE =============
    public interface ILightSystemComposer
    {
        ILightService LightService { get; }
        ILightFactory LightFactory { get; }
        ILightCommandInvoker CommandInvoker { get; }
        void Initialize();
        void Cleanup();
    }

    // ============= ENUM DEFINITIONS =============
    public enum CustomLightType
    {
        Global,
        Point,
        Directional,
        Spot,
        Area
    }

    public enum LightBehaviorType
    {
        None,
        Fade,
        Blink,
        Pulse,
        Flicker,
        Smooth
    }

    // ============= DATA STRUCTURES =============
    [System.Serializable]
    public class LightConfigurationData
    {
        public float defaultIntensity = 1f;
        public Color defaultColor = Color.white;
        public float fadeSpeed = 1f;
        public float blinkSpeed = 2f;
        public bool autoRestore = true;
    }

    [System.Serializable]
    public class LightEffectData
    {
        public string effectName;
        public float duration = 1f;
        public float targetIntensity = 0f;
        public Color targetColor = Color.white;
        public AnimationCurve intensityCurve = AnimationCurve.Linear(0, 0, 1, 1);
    }
}