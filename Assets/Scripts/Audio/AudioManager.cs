using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum Sound
{
    Pickup
}

/// <summary>
/// OBSOLETO: Usar AudioSystemComposer en su lugar
/// Refactorizado aplicando SOLID y Strategy Pattern
/// Migrar a: AudioSystemComposer que incluye múltiples estrategias de audio
/// Fecha: Diciembre 2024
/// Razón: Violación de SRP, falta de extensibilidad, acoplamiento fuerte
/// </summary>
[System.Obsolete("Use AudioSystemComposer instead - Refactored with SOLID principles and Strategy Pattern", false)]
public class AudioManager : MonoBehaviourSingleton<AudioManager>
{
    // Sistema de compatibilidad hacia atrás
    private AudioSystemComposer audioSystemComposer;

    [System.Serializable]
    private class Audio
    {
        [SerializeField]
        private Sound sound;
        public Sound Sound => sound;
        [SerializeField]
        private AudioClip clip;
        public AudioClip Clip => clip;
        [SerializeField]
        private float volume = 0.5f;
        public float Volume => volume;
        public AudioSource audioSource { get; set; }
    }
    
    [SerializeField] private AudioMixerGroup audioMixerGroup;
    [SerializeField] private Audio[] audios;
    private Dictionary<Sound, Audio> audioDictionary = new Dictionary<Sound, Audio>();
    
    protected override void Awake()
    {
        base.Awake();
        
        // Compatibilidad: Intentar usar el nuevo sistema primero
        var legacyAdapter = FindObjectOfType<CleanArchitecture.Presentation.Adapters.LegacySoundAdapter>();
        
        if (legacyAdapter != null)
        {
            Debug.Log("[AudioManager] Delegando a LegacySoundAdapter (Clean Architecture)");
            return;
        }
        
        // Segundo nivel: AudioSystemComposer
        audioSystemComposer = FindObjectOfType<AudioSystemComposer>();
        
        if (audioSystemComposer == null)
        {
            // Sistema legacy (silenciado hasta completar migración)
            InitializeLegacyAudio();
        }
        else
        {
            Debug.Log("[AudioManager] Delegando a AudioSystemComposer (SOLID refactorizado)");
        }
    }
    
    private void InitializeLegacyAudio()
    {
        foreach (var audio in audios)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audio.Clip;
            audioSource.volume = audio.Volume;
            audioSource.outputAudioMixerGroup = audioMixerGroup;

            audio.audioSource = audioSource;
            audioDictionary[audio.Sound] = audio;
        }
    }
    
    /// <summary>
    /// OBSOLETO: Usar LegacySoundAdapter o AudioService directamente
    /// </summary>
    [System.Obsolete("Use LegacySoundAdapter or AudioService directly", false)]
    public void Play(Sound sound)
    {
        // Prioridad 1: Clean Architecture
        var legacyAdapter = CleanArchitecture.Presentation.Adapters.LegacySoundAdapter.Instance;
        if (legacyAdapter != null)
        {
            legacyAdapter.PlaySound(sound);
            return;
        }
        
        // Prioridad 2: AudioSystemComposer
        if (audioSystemComposer != null)
        {
            audioSystemComposer.PlaySound(sound);
            return;
        }
        
        // Prioridad 3: Implementación legacy
        if (audioDictionary.ContainsKey(sound))
        {
            audioDictionary[sound].audioSource.Play();
        }
    }
}
