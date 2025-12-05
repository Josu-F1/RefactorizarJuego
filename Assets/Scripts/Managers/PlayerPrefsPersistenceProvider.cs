using UnityEngine;

/// <summary>
/// Implementación de persistencia usando PlayerPrefs
/// Patrón: Repository Pattern - Implementación específica de persistencia
/// </summary>
public class PlayerPrefsPersistenceProvider : IPersistenceProvider
{
    public void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    
    public int GetInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }
    
    public void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
    
    public string GetString(string key, string defaultValue = "")
    {
        return PlayerPrefs.GetString(key, defaultValue);
    }
    
    public bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
    
    public void Save()
    {
        PlayerPrefs.Save();
    }
    
    public void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
}