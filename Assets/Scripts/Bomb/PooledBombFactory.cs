#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;
using Vector2Extensions;

/// <summary>
/// Fábrica estándar de bombas usando Object Pool
/// Patrón: Factory Pattern - Crea bombas configuradas
/// </summary>
public class PooledBombFactory : IBombFactory
{
    private ObjectPool bombPool;
    private ObjectPool explosionPool;
    
    public PooledBombFactory(ObjectPool bombPool, ObjectPool explosionPool)
    {
        this.bombPool = bombPool;
        this.explosionPool = explosionPool;
    }
    
    public Bomb CreateBomb(Vector2 position, BombConfiguration config, CharacterType characterType)
    {
        if (bombPool == null) return null;
        
        Vector2 cellCenterPos = position.ToCellCenter();
        Bomb bomb = bombPool.Get(cellCenterPos).GetComponent<Bomb>();
        
        ConfigureBomb(bomb, config, characterType);
        
        return bomb;
    }
    
    public Bomb CreateThrowableBomb(Vector2 destination, float throwSpeed, BombConfiguration config, CharacterType characterType)
    {
        if (bombPool == null) return null;
        
        Bomb bomb = bombPool.Get(Vector2.zero).GetComponent<Bomb>();
        
        ConfigureBomb(bomb, config, characterType);
        
        // Configuración específica para bomba arrojadiza
        Vector2 cellCenterPos = destination.ToCellCenter();
        bomb.Destination = cellCenterPos;
        bomb.Speed = throwSpeed;
        
        return bomb;
    }
    
    private void ConfigureBomb(Bomb bomb, BombConfiguration config, CharacterType characterType)
    {
        if (bomb == null) return;
        
        bomb.Damage = config.Damage;
        bomb.Lifetime = config.Lifetime;
        bomb.Length = config.Length;
        bomb.CharacterType = characterType;
        bomb.ExplosionPool = explosionPool;
    }
}