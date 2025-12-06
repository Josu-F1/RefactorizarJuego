#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;
using System;

/// <summary>
/// Componentes concretos para el sistema de personajes
/// Principio: Single Responsibility Principle (SRP) - Cada componente una responsabilidad
/// Principio: Open/Closed Principle (OCP) - Extensibles sin modificar código existente
/// Patrón: Component Pattern - Comportamientos modulares y reutilizables
/// </summary>

/// <summary>
/// Proveedor de puntuación básico
/// </summary>
public class ScoreProvider : IScoreProvider
{
    public int Score { get; private set; }
    public bool IsActive { get; private set; }
    public event Action<int> OnScoreAwarded;
    
    private ICharacterController controller;
    
    public ScoreProvider(int score)
    {
        Score = score;
    }
    
    public void Initialize(ICharacterController controller)
    {
        this.controller = controller;
        IsActive = true;
    }
    
    public void AwardScore()
    {
        if (IsActive && Score > 0)
        {
            OnScoreAwarded?.Invoke(Score);
            Debug.Log($"[ScoreProvider] Score awarded: {Score}");
        }
    }
    
    public void OnDestroy()
    {
        IsActive = false;
        OnScoreAwarded = null;
    }
}

/// <summary>
/// Manejador de muerte con diferentes estrategias
/// Patrón: Strategy Pattern - Diferentes comportamientos de muerte
/// </summary>
public class DeathHandler : IDeathHandler
{
    public bool IsActive { get; private set; }
    public event Action OnDeath;
    
    private ICharacterController controller;
    private DeathBehaviorType behaviorType;
    private float deathDelay;
    
    public DeathHandler(DeathBehaviorType behaviorType, float deathDelay = 0f)
    {
        this.behaviorType = behaviorType;
        this.deathDelay = deathDelay;
    }
    
    public void Initialize(ICharacterController controller)
    {
        this.controller = controller;
        IsActive = true;
    }
    
    public void HandleDeath()
    {
        if (!IsActive) return;
        
        OnDeath?.Invoke();
        
        if (deathDelay > 0)
        {
            // Usar Coroutine para delay
            if (controller.GameObject != null)
            {
                var mono = controller.GameObject.GetComponent<MonoBehaviour>();
                mono?.StartCoroutine(HandleDeathWithDelay());
            }
        }
        else
        {
            ExecuteDeathBehavior();
        }
    }
    
    private System.Collections.IEnumerator HandleDeathWithDelay()
    {
        yield return new WaitForSeconds(deathDelay);
        ExecuteDeathBehavior();
    }
    
    private void ExecuteDeathBehavior()
    {
        switch (behaviorType)
        {
            case DeathBehaviorType.Destroy:
                if (controller.GameObject != null)
                {
                    UnityEngine.Object.Destroy(controller.GameObject);
                }
                break;
                
            case DeathBehaviorType.Deactivate:
                if (controller.GameObject != null)
                {
                    controller.GameObject.SetActive(false);
                }
                break;
                
            case DeathBehaviorType.Respawn:
                // Implementación básica - se puede extender
                Debug.Log("[DeathHandler] Respawn behavior - to be implemented");
                break;
                
            case DeathBehaviorType.Custom:
                // Para comportamientos personalizados
                Debug.Log("[DeathHandler] Custom death behavior");
                break;
        }
        
        Debug.Log($"[DeathHandler] Death handled with behavior: {behaviorType}");
    }
    
    public void OnDestroy()
    {
        IsActive = false;
        OnDeath = null;
    }
}

/// <summary>
/// Manejador de eventos de salud
/// Principio: Single Responsibility Principle (SRP) - Solo bridge Health-Character
/// </summary>
/// <summary>
/// ⚠️ DEPRECATED: Este componente usa Health legacy
/// TODO: Migrar a CharacterSystemComposer con EventBus
/// </summary>
public class HealthEventHandler : IHealthEventHandler
{
    public bool IsActive { get; private set; }
    public event Action OnHealthDepleted;
    
    private ICharacterController controller;
    // private Health health; // REMOVED - legacy class deprecated
    
    public void Initialize(ICharacterController controller)
    {
        this.controller = controller;
        IsActive = true;
        // SubscribeToHealth(); // DISABLED - Health legacy deprecated
    }
    
    public void SubscribeToHealth()
    {
        // DISABLED - Health legacy deprecated
        // TODO: Usar EventBus.Subscribe<CharacterDiedEvent>()
    }
    
    public void UnsubscribeFromHealth()
    {
        // DISABLED - Health legacy deprecated
    }
    
    private void HandleHealthDepleted()
    {
        if (IsActive)
        {
            OnHealthDepleted?.Invoke();
            controller?.NotifyEvent(CharacterEvent.HealthDepleted);
        }
    }
    
    public void OnDestroy()
    {
        IsActive = false;
        OnHealthDepleted = null;
    }
}