using UnityEngine;

namespace CleanArchitecture.Domain.Audio
{
    /// <summary>
    /// Contrato para reproducir/pausar sonidos desde casos de uso.
    /// </summary>
    public interface IAudioRepository
    {
        void Play(SoundId sound);
        void PlayAtPosition(SoundId sound, Vector3 position);
        void Stop(SoundId sound);
        void SetVolume(SoundId sound, float volume);
        void SetGlobalVolume(float volume);
        bool IsPlaying(SoundId sound);
    }
}
