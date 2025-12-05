/// <summary>
/// Interface para repositorio de progreso de niveles
/// Patrón: Repository Pattern - Abstrae la persistencia de progreso
/// </summary>
public interface IProgressRepository
{
    int GetPlayerLevel(string username);
    void SavePlayerLevel(string username, int level);
    void ResetProgress(string username);
}