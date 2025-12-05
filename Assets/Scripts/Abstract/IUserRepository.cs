/// <summary>
/// Interface para repositorio de usuarios
/// Patrón: Repository Pattern - Abstrae la persistencia de usuarios
/// </summary>
public interface IUserRepository
{
    bool UserExists(string username);
    void CreateUser(string username);
    bool ValidateUser(string username);
    string[] GetRecentUsernames(int maxCount = 3);
    void AddRecentUsername(string username);
}