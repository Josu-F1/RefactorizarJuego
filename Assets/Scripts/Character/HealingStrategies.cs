using UnityEngine;

/// <summary>
/// Estrategia de curación estándar - suma curación directamente
/// Patrón: Strategy Pattern
/// </summary>
[System.Serializable]
public class StandardHealingStrategy : IHealingStrategy
{
    public float ApplyHealing(float currentHP, float maxHP, float healAmount)
    {
        return Mathf.Min(maxHP, currentHP + healAmount);
    }
}

/// <summary>
/// Estrategia de curación gradual - cura por tiempo
/// </summary>
[System.Serializable]
public class GradualHealingStrategy : IHealingStrategy
{
    [SerializeField] private float healingRate = 0.5f; // Porcentaje de curación aplicada
    
    public GradualHealingStrategy(float rate = 0.5f)
    {
        healingRate = rate;
    }
    
    public float ApplyHealing(float currentHP, float maxHP, float healAmount)
    {
        float gradualHeal = healAmount * healingRate;
        return Mathf.Min(maxHP, currentHP + gradualHeal);
    }
}