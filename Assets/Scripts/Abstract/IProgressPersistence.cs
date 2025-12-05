/// <summary>
/// Interface para manejar persistencia de progreso del jugador
/// Principio: Single Responsibility Principle (SRP)
/// </summary>
public interface IProgressPersistence
{
    void SaveLevelCompletion(int levelNumber);
    int GetPlayerLevel(string username);
}