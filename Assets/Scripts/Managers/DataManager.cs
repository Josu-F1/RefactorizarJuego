using UnityEngine;

/// <summary>
/// OBSOLETO: Esta clase viola principios SOLID y Repository Pattern.
/// Usar DataManagerComposer con repositorios especializados
/// </summary>
[System.Obsolete("Use DataManagerComposer instead. This class violates SOLID principles.")]
public static class DataManager
{
    private static string currentUsername;

    public static string CurrentUsername
    {
        get => currentUsername;
        set => currentUsername = value;
    }

    public static void SaveUsername(string username)
    {
        PlayerPrefs.SetInt($"Player_${username}_Level", 0);
        PlayerPrefs.Save();
    }

    public static void SavePlayerLevel(string username, int level)
    {
        PlayerPrefs.SetInt($"Player_${username}_Level", level);
        PlayerPrefs.Save();
    }

    public static bool UsernameExists(string username)
    {
        return PlayerPrefs.HasKey($"Player_${username}_Level");
    }

    public static int GetPlayerLevel(string username)
    {
        return PlayerPrefs.GetInt($"Player_${username}_Level", 0);
    }
}
