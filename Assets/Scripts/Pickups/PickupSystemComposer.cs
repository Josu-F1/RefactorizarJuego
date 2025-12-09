#pragma warning disable CS0618

using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// Sistema de pickups refactorizado aplicando Clean Architecture
/// Patrón: Factory + Strategy + Observer
/// Principios: SRP, OCP, DIP
/// </summary>
public class PickupSystemComposer : MonoBehaviourSingleton<PickupSystemComposer>
{
    [Header("Configuration")]
    [SerializeField] private bool enableDebugLogging = false;
    [SerializeField] private PickupSpawner legacySpawner; // Referencia al spawner legacy
    
    private PickupService pickupService;
    private ModernPickupFactory pickupFactory;
    private List<IPickupEffect> activePickups = new List<IPickupEffect>();
    
    // Eventos
    public static event Action<GameObject, PickupType> OnPickupCollected;
    public static event Action<GameObject, PickupType> OnPickupEffectApplied;
    
    protected override void Awake()
    {
        base.Awake();
        InitializeSystem();
    }
    
    private void InitializeSystem()
    {
        pickupService = new PickupService();
        pickupFactory = new ModernPickupFactory();
        
        if (enableDebugLogging)
            Debug.Log("[PickupSystemComposer] ✅ Sistema inicializado");
    }
    
    /// <summary>
    /// Aplica un pickup a un objetivo
    /// </summary>
    public void ApplyPickup(GameObject target, PickupType pickupType, float value)
    {
        if (target == null)
        {
            Debug.LogError("[PickupSystemComposer] Target es null");
            return;
        }
        
        var pickupEffect = pickupFactory.CreatePickupEffect(pickupType, target, value);
        
        if (pickupEffect != null)
        {
            pickupEffect.Apply();
            activePickups.Add(pickupEffect);
            
            OnPickupCollected?.Invoke(target, pickupType);
            OnPickupEffectApplied?.Invoke(target, pickupType);
            
            if (enableDebugLogging)
                Debug.Log($"[PickupSystemComposer] ✅ Pickup '{pickupType}' aplicado a {target.name}");
        }
    }
    
    /// <summary>
    /// Spawns un pickup en una posición
    /// </summary>
    public GameObject SpawnPickup(PickupType pickupType, Vector3 position)
    {
        // Usar factory para crear pickup
        GameObject pickupPrefab = GetPickupPrefab(pickupType);
        
        if (pickupPrefab != null)
        {
            var pickup = Instantiate(pickupPrefab, position, Quaternion.identity);
            
            if (enableDebugLogging)
                Debug.Log($"[PickupSystemComposer] Pickup '{pickupType}' spawned en {position}");
            
            return pickup;
        }
        
        return null;
    }
    
    private GameObject GetPickupPrefab(PickupType pickupType)
    {
        // Por ahora retornar null - implementar cuando sea necesario
        // Los pickups se crean dinámicamente usando el factory
        return null;
    }
    
    /// <summary>
    /// Remueve un efecto de pickup activo
    /// </summary>
    public void RemovePickupEffect(IPickupEffect effect)
    {
        if (effect != null && activePickups.Contains(effect))
        {
            effect.Remove();
            activePickups.Remove(effect);
        }
    }
    
    /// <summary>
    /// Migra pickups legacy al nuevo sistema
    /// </summary>
    // [REMOVED] MigrateLegacyPickups - Legacy pickups deprecados, usar ModernPickupFactory en su lugar
    
    protected override void OnDestroy()
    {
        // Limpiar todos los efectos activos
        foreach (var effect in activePickups)
        {
            effect.Remove();
        }
        activePickups.Clear();
    }
}

/// <summary>
/// Servicio de pickups (Application Layer)
/// </summary>
public class PickupService
{
    public void ProcessPickup(GameObject target, IPickupEffect effect)
    {
        if (target == null || effect == null) return;
        effect.Apply();
    }
}

/// <summary>
/// Factory para crear efectos de pickups
/// </summary>
public class ModernPickupFactory
{
    public IPickupEffect CreatePickupEffect(PickupType type, GameObject target, float value)
    {
        return type switch
        {
            PickupType.Health => new HealthPickupEffect(target, value),
            PickupType.Speed => new SpeedPickupEffect(target, value),
            PickupType.BombLimit => new BombLimitPickupEffect(target, (int)value),
            PickupType.BombLength => new BombLengthPickupEffect(target, (int)value),
            PickupType.Damage => new DamagePickupEffect(target, value),
            _ => null
        };
    }
}

/// <summary>
/// Interface para efectos de pickups
/// </summary>
public interface IPickupEffect
{
    void Apply();
    void Remove();
    PickupType GetPickupType();
}

/// <summary>
/// Tipos de pickups disponibles
/// </summary>
public enum PickupType
{
    Health,
    Speed,
    BombLimit,
    BombLength,
    Damage
}

/// <summary>
/// Efecto de pickup de salud
/// </summary>
public class HealthPickupEffect : IPickupEffect
{
    private GameObject target;
    private float healAmount;
    
    public HealthPickupEffect(GameObject target, float healAmount)
    {
        this.target = target;
        this.healAmount = healAmount;
    }
    
    public void Apply()
    {
        // TODO: Implementar curación con CharacterSystemComposer
        // Por ahora, registrar pickup recogido
        Debug.Log($"[HealthPickup] ✅ Pickup collected (heal amount: {healAmount})");
        
        // TODO: Publicar PickupCollectedEvent en EventBus
        // EventBus.Instance.Publish(new PickupCollectedEvent("Health", target.gameObject, target));
    }
    
    public void Remove()
    {
        // Health no se remueve
    }
    
    public PickupType GetPickupType() => PickupType.Health;
}

/// <summary>
/// Efecto de pickup de velocidad
/// </summary>
public class SpeedPickupEffect : IPickupEffect
{
    private GameObject target;
    private float speedIncrease;
    private float originalSpeed;
    private MoveComponent moveComponent;
    
    public SpeedPickupEffect(GameObject target, float speedIncrease)
    {
        this.target = target;
        this.speedIncrease = speedIncrease;
        this.moveComponent = target.GetComponent<MoveComponent>();
        if (moveComponent != null)
        {
            originalSpeed = moveComponent.MoveSpeed;
        }
    }
    
    public void Apply()
    {
        if (moveComponent != null)
        {
            moveComponent.IncreaseMoveSpeed(speedIncrease);
        }
    }
    
    public void Remove()
    {
        if (moveComponent != null)
        {
            moveComponent.SetMoveSpeed(originalSpeed);
        }
    }
    
    public PickupType GetPickupType() => PickupType.Speed;
}

/// <summary>
/// Efecto de pickup de límite de bombas
/// </summary>
public class BombLimitPickupEffect : IPickupEffect
{
    private GameObject target;
    private int limitIncrease;
    
    public BombLimitPickupEffect(GameObject target, int limitIncrease)
    {
        this.target = target;
        this.limitIncrease = limitIncrease;
    }
    
    public void Apply()
    {
        var bombSpawner = target.GetComponentInChildren<BombSpawner>();
        if (bombSpawner != null)
        {
            bombSpawner.BombLimit += limitIncrease;
        }
    }
    
    public void Remove()
    {
        // Bomb limit no se remueve
    }
    
    public PickupType GetPickupType() => PickupType.BombLimit;
}

/// <summary>
/// Efecto de pickup de alcance de bombas
/// </summary>
public class BombLengthPickupEffect : IPickupEffect
{
    private GameObject target;
    private int lengthIncrease;
    
    public BombLengthPickupEffect(GameObject target, int lengthIncrease)
    {
        this.target = target;
        this.lengthIncrease = lengthIncrease;
    }
    
    public void Apply()
    {
        var bombSpawner = target.GetComponentInChildren<BombSpawner>();
        if (bombSpawner != null)
        {
            bombSpawner.Length += lengthIncrease;
        }
    }
    
    public void Remove()
    {
        // Bomb length no se remueve
    }
    
    public PickupType GetPickupType() => PickupType.BombLength;
}

/// <summary>
/// Efecto de pickup de daño
/// </summary>
public class DamagePickupEffect : IPickupEffect
{
    private GameObject target;
    private float damageIncrease;
    
    public DamagePickupEffect(GameObject target, float damageIncrease)
    {
        this.target = target;
        this.damageIncrease = damageIncrease;
    }
    
    public void Apply()
    {
        var bombSpawner = target.GetComponentInChildren<BombSpawner>();
        if (bombSpawner != null)
        {
            bombSpawner.Damage += damageIncrease;
        }
    }
    
    public void Remove()
    {
        // Damage no se remueve
    }
    
    public PickupType GetPickupType() => PickupType.Damage;
}

#pragma warning restore CS0618
