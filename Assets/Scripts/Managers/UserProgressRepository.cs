using UnityEngine;

/// <summary>
/// Repositorio para manejo de progreso de usuario
/// Patrón: Repository Pattern - Abstrae la persistencia
/// Principio: Single Responsibility Principle (SRP) - Solo persistencia de progreso
/// </summary>
public class UserProgressRepository : IUserProgressRepository
{
    public UserProgress LoadUserProgress(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
            Debug.LogWarning("[UserProgressRepository] UserName is null or empty");
            return CreateDefaultProgress("Guest");
        }
        
        // Usar UserProgressManager existente para compatibilidad
        UserProgress progress = UserProgressManager.LoadProgress(userName);
        
        if (progress == null)
        {
            Debug.Log($"[UserProgressRepository] Creating new progress for user: {userName}");
            progress = CreateDefaultProgress(userName);
        }
        
        return progress;
    }
    
    public void SaveUserProgress(UserProgress progress)
    {
        if (progress == null)
        {
            Debug.LogError("[UserProgressRepository] Cannot save null progress");
            return;
        }
        
        UserProgressManager.SaveProgress(progress);
        Debug.Log($"[UserProgressRepository] Progress saved for user: {progress.userName}");
    }
    
    private UserProgress CreateDefaultProgress(string userName)
    {
        return new UserProgress
        {
            userName = userName,
            level = 1,
            points = 0
        };
    }
}