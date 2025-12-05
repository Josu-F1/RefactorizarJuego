using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Servicio de audio refactorizado aplicando principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo lógica de audio
/// Principio: Dependency Inversion Principle (DIP) - Depende de interfaces
/// Patrón: Strategy Pattern - Diferentes estrategias de reproducción
/// </summary>
public class AudioService : IAudioService
{
    private IAudioConfiguration configuration;
    private IAudioSourceFactory sourceFactory;
    private IAudioPlayStrategy playStrategy;
    private Dictionary<Sound, AudioSource> audioSources;
    private float globalVolume = 1f;
    
    public AudioService(IAudioConfiguration configuration, IAudioSourceFactory sourceFactory, IAudioPlayStrategy playStrategy)
    {
        this.configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        this.sourceFactory = sourceFactory ?? throw new System.ArgumentNullException(nameof(sourceFactory));
        this.playStrategy = playStrategy ?? throw new System.ArgumentNullException(nameof(playStrategy));
        
        audioSources = new Dictionary<Sound, AudioSource>();
        InitializeAudioSources();
    }
    
    private void InitializeAudioSources()
    {
        // Crear AudioSources para todos los sonidos configurados
        foreach (Sound sound in System.Enum.GetValues(typeof(Sound)))
        {
            if (configuration.HasSound(sound))
            {
                AudioClip clip = configuration.GetClip(sound);
                float volume = configuration.GetVolume(sound);
                float pitch = configuration.GetPitch(sound);
                
                AudioSource audioSource = sourceFactory.CreateAudioSource(clip, volume);
                audioSource.pitch = pitch;
                audioSources[sound] = audioSource;
            }
        }
        
        Debug.Log($"[AudioService] Initialized with {audioSources.Count} audio sources");
    }
    
    public void PlaySound(Sound sound)
    {
        if (audioSources.TryGetValue(sound, out AudioSource audioSource))
        {
            playStrategy.Play(audioSource);
        }
        else
        {
            Debug.LogWarning($"[AudioService] Sound not found: {sound}");
        }
    }
    
    public void PlaySoundAtPosition(Sound sound, Vector3 position)
    {
        if (configuration.HasSound(sound))
        {
            AudioClip clip = configuration.GetClip(sound);
            float volume = configuration.GetVolume(sound) * globalVolume;
            float pitch = configuration.GetPitch(sound);
            
            AudioSource audioSource = sourceFactory.Create3DAudioSource(clip, volume, position);
            audioSource.pitch = pitch;
            playStrategy.Play(audioSource);
            
            // Destruir el AudioSource después de reproducir (para sonidos one-shot)
            if (audioSource.clip != null)
            {
                Object.Destroy(audioSource.gameObject, audioSource.clip.length + 1f);
            }
        }
    }
    
    public void StopSound(Sound sound)
    {
        if (audioSources.TryGetValue(sound, out AudioSource audioSource))
        {
            playStrategy.Stop(audioSource);
        }
    }
    
    public void SetVolume(Sound sound, float volume)
    {
        if (audioSources.TryGetValue(sound, out AudioSource audioSource))
        {
            playStrategy.SetVolume(audioSource, volume * globalVolume);
        }
    }
    
    public void SetGlobalVolume(float volume)
    {
        globalVolume = Mathf.Clamp01(volume);
        
        // Aplicar el volumen global a todos los AudioSources
        foreach (var audioSource in audioSources.Values)
        {
            if (audioSource != null)
            {
                float originalVolume = configuration.GetVolume(GetSoundForAudioSource(audioSource));
                playStrategy.SetVolume(audioSource, originalVolume * globalVolume);
            }
        }
    }
    
    public bool IsPlaying(Sound sound)
    {
        if (audioSources.TryGetValue(sound, out AudioSource audioSource))
        {
            return audioSource != null && audioSource.isPlaying;
        }
        return false;
    }
    
    private Sound GetSoundForAudioSource(AudioSource audioSource)
    {
        foreach (var kvp in audioSources)
        {
            if (kvp.Value == audioSource)
            {
                return kvp.Key;
            }
        }
        return default(Sound);
    }
    
    public void Cleanup()
    {
        audioSources.Clear();
    }
}