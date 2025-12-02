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
        // Intentar usar el sistema refactorizado primero
        audioSystemComposer = AudioSystemComposer.Instance;
        
        if (audioSystemComposer == null)
        {
            // Fallback al sistema legacy
            audioManager = AudioManager.Instance;
            Debug.LogWarning("[AudioPlayer] Usando AudioManager legacy. Recomienda migrar a AudioSystemComposer.");
        }
        else
        {
            Debug.Log("[AudioPlayer] Usando AudioSystemComposer (SOLID refactorizado)");
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
        if (audioSystemComposer != null)
        {
            // Sistema refactorizado con SOLID
            if (usePositionalAudio)
            {
                audioSystemComposer.PlaySoundAtPosition(sound, transform.position);
            }
            else
            {
                audioSystemComposer.PlaySound(sound);
            }
        }
        else if (audioManager != null)
        {
            // Sistema legacy
            audioManager.Play(sound);
        }
        else
        {
            Debug.LogError("[AudioPlayer] No hay sistema de audio disponible!");
        }
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

