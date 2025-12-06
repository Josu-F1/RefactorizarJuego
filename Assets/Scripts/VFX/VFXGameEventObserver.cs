#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Observador de eventos de juego para efectos VFX
/// Patrón: Observer Pattern - Reacciona a eventos sin acoplamiento fuerte
/// Principio: Single Responsibility Principle (SRP) - Solo maneja eventos para VFX
/// Principio: Dependency Inversion Principle (DIP) - Usa interfaces, no implementaciones
/// </summary>
public class VFXGameEventObserver : MonoBehaviour, IGameEventObserver
{
    [Header("VFX Observer Configuration")]
    [SerializeField] private bool observeHealthEvents = true;
    [SerializeField] private bool observeScoreEvents = true;
    [SerializeField] private bool observeDeathEvents = true;
    [SerializeField] private bool observeExplosionEvents = true;
    
    // Sistema VFX
    private IEffectSpawner effectSpawner;
    
    // Configuraciones predefinidas
    private Dictionary<string, EffectConfig> effectConfigs;
    
    private void Awake()
    {
        InitializeEffectConfigs();
    }
    
    private void Start()
    {
        // Obtener el sistema VFX
        effectSpawner = VFXSystemComposer.Instance;
        
        // Suscribirse a eventos si están habilitados
        SubscribeToEvents();
    }
    
    private void InitializeEffectConfigs()
    {
        effectConfigs = new Dictionary<string, EffectConfig>
        {
            ["damage"] = new EffectConfig
            {
                color = Color.red,
                duration = 1.5f,
                velocity = Vector3.up * 2f,
                fadeOut = true,
                fontSize = 2f
            },
            ["heal"] = new EffectConfig
            {
                color = Color.green,
                duration = 1.5f,
                velocity = Vector3.up * 2f,
                fadeOut = true,
                fontSize = 2f
            },
            ["score"] = new EffectConfig
            {
                color = Color.yellow,
                duration = 2f,
                velocity = Vector3.up * 1.5f,
                fadeOut = true,
                fontSize = 2.5f
            },
            ["death"] = new EffectConfig
            {
                color = Color.white,
                duration = 2f,
                particleCount = 20,
                particleSize = 1f
            },
            ["explosion"] = new EffectConfig
            {
                color = new Color(1f, 0.5f, 0f), // Orange
                duration = 1f,
                particleCount = 50,
                particleSize = 1.5f,
                emissionRate = 100f
            }
        };
    }
    
    private void SubscribeToEvents()
    {
        if (observeHealthEvents)
        {
            // Suscribirse al evento global de Health usando adaptador
            Health.OnAnyCharacterHealthChanged += OnHealthChangedLegacy;
            Debug.Log("[VFXGameEventObserver] Subscribed to Health events");
        }
        
        if (observeScoreEvents)
        {
            // Suscribirse al evento global de Enemy
            Enemy.OnAnyEnemyKilled += OnEnemyKilled;
            Debug.Log("[VFXGameEventObserver] Subscribed to Score events");
        }
        
        if (observeDeathEvents)
        {
            // Para muerte de personajes, se puede extender con un sistema de eventos más general
            Debug.Log("[VFXGameEventObserver] Death events observer ready");
        }
    }
    
    private void UnsubscribeFromEvents()
    {
        if (observeHealthEvents)
        {
            Health.OnAnyCharacterHealthChanged -= OnHealthChangedLegacy;
        }
        
        if (observeScoreEvents)
        {
            Enemy.OnAnyEnemyKilled -= OnEnemyKilled;
        }
    }
    
    // Implementación de IGameEventObserver
    public void OnHealthChanged(float amount, Transform target)
    {
        if (effectSpawner == null || target == null) return;
        
        // Determinar si es daño o curación
        string configKey = amount > 0 ? "heal" : "damage";
        var config = effectConfigs[configKey];
        
        // Configurar el texto
        config.text = Mathf.Abs((int)amount).ToString();
        
        // Spawn del efecto
        effectSpawner.SpawnEffect(EffectType.FloatingText, target, config);
        
        Debug.Log($"[VFXGameEventObserver] Health effect spawned: {configKey} ({amount})");
    }
    
    // Método adaptador para el evento Health legacy
    private void OnHealthChangedLegacy(float amount, Health health)
    {
        OnHealthChanged(amount, health.transform);
    }
    
    public void OnScoreEarned(int score, Transform target)
    {
        if (effectSpawner == null || target == null) return;
        
        var config = effectConfigs["score"];
        config.text = $"+{score}";
        
        effectSpawner.SpawnEffect(EffectType.FloatingText, target, config);
        
        Debug.Log($"[VFXGameEventObserver] Score effect spawned: +{score}");
    }
    
    public void OnCharacterDeath(Transform target)
    {
        if (effectSpawner == null || target == null) return;
        
        var config = effectConfigs["death"];
        effectSpawner.SpawnEffect(EffectType.ParticleExplosion, target, config);
        
        Debug.Log("[VFXGameEventObserver] Death effect spawned");
    }
    
    public void OnExplosion(Vector3 position, float intensity)
    {
        if (effectSpawner == null) return;
        
        var config = effectConfigs["explosion"];
        config.particleCount = Mathf.RoundToInt(config.particleCount * intensity);
        
        effectSpawner.SpawnEffect(EffectType.ParticleExplosion, position, config);
        
        Debug.Log($"[VFXGameEventObserver] Explosion effect spawned at {position}");
    }
    
    // Métodos de compatibilidad con el sistema existente
    private void OnEnemyKilled(int score)
    {
        // El score se otorga al player, así que usar su transform
        var player = Player.Instance;
        if (player != null)
        {
            OnScoreEarned(score, player.transform);
        }
    }
    
    // Método para efectos manuales desde otros sistemas
    public void TriggerEffect(EffectType effectType, Vector3 position, string configKey = null)
    {
        if (effectSpawner == null) return;
        
        EffectConfig config = null;
        if (!string.IsNullOrEmpty(configKey) && effectConfigs.TryGetValue(configKey, out config))
        {
            effectSpawner.SpawnEffect(effectType, position, config);
        }
        else
        {
            effectSpawner.SpawnEffect(effectType, position);
        }
    }
    
    public void TriggerEffect(EffectType effectType, Transform target, string configKey = null)
    {
        if (effectSpawner == null || target == null) return;
        
        EffectConfig config = null;
        if (!string.IsNullOrEmpty(configKey) && effectConfigs.TryGetValue(configKey, out config))
        {
            effectSpawner.SpawnEffect(effectType, target, config);
        }
        else
        {
            effectSpawner.SpawnEffect(effectType, target);
        }
    }
    
    // Método para registrar nuevas configuraciones
    public void RegisterEffectConfig(string key, EffectConfig config)
    {
        effectConfigs[key] = config;
        Debug.Log($"[VFXGameEventObserver] Registered effect config: {key}");
    }
    
    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
}