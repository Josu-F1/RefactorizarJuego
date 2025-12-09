using System.Collections.Generic;
using UnityEngine;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Infrastructure.Services
{
    /// <summary>
    /// Implementación del servicio de audio
    /// Gestiona reproducción de sonidos y música
    /// </summary>
    public class AudioService : CleanArchitecture.Application.Services.IAudioService
    {
        private readonly Transform _audioRoot;
        private readonly Dictionary<string, AudioSource> _audioSources = new Dictionary<string, AudioSource>();
        private AudioSource _musicSource;

        public float MasterVolume { get; set; } = 1f;
        public float SFXVolume { get; set; } = 1f;
        public float MusicVolume { get; set; } = 1f;

        private bool _isMuted = false;

        public AudioService(Transform audioRoot = null)
        {
            // Crear GameObject para alojar AudioSources
            if (audioRoot == null)
            {
                var go = new GameObject("[AudioService]");
                Object.DontDestroyOnLoad(go);
                _audioRoot = go.transform;
            }
            else
            {
                _audioRoot = audioRoot;
            }

            // Crear AudioSource para música
            _musicSource = CreateAudioSource("Music");
            _musicSource.loop = true;

            Debug.Log("[AudioService] ✅ Servicio de audio inicializado");
        }

        public void PlaySound(AudioClip clip, float volume = 1f)
        {
            if (clip == null || _isMuted) return;

            var source = GetOrCreateAudioSource(clip.name);
            source.clip = clip;
            source.volume = volume * SFXVolume * MasterVolume;
            source.loop = false;
            source.Play();
        }

        public void PlaySoundAtPosition(AudioClip clip, Vector3 position, float volume = 1f)
        {
            if (clip == null || _isMuted) return;

            AudioSource.PlayClipAtPoint(clip, position, volume * SFXVolume * MasterVolume);
        }

        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            if (clip == null || _isMuted) return;

            _musicSource.clip = clip;
            _musicSource.loop = loop;
            _musicSource.volume = MusicVolume * MasterVolume;
            _musicSource.Play();

            Debug.Log($"[AudioService] 🎵 Música reproducida: {clip.name}");
        }

        public void StopMusic()
        {
            _musicSource.Stop();
            Debug.Log("[AudioService] 🔇 Música detenida");
        }

        public void SetMute(bool mute)
        {
            _isMuted = mute;

            foreach (var source in _audioSources.Values)
            {
                source.mute = mute;
            }

            _musicSource.mute = mute;

            Debug.Log($"[AudioService] {(mute ? "🔇 Silenciado" : "🔊 Audio activado")}");
        }

        private AudioSource GetOrCreateAudioSource(string name)
        {
            if (!_audioSources.ContainsKey(name))
            {
                _audioSources[name] = CreateAudioSource(name);
            }

            return _audioSources[name];
        }

        private AudioSource CreateAudioSource(string name)
        {
            var go = new GameObject($"AudioSource_{name}");
            go.transform.SetParent(_audioRoot);
            var source = go.AddComponent<AudioSource>();
            source.playOnAwake = false;
            return source;
        }
    }
}
