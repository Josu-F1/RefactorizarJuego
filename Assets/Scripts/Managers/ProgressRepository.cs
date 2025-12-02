/// <summary>
/// Repositorio de progreso usando provider de persistencia
/// Patrón: Repository Pattern - Maneja operaciones de progreso
/// Principio: Single Responsibility Principle (SRP) - Solo progreso
/// </summary>
public class ProgressRepository : IProgressRepository
{
    private IPersistenceProvider persistenceProvider;
    private const string USER_KEY_PREFIX = "Player_";
    private const string USER_KEY_SUFFIX = "_Level";
    
    public ProgressRepository(IPersistenceProvider persistenceProvider)
    {
        this.persistenceProvider = persistenceProvider;
    }
    
    public int GetPlayerLevel(string username)
    {
        if (string.IsNullOrEmpty(username)) return 0;
        
        string key = GenerateProgressKey(username);
        return persistenceProvider.GetInt(key, 0);
    }
    
    public void SavePlayerLevel(string username, int level)
    {
        if (string.IsNullOrEmpty(username) || level < 0) return;
        
        string key = GenerateProgressKey(username);
        persistenceProvider.SetInt(key, level);
        persistenceProvider.Save();
    }
    
    public void ResetProgress(string username)
    {
        if (string.IsNullOrEmpty(username)) return;
        
        string key = GenerateProgressKey(username);
        persistenceProvider.SetInt(key, 0);
        persistenceProvider.Save();
    }
    
    private string GenerateProgressKey(string username)
    {
        return $"{USER_KEY_PREFIX}{username}{USER_KEY_SUFFIX}";
    }
}