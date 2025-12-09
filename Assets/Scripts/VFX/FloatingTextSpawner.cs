using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// OBSOLETO: Usar VFXSystemComposer en su lugar
/// Refactorizado aplicando Observer Pattern y principios SOLID
/// Migrar a: VFXSystemComposer con VFXGameEventObserver
/// Fecha: Diciembre 2024
/// Razón: Violación SRP (spawning + eventos + configuración), acoplamiento fuerte con Health/Enemy
/// </summary>
[System.Obsolete("Use VFXSystemComposer with VFXGameEventObserver instead - Refactored with Observer Pattern and SOLID principles", false)]
public class FloatingTextSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool floatingTextPool;
    [Header("Health")]
    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private Color healColor = Color.green;
    [Header("Score")]
    [SerializeField] private Color scoreColor = Color.yellow;
    
    private Transform playerTransform;
    
    // Sistema de compatibilidad hacia atrás
    private VFXSystemComposer vfxSystemComposer;
    
    private void Start()
    {
        // Intentar usar el sistema refactorizado primero
        vfxSystemComposer = VFXSystemComposer.Instance;
        
        if (vfxSystemComposer != null)
        {
            Debug.Log("[FloatingTextSpawner] Delegando a VFXSystemComposer (SOLID refactorizado)");
            // El VFXGameEventObserver ya maneja estos eventos automáticamente
            return;
        }
        else
        {
            // Fallback al sistema legacy (silenciado hasta completar migración)
            InitializeLegacySystem();
        }
    }
    
    private void InitializeLegacySystem()
    {
        playerTransform = Player.Instance.transform;
        global::Health.OnAnyCharacterHealthChanged += SpawnDamageText;
        Enemy.OnAnyEnemyKilled += SpawnScoreText;
    }
    
    /// <summary>
    /// OBSOLETO: El VFXGameEventObserver maneja esto automáticamente
    /// </summary>
    [System.Obsolete("VFXGameEventObserver handles this automatically", false)]
    private void SpawnScoreText(int score)
    {
        // Usar sistema refactorizado si está disponible
        if (vfxSystemComposer != null)
        {
            vfxSystemComposer.SpawnScoreText(score, playerTransform);
            return;
        }
        
        // Sistema legacy
        if (floatingTextPool != null && playerTransform != null)
        {
            TextMeshPro floatingText = floatingTextPool.Get(playerTransform.position).GetComponent<TextMeshPro>();
            floatingText.GetComponent<TransformAttach>().AttachTransform = playerTransform;
            floatingText.text = string.Format("+{0}", score);
            floatingText.color = scoreColor;
        }
    }
    
    /// <summary>
    /// OBSOLETO: El VFXGameEventObserver maneja esto automáticamente
    /// </summary>
    [System.Obsolete("VFXGameEventObserver handles this automatically", false)]
    private void SpawnDamageText(float changedAmount, global::Health health)
    {
        // Usar sistema refactorizado si está disponible
        if (vfxSystemComposer != null)
        {
            if (changedAmount > 0)
                vfxSystemComposer.SpawnHealText((int)changedAmount, health.transform);
            else
                vfxSystemComposer.SpawnDamageText((int)Mathf.Abs(changedAmount), health.transform);
            return;
        }
        
        // Sistema legacy
        if (floatingTextPool != null)
        {
            TextMeshPro floatingText = floatingTextPool.Get(health.transform.position).GetComponent<TextMeshPro>();
            floatingText.GetComponent<TransformAttach>().AttachTransform = health.transform;
            int displayAmount = (int)Mathf.Abs(changedAmount);
            floatingText.text = displayAmount.ToString();
            floatingText.color = changedAmount > 0 ? healColor : damageColor;
        }
    }
    
    private void OnDestroy()
    {
        // Solo limpiar eventos legacy
        if (vfxSystemComposer == null)
        {
            global::Health.OnAnyCharacterHealthChanged -= SpawnDamageText;
            Enemy.OnAnyEnemyKilled -= SpawnScoreText;
        }
    }
}
