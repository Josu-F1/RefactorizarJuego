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
        
        // Compatibilidad: Si no existe AudioSystemComposer, usar implementación original
        audioSystemComposer = FindObjectOfType<AudioSystemComposer>();
        
        if (audioSystemComposer == null)
        {
            Debug.LogWarning("[AudioManager] OBSOLETO: Usando implementación legacy. Migrar a AudioSystemComposer.");
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
    /// OBSOLETO: Usar AudioSystemComposer.PlaySound() en su lugar
    /// </summary>
    [System.Obsolete("Use AudioSystemComposer.PlaySound() instead", false)]
    public void Play(Sound sound)
    {
        // Delegar al nuevo sistema si existe
        if (audioSystemComposer != null)
        {
            audioSystemComposer.PlaySound(sound);
        }
        else
        {
            // Implementación legacy
            if (audioDictionary.ContainsKey(sound))
            {
                audioDictionary[sound].audioSource.Play();
            }
        }
    }
}
