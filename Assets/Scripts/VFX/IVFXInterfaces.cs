using UnityEngine;
using System;

/// <summary>
/// Interfaces para el sistema VFX refactorizado
/// Principio: Interface Segregation Principle (ISP) - Interfaces específicas y pequeñas
/// Principio: Dependency Inversion Principle (DIP) - Abstracciones, no concreciones
/// Patrón: Observer Pattern - Reacción a eventos del juego
/// </summary>
/// 
/// <summary>
/// Interfaz base para efectos visuales
/// Principio: Single Responsibility Principle (SRP) - Solo comportamiento de efecto
/// </summary>
public interface IVisualEffect
{
    void Play();
    void Stop();
    bool IsPlaying { get; }
    EffectType EffectType { get; }
}

/// <summary>
/// Interfaz para efectos configurables
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevas configuraciones
/// </summary>
public interface IConfigurableEffect : IVisualEffect
{
    void Configure(EffectConfig config);
}

/// <summary>
/// Interfaz para efectos posicionales
/// </summary>
public interface IPositionalEffect : IVisualEffect
{
    void PlayAt(Vector3 position);
}

/// <summary>
/// Interfaz para efectos que siguen transforms
/// </summary>
public interface IAttachableEffect : IVisualEffect
{
    void AttachTo(Transform target);
    void Detach();
    Transform AttachedTarget { get; }
}

/// <summary>
/// Observador de eventos de juego para efectos
/// Patrón: Observer Pattern - Desacoplado de la lógica del juego
/// </summary>
public interface IGameEventObserver
{
    void OnHealthChanged(float amount, Transform target);
    void OnScoreEarned(int score, Transform target);
    void OnCharacterDeath(Transform target);
    void OnExplosion(Vector3 position, float intensity);
}

/// <summary>
/// Spawner de efectos con strategy pattern
/// Patrón: Strategy Pattern - Diferentes estrategias de spawn
/// </summary>
public interface IEffectSpawner
{
    void SpawnEffect(EffectType effectType, Vector3 position, EffectConfig config = null);
    void SpawnEffect(EffectType effectType, Transform target, EffectConfig config = null);
    void RegisterEffect(EffectType effectType, IVisualEffect effectPrefab);
}

/// <summary>
/// Factory para crear efectos
/// Patrón: Factory Pattern - Creación centralizada
/// </summary>
public interface IEffectFactory
{
    IVisualEffect CreateEffect(EffectType effectType, EffectConfig config = null);
    T CreateEffect<T>() where T : class, IVisualEffect;
}

/// <summary>
/// Pool de efectos para optimización
/// Principio: Single Responsibility Principle (SRP) - Solo pooling de efectos
/// </summary>
public interface IEffectPool
{
    T GetPooledEffect<T>() where T : class, IVisualEffect;
    void ReturnToPool(IVisualEffect effect);
    void PrewarmPool(EffectType effectType, int count);
}

/// <summary>
/// Tipos de efectos disponibles
/// </summary>
public enum EffectType
{
    FloatingText,
    ColorFlash,
    ParticleExplosion,
    DamageNumber,
    HealNumber,
    ScoreNumber,
    DeathEffect,
    HitEffect
}

/// <summary>
/// Configuración de efectos
/// Principio: Single Responsibility Principle (SRP) - Solo datos de configuración
/// </summary>
[System.Serializable]
public class EffectConfig
{
    [Header("Basic Settings")]
    public float duration = 1f;
    public Color color = Color.white;
    public Vector3 offset = Vector3.zero;
    
    [Header("Text Settings")]
    public string text = "";
    public float fontSize = 1f;
    
    [Header("Movement Settings")]
    public Vector3 velocity = Vector3.up;
    public AnimationCurve movementCurve = AnimationCurve.Linear(0, 0, 1, 1);
    
    [Header("Fade Settings")]
    public bool fadeOut = true;
    public AnimationCurve fadeCurve = AnimationCurve.Linear(0, 1, 1, 0);
    
    [Header("Scale Settings")]
    public bool scaleEffect = false;
    public AnimationCurve scaleCurve = AnimationCurve.Linear(0, 1, 1, 1);
    
    [Header("Particle Settings")]
    public int particleCount = 10;
    public float particleSize = 1f;
    public float emissionRate = 10f;
}

/// <summary>
/// Datos de evento para efectos
/// </summary>
public struct EffectEventData
{
    public EffectType effectType;
    public Vector3 position;
    public Transform target;
    public EffectConfig config;
    public object additionalData;
    
    public EffectEventData(EffectType type, Vector3 pos, EffectConfig cfg = null)
    {
        effectType = type;
        position = pos;
        target = null;
        config = cfg;
        additionalData = null;
    }
    
    public EffectEventData(EffectType type, Transform tgt, EffectConfig cfg = null)
    {
        effectType = type;
        position = tgt?.position ?? Vector3.zero;
        target = tgt;
        config = cfg;
        additionalData = null;
    }
}