/// <summary>
/// Implementación simple de información de usuario usando DataManager
/// Principio: Single Responsibility Principle (SRP)
/// </summary>
public class GameUserInfo : IUserInfo
{
    public string Username => DataManager.CurrentUsername;
}