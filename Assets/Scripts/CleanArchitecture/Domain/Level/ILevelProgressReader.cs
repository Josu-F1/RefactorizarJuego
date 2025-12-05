namespace CleanArchitecture.Domain.Level
{
    /// <summary>
    /// Contrato de solo lectura para progreso de niveles.
    /// </summary>
    public interface ILevelProgressReader
    {
        int GetCompletedLevel(string username);
    }
}
