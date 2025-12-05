using UnityEngine;

/// <summary>
/// Interfaz para servicios de audio
/// Principio: Single Responsibility Principle (SRP) - Solo operaciones de audio
/// Principio: Interface Segregation Principle (ISP) - Interfaz específica
/// </summary>
public interface IAudioService
{
    void PlaySound(Sound sound);
    void PlaySoundAtPosition(Sound sound, Vector3 position);
    void StopSound(Sound sound);
    void SetVolume(Sound sound, float volume);
    void SetGlobalVolume(float volume);
    bool IsPlaying(Sound sound);
}

/// <summary>
/// Interfaz para configuración de audio
/// Principio: Single Responsibility Principle (SRP) - Solo configuración
/// </summary>
public interface IAudioConfiguration
{
    AudioClip GetClip(Sound sound);
    float GetVolume(Sound sound);
    bool HasSound(Sound sound);
    float GetPitch(Sound sound);
}

/// <summary>
/// Interfaz para factory de audio sources
/// Patrón: Factory Pattern
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevos tipos
/// </summary>
public interface IAudioSourceFactory
{
    AudioSource CreateAudioSource(AudioClip clip, float volume);
    AudioSource Create2DAudioSource(AudioClip clip, float volume);
    AudioSource Create3DAudioSource(AudioClip clip, float volume, Vector3 position);
}

/// <summary>
/// Interfaz para estrategias de reproducción de audio
/// Patrón: Strategy Pattern
/// Principio: Open/Closed Principle (OCP) - Diferentes estrategias de reproducción
/// </summary>
public interface IAudioPlayStrategy
{
    void Play(AudioSource audioSource);
    void Stop(AudioSource audioSource);
    void SetVolume(AudioSource audioSource, float volume);
}

/// <summary>
/// Interfaz para gestión de pools de audio sources
/// Patrón: Object Pool Pattern
/// Principio: Single Responsibility Principle (SRP) - Solo gestión de pool
/// </summary>
public interface IAudioSourcePool
{
    AudioSource GetAudioSource();
    void ReturnAudioSource(AudioSource audioSource);
    void Clear();
}