/// <summary>
/// Adaptador para usar DataManager como sistema de persistencia
/// Patrón: Adapter Pattern
/// Principio: Single Responsibility Principle (SRP)
/// </summary>
public class DataManagerProgressAdapter : IProgressPersistence
{
    public void SaveLevelCompletion(int levelNumber)
    {
        string username = DataManager.CurrentUsername;
        int currentPlayerLevel = DataManager.GetPlayerLevel(username);
        
        if (levelNumber > currentPlayerLevel)
        {
            DataManager.SavePlayerLevel(username, levelNumber);
        }
    }
    
    public int GetPlayerLevel(string username)
    {
        return DataManager.GetPlayerLevel(username);
    }
}