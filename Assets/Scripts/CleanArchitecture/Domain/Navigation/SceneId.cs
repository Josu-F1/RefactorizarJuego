namespace CleanArchitecture.Domain.Navigation
{
    /// <summary>
    /// Identificador simple de escena. Usa nombre para compatibilidad.
    /// </summary>
    public readonly struct SceneId
    {
        public readonly string Name;

        public SceneId(string name)
        {
            Name = name;
        }

        public bool IsValid => !string.IsNullOrWhiteSpace(Name);
    }
}
