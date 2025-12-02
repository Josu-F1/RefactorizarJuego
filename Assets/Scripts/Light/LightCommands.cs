using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LightSystem.Interfaces;

namespace LightSystem.Commands
{
    // ============= BASE COMMAND =============
    public abstract class BaseLightCommand : ILightCommand
    {
        protected readonly ILightController lightController;
        protected bool canExecute = true;

        public abstract string CommandName { get; }
        public virtual bool CanExecute() => canExecute && lightController != null;

        protected BaseLightCommand(ILightController controller)
        {
            lightController = controller ?? throw new System.ArgumentNullException(nameof(controller));
        }

        public abstract void Execute();
        public abstract void Undo();
    }

    // ============= LIGHT COMMANDS =============
    public class SetLightEnabledCommand : BaseLightCommand
    {
        private readonly bool targetEnabled;
        private bool previousEnabled;

        public override string CommandName => $"SetEnabled({targetEnabled})";

        public SetLightEnabledCommand(ILightController controller, bool enabled) : base(controller)
        {
            targetEnabled = enabled;
        }

        public override void Execute()
        {
            if (!CanExecute()) return;

            previousEnabled = lightController.CurrentLightData.IsEnabled;
            lightController.SetEnabled(targetEnabled);
        }

        public override void Undo()
        {
            if (!CanExecute()) return;
            lightController.SetEnabled(previousEnabled);
        }
    }

    public class SetLightIntensityCommand : BaseLightCommand
    {
        private readonly float targetIntensity;
        private float previousIntensity;

        public override string CommandName => $"SetIntensity({targetIntensity})";

        public SetLightIntensityCommand(ILightController controller, float intensity) : base(controller)
        {
            targetIntensity = Mathf.Clamp01(intensity);
        }

        public override void Execute()
        {
            if (!CanExecute()) return;

            previousIntensity = lightController.CurrentLightData.Intensity;
            lightController.SetIntensity(targetIntensity);
        }

        public override void Undo()
        {
            if (!CanExecute()) return;
            lightController.SetIntensity(previousIntensity);
        }
    }

    public class SetLightColorCommand : BaseLightCommand
    {
        private readonly Color targetColor;
        private Color previousColor;

        public override string CommandName => $"SetColor({targetColor})";

        public SetLightColorCommand(ILightController controller, Color color) : base(controller)
        {
            targetColor = color;
        }

        public override void Execute()
        {
            if (!CanExecute()) return;

            previousColor = lightController.CurrentLightData.LightColor;
            lightController.SetColor(targetColor);
        }

        public override void Undo()
        {
            if (!CanExecute()) return;
            lightController.SetColor(previousColor);
        }
    }

    public class TurnOffLightCommand : BaseLightCommand
    {
        private readonly float duration;
        private bool wasEnabled;

        public override string CommandName => $"TurnOff({duration}s)";

        public TurnOffLightCommand(ILightController controller, float duration) : base(controller)
        {
            this.duration = duration;
        }

        public override void Execute()
        {
            if (!CanExecute()) return;

            wasEnabled = lightController.CurrentLightData.IsEnabled;
            lightController.TurnOff(duration);
        }

        public override void Undo()
        {
            if (!CanExecute()) return;
            lightController.SetEnabled(wasEnabled);
        }
    }

    // ============= COMMAND INVOKER =============
    [System.Serializable]
    public class LightCommandInvoker : ILightCommandInvoker
    {
        private readonly Stack<ILightCommand> commandHistory;
        private readonly int maxHistorySize;

        public bool CanUndo() => commandHistory.Count > 0;

        public LightCommandInvoker(int maxHistory = 20)
        {
            commandHistory = new Stack<ILightCommand>();
            maxHistorySize = maxHistory;
        }

        public void ExecuteCommand(ILightCommand command)
        {
            if (command?.CanExecute() == true)
            {
                command.Execute();
                
                // Add to history
                commandHistory.Push(command);
                
                // Limit history size
                if (commandHistory.Count > maxHistorySize)
                {
                    var commands = commandHistory.ToArray();
                    commandHistory.Clear();
                    for (int i = commands.Length - maxHistorySize; i < commands.Length; i++)
                    {
                        commandHistory.Push(commands[i]);
                    }
                }
            }
        }

        public void UndoLastCommand()
        {
            if (CanUndo())
            {
                var lastCommand = commandHistory.Pop();
                lastCommand.Undo();
            }
        }

        public void ClearHistory()
        {
            commandHistory.Clear();
        }

        public int HistoryCount => commandHistory.Count;
    }
}

namespace LightSystem.Behaviors
{
    // ============= BASE BEHAVIOR =============
    public abstract class BaseLightBehavior : ILightBehavior
    {
        protected ILightController lightController;
        protected float duration;
        protected float elapsedTime;
        protected bool isActive;

        public bool IsActive => isActive;
        public abstract string BehaviorName { get; }

        public virtual void StartBehavior(ILightController controller, float behaviorDuration)
        {
            lightController = controller ?? throw new System.ArgumentNullException(nameof(controller));
            duration = behaviorDuration;
            elapsedTime = 0f;
            isActive = true;
        }

        public virtual void UpdateBehavior(float deltaTime)
        {
            if (!isActive) return;

            elapsedTime += deltaTime;
            
            if (elapsedTime >= duration)
            {
                CompleteBehavior();
                return;
            }

            float progress = elapsedTime / duration;
            UpdateBehaviorLogic(progress, deltaTime);
        }

        public virtual void StopBehavior()
        {
            isActive = false;
        }

        protected abstract void UpdateBehaviorLogic(float progress, float deltaTime);
        protected virtual void CompleteBehavior()
        {
            isActive = false;
        }
    }

    // ============= FADE BEHAVIOR =============
    public class FadeLightBehavior : BaseLightBehavior
    {
        private float startIntensity;
        private float targetIntensity;

        public override string BehaviorName => "Fade";

        public FadeLightBehavior(float target = 0f)
        {
            targetIntensity = Mathf.Clamp01(target);
        }

        public override void StartBehavior(ILightController controller, float behaviorDuration)
        {
            base.StartBehavior(controller, behaviorDuration);
            startIntensity = controller.CurrentLightData.Intensity;
        }

        protected override void UpdateBehaviorLogic(float progress, float deltaTime)
        {
            float currentIntensity = Mathf.Lerp(startIntensity, targetIntensity, progress);
            lightController.SetIntensity(currentIntensity);
        }

        public void SetTargetIntensity(float target)
        {
            targetIntensity = Mathf.Clamp01(target);
        }
    }

    // ============= BLINK BEHAVIOR =============
    public class BlinkLightBehavior : BaseLightBehavior
    {
        private float blinkInterval;
        private float lastBlinkTime;
        private bool isOn;
        private float originalIntensity;

        public override string BehaviorName => "Blink";

        public BlinkLightBehavior(float interval = 0.5f)
        {
            blinkInterval = interval;
        }

        public override void StartBehavior(ILightController controller, float behaviorDuration)
        {
            base.StartBehavior(controller, behaviorDuration);
            originalIntensity = controller.CurrentLightData.Intensity;
            isOn = controller.CurrentLightData.IsEnabled;
            lastBlinkTime = 0f;
        }

        protected override void UpdateBehaviorLogic(float progress, float deltaTime)
        {
            lastBlinkTime += deltaTime;
            
            if (lastBlinkTime >= blinkInterval)
            {
                isOn = !isOn;
                lightController.SetIntensity(isOn ? originalIntensity : 0f);
                lastBlinkTime = 0f;
            }
        }

        protected override void CompleteBehavior()
        {
            base.CompleteBehavior();
            // Restore original state
            lightController.SetIntensity(originalIntensity);
        }

        public void SetBlinkInterval(float interval)
        {
            blinkInterval = Mathf.Max(0.1f, interval);
        }
    }

    // ============= PULSE BEHAVIOR =============
    public class PulseLightBehavior : BaseLightBehavior
    {
        private float minIntensity;
        private float maxIntensity;
        private float pulseSpeed;

        public override string BehaviorName => "Pulse";

        public PulseLightBehavior(float min = 0.2f, float max = 1f, float speed = 2f)
        {
            minIntensity = Mathf.Clamp01(min);
            maxIntensity = Mathf.Clamp01(max);
            pulseSpeed = speed;
        }

        protected override void UpdateBehaviorLogic(float progress, float deltaTime)
        {
            float pulseValue = Mathf.Sin(elapsedTime * pulseSpeed * Mathf.PI) * 0.5f + 0.5f;
            float currentIntensity = Mathf.Lerp(minIntensity, maxIntensity, pulseValue);
            lightController.SetIntensity(currentIntensity);
        }

        public void SetPulseRange(float min, float max)
        {
            minIntensity = Mathf.Clamp01(min);
            maxIntensity = Mathf.Clamp01(max);
        }

        public void SetPulseSpeed(float speed)
        {
            pulseSpeed = Mathf.Max(0.1f, speed);
        }
    }

    // ============= FLICKER BEHAVIOR =============
    public class FlickerLightBehavior : BaseLightBehavior
    {
        private float originalIntensity;
        private float flickerIntensity;

        public override string BehaviorName => "Flicker";

        public FlickerLightBehavior(float flickerAmount = 0.3f)
        {
            flickerIntensity = Mathf.Clamp01(flickerAmount);
        }

        public override void StartBehavior(ILightController controller, float behaviorDuration)
        {
            base.StartBehavior(controller, behaviorDuration);
            originalIntensity = controller.CurrentLightData.Intensity;
        }

        protected override void UpdateBehaviorLogic(float progress, float deltaTime)
        {
            float randomFlicker = Random.Range(-flickerIntensity, flickerIntensity);
            float currentIntensity = Mathf.Clamp01(originalIntensity + randomFlicker);
            lightController.SetIntensity(currentIntensity);
        }

        protected override void CompleteBehavior()
        {
            base.CompleteBehavior();
            // Restore original intensity
            lightController.SetIntensity(originalIntensity);
        }

        public void SetFlickerIntensity(float intensity)
        {
            flickerIntensity = Mathf.Clamp01(intensity);
        }
    }
}