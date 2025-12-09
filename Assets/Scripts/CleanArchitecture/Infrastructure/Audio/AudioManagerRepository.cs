#pragma warning disable CS0618 // Type or member is obsolete
using System;
using UnityEngine;
using CleanArchitecture.Domain.Audio;

/// <summary>
/// Adaptador que reutiliza AudioSystemComposer o AudioManager legacy.
/// </summary>
namespace CleanArchitecture.Infrastructure.Audio
{
    public class AudioManagerRepository : IAudioRepository
    {
        private readonly AudioSystemComposer composer;
        private readonly AudioManager legacy;

        public AudioManagerRepository(AudioSystemComposer composer)
        {
            this.composer = composer ?? throw new ArgumentNullException(nameof(composer));
        }

        public AudioManagerRepository(AudioManager legacy)
        {
            this.legacy = legacy ?? throw new ArgumentNullException(nameof(legacy));
        }

        private void EnsureOne()
        {
            if (composer == null && legacy == null)
            {
                throw new InvalidOperationException("No audio backend provided");
            }
        }

        public void Play(SoundId sound)
        {
            EnsureOne();
            if (composer != null) composer.PlaySound(sound.SoundEnum);
            else legacy?.Play(sound.SoundEnum);
        }

        public void PlayAtPosition(SoundId sound, Vector3 position)
        {
            EnsureOne();
            if (composer != null) composer.PlaySoundAtPosition(sound.SoundEnum, position);
            else legacy?.Play(sound.SoundEnum);
        }

        public void Stop(SoundId sound)
        {
            if (composer != null) composer.StopSound(sound.SoundEnum);
        }

        public void SetVolume(SoundId sound, float volume)
        {
            if (composer != null) composer.SetVolume(sound.SoundEnum, volume);
        }

        public void SetGlobalVolume(float volume)
        {
            if (composer != null) composer.SetGlobalVolume(volume);
        }

        public bool IsPlaying(SoundId sound)
        {
            return composer != null ? composer.IsPlaying(sound.SoundEnum) : false;
        }
    }
}
