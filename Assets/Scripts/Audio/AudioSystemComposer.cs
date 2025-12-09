using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Composer que integra el sistema de audio refactorizado
/// Patrón: Facade Pattern - Simplifica el acceso al sistema de audio
/// Principio: Dependency Inversion Principle (DIP) - Usa interfaces
/// Principio: Single Responsibility Principle (SRP) - Solo coordina componentes de audio
/// </summary>
[System.Obsolete("AudioSystemComposer is deprecated. Use IAudioService from ServiceLocator with LegacySoundAdapter instead.")]
public class AudioSystemComposer : MonoBehaviourSingleton<AudioSystemComposer>
{
    [Header("Audio Configuration")]
    [SerializeField] private AudioConfig[] audioConfigs;
    [SerializeField] private AudioMixerGroup audioMixerGroup;
    
    [Header("Settings")]
    [SerializeField] private AudioPlayStrategyType defaultStrategy = AudioPlayStrategyType.Standard;
    
    // Sistemas SOLID
    private IAudioService audioService;
    private IAudioConfiguration configuration;
    private IAudioSourceFactory sourceFactory;
    private IAudioPlayStrategy playStrategy;
    
    public enum AudioPlayStrategyType
    {
        Standard,
        Fade,
        NonOverlapping
    }
    
    protected override void Awake()
    {
        base.Awake();
        InitializeAudioSystem();
    }
    
    private void InitializeAudioSystem()
    {
        // Crear configuración
        configuration = new AudioConfiguration(audioConfigs);
        
        // Crear factory
        sourceFactory = new AudioSourceFactory(audioMixerGroup, gameObject);
        
        // Crear estrategia de reproducción
        playStrategy = CreatePlayStrategy(defaultStrategy);
        
        // Crear servicio de audio
        audioService = new AudioService(configuration, sourceFactory, playStrategy);
        
        Debug.Log("[AudioSystemComposer] Sistema de audio inicializado con principios SOLID");
    }
    
    private IAudioPlayStrategy CreatePlayStrategy(AudioPlayStrategyType strategyType)
    {
        switch (strategyType)
        {
            case AudioPlayStrategyType.Fade:
                return new FadeAudioPlayStrategy();
            case AudioPlayStrategyType.NonOverlapping:
                return new NonOverlappingAudioPlayStrategy();
            case AudioPlayStrategyType.Standard:
            default:
                return new StandardAudioPlayStrategy();
        }
    }
    
    // API pública para mantener compatibilidad
    public void PlaySound(Sound sound)
    {
        audioService?.PlaySound(sound);
    }
    
    public void PlaySoundAtPosition(Sound sound, Vector3 position)
    {
        audioService?.PlaySoundAtPosition(sound, position);
    }
    
    public void StopSound(Sound sound)
    {
        audioService?.StopSound(sound);
    }
    
    public void SetVolume(Sound sound, float volume)
    {
        audioService?.SetVolume(sound, volume);
    }
    
    public void SetGlobalVolume(float volume)
    {
        audioService?.SetGlobalVolume(volume);
    }
    
    public bool IsPlaying(Sound sound)
    {
        return audioService?.IsPlaying(sound) ?? false;
    }
    
    // Método para cambiar estrategia en runtime
    public void ChangePlayStrategy(AudioPlayStrategyType newStrategy)
    {
        playStrategy = CreatePlayStrategy(newStrategy);
        
        // Recrear el servicio con la nueva estrategia
        audioService = new AudioService(configuration, sourceFactory, playStrategy);
        
        Debug.Log($"[AudioSystemComposer] Estrategia de audio cambiada a: {newStrategy}");
    }
    
    // Método para compatibilidad con el sistema anterior
    public void Play(Sound sound)
    {
        PlaySound(sound);
    }
}