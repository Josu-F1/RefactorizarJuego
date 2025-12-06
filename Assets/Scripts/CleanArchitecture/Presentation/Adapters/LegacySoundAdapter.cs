using UnityEngine;
using CleanArchitecture.Infrastructure.DependencyInjection;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Presentation.Adapters
{
    /// <summary>
    /// Adapter que permite usar el enum Sound legacy con el nuevo AudioService
    /// Mapea sonidos del enum a AudioClips
    /// </summary>
    public class LegacySoundAdapter : MonoBehaviour
    {
        [System.Serializable]
        public class SoundMapping
        {
            public Sound sound;
            public AudioClip clip;
            [Range(0f, 1f)]
            public float volume = 1f;
        }

        [Header("Mapeo de Sonidos Legacy")]
        [SerializeField] private SoundMapping[] soundMappings;

        private CleanArchitecture.Application.Services.IAudioService _audioService;

        private void Awake()
        {
            _audioService = ServiceLocator.Instance.Get<CleanArchitecture.Application.Services.IAudioService>();

            if (_audioService == null)
            {
                Debug.LogError("[LegacySoundAdapter] ❌ AudioService no encontrado");
            }
            else
            {
                Debug.Log("[LegacySoundAdapter] ✅ Conectado al AudioService");
            }
        }

        /// <summary>
        /// Reproduce un sonido usando el enum Sound legacy
        /// </summary>
        public void PlaySound(Sound sound)
        {
            if (_audioService == null) return;

            var mapping = GetMapping(sound);
            if (mapping != null)
            {
                _audioService.PlaySound(mapping.clip, mapping.volume);
            }
            else
            {
                Debug.LogWarning($"[LegacySoundAdapter] Sonido {sound} no mapeado");
            }
        }

        /// <summary>
        /// Reproduce un sonido en una posición específica
        /// </summary>
        public void PlaySoundAtPosition(Sound sound, Vector3 position)
        {
            if (_audioService == null) return;

            var mapping = GetMapping(sound);
            if (mapping != null)
            {
                _audioService.PlaySoundAtPosition(mapping.clip, position, mapping.volume);
            }
        }

        private SoundMapping GetMapping(Sound sound)
        {
            foreach (var mapping in soundMappings)
            {
                if (mapping.sound == sound)
                    return mapping;
            }
            return null;
        }

        /// <summary>
        /// Método estático para acceso global (mantiene compatibilidad con código legacy)
        /// </summary>
        private static LegacySoundAdapter _instance;
        public static LegacySoundAdapter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<LegacySoundAdapter>();
                }
                return _instance;
            }
        }
    }
}
