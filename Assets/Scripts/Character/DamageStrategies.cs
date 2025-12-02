using UnityEngine;

/// <summary>
/// Estrategia de daño estándar - resta daño directamente
/// Patrón: Strategy Pattern
/// </summary>
[System.Serializable]
public class StandardDamageStrategy : IDamageStrategy
{
    public float ApplyDamage(float currentHP, float maxHP, float damageAmount)
    {
        return Mathf.Max(0, currentHP - damageAmount);
    }
}

/// <summary>
/// Estrategia de daño porcentual - daño basado en porcentaje de HP máximo
/// </summary>
[System.Serializable]
public class PercentageDamageStrategy : IDamageStrategy
{
    [SerializeField] private float damageMultiplier = 1f;
    
    public PercentageDamageStrategy(float multiplier = 1f)
    {
        damageMultiplier = multiplier;
    }
    
    public float ApplyDamage(float currentHP, float maxHP, float damageAmount)
    {
        float percentageDamage = (damageAmount / 100f) * maxHP * damageMultiplier;
        return Mathf.Max(0, currentHP - percentageDamage);
    }
}