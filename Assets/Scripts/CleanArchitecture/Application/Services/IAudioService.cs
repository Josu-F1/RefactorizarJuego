using UnityEngine;

namespace CleanArchitecture.Application.Services
{
    /// <summary>
    /// Servicio para reproducir audio
    /// Reemplaza AudioManager singleton
    /// </summary>
    public interface IAudioService
    {
        /// <summary>
        /// Reproduce un clip de audio
        /// </summary>
        void PlaySound(AudioClip clip, float volume = 1f);

        /// <summary>
        /// Reproduce un sonido en una posición 3D
        /// </summary>
        void PlaySoundAtPosition(AudioClip clip, Vector3 position, float volume = 1f);

        /// <summary>
        /// Reproduce música de fondo
        /// </summary>
        void PlayMusic(AudioClip clip, bool loop = true);

        /// <summary>
        /// Detiene la música
        /// </summary>
        void StopMusic();

        /// <summary>
        /// Volumen maestro (0-1)
        /// </summary>
        float MasterVolume { get; set; }

        /// <summary>
        /// Volumen de efectos (0-1)
        /// </summary>
        float SFXVolume { get; set; }

        /// <summary>
        /// Volumen de música (0-1)
        /// </summary>
        float MusicVolume { get; set; }

        /// <summary>
        /// Silencia/activa todo el audio
        /// </summary>
        void SetMute(bool mute);
    }
}
