namespace CleanArchitecture.Domain.Progress
{
    /// <summary>
    /// Contrato para leer/escribir progreso de usuario.
    /// </summary>
    public interface IProgressRepository
    {
        UserProgressRecord Load(string username);
        void Save(UserProgressRecord record);
    }
}
