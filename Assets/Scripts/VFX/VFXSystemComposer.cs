using UnityEngine;
using System.Collections.Generic;
using TMPro;

/// <summary>
/// Composer principal del sistema VFX refactorizado
/// Patrón: Facade Pattern - Simplifica el acceso a todo el sistema VFX
/// Principio: Single Responsibility Principle (SRP) - Solo orquesta el sistema VFX
/// Principio: Dependency Inversion Principle (DIP) - Usa interfaces, no implementaciones
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevos efectos
/// </summary>
public class VFXSystemComposer : MonoBehaviourSingleton<VFXSystemComposer>, IEffectSpawner
{
    [Header("VFX System Configuration")]
    [SerializeField] private VFXEffectDatabase effectDatabase;
    [SerializeField] private Transform effectsParent;
    
    [Header("Pool Settings")]
    [SerializeField] private int defaultPoolSize = 10;
    [SerializeField] private bool prewarmPools = true;
    
    [Header("Observer Settings")]
    [SerializeField] private bool autoCreateObserver = true;
    
    // Sistemas SOLID
    private IEffectFactory effectFactory;
    private IEffectPool effectPool;
    private IEffectSpawner effectSpawner;
    private IGameEventObserver gameEventObserver;
    
    // Referencias para compatibilidad
    private VFXGameEventObserver observerComponent;
    
    protected override void Awake()
    {
        base.Awake();
        InitializeVFXSystem();
    }
    
    private void Start()
    {
        if (autoCreateObserver)
        {
            CreateGameEventObserver();
        }
        
        if (prewarmPools)
        {
            PrewarmAllPools();
        }
    }
    
    private void InitializeVFXSystem()
    {
        // Crear parent si no existe
        if (effectsParent == null)
        {
            GameObject parentGO = new GameObject("VFX_Effects");
            parentGO.transform.SetParent(transform);
            effectsParent = parentGO.transform;
        }
        
        // Crear factory
        effectFactory = new VFXEffectFactory(effectsParent);
        
        // Crear pool
        effectPool = new VFXEffectPool(effectFactory, defaultPoolSize);
        
        // Crear spawner
        effectSpawner = new VFXEffectSpawner(effectFactory, effectPool);
        
        // Registrar efectos del database
        RegisterEffectsFromDatabase();
        
        Debug.Log("[VFXSystemComposer] Sistema VFX inicializado con principios SOLID");
    }
    
    private void RegisterEffectsFromDatabase()
    {
        bool floatingTextRegistered = false;

        if (effectDatabase == null)
        {
            Debug.LogWarning("[VFXSystemComposer] No effect database assigned - using runtime fallbacks");
        }
        else if (effectFactory is VFXEffectFactory databaseFactory)
        {
            foreach (var entry in effectDatabase.EffectEntries)
            {
                if (entry.prefab == null) continue;

                databaseFactory.RegisterEffectPrefab(entry.effectType, entry.prefab);
                if (entry.effectType == EffectType.FloatingText)
                {
                    floatingTextRegistered = true;
                }
            }

            Debug.Log($"[VFXSystemComposer] Registered {effectDatabase.EffectEntries.Count} effects from database");
        }

        EnsureFallbackEffectPrefabs(floatingTextRegistered);
    }

    private void EnsureFallbackEffectPrefabs(bool floatingTextRegistered)
    {
        if (effectFactory is not VFXEffectFactory factory) return;

        if (!floatingTextRegistered)
        {
            var runtimeFloatingText = CreateRuntimeFloatingTextPrefab();
            factory.RegisterEffectPrefab(EffectType.FloatingText, runtimeFloatingText);
            Debug.LogWarning("[VFXSystemComposer] FloatingText prefab missing in database. Registered runtime fallback prefab.");
        }
    }

    private GameObject CreateRuntimeFloatingTextPrefab()
    {
        var runtimePrefab = new GameObject("RuntimeFloatingTextEffect");
        runtimePrefab.SetActive(false);

        var textMesh = runtimePrefab.AddComponent<TextMeshPro>();
        textMesh.text = "0";
        textMesh.fontSize = 2f;
        textMesh.alignment = TextAlignmentOptions.Center;

        runtimePrefab.AddComponent<TransformAttach>();
        runtimePrefab.AddComponent<FloatingTextEffect>();

        var meshRenderer = runtimePrefab.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.sortingOrder = 100;
        }

        runtimePrefab.hideFlags = HideFlags.HideAndDontSave;
        return runtimePrefab;
    }
    
    private void CreateGameEventObserver()
    {
        // Crear componente observer si no existe
        observerComponent = GetComponent<VFXGameEventObserver>();
        if (observerComponent == null)
        {
            observerComponent = gameObject.AddComponent<VFXGameEventObserver>();
        }
        
        gameEventObserver = observerComponent;
        Debug.Log("[VFXSystemComposer] Game event observer created");
    }
    
    private void PrewarmAllPools()
    {
        if (effectDatabase == null) return;
        
        foreach (var entry in effectDatabase.EffectEntries)
        {
            if (entry.prewarmCount > 0)
            {
                effectPool.PrewarmPool(entry.effectType, entry.prewarmCount);
            }
        }
        
        Debug.Log("[VFXSystemComposer] All pools prewarmed");
    }
    
    // Implementación de IEffectSpawner para API pública
    public void SpawnEffect(EffectType effectType, Vector3 position, EffectConfig config = null)
    {
        effectSpawner?.SpawnEffect(effectType, position, config);
    }
    
    public void SpawnEffect(EffectType effectType, Transform target, EffectConfig config = null)
    {
        effectSpawner?.SpawnEffect(effectType, target, config);
    }
    
    public void RegisterEffect(EffectType effectType, IVisualEffect effectPrefab)
    {
        effectSpawner?.RegisterEffect(effectType, effectPrefab);
    }
    
    // APIs de conveniencia para efectos comunes
    public void SpawnDamageText(int damage, Transform target)
    {
        var config = new EffectConfig
        {
            text = damage.ToString(),
            color = Color.red,
            duration = 1.5f,
            velocity = Vector3.up * 2f,
            fadeOut = true
        };
        
        SpawnEffect(EffectType.FloatingText, target, config);
    }
    
    public void SpawnHealText(int healAmount, Transform target)
    {
        var config = new EffectConfig
        {
            text = healAmount.ToString(),
            color = Color.green,
            duration = 1.5f,
            velocity = Vector3.up * 2f,
            fadeOut = true
        };
        
        SpawnEffect(EffectType.FloatingText, target, config);
    }
    
    public void SpawnScoreText(int score, Transform target)
    {
        var config = new EffectConfig
        {
            text = $"+{score}",
            color = Color.yellow,
            duration = 2f,
            velocity = Vector3.up * 1.5f,
            fadeOut = true
        };
        
        SpawnEffect(EffectType.FloatingText, target, config);
    }
    
    public void FlashColor(GameObject target, Color flashColor, float duration = 0.2f)
    {
        var colorFlash = target.GetComponent<ColorFlashEffect>();
        if (colorFlash == null)
        {
            colorFlash = target.AddComponent<ColorFlashEffect>();
        }
        
        var config = new EffectConfig
        {
            color = flashColor,
            duration = duration
        };
        
        colorFlash.Configure(config);
        colorFlash.Play();
    }
    
    public void SpawnExplosion(Vector3 position, float intensity = 1f)
    {
        var config = new EffectConfig
        {
            color = new Color(1f, 0.5f, 0f), // Orange color
            duration = 1f,
            particleCount = Mathf.RoundToInt(20 * intensity),
            particleSize = 1f * intensity,
            emissionRate = 50f * intensity
        };
        
        SpawnEffect(EffectType.ParticleExplosion, position, config);
    }
    
    // Métodos para compatibilidad con sistemas existentes
    public void TriggerHealthEffect(float healthChange, Transform target)
    {
        if (gameEventObserver != null)
        {
            gameEventObserver.OnHealthChanged(healthChange, target);
        }
    }
    
    public void TriggerScoreEffect(int score, Transform target)
    {
        if (gameEventObserver != null)
        {
            gameEventObserver.OnScoreEarned(score, target);
        }
    }
    
    // Método para obtener referencias a subsistemas (para testing)
    public IEffectFactory GetEffectFactory() => effectFactory;
    public IEffectPool GetEffectPool() => effectPool;
    public IGameEventObserver GetGameEventObserver() => gameEventObserver;
    
    // Cleanup
    private void OnDestroy()
    {
        if (effectPool != null)
        {
            // Cleanup pool si es necesario
        }
    }
}

/// <summary>
/// Database de efectos configurables en Inspector
/// Principio: Single Responsibility Principle (SRP) - Solo datos de configuración
/// </summary>
[CreateAssetMenu(fileName = "VFXEffectDatabase", menuName = "VFX/Effect Database")]
public class VFXEffectDatabase : ScriptableObject
{
    [System.Serializable]
    public class EffectEntry
    {
        public EffectType effectType;
        public GameObject prefab;
        public int prewarmCount = 5;
        public EffectConfig defaultConfig;
    }
    
    [SerializeField] private List<EffectEntry> effectEntries = new List<EffectEntry>();
    
    public List<EffectEntry> EffectEntries => effectEntries;
    
    public EffectEntry GetEntry(EffectType effectType)
    {
        return effectEntries.Find(entry => entry.effectType == effectType);
    }
}