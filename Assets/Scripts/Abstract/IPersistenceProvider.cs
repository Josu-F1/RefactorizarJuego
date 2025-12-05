/// <summary>
/// Interface base para persistencia
/// Principio: Dependency Inversion Principle (DIP) - Abstrae el mecanismo de persistencia
/// </summary>
public interface IPersistenceProvider
{
    void SetInt(string key, int value);
    int GetInt(string key, int defaultValue = 0);
    void SetString(string key, string value);
    string GetString(string key, string defaultValue = "");
    bool HasKey(string key);
    void Save();
    void DeleteKey(string key);
}