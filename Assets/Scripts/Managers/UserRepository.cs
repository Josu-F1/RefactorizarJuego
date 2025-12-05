using System.Collections.Generic;

/// <summary>
/// Repositorio de usuarios usando provider de persistencia
/// Patrón: Repository Pattern - Maneja operaciones de usuario
/// Principio: Single Responsibility Principle (SRP) - Solo usuarios
/// </summary>
public class UserRepository : IUserRepository
{
    private IPersistenceProvider persistenceProvider;
    private const string USER_KEY_PREFIX = "Player_";
    private const string USER_KEY_SUFFIX = "_Level";
    
    public UserRepository(IPersistenceProvider persistenceProvider)
    {
        this.persistenceProvider = persistenceProvider;
    }
    
    public bool UserExists(string username)
    {
        if (string.IsNullOrEmpty(username)) return false;
        
        string key = GenerateUserKey(username);
        return persistenceProvider.HasKey(key);
    }
    
    public void CreateUser(string username)
    {
        if (string.IsNullOrEmpty(username)) return;
        
        string key = GenerateUserKey(username);
        persistenceProvider.SetInt(key, 0); // Nivel inicial
        persistenceProvider.Save();
    }
    
    public bool ValidateUser(string username)
    {
        return !string.IsNullOrEmpty(username) && UserExists(username);
    }
    
    public string[] GetRecentUsernames(int maxCount = 3)
    {
        List<string> recentUsers = new List<string>();
        
        for (int i = 0; i < maxCount; i++)
        {
            string key = $"RecentUser_{i}";
            if (persistenceProvider.HasKey(key))
            {
                string username = persistenceProvider.GetString(key, "");
                if (!string.IsNullOrEmpty(username))
                {
                    recentUsers.Add(username);
                }
            }
        }
        
        return recentUsers.ToArray();
    }
    
    public void AddRecentUsername(string username)
    {
        if (string.IsNullOrEmpty(username)) return;
        
        List<string> recentUsers = new List<string>(GetRecentUsernames(3));
        
        // Remover si ya existe para ponerlo al principio
        recentUsers.Remove(username);
        
        // Agregar al principio
        recentUsers.Insert(0, username);
        
        // Mantener solo los primeros 3
        if (recentUsers.Count > 3)
        {
            recentUsers.RemoveRange(3, recentUsers.Count - 3);
        }
        
        // Guardar la lista actualizada
        for (int i = 0; i < 3; i++)
        {
            string key = $"RecentUser_{i}";
            if (i < recentUsers.Count)
            {
                persistenceProvider.SetString(key, recentUsers[i]);
            }
            else
            {
                persistenceProvider.DeleteKey(key);
            }
        }
        
        persistenceProvider.Save();
    }
    
    private string GenerateUserKey(string username)
    {
        return $"{USER_KEY_PREFIX}{username}{USER_KEY_SUFFIX}";
    }
}