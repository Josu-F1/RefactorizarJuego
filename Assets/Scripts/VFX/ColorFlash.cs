using UnityEngine;

/// <summary>
/// OBSOLETO: Usar ColorFlashEffect o VFXSystemComposer.FlashColor en su lugar
/// Refactorizado aplicando Strategy Pattern y principios SOLID
/// Migrar a: ColorFlashEffect que implementa IConfigurableEffect
/// Fecha: Diciembre 2024
/// Razón: Update loop innecesario, falta de configurabilidad, no reutilizable
/// </summary>
[System.Obsolete("Use ColorFlashEffect or VFXSystemComposer.FlashColor instead - Refactored with Strategy Pattern", false)]
public class ColorFlash : MonoBehaviour
{
    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] private float duration = 0.2f;
    private float durationLeft;
    private bool isOriginalColor;
    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    
    // Sistema de compatibilidad
    private ColorFlashEffect modernEffect;
    private VFXSystemComposer vfxSystemComposer;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        
        // Intentar obtener el sistema refactorizado
        vfxSystemComposer = VFXSystemComposer.Instance;
        if (vfxSystemComposer != null)
        {
            // Migrar automáticamente a ColorFlashEffect
            modernEffect = gameObject.GetComponent<ColorFlashEffect>();
            if (modernEffect == null)
            {
                modernEffect = gameObject.AddComponent<ColorFlashEffect>();
            }
            Debug.Log("[ColorFlash] Migrado automáticamente a ColorFlashEffect (SOLID refactorizado)");
        }
        else
        {
            Debug.LogWarning("[ColorFlash] OBSOLETO: Usando implementación legacy. Migrar a ColorFlashEffect.");
        }
    }
    
    private void Update()
    {
        // Solo usar Update loop si no hay sistema moderno
        if (modernEffect != null || isOriginalColor) return;
        
        if (durationLeft > 0)
        {
            durationLeft -= Time.deltaTime;
            return;
        }
        Reset();
    }
    
    /// <summary>
    /// OBSOLETO: Usar ColorFlashEffect.Play() o VFXSystemComposer.FlashColor()
    /// </summary>
    [System.Obsolete("Use ColorFlashEffect.Play() or VFXSystemComposer.FlashColor() instead", false)]
    public void Flash()
    {
        // Usar sistema refactorizado si está disponible
        if (modernEffect != null)
        {
            var config = new EffectConfig
            {
                color = flashColor,
                duration = duration
            };
            modernEffect.Configure(config);
            modernEffect.Play();
            return;
        }
        else if (vfxSystemComposer != null)
        {
            vfxSystemComposer.FlashColor(gameObject, flashColor, duration);
            return;
        }
        
        // Sistema legacy
        if (spriteRenderer != null)
        {
            spriteRenderer.color = flashColor;
            isOriginalColor = false;
            durationLeft = duration;
        }
    }
    
    private void Reset()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
            isOriginalColor = true;
            durationLeft = 0;
        }
    }
}
