namespace CleanArchitecture.Domain.Navigation
{
    /// <summary>
    /// Contrato para cambiar/recargar escenas.
    /// </summary>
    public interface INavRepository
    {
        void Load(SceneId scene);
        void ReloadCurrent();
    }
}
