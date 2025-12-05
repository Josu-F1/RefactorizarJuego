using UnityEngine;

/// <summary>
/// Configuración individual de audio compatible con el enum Sound existente
/// Principio: Single Responsibility Principle (SRP) - Solo maneja configuración de un audio
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevos tipos de audio
/// </summary>
[System.Serializable]
public class AudioConfig
{
    [Header("Audio Identification")]
    [SerializeField] private Sound sound;
    public Sound Sound => sound;
    
    [Header("Audio Properties")]
    [SerializeField] private AudioClip clip;
    public AudioClip Clip => clip;
    
    [SerializeField, Range(0f, 1f)] private float volume = 0.5f;
    public float Volume => volume;
    
    [SerializeField, Range(0f, 3f)] private float pitch = 1f;
    public float Pitch => pitch;
    
    [SerializeField] private bool loop = false;
    public bool Loop => loop;
    
    [Header("3D Audio Settings")]
    [SerializeField] private bool is3D = false;
    public bool Is3D => is3D;
    
    [SerializeField, Range(0f, 500f)] private float maxDistance = 50f;
    public float MaxDistance => maxDistance;
    
    [SerializeField, Range(0f, 1f)] private float spatialBlend = 0f;
    public float SpatialBlend => spatialBlend;
    
    [Header("Advanced Settings")]
    [SerializeField, Range(0f, 1f)] private float priority = 0.5f;
    public float Priority => priority;
    
    /// <summary>
    /// Aplica la configuración a un AudioSource
    /// </summary>
    public void ApplyToAudioSource(AudioSource audioSource)
    {
        if (audioSource == null) return;
        
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.loop = loop;
        audioSource.priority = Mathf.RoundToInt(priority * 256f);
        
        if (is3D)
        {
            audioSource.spatialBlend = 1f; // 3D
            audioSource.maxDistance = maxDistance;
        }
        else
        {
            audioSource.spatialBlend = 0f; // 2D
        }
    }
    
    /// <summary>
    /// Valida que la configuración sea válida
    /// </summary>
    public bool IsValid()
    {
        return clip != null;
    }
}