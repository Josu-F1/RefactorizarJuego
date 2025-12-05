using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Factory para crear AudioSources aplicando Factory Pattern
/// Patrón: Factory Pattern - Crea diferentes tipos de AudioSource
/// Principio: Single Responsibility Principle (SRP) - Solo creación de AudioSource
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevos tipos
/// </summary>
public class AudioSourceFactory : IAudioSourceFactory
{
    private AudioMixerGroup mixerGroup;
    private GameObject parent;
    
    public AudioSourceFactory(AudioMixerGroup mixerGroup, GameObject parent)
    {
        this.mixerGroup = mixerGroup;
        this.parent = parent;
    }
    
    public AudioSource CreateAudioSource(AudioClip clip, float volume)
    {
        return Create2DAudioSource(clip, volume);
    }
    
    public AudioSource Create2DAudioSource(AudioClip clip, float volume)
    {
        AudioSource audioSource = parent.AddComponent<AudioSource>();
        ConfigureAudioSource(audioSource, clip, volume);
        
        // Configuración 2D
        audioSource.spatialBlend = 0f; // 2D
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        
        return audioSource;
    }
    
    public AudioSource Create3DAudioSource(AudioClip clip, float volume, Vector3 position)
    {
        // Crear GameObject separado para audio 3D
        GameObject audioObject = new GameObject($"Audio3D_{clip.name}");
        audioObject.transform.position = position;
        
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        ConfigureAudioSource(audioSource, clip, volume);
        
        // Configuración 3D
        audioSource.spatialBlend = 1f; // 3D
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.minDistance = 1f;
        audioSource.maxDistance = 20f;
        
        return audioSource;
    }
    
    private void ConfigureAudioSource(AudioSource audioSource, AudioClip clip, float volume)
    {
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.outputAudioMixerGroup = mixerGroup;
        audioSource.playOnAwake = false;
    }
}