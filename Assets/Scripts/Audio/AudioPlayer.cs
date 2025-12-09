#pragma warning disable CS0618 // Type or member is obsolete
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reproductor de audio refactorizado con principios SOLID
/// Principio: Dependency Inversion Principle (DIP) - Usa interfaces, no implementaciones concretas
/// Principio: Single Responsibility Principle (SRP) - Solo reproduce un audio específico
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevos comportamientos de reproducción
/// </summary>
public class AudioPlayer : MonoBehaviour
{
    [Header("Audio Configuration")]
    [SerializeField] private Sound sound;
    
    [Header("Playback Options")]
    [SerializeField] private bool playOnStart = false;
    [SerializeField] private bool usePositionalAudio = false;
    
    // Sistema refactorizado (preferido)
    private AudioSystemComposer audioSystemComposer;
    
    // Sistema legacy (compatibilidad)
    private AudioManager audioManager;
    
    private void Start() 
    {
        // Prioridad 1: Clean Architecture (LegacySoundAdapter)
        var legacyAdapter = CleanArchitecture.Presentation.Adapters.LegacySoundAdapter.Instance;
        
        if (legacyAdapter != null)
        {
            Debug.Log("[AudioPlayer] Usando LegacySoundAdapter (Clean Architecture)");
        }
        else
        {
            // Fallback al sistema legacy
            audioManager = AudioManager.Instance;
            if (audioManager == null)
            {
                Debug.LogWarning("[AudioPlayer] No hay sistema de audio disponible. Recomienda migrar a Clean Architecture.");
            }
        }
        
        if (playOnStart)
        {
            Play();
        }
    }
    
    /// <summary>
    /// Reproduce el audio configurado
    /// </summary>
    public void Play()
    {
        // Prioridad 1: Clean Architecture
        var legacyAdapter = CleanArchitecture.Presentation.Adapters.LegacySoundAdapter.Instance;
        if (legacyAdapter != null)
        {
            if (usePositionalAudio)
            {
                legacyAdapter.PlaySoundAtPosition(sound, transform.position);
            }
            else
            {
                legacyAdapter.PlaySound(sound);
            }
            return;
        }
        
        // Fallback: Sistema legacy
        if (audioManager != null)
        {
            audioManager.Play(sound);
            return;
        }
        
        Debug.LogError("[AudioPlayer] No hay sistema de audio disponible!");
    }
    
    /// <summary>
    /// Detiene el audio si está reproduciéndose
    /// </summary>
    public void Stop()
    {
        if (audioSystemComposer != null)
        {
            audioSystemComposer.StopSound(sound);
        }
        else
        {
            Debug.LogWarning("[AudioPlayer] Stop no disponible en sistema legacy");
        }
    }
    
    /// <summary>
    /// Verifica si el audio está reproduciéndose
    /// </summary>
    public bool IsPlaying()
    {
        if (audioSystemComposer != null)
        {
            return audioSystemComposer.IsPlaying(sound);
        }
        
        return false; // Sistema legacy no soporta esta funcionalidad
    }
    
    /// <summary>
    /// Cambia el volumen del audio
    /// </summary>
    public void SetVolume(float volume)
    {
        if (audioSystemComposer != null)
        {
            audioSystemComposer.SetVolume(sound, volume);
        }
        else
        {
            Debug.LogWarning("[AudioPlayer] SetVolume no disponible en sistema legacy");
        }
    }
}

