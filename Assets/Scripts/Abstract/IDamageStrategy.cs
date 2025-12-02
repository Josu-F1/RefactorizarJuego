/// <summary>
/// Interface para estrategias de daño
/// Patrón: Strategy Pattern - Diferentes formas de aplicar daño
/// </summary>
public interface IDamageStrategy
{
    float ApplyDamage(float currentHP, float maxHP, float damageAmount);
}