using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Factory para crear efectos VFX
/// Patrón: Factory Pattern - Creación centralizada y configurable
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevos tipos
/// Principio: Single Responsibility Principle (SRP) - Solo creación de efectos
/// </summary>
public class VFXEffectFactory : IEffectFactory
{
    private Dictionary<EffectType, GameObject> effectPrefabs;
    private Transform parentTransform;
    
    public VFXEffectFactory(Transform parent = null)
    {
        parentTransform = parent;
        effectPrefabs = new Dictionary<EffectType, GameObject>();
    }
    
    public void RegisterEffectPrefab(EffectType effectType, GameObject prefab)
    {
        effectPrefabs[effectType] = prefab;
        Debug.Log($"[VFXEffectFactory] Registered effect prefab: {effectType}");
    }
    
    public IVisualEffect CreateEffect(EffectType effectType, EffectConfig config = null)
    {
        if (!effectPrefabs.TryGetValue(effectType, out GameObject prefab))
        {
            Debug.LogError($"[VFXEffectFactory] No prefab registered for effect type: {effectType}");
            return null;
        }
        
        GameObject instance = Object.Instantiate(prefab, parentTransform);
        IVisualEffect effect = instance.GetComponent<IVisualEffect>();
        
        if (effect == null)
        {
            Debug.LogError($"[VFXEffectFactory] Prefab for {effectType} doesn't have IVisualEffect component");
            Object.Destroy(instance);
            return null;
        }
        
        // Configurar si es configurable
        if (effect is IConfigurableEffect configurableEffect && config != null)
        {
            configurableEffect.Configure(config);
        }
        
        Debug.Log($"[VFXEffectFactory] Created effect: {effectType}");
        return effect;
    }
    
    public T CreateEffect<T>() where T : class, IVisualEffect
    {
        // Buscar el tipo de efecto basado en el tipo T
        foreach (var kvp in effectPrefabs)
        {
            var component = kvp.Value.GetComponent<T>();
            if (component != null)
            {
                return CreateEffect(kvp.Key) as T;
            }
        }
        
        Debug.LogError($"[VFXEffectFactory] No effect found for type: {typeof(T).Name}");
        return null;
    }
}

/// <summary>
/// Pool simple de efectos para optimización
/// Principio: Single Responsibility Principle (SRP) - Solo pooling
/// Patrón: Object Pool Pattern - Reutilización de objetos
/// </summary>
public class VFXEffectPool : IEffectPool
{
    private Dictionary<EffectType, Queue<IVisualEffect>> pools;
    private IEffectFactory factory;
    private int maxPoolSize = 10;
    
    public VFXEffectPool(IEffectFactory effectFactory, int maxSize = 10)
    {
        factory = effectFactory;
        maxPoolSize = maxSize;
        pools = new Dictionary<EffectType, Queue<IVisualEffect>>();
    }
    
    public T GetPooledEffect<T>() where T : class, IVisualEffect
    {
        // Determinar el EffectType basado en T
        EffectType effectType = GetEffectTypeFromInterface<T>();
        
        if (!pools.TryGetValue(effectType, out Queue<IVisualEffect> pool))
        {
            pool = new Queue<IVisualEffect>();
            pools[effectType] = pool;
        }
        
        IVisualEffect effect;
        if (pool.Count > 0)
        {
            effect = pool.Dequeue();
            if (effect != null && (effect as Component)?.gameObject != null)
            {
                (effect as Component).gameObject.SetActive(true);
                return effect as T;
            }
        }
        
        // Crear nuevo si no hay en pool
        effect = factory.CreateEffect(effectType);
        return effect as T;
    }
    
    public void ReturnToPool(IVisualEffect effect)
    {
        if (effect == null) return;
        
        var gameObject = (effect as Component)?.gameObject;
        if (gameObject == null) return;
        
        gameObject.SetActive(false);
        
        EffectType effectType = effect.EffectType;
        if (!pools.TryGetValue(effectType, out Queue<IVisualEffect> pool))
        {
            pool = new Queue<IVisualEffect>();
            pools[effectType] = pool;
        }
        
        if (pool.Count < maxPoolSize)
        {
            pool.Enqueue(effect);
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }
    
    public void PrewarmPool(EffectType effectType, int count)
    {
        if (!pools.TryGetValue(effectType, out Queue<IVisualEffect> pool))
        {
            pool = new Queue<IVisualEffect>();
            pools[effectType] = pool;
        }
        
        for (int i = 0; i < count; i++)
        {
            var effect = factory.CreateEffect(effectType);
            if (effect != null)
            {
                (effect as Component).gameObject.SetActive(false);
                pool.Enqueue(effect);
            }
        }
        
        Debug.Log($"[VFXEffectPool] Prewarmed pool for {effectType} with {count} effects");
    }
    
    private EffectType GetEffectTypeFromInterface<T>() where T : class, IVisualEffect
    {
        // Mapeo simple - se puede mejorar con reflection o registro
        var typeName = typeof(T).Name;
        if (typeName.Contains("FloatingText")) return EffectType.FloatingText;
        if (typeName.Contains("ColorFlash")) return EffectType.ColorFlash;
        if (typeName.Contains("Particle")) return EffectType.ParticleExplosion;
        
        return EffectType.FloatingText; // Default
    }
}

/// <summary>
/// Spawner de efectos con diferentes estrategias
/// Patrón: Strategy Pattern - Diferentes formas de spawn
/// </summary>
public class VFXEffectSpawner : IEffectSpawner
{
    private IEffectFactory factory;
    private IEffectPool pool;
    private Dictionary<EffectType, GameObject> registeredPrefabs;
    
    public VFXEffectSpawner(IEffectFactory effectFactory, IEffectPool effectPool)
    {
        factory = effectFactory;
        pool = effectPool;
        registeredPrefabs = new Dictionary<EffectType, GameObject>();
    }
    
    public void RegisterEffect(EffectType effectType, IVisualEffect effectPrefab)
    {
        if (effectPrefab is Component comp)
        {
            registeredPrefabs[effectType] = comp.gameObject;
            
            // También registrar en el factory si es VFXEffectFactory
            if (factory is VFXEffectFactory vfxFactory)
            {
                vfxFactory.RegisterEffectPrefab(effectType, comp.gameObject);
            }
        }
    }
    
    public void SpawnEffect(EffectType effectType, Vector3 position, EffectConfig config = null)
    {
        IVisualEffect effect = null;
        
        // Intentar obtener del pool primero
        if (pool != null)
        {
            effect = GetEffectFromPool(effectType);
        }
        
        // Si no hay en pool, crear nuevo
        if (effect == null)
        {
            effect = factory.CreateEffect(effectType, config);
        }
        
        if (effect != null)
        {
            // Configurar si es necesario
            if (effect is IConfigurableEffect configurableEffect && config != null)
            {
                configurableEffect.Configure(config);
            }
            
            // Posicionar y reproducir
            if (effect is IPositionalEffect positionalEffect)
            {
                positionalEffect.PlayAt(position);
            }
            else
            {
                (effect as Component).transform.position = position;
                effect.Play();
            }
        }
    }
    
    public void SpawnEffect(EffectType effectType, Transform target, EffectConfig config = null)
    {
        if (target == null)
        {
            Debug.LogWarning("[VFXEffectSpawner] Target is null, cannot spawn effect");
            return;
        }
        
        IVisualEffect effect = null;
        
        // Intentar obtener del pool primero
        if (pool != null)
        {
            effect = GetEffectFromPool(effectType);
        }
        
        // Si no hay en pool, crear nuevo
        if (effect == null)
        {
            effect = factory.CreateEffect(effectType, config);
        }
        
        if (effect != null)
        {
            // Configurar si es necesario
            if (effect is IConfigurableEffect configurableEffect && config != null)
            {
                configurableEffect.Configure(config);
            }
            
            // Adjuntar al target si es posible
            if (effect is IAttachableEffect attachableEffect)
            {
                attachableEffect.AttachTo(target);
                attachableEffect.Play();
            }
            else
            {
                (effect as Component).transform.position = target.position;
                effect.Play();
            }
        }
    }
    
    private IVisualEffect GetEffectFromPool(EffectType effectType)
    {
        switch (effectType)
        {
            case EffectType.FloatingText:
                return pool.GetPooledEffect<FloatingTextEffect>();
            case EffectType.ColorFlash:
                return pool.GetPooledEffect<ColorFlashEffect>();
            case EffectType.ParticleExplosion:
                return pool.GetPooledEffect<ParticleEffect>();
            default:
                return null;
        }
    }
}