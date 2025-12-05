using System;
using UnityEngine;
using CleanArchitecture.Domain.Audio;

namespace CleanArchitecture.Application.Audio
{
    /// <summary>
    /// Caso de uso para reproducir y controlar audio.
    /// </summary>
    public class AudioService
    {
        private readonly IAudioRepository repository;

        public AudioService(IAudioRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void Play(Sound sound)
        {
            repository.Play(new SoundId(sound));
        }

        public void PlayAtPosition(Sound sound, Vector3 position)
        {
            repository.PlayAtPosition(new SoundId(sound), position);
        }

        public void Stop(Sound sound)
        {
            repository.Stop(new SoundId(sound));
        }

        public void SetVolume(Sound sound, float volume)
        {
            repository.SetVolume(new SoundId(sound), volume);
        }

        public void SetGlobalVolume(float volume)
        {
            repository.SetGlobalVolume(volume);
        }

        public bool IsPlaying(Sound sound)
        {
            return repository.IsPlaying(new SoundId(sound));
        }
    }
}
