using UnityEngine;

/// <summary>
/// Estrategia estándar de reproducción de audio
/// Patrón: Strategy Pattern - Estrategia básica de reproducción
/// Principio: Single Responsibility Principle (SRP) - Solo reproducción básica
/// </summary>
public class StandardAudioPlayStrategy : IAudioPlayStrategy
{
    public void Play(AudioSource audioSource)
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
    
    public void Stop(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
    
    public void SetVolume(AudioSource audioSource, float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(volume);
        }
    }
}

/// <summary>
/// Estrategia de reproducción con fade
/// Patrón: Strategy Pattern - Estrategia con efectos de fade
/// Principio: Open/Closed Principle (OCP) - Extensión sin modificar estrategia base
/// </summary>
public class FadeAudioPlayStrategy : IAudioPlayStrategy
{
    private float fadeDuration;
    
    public FadeAudioPlayStrategy(float fadeDuration = 1f)
    {
        this.fadeDuration = fadeDuration;
    }
    
    public void Play(AudioSource audioSource)
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.volume = 0f;
            audioSource.Play();
            // En una implementación real, aquí haríamos el fade in con corrutina
            FadeIn(audioSource);
        }
    }
    
    public void Stop(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            // En una implementación real, aquí haríamos el fade out con corrutina
            FadeOut(audioSource);
        }
    }
    
    public void SetVolume(AudioSource audioSource, float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(volume);
        }
    }
    
    private void FadeIn(AudioSource audioSource)
    {
        // Implementación simplificada - en un proyecto real usaríamos corrutinas
        audioSource.volume = 0.5f;
    }
    
    private void FadeOut(AudioSource audioSource)
    {
        // Implementación simplificada - en un proyecto real usaríamos corrutinas
        audioSource.volume = 0f;
        audioSource.Stop();
    }
}

/// <summary>
/// Estrategia de reproducción que evita solapamientos
/// Patrón: Strategy Pattern - Estrategia que previene múltiples reproducciones
/// </summary>
public class NonOverlappingAudioPlayStrategy : IAudioPlayStrategy
{
    public void Play(AudioSource audioSource)
    {
        if (audioSource != null && audioSource.clip != null)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
    
    public void Stop(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
    
    public void SetVolume(AudioSource audioSource, float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(volume);
        }
    }
}