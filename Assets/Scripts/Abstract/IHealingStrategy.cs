/// <summary>
/// Interface para estrategias de curación
/// Patrón: Strategy Pattern - Diferentes formas de curar
/// </summary>
public interface IHealingStrategy
{
    float ApplyHealing(float currentHP, float maxHP, float healAmount);
}