using UnityEngine;

/// <summary>
/// Interfaz para estadísticas de progreso del usuario
/// Principio: Interface Segregation Principle (ISP)
/// </summary>
public interface IProgressStats
{
    string UserName { get; }
    int Level { get; }
    int Points { get; }
}

/// <summary>
/// Interfaz para operaciones de progreso
/// Principio: Single Responsibility Principle (SRP) - Solo operaciones de progreso
/// </summary>
public interface IProgressOperations
{
    void AddPoints(int points);
    void NextLevel();
    void SaveProgress();
    void LoadUser(string userName);
}

/// <summary>
/// Interfaz para persistencia de progreso de usuario
/// Patrón: Repository Pattern
/// Principio: Dependency Inversion Principle (DIP)
/// </summary>
public interface IUserProgressRepository
{
    UserProgress LoadUserProgress(string userName);
    void SaveUserProgress(UserProgress progress);
}

/// <summary>
/// Interfaz para notificaciones de cambios de progreso
/// Patrón: Observer Pattern
/// Principio: Open/Closed Principle (OCP)
/// </summary>
public interface IProgressObserver
{
    void OnProgressChanged(UserProgress progress);
}