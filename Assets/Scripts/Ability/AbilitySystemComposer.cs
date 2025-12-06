using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// Sistema de habilidades refactorizado aplicando Clean Architecture
/// Patrón: Strategy + Command + Observer
/// Principios: SRP, OCP, LSP, DIP
/// </summary>
public class AbilitySystemComposer : MonoBehaviourSingleton<AbilitySystemComposer>
{
    [Header("Configuration")]
    [SerializeField] private bool enableDebugLogging = false;
    
    private Dictionary<GameObject, List<IAbility>> objectAbilities = new Dictionary<GameObject, List<IAbility>>();
    private AbilityService abilityService;
    
    // Eventos
    public static event Action<GameObject, string> OnAbilityActivated;
    public static event Action<GameObject, string> OnAbilityDeactivated;
    
    protected override void Awake()
    {
        base.Awake();
        InitializeSystem();
    }
    
    private void InitializeSystem()
    {
        abilityService = new AbilityService();
        
        if (enableDebugLogging)
            Debug.Log("[AbilitySystemComposer] ✅ Sistema inicializado");
    }
    
    /// <summary>
    /// Registra una habilidad a un GameObject
    /// </summary>
    public void RegisterAbility(GameObject target, IAbility ability)
    {
        if (target == null || ability == null)
        {
            Debug.LogError("[AbilitySystemComposer] Target o Ability es null");
            return;
        }
        
        if (!objectAbilities.ContainsKey(target))
        {
            objectAbilities[target] = new List<IAbility>();
        }
        
        if (!objectAbilities[target].Contains(ability))
        {
            objectAbilities[target].Add(ability);
            
            if (enableDebugLogging)
                Debug.Log($"[AbilitySystemComposer] ✅ Habilidad '{ability.GetAbilityName()}' registrada para {target.name}");
        }
    }
    
    /// <summary>
    /// Activa una habilidad por nombre
    /// </summary>
    public void ActivateAbility(GameObject target, string abilityName)
    {
        if (target == null || string.IsNullOrEmpty(abilityName)) return;
        
        if (objectAbilities.TryGetValue(target, out var abilities))
        {
            var ability = abilities.Find(a => a.GetAbilityName() == abilityName);
            if (ability != null && ability.CanActivate())
            {
                ability.Activate();
                OnAbilityActivated?.Invoke(target, abilityName);
                
                if (enableDebugLogging)
                    Debug.Log($"[AbilitySystemComposer] ✨ Habilidad '{abilityName}' activada en {target.name}");
            }
        }
    }
    
    /// <summary>
    /// Desactiva una habilidad por nombre
    /// </summary>
    public void DeactivateAbility(GameObject target, string abilityName)
    {
        if (target == null || string.IsNullOrEmpty(abilityName)) return;
        
        if (objectAbilities.TryGetValue(target, out var abilities))
        {
            var ability = abilities.Find(a => a.GetAbilityName() == abilityName);
            if (ability != null)
            {
                ability.Deactivate();
                OnAbilityDeactivated?.Invoke(target, abilityName);
                
                if (enableDebugLogging)
                    Debug.Log($"[AbilitySystemComposer] Habilidad '{abilityName}' desactivada en {target.name}");
            }
        }
    }
    
    /// <summary>
    /// Obtiene todas las habilidades de un GameObject
    /// </summary>
    public List<IAbility> GetAbilities(GameObject target)
    {
        if (target == null) return null;
        
        objectAbilities.TryGetValue(target, out var abilities);
        return abilities;
    }
    
    /// <summary>
    /// Verifica si una habilidad está activa
    /// </summary>
    public bool IsAbilityActive(GameObject target, string abilityName)
    {
        if (target == null || string.IsNullOrEmpty(abilityName)) return false;
        
        if (objectAbilities.TryGetValue(target, out var abilities))
        {
            var ability = abilities.Find(a => a.GetAbilityName() == abilityName);
            return ability?.IsActive() ?? false;
        }
        
        return false;
    }
    
    /// <summary>
    /// Limpia las habilidades de un GameObject
    /// </summary>
    public void CleanupAbilities(GameObject target)
    {
        if (target == null) return;
        
        if (objectAbilities.ContainsKey(target))
        {
            // Desactivar todas las habilidades activas
            foreach (var ability in objectAbilities[target])
            {
                if (ability.IsActive())
                {
                    ability.Deactivate();
                }
            }
            
            objectAbilities.Remove(target);
            
            if (enableDebugLogging)
                Debug.Log($"[AbilitySystemComposer] Habilidades limpiadas para {target.name}");
        }
    }
    
    /// <summary>
    /// Migra habilidades legacy a nuevo sistema
    /// </summary>
    [ContextMenu("Migrate Legacy Abilities")]
    public void MigrateLegacyAbilities()
    {
        // Migrar DashAbility
        var dashAbilities = FindObjectsOfType<DashAbility>();
        foreach (var legacy in dashAbilities)
        {
            var modernAbility = new DashAbilityStrategy(legacy.gameObject);
            RegisterAbility(legacy.gameObject, modernAbility);
        }
        
        // Migrar InvisibleAbility
        var invisibleAbilities = FindObjectsOfType<InvisibleAbility>();
        foreach (var legacy in invisibleAbilities)
        {
            var modernAbility = new InvisibilityAbilityStrategy(legacy.gameObject);
            RegisterAbility(legacy.gameObject, modernAbility);
        }
        
        // Migrar BlindAbility
        var blindAbilities = FindObjectsOfType<BlindAbility>();
        foreach (var legacy in blindAbilities)
        {
            var modernAbility = new BlindAbilityStrategy(legacy.gameObject);
            RegisterAbility(legacy.gameObject, modernAbility);
        }
        
        if (enableDebugLogging)
            Debug.Log($"[AbilitySystemComposer] Migradas {dashAbilities.Length + invisibleAbilities.Length + blindAbilities.Length} habilidades legacy");
    }
    
    private void OnDestroy()
    {
        objectAbilities.Clear();
    }
}

/// <summary>
/// Servicio de habilidades (Application Layer)
/// </summary>
public class AbilityService
{
    public void ExecuteAbility(GameObject target, IAbility ability)
    {
        if (target == null || ability == null) return;
        
        if (ability.CanActivate())
        {
            ability.Activate();
        }
    }
    
    public void CancelAbility(GameObject target, IAbility ability)
    {
        if (target == null || ability == null) return;
        
        if (ability.IsActive())
        {
            ability.Deactivate();
        }
    }
}

/// <summary>
/// Interface base para habilidades
/// </summary>
public interface IAbility
{
    string GetAbilityName();
    bool CanActivate();
    void Activate();
    void Deactivate();
    bool IsActive();
    float GetCooldown();
    float GetDuration();
}

/// <summary>
/// Clase base abstracta para habilidades
/// </summary>
public abstract class BaseAbility : IAbility
{
    protected GameObject target;
    protected bool isActive;
    protected float cooldownTime;
    protected float duration;
    protected float lastActivationTime;
    
    public BaseAbility(GameObject target)
    {
        this.target = target;
        this.isActive = false;
        this.lastActivationTime = -999f;
    }
    
    public abstract string GetAbilityName();
    
    public virtual bool CanActivate()
    {
        if (isActive) return false;
        if (Time.time - lastActivationTime < cooldownTime) return false;
        return true;
    }
    
    public virtual void Activate()
    {
        if (!CanActivate()) return;
        
        isActive = true;
        lastActivationTime = Time.time;
        OnActivate();
    }
    
    public virtual void Deactivate()
    {
        if (!isActive) return;
        
        isActive = false;
        OnDeactivate();
    }
    
    public bool IsActive() => isActive;
    public float GetCooldown() => cooldownTime;
    public float GetDuration() => duration;
    
    protected abstract void OnActivate();
    protected abstract void OnDeactivate();
}

/// <summary>
/// Estrategia para habilidad Dash
/// </summary>
public class DashAbilityStrategy : BaseAbility
{
    private float dashSpeed = 20f;
    private Vector2 dashDirection;
    
    public DashAbilityStrategy(GameObject target) : base(target)
    {
        cooldownTime = 2f;
        duration = 0.2f;
    }
    
    public override string GetAbilityName() => "Dash";
    
    protected override void OnActivate()
    {
        // Obtener dirección de input
        var moveComponent = target.GetComponent<MoveComponent>();
        if (moveComponent != null)
        {
            dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            
            if (dashDirection != Vector2.zero)
            {
                // Aplicar dash
                target.transform.Translate(new Vector3(dashDirection.x, dashDirection.y, 0) * dashSpeed * Time.deltaTime);
            }
        }
        
        // Auto-desactivar después de duration
        MonoBehaviourHelper.Instance.StartCoroutine(AutoDeactivate());
    }
    
    protected override void OnDeactivate()
    {
        // Cleanup si es necesario
    }
    
    private System.Collections.IEnumerator AutoDeactivate()
    {
        yield return new WaitForSeconds(duration);
        Deactivate();
    }
}

/// <summary>
/// Estrategia para habilidad Invisibilidad
/// </summary>
public class InvisibilityAbilityStrategy : BaseAbility
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    
    public InvisibilityAbilityStrategy(GameObject target) : base(target)
    {
        cooldownTime = 5f;
        duration = 3f;
        spriteRenderer = target.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }
    
    public override string GetAbilityName() => "Invisibility";
    
    protected override void OnActivate()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.3f);
        }
        
        // Auto-desactivar después de duration
        MonoBehaviourHelper.Instance.StartCoroutine(AutoDeactivate());
    }
    
    protected override void OnDeactivate()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }
    }
    
    private System.Collections.IEnumerator AutoDeactivate()
    {
        yield return new WaitForSeconds(duration);
        Deactivate();
    }
}

/// <summary>
/// Estrategia para habilidad Ceguera
/// </summary>
#pragma warning disable CS0618
public class BlindAbilityStrategy : BaseAbility
{
    private GlobalLight globalLight;
    
    public BlindAbilityStrategy(GameObject target) : base(target)
    {
        cooldownTime = 10f;
        duration = 2f;
        globalLight = GameObject.FindObjectOfType<GlobalLight>();
    }
#pragma warning restore CS0618
    
    public override string GetAbilityName() => "Blind";
    
    protected override void OnActivate()
    {
        if (globalLight != null)
        {
            globalLight.TurnOff(duration);
        }
        
        // Auto-desactivar después de duration
        MonoBehaviourHelper.Instance.StartCoroutine(AutoDeactivate());
    }
    
    protected override void OnDeactivate()
    {
        // La luz se reenciende automáticamente con TurnOff(duration)
    }
    
    private System.Collections.IEnumerator AutoDeactivate()
    {
        yield return new WaitForSeconds(duration);
        Deactivate();
    }
}

/// <summary>
/// Helper para ejecutar coroutines desde clases no-MonoBehaviour
/// </summary>
public class MonoBehaviourHelper : MonoBehaviourSingleton<MonoBehaviourHelper>
{
    // Solo sirve como ejecutor de coroutines
}
