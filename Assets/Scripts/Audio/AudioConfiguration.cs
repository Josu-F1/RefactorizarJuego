using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

/// <summary>
/// Configuración de audio implementando interfaces SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo configuración
/// Principio: Dependency Inversion Principle (DIP) - Usa abstracciones
/// </summary>
public class AudioConfiguration : IAudioConfiguration
{
    private Dictionary<Sound, AudioConfig> audioConfigs;
    
    public AudioConfiguration(AudioConfig[] configs)
    {
        audioConfigs = new Dictionary<Sound, AudioConfig>();
        
        foreach (var config in configs)
        {
            if (config.Clip != null)
            {
                audioConfigs[config.Sound] = config;
            }
            else
            {
                Debug.LogWarning($"[AudioConfiguration] No clip assigned for sound: {config.Sound}");
            }
        }
    }
    
    public AudioClip GetClip(Sound sound)
    {
        return audioConfigs.TryGetValue(sound, out AudioConfig config) ? config.Clip : null;
    }
    
    public float GetVolume(Sound sound)
    {
        return audioConfigs.TryGetValue(sound, out AudioConfig config) ? config.Volume : 0.5f;
    }
    
    public bool HasSound(Sound sound)
    {
        return audioConfigs.ContainsKey(sound);
    }
    
    public bool IsLoop(Sound sound)
    {
        return audioConfigs.TryGetValue(sound, out AudioConfig config) && config.Loop;
    }
    
    public bool Is3D(Sound sound)
    {
        return audioConfigs.TryGetValue(sound, out AudioConfig config) && config.Is3D;
    }
    
    public float GetPitch(Sound sound)
    {
        return audioConfigs.TryGetValue(sound, out AudioConfig config) ? config.Pitch : 1f;
    }
}