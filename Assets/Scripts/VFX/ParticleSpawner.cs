#pragma warning disable 0649
using UnityEngine;

/// <summary>
/// OBSOLETO: Usar VFXSystemComposer.SpawnEffect o ParticleEffect en su lugar
/// Refactorizado aplicando Factory Pattern y principios SOLID
/// Migrar a: VFXSystemComposer con EffectType.ParticleExplosion
/// Fecha: Diciembre 2024
/// Razón: Instantiate/Destroy manual, falta de pooling, configuración limitada
/// </summary>
[System.Obsolete("Use VFXSystemComposer.SpawnEffect or ParticleEffect instead - Refactored with Factory Pattern and pooling", false)]
public class ParticleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject particlePrefab;
    [SerializeField]
    private float lifetime = 1f;
    [SerializeField]
    private Color color = Color.white;
    
    // Sistema de compatibilidad
    private VFXSystemComposer vfxSystemComposer;
    
    private void Start()
    {
        vfxSystemComposer = VFXSystemComposer.Instance;
        if (vfxSystemComposer != null)
        {
            Debug.Log("[ParticleSpawner] VFXSystemComposer disponible (SOLID refactorizado)");
        }
        else
        {
            Debug.LogWarning("[ParticleSpawner] OBSOLETO: Usando implementación legacy. Migrar a VFXSystemComposer.");
        }
    }
    
    /// <summary>
    /// OBSOLETO: Usar VFXSystemComposer.SpawnExplosion() en su lugar
    /// </summary>
    [System.Obsolete("Use VFXSystemComposer.SpawnExplosion() instead", false)]
    public void Spawn(Vector3 position)
    {
        // Usar sistema refactorizado si está disponible
        if (vfxSystemComposer != null)
        {
            var config = new EffectConfig
            {
                color = color,
                duration = lifetime,
                particleCount = 20,
                particleSize = 1f
            };
            
            vfxSystemComposer.SpawnEffect(EffectType.ParticleExplosion, position, config);
            return;
        }
        
        // Sistema legacy
        if (particlePrefab != null)
        {
            ParticleSystem particleSystem = Instantiate(particlePrefab, position, Quaternion.identity).GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                ParticleSystem.MainModule settings = particleSystem.main;
                settings.startColor = color;
                Destroy(particleSystem.gameObject, lifetime);
            }
        }
    }
    
    /// <summary>
    /// OBSOLETO: Usar VFXSystemComposer.SpawnExplosion() en su lugar
    /// </summary>
    [System.Obsolete("Use VFXSystemComposer.SpawnExplosion() instead", false)]
    public void Spawn()
    {
        Spawn(transform.position);
    }
}