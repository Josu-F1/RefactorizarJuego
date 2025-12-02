using UnityEngine;

/// <summary>
/// Configuración para la creación de bombas
/// Principio: Single Responsibility Principle (SRP) - Solo datos de configuración
/// </summary>
[System.Serializable]
public class BombConfiguration
{
    [SerializeField] private float damage = 20f;
    [SerializeField] private int length = 2;
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private int bombLimit = 999;
    
    public float Damage { get => damage; set => damage = value; }
    public int Length { get => length; set => length = value; }
    public float Lifetime { get => lifetime; set => lifetime = value; }
    public int BombLimit { get => bombLimit; set => bombLimit = value; }
    
    public BombConfiguration(float damage = 20f, int length = 2, float lifetime = 2f, int bombLimit = 999)
    {
        this.damage = damage;
        this.length = length;
        this.lifetime = lifetime;
        this.bombLimit = bombLimit;
    }
}