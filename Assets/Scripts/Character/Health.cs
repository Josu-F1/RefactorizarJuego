#pragma warning disable 0649

using UnityEngine;
using System;
using UnityEngine.Events;

/// <summary>
/// ❌ DEPRECATED: Esta clase viola principios SOLID y OCP.
/// ✅ MIGRAR A: CharacterSystemComposer con Clean Architecture
/// Esta clase ya NO debe usarse - el proyecto está 100% en Clean Architecture
/// </summary>
[System.Obsolete("❌ DEPRECATED: Use CharacterSystemComposer (Clean Architecture) instead. This legacy class is NO LONGER SUPPORTED.", true)]
public class Health : MonoBehaviour
{
    public static Action<float, Health> OnAnyCharacterHealthChanged { get; set; }
    public Action<float> OnHealthChanged { get; set; }
    public Action OnDead { get; set; }
    [SerializeField] private float maxHP = 200;
    [SerializeField] private UnityEvent<float> onDamageTaken;
    [SerializeField] private UnityEvent<float> onHeal;
    [SerializeField] private UnityEvent onDead;
    private bool isDead = false;
    private float currentHP;
    private void Awake()
    {
        currentHP = maxHP;
    }
    private void Update()
    {
        if (isDead) return;
        if (currentHP <= 0)
        {
            Die();
        }
    }
    public void TakeDamage(float damage)
    {
        if (isDead) return; // No recibir daño si ya está muerto
        
        currentHP -= damage;
        ClampHP();
        OnHealthChanged?.Invoke(-damage);
        OnAnyCharacterHealthChanged?.Invoke(-damage, this);
        onDamageTaken?.Invoke(damage);
    }
    public void Heal(float healAmount)
    {
        currentHP += healAmount;
        ClampHP();
        OnHealthChanged?.Invoke(healAmount);
        OnAnyCharacterHealthChanged?.Invoke(healAmount, this);
    }
    private void ClampHP()
    {
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }
    public void Die()
    {
        isDead = true;
        onDead?.Invoke();
        OnDead?.Invoke();
    }
    public float Percentage => currentHP / maxHP;
    public bool IsFull => currentHP == maxHP;
    public bool IsDead => isDead; // Usar el flag en vez de comparación con 0
}