namespace CleanArchitecture.Domain.Audio
{
    /// <summary>
    /// Identificador de sonido; usamos el enum Sound existente para compatibilidad.
    /// </summary>
    public readonly struct SoundId
    {
        public readonly Sound SoundEnum;

        public SoundId(Sound sound)
        {
            SoundEnum = sound;
        }
    }
}
