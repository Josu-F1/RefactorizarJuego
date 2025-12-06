#pragma warning disable CS0618 // Type or member is obsolete
using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Sistema de salud refactorizado usando Strategy Pattern y principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo maneja el estado de salud
/// Principio: Open/Closed Principle (OCP) - Abierto para extensión mediante estrategias
/// Patrón: Strategy Pattern - Diferentes comportamientos de daño, curación y muerte
/// </summary>
public class HealthSystemComposer : MonoBehaviour, IHealthStats
{
    [Header("Health Configuration")]
    [SerializeField] private float maxHP = 200f;
    
    [Header("Strategies")]
    [SerializeField] private bool useCustomStrategies = false;
    
    [Header("Events")]
    [SerializeField] private UnityEvent<float> onDamageTaken;
    [SerializeField] private UnityEvent<float> onHeal;
    [SerializeField] private UnityEvent onDead;
    
    // Estrategias intercambiables
    private IDamageStrategy damageStrategy;
    private IHealingStrategy healingStrategy;
    private IDeathStrategy deathStrategy;
    
    // Estado interno
    private float currentHP;
    private bool isDead = false;
    
    // Propiedades de IHealthStats
    public float CurrentHP => currentHP;
    public float MaxHP => maxHP;
    public float Percentage => maxHP > 0 ? currentHP / maxHP : 0f;
    public bool IsFull => Mathf.Approximately(currentHP, maxHP);
    public bool IsDead => currentHP <= 0 || isDead;
    
    // Eventos estáticos y de instancia
    public static Action<float, HealthSystemComposer> OnAnyCharacterHealthChanged { get; set; }
    public event Action<float> OnHealthChanged;
    public event Action OnDead;
    
    private void Awake()
    {
        currentHP = maxHP;
        InitializeStrategies();
    }
    
    private void InitializeStrategies()
    {
        // Usar estrategias por defecto si no se configuran personalizadas
        if (!useCustomStrategies || damageStrategy == null)
            damageStrategy = new StandardDamageStrategy();
            
        if (!useCustomStrategies || healingStrategy == null)
            healingStrategy = new StandardHealingStrategy();
            
        if (!useCustomStrategies || deathStrategy == null)
        {
            // Determinar estrategia de muerte según el tipo de personaje
            if (GetComponent<Enemy>() != null)
            {
                var enemy = GetComponent<Enemy>();
                deathStrategy = new EnemyDeathStrategy(); // Usará el score del Enemy
            }
            else if (GetComponent<Player>() != null)
            {
                deathStrategy = new DeactivateDeathStrategy(); // Jugador se desactiva
            }
            else
            {
                deathStrategy = new DestroyDeathStrategy(); // Por defecto destruir
            }
        }
    }
    
    private void Update()
    {
        // Verificar muerte solo si no está ya muerto
        if (!isDead && currentHP <= 0)
        {
            ProcessDeath();
        }
    }
    
    /// <summary>
    /// Aplica daño usando la estrategia configurada
    /// </summary>
    public void TakeDamage(float damage)
    {
        if (isDead || damage <= 0) return;
        
        float previousHP = currentHP;
        currentHP = damageStrategy.ApplyDamage(currentHP, maxHP, damage);
        
        float actualDamage = previousHP - currentHP;
        
        // Notificar eventos
        OnHealthChanged?.Invoke(-actualDamage);
        OnAnyCharacterHealthChanged?.Invoke(-actualDamage, this);
        onDamageTaken?.Invoke(actualDamage);
    }
    
    /// <summary>
    /// Aplica curación usando la estrategia configurada
    /// </summary>
    public void Heal(float healAmount)
    {
        if (isDead || healAmount <= 0) return;
        
        float previousHP = currentHP;
        currentHP = healingStrategy.ApplyHealing(currentHP, maxHP, healAmount);
        
        float actualHeal = currentHP - previousHP;
        
        // Notificar eventos
        OnHealthChanged?.Invoke(actualHeal);
        OnAnyCharacterHealthChanged?.Invoke(actualHeal, this);
        onHeal?.Invoke(actualHeal);
    }
    
    /// <summary>
    /// Fuerza la muerte del personaje
    /// </summary>
    public void Die()
    {
        if (isDead) return;
        ProcessDeath();
    }
    
    private void ProcessDeath()
    {
        isDead = true;
        currentHP = 0;
        
        // Notificar muerte
        OnDead?.Invoke();
        onDead?.Invoke();
        
        // Aplicar estrategia de muerte
        deathStrategy?.OnDeath(gameObject);
    }
    
    /// <summary>
    /// Permite cambiar la estrategia de daño en runtime
    /// </summary>
    public void SetDamageStrategy(IDamageStrategy strategy)
    {
        damageStrategy = strategy ?? new StandardDamageStrategy();
    }
    
    /// <summary>
    /// Permite cambiar la estrategia de curación en runtime
    /// </summary>
    public void SetHealingStrategy(IHealingStrategy strategy)
    {
        healingStrategy = strategy ?? new StandardHealingStrategy();
    }
    
    /// <summary>
    /// Permite cambiar la estrategia de muerte en runtime
    /// </summary>
    public void SetDeathStrategy(IDeathStrategy strategy)
    {
        deathStrategy = strategy ?? new DestroyDeathStrategy();
    }
}