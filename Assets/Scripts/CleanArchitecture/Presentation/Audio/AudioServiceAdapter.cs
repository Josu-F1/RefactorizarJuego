using UnityEngine;
using CaAudioService = CleanArchitecture.Application.Audio.AudioService;
using CleanArchitecture.Infrastructure.Audio;

namespace CleanArchitecture.Presentation.Audio
{
    /// <summary>
    /// MonoBehaviour opcional para usar el AudioService con AudioSystemComposer o AudioManager legacy.
    /// </summary>
    public class AudioServiceAdapter : MonoBehaviour
    {
        [SerializeField] private AudioSystemComposer audioSystemComposer;
        [SerializeField] private AudioManager legacyAudioManager;

        private CaAudioService service;

        private void Awake()
        {
            if (audioSystemComposer == null)
            {
                audioSystemComposer = FindObjectOfType<AudioSystemComposer>();
            }
            if (legacyAudioManager == null)
            {
                legacyAudioManager = FindObjectOfType<AudioManager>();
            }

            if (audioSystemComposer != null)
            {
                var repo = new AudioManagerRepository(audioSystemComposer);
                service = new CaAudioService(repo);
            }
            else if (legacyAudioManager != null)
            {
                var repo = new AudioManagerRepository(legacyAudioManager);
                service = new CaAudioService(repo);
            }
        }

        public void Play(Sound sound) => service?.Play(sound);
        public void PlayAtPosition(Sound sound, Vector3 position) => service?.PlayAtPosition(sound, position);
        public void Stop(Sound sound) => service?.Stop(sound);
        public void SetVolume(Sound sound, float volume) => service?.SetVolume(sound, volume);
        public void SetGlobalVolume(float volume) => service?.SetGlobalVolume(volume);
        public bool IsPlaying(Sound sound) => service?.IsPlaying(sound) ?? false;
    }
}
