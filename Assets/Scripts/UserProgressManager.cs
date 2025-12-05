    using System;
    using System.IO;
    using UnityEngine;

    [Serializable]
    public class UserProgress
    {
        public string userName;
        public string password; // Nuevo campo para la contraseña
        public int level;
        public int points;
    }

    public static class UserProgressManager
    {
        private static string GetFilePath(string userName)
        {
            return Path.Combine(Application.persistentDataPath, userName + "_progress.json");
        }

        public static void SaveProgress(UserProgress progress)
        {
            string json = JsonUtility.ToJson(progress);
            File.WriteAllText(GetFilePath(progress.userName), json);
        }

        public static UserProgress LoadProgress(string userName)
        {
            string path = GetFilePath(userName);
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return JsonUtility.FromJson<UserProgress>(json);
            }
            return null; // Cambiado para manejar mejor el login
        }
    }