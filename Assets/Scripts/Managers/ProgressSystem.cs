using UnityEngine;
using System;

/// <summary>
/// Sistema de progreso del usuario aplicando principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo maneja lógica de progreso
/// Principio: Dependency Inversion Principle (DIP) - Depende de interfaces
/// Patrón: Observer Pattern - Notifica cambios
/// </summary>
public class ProgressSystem : IProgressStats, IProgressOperations
{
    private UserProgress currentProgress;
    private IUserProgressRepository repository;
    private IProgressObserver observer;
    
    public event Action<UserProgress> OnProgressUpdated;
    
    public ProgressSystem(IUserProgressRepository repository, IProgressObserver observer = null)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this.observer = observer;
    }
    
    // IProgressStats implementation
    public string UserName => currentProgress?.userName ?? "";
    public int Level => currentProgress?.level ?? 0;
    public int Points => currentProgress?.points ?? 0;
    
    // IProgressOperations implementation
    public void LoadUser(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
            Debug.LogWarning("[ProgressSystem] UserName is null or empty");
            return;
        }
        
        currentProgress = repository.LoadUserProgress(userName);
        NotifyProgressChange();
    }
    
    public void AddPoints(int points)
    {
        if (currentProgress == null)
        {
            Debug.LogWarning("[ProgressSystem] No user loaded");
            return;
        }
        
        if (points < 0)
        {
            Debug.LogWarning("[ProgressSystem] Cannot add negative points");
            return;
        }
        
        currentProgress.points += points;
        SaveProgress();
        NotifyProgressChange();
    }
    
    public void NextLevel()
    {
        if (currentProgress == null)
        {
            Debug.LogWarning("[ProgressSystem] No user loaded");
            return;
        }
        
        currentProgress.level++;
        SaveProgress();
        NotifyProgressChange();
    }
    
    public void SaveProgress()
    {
        if (currentProgress == null)
        {
            Debug.LogWarning("[ProgressSystem] No progress to save");
            return;
        }
        
        repository.SaveUserProgress(currentProgress);
    }
    
    private void NotifyProgressChange()
    {
        observer?.OnProgressChanged(currentProgress);
        OnProgressUpdated?.Invoke(currentProgress);
    }
    
    public UserProgress GetCurrentProgress()
    {
        return currentProgress;
    }
}