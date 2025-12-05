using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Repositorio de usuarios usando PlayerPrefs
/// Principio: Single Responsibility Principle (SRP) - Solo maneja persistencia de usuarios
/// Principio: Dependency Inversion Principle (DIP) - Implementa IUserRepository
/// Patrón: Repository Pattern - Abstrae la lógica de acceso a datos
/// </summary>
public class PlayerPrefsUserRepository : IUserRepository
{
    private const string USER_DATA_PREFIX = "UserData_";
    private const string USER_LIST_KEY = "RegisteredUsers";
    private readonly Dictionary<string, UserCredentials> userCache;

    public PlayerPrefsUserRepository()
    {
        userCache = new Dictionary<string, UserCredentials>();
        LoadAllUsers();
    }

    public bool UserExists(string userName)
    {
        if (string.IsNullOrEmpty(userName))
            return false;

        return userCache.ContainsKey(userName.ToLower()) || 
               PlayerPrefs.HasKey(USER_DATA_PREFIX + userName.ToLower());
    }

    public void SaveUser(UserCredentials user)
    {
        if (user == null || string.IsNullOrEmpty(user.UserName))
        {
            Debug.LogError("[PlayerPrefsUserRepository] Cannot save null user or user with empty name");
            return;
        }

        try
        {
            string key = USER_DATA_PREFIX + user.UserName.ToLower();
            string userData = JsonUtility.ToJson(user);
            
            PlayerPrefs.SetString(key, userData);
            userCache[user.UserName.ToLower()] = user;
            
            UpdateUserList(user.UserName);
            PlayerPrefs.Save();
            
            Debug.Log($"[PlayerPrefsUserRepository] User {user.UserName} saved successfully");
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PlayerPrefsUserRepository] Error saving user {user.UserName}: {ex.Message}");
        }
    }

    public UserCredentials GetUser(string userName)
    {
        if (string.IsNullOrEmpty(userName))
            return null;

        string lowerUserName = userName.ToLower();
        
        // Revisar cache primero
        if (userCache.TryGetValue(lowerUserName, out UserCredentials cachedUser))
            return cachedUser;

        // Cargar desde PlayerPrefs
        string key = USER_DATA_PREFIX + lowerUserName;
        if (PlayerPrefs.HasKey(key))
        {
            try
            {
                string userData = PlayerPrefs.GetString(key);
                UserCredentials user = JsonUtility.FromJson<UserCredentials>(userData);
                
                if (user != null)
                {
                    userCache[lowerUserName] = user;
                    return user;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"[PlayerPrefsUserRepository] Error loading user {userName}: {ex.Message}");
            }
        }

        return null;
    }

    public void UpdateUser(UserCredentials user)
    {
        if (user == null || string.IsNullOrEmpty(user.UserName))
            return;

        // UpdateUser es igual que SaveUser en este contexto
        SaveUser(user);
    }

    public void DeleteUser(string userName)
    {
        if (string.IsNullOrEmpty(userName))
            return;

        try
        {
            string lowerUserName = userName.ToLower();
            string key = USER_DATA_PREFIX + lowerUserName;
            
            if (PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.DeleteKey(key);
                userCache.Remove(lowerUserName);
                RemoveFromUserList(userName);
                PlayerPrefs.Save();
                
                Debug.Log($"[PlayerPrefsUserRepository] User {userName} deleted successfully");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PlayerPrefsUserRepository] Error deleting user {userName}: {ex.Message}");
        }
    }

    private void LoadAllUsers()
    {
        string userListJson = PlayerPrefs.GetString(USER_LIST_KEY, "");
        if (string.IsNullOrEmpty(userListJson))
            return;

        try
        {
            UserListData userList = JsonUtility.FromJson<UserListData>(userListJson);
            if (userList?.userNames != null)
            {
                foreach (string userName in userList.userNames)
                {
                    UserCredentials user = GetUser(userName);
                    if (user != null)
                    {
                        userCache[userName.ToLower()] = user;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PlayerPrefsUserRepository] Error loading user list: {ex.Message}");
        }
    }

    private void UpdateUserList(string userName)
    {
        if (string.IsNullOrEmpty(userName))
            return;

        try
        {
            List<string> userNames = GetUserList();
            string lowerUserName = userName.ToLower();
            
            if (!userNames.Contains(lowerUserName))
            {
                userNames.Add(lowerUserName);
                SaveUserList(userNames);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PlayerPrefsUserRepository] Error updating user list: {ex.Message}");
        }
    }

    private void RemoveFromUserList(string userName)
    {
        if (string.IsNullOrEmpty(userName))
            return;

        try
        {
            List<string> userNames = GetUserList();
            string lowerUserName = userName.ToLower();
            
            if (userNames.Remove(lowerUserName))
            {
                SaveUserList(userNames);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PlayerPrefsUserRepository] Error removing from user list: {ex.Message}");
        }
    }

    private List<string> GetUserList()
    {
        string userListJson = PlayerPrefs.GetString(USER_LIST_KEY, "");
        if (string.IsNullOrEmpty(userListJson))
            return new List<string>();

        try
        {
            UserListData userList = JsonUtility.FromJson<UserListData>(userListJson);
            return userList?.userNames ?? new List<string>();
        }
        catch
        {
            return new List<string>();
        }
    }

    private void SaveUserList(List<string> userNames)
    {
        try
        {
            UserListData userList = new UserListData { userNames = userNames };
            string json = JsonUtility.ToJson(userList);
            PlayerPrefs.SetString(USER_LIST_KEY, json);
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PlayerPrefsUserRepository] Error saving user list: {ex.Message}");
        }
    }

    public int GetUserCount()
    {
        return userCache.Count;
    }

    public List<string> GetAllUserNames()
    {
        return new List<string>(userCache.Keys);
    }

    public void ClearAllUsers()
    {
        try
        {
            List<string> userNames = GetAllUserNames();
            foreach (string userName in userNames)
            {
                DeleteUser(userName);
            }
            
            PlayerPrefs.DeleteKey(USER_LIST_KEY);
            userCache.Clear();
            PlayerPrefs.Save();
            
            Debug.Log("[PlayerPrefsUserRepository] All users cleared successfully");
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PlayerPrefsUserRepository] Error clearing all users: {ex.Message}");
        }
    }

    // Implementación de métodos faltantes de IUserRepository

    public void CreateUser(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            Debug.LogError("[PlayerPrefsUserRepository] Cannot create user with empty username");
            return;
        }

        if (UserExists(username))
        {
            Debug.LogWarning($"[PlayerPrefsUserRepository] User {username} already exists");
            return;
        }

        try
        {
            // Crear un usuario básico con solo el username usando la clase legacy UserCredentials
            UserCredentials newUser = new UserCredentials(username, "");

            SaveUser(newUser);
            Debug.Log($"[PlayerPrefsUserRepository] User {username} created successfully");
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PlayerPrefsUserRepository] Error creating user {username}: {ex.Message}");
        }
    }

    public bool ValidateUser(string username)
    {
        if (string.IsNullOrEmpty(username))
            return false;

        return UserExists(username);
    }

    public string[] GetRecentUsernames(int maxCount = 3)
    {
        try
        {
            List<string> allUsers = GetAllUserNames();
            
            // Limitar la cantidad de usuarios recientes
            if (allUsers.Count > maxCount)
            {
                allUsers = allUsers.GetRange(allUsers.Count - maxCount, maxCount);
            }

            return allUsers.ToArray();
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PlayerPrefsUserRepository] Error getting recent usernames: {ex.Message}");
            return new string[0];
        }
    }

    public void AddRecentUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
            return;

        try
        {
            // En este contexto, simplemente asegurarse de que el usuario existe
            if (!UserExists(username))
            {
                CreateUser(username);
            }
            else
            {
                Debug.Log($"[PlayerPrefsUserRepository] User {username} added to recent list");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PlayerPrefsUserRepository] Error adding recent username {username}: {ex.Message}");
        }
    }
}

/// <summary>
/// Clase auxiliar para serializar la lista de usuarios
/// </summary>
[System.Serializable]
public class UserListData
{
    public List<string> userNames = new List<string>();
}