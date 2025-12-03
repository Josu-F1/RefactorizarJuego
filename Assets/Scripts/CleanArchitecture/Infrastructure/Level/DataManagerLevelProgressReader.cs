using CleanArchitecture.Domain.Level;

/// <summary>
/// Adaptador de solo lectura para progreso de niveles usando DataManagerComposer legacy.
/// </summary>
namespace CleanArchitecture.Infrastructure.Level
{
    public class DataManagerLevelProgressReader : ILevelProgressReader
    {
        public int GetCompletedLevel(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return 0;
            return global::DataManagerComposer.GetPlayerLevel(username);
        }
    }
}
