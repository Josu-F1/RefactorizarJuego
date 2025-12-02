/// <summary>
/// Implementación simple de información de usuario usando DataManagerComposer
/// Principio: Single Responsibility Principle (SRP)
/// </summary>
public class GameUserInfo : IUserInfo
{
    public string Username => DataManagerComposer.CurrentUsername;
}