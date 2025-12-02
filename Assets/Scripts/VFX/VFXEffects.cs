using UnityEngine;
using TMPro;
using System.Collections;

/// <summary>
/// Implementaciones de efectos visuales refactorizadas
/// Principio: Single Responsibility Principle (SRP) - Cada efecto una responsabilidad
/// Principio: Open/Closed Principle (OCP) - Extensible sin modificar código existente
/// Patrón: Strategy Pattern - Diferentes comportamientos de efectos
/// </summary>
/// 
/// <summary>
/// Efecto de texto flotante refactorizado
/// </summary>
public class FloatingTextEffect : PoolObject, IConfigurableEffect, IAttachableEffect
{
    [Header("Components")]
    [SerializeField] private TextMeshPro textMesh;
    [SerializeField] private MeshRenderer meshRenderer;
    
    public EffectType EffectType => EffectType.FloatingText;
    public bool IsPlaying { get; private set; }
    public Transform AttachedTarget { get; private set; }
    
    private EffectConfig currentConfig;
    private Coroutine effectCoroutine;
    
    private void Awake()
    {
        if (textMesh == null) textMesh = GetComponent<TextMeshPro>();
        if (meshRenderer == null) meshRenderer = GetComponent<MeshRenderer>();
        
        // Asegurar que esté en el layer correcto
        if (meshRenderer != null)
            meshRenderer.sortingOrder = 100;
    }
    
    public void Configure(EffectConfig config)
    {
        currentConfig = config ?? new EffectConfig();
        
        if (textMesh != null)
        {
            textMesh.text = currentConfig.text;
            textMesh.color = currentConfig.color;
            textMesh.fontSize = currentConfig.fontSize;
        }
    }
    
    public void Play()
    {
        if (IsPlaying) Stop();
        
        IsPlaying = true;
        gameObject.SetActive(true);
        
        if (effectCoroutine != null)
            StopCoroutine(effectCoroutine);
            
        effectCoroutine = StartCoroutine(PlayEffectCoroutine());
    }
    
    public void PlayAt(Vector3 position)
    {
        transform.position = position + (currentConfig?.offset ?? Vector3.zero);
        Play();
    }
    
    public void AttachTo(Transform target)
    {
        AttachedTarget = target;
        if (target != null)
        {
            var attachComponent = GetComponent<TransformAttach>();
            if (attachComponent != null)
            {
                attachComponent.AttachTransform = target;
            }
        }
    }
    
    public void Detach()
    {
        AttachedTarget = null;
        var attachComponent = GetComponent<TransformAttach>();
        if (attachComponent != null)
        {
            attachComponent.AttachTransform = null;
        }
    }
    
    public void Stop()
    {
        if (effectCoroutine != null)
        {
            StopCoroutine(effectCoroutine);
            effectCoroutine = null;
        }
        
        IsPlaying = false;
        Detach();
        OnReturnToPoolInternal();
        ReturnToPool();
    }
    
    private IEnumerator PlayEffectCoroutine()
    {
        float elapsed = 0f;
        float duration = currentConfig?.duration ?? 1f;
        
        Vector3 startPos = transform.position;
        Vector3 velocity = currentConfig?.velocity ?? Vector3.up;
        
        Color startColor = textMesh.color;
        Vector3 startScale = transform.localScale;
        
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            
            // Movement
            if (currentConfig?.movementCurve != null)
            {
                float curveValue = currentConfig.movementCurve.Evaluate(t);
                transform.position = startPos + velocity * curveValue * elapsed;
            }
            
            // Fade
            if (currentConfig?.fadeOut == true && currentConfig.fadeCurve != null)
            {
                float alpha = currentConfig.fadeCurve.Evaluate(t);
                Color color = startColor;
                color.a = alpha;
                textMesh.color = color;
            }
            
            // Scale
            if (currentConfig?.scaleEffect == true && currentConfig.scaleCurve != null)
            {
                float scale = currentConfig.scaleCurve.Evaluate(t);
                transform.localScale = startScale * scale;
            }
            
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        Stop();
    }
    
    private void OnReturnToPoolInternal()
    {
        Stop();
        transform.localScale = Vector3.one;
        if (textMesh != null)
        {
            textMesh.text = "";
            textMesh.color = Color.white;
        }
    }
    
    protected override void Start()
    {
        base.Start();
        // Additional setup if needed
    }
}

/// <summary>
/// Efecto de flash de color refactorizado
/// </summary>
public class ColorFlashEffect : MonoBehaviour, IConfigurableEffect
{
    [Header("Settings")]
    [SerializeField] private Color defaultFlashColor = Color.red;
    [SerializeField] private float defaultDuration = 0.2f;
    
    public EffectType EffectType => EffectType.ColorFlash;
    public bool IsPlaying { get; private set; }
    
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private EffectConfig currentConfig;
    private Coroutine flashCoroutine;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            originalColor = spriteRenderer.color;
    }
    
    public void Configure(EffectConfig config)
    {
        currentConfig = config ?? new EffectConfig
        {
            color = defaultFlashColor,
            duration = defaultDuration
        };
    }
    
    public void Play()
    {
        if (spriteRenderer == null) return;
        if (IsPlaying) Stop();
        
        IsPlaying = true;
        
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);
            
        flashCoroutine = StartCoroutine(FlashCoroutine());
    }
    
    public void Stop()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
            flashCoroutine = null;
        }
        
        IsPlaying = false;
        
        if (spriteRenderer != null)
            spriteRenderer.color = originalColor;
    }
    
    private IEnumerator FlashCoroutine()
    {
        Color flashColor = currentConfig?.color ?? defaultFlashColor;
        float duration = currentConfig?.duration ?? defaultDuration;
        
        // Flash to target color
        spriteRenderer.color = flashColor;
        
        // Wait for duration
        yield return new WaitForSeconds(duration);
        
        // Return to original color
        spriteRenderer.color = originalColor;
        IsPlaying = false;
    }
}

/// <summary>
/// Efecto de partículas refactorizado
/// </summary>
public class ParticleEffect : PoolObject, IConfigurableEffect, IPositionalEffect
{
    [Header("Particle Settings")]
    [SerializeField] private new ParticleSystem particleSystem;
    
    public EffectType EffectType => EffectType.ParticleExplosion;
    public bool IsPlaying => particleSystem != null && particleSystem.isPlaying;
    
    private EffectConfig currentConfig;
    
    private void Awake()
    {
        if (particleSystem == null)
            particleSystem = GetComponent<ParticleSystem>();
    }
    
    public void Configure(EffectConfig config)
    {
        currentConfig = config ?? new EffectConfig();
        
        if (particleSystem != null)
        {
            var main = particleSystem.main;
            main.startColor = currentConfig.color;
            main.startLifetime = currentConfig.duration;
            main.startSize = currentConfig.particleSize;
            
            var emission = particleSystem.emission;
            emission.rateOverTime = currentConfig.emissionRate;
        }
    }
    
    public void Play()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
            
            // Auto return to pool after duration
            float duration = currentConfig?.duration ?? 1f;
            Invoke(nameof(ReturnToPoolDelayed), duration + 1f);
        }
    }
    
    public void PlayAt(Vector3 position)
    {
        transform.position = position + (currentConfig?.offset ?? Vector3.zero);
        Play();
    }
    
    public void Stop()
    {
        if (particleSystem != null)
        {
            particleSystem.Stop();
        }
        CancelInvoke(nameof(ReturnToPoolDelayed));
        OnReturnToPoolInternal();
        ReturnToPool();
    }
    
    private void ReturnToPoolDelayed()
    {
        OnReturnToPoolInternal();
        ReturnToPool();
    }
    
    private void OnReturnToPoolInternal()
    {
        if (particleSystem != null && particleSystem.isPlaying)
        {
            particleSystem.Stop();
        }
        CancelInvoke();
    }
    
    protected override void Start()
    {
        base.Start();
        // Additional setup if needed
    }
}