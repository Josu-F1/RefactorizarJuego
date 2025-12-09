using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Infrastructure.Persistence
{
    /// <summary>
    /// ✅ Clean Architecture - Persistence Layer
    /// Patrón: Repository + Strategy
    /// Responsabilidad: Gestionar guardado/carga de datos
    /// </summary>
    public class PersistenceSystem : MonoBehaviourSingleton<PersistenceSystem>
    {
        [Header("Configuration")]
        [SerializeField] private bool useEncryption = false;
        [SerializeField] private string saveDirectory = "Saves";
        
        private IPersistenceStrategy strategy;
        private string savePath;
        
        protected override void Awake()
        {
            base.Awake();
            InitializeStrategy();
        }
        
        private void InitializeStrategy()
        {
            // Por ahora usar JSON, podemos cambiar a Binary o Cloud después
            strategy = new JsonPersistenceStrategy(useEncryption);
            savePath = Path.Combine(Application.persistentDataPath, saveDirectory);
            
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            
            Debug.Log($"[PersistenceSystem] ✅ Initialized - Path: {savePath}");
        }
        
        #region Save/Load
        
        public void Save<T>(string key, T data) where T : class
        {
            try
            {
                string filePath = GetFilePath(key);
                strategy.Save(filePath, data);
                Debug.Log($"[PersistenceSystem] ✅ Saved: {key}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"[PersistenceSystem] ❌ Save failed: {ex.Message}");
            }
        }
        
        public T Load<T>(string key) where T : class
        {
            try
            {
                string filePath = GetFilePath(key);
                if (!File.Exists(filePath))
                {
                    Debug.LogWarning($"[PersistenceSystem] ⚠️ File not found: {key}");
                    return null;
                }
                
                var data = strategy.Load<T>(filePath);
                Debug.Log($"[PersistenceSystem] ✅ Loaded: {key}");
                return data;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[PersistenceSystem] ❌ Load failed: {ex.Message}");
                return null;
            }
        }
        
        public bool Exists(string key)
        {
            string filePath = GetFilePath(key);
            return File.Exists(filePath);
        }
        
        public void Delete(string key)
        {
            try
            {
                string filePath = GetFilePath(key);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Debug.Log($"[PersistenceSystem] ✅ Deleted: {key}");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"[PersistenceSystem] ❌ Delete failed: {ex.Message}");
            }
        }
        
        public void DeleteAll()
        {
            try
            {
                if (Directory.Exists(savePath))
                {
                    Directory.Delete(savePath, true);
                    Directory.CreateDirectory(savePath);
                    Debug.Log("[PersistenceSystem] ✅ All data deleted");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"[PersistenceSystem] ❌ DeleteAll failed: {ex.Message}");
            }
        }
        
        #endregion
        
        #region Helpers
        
        private string GetFilePath(string key)
        {
            return Path.Combine(savePath, $"{key}.dat");
        }
        
        #endregion
    }
    
    #region Persistence Strategies
    
    /// <summary>
    /// Estrategia de persistencia
    /// </summary>
    public interface IPersistenceStrategy
    {
        void Save<T>(string path, T data) where T : class;
        T Load<T>(string path) where T : class;
    }
    
    /// <summary>
    /// Estrategia JSON
    /// </summary>
    public class JsonPersistenceStrategy : IPersistenceStrategy
    {
        private readonly bool useEncryption;
        
        public JsonPersistenceStrategy(bool encryption)
        {
            useEncryption = encryption;
        }
        
        public void Save<T>(string path, T data) where T : class
        {
            string json = JsonUtility.ToJson(data, true);
            
            if (useEncryption)
            {
                json = Encrypt(json);
            }
            
            File.WriteAllText(path, json);
        }
        
        public T Load<T>(string path) where T : class
        {
            string json = File.ReadAllText(path);
            
            if (useEncryption)
            {
                json = Decrypt(json);
            }
            
            return JsonUtility.FromJson<T>(json);
        }
        
        private string Encrypt(string data)
        {
            // Encriptación simple (mejorar en producción)
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(data));
        }
        
        private string Decrypt(string data)
        {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(data));
        }
    }
    
    /// <summary>
    /// Estrategia Binary (para datos más grandes)
    /// </summary>
    public class BinaryPersistenceStrategy : IPersistenceStrategy
    {
        public void Save<T>(string path, T data) where T : class
        {
            // Implementar serialización binaria si es necesario
            throw new NotImplementedException("Binary persistence not implemented yet");
        }
        
        public T Load<T>(string path) where T : class
        {
            throw new NotImplementedException("Binary persistence not implemented yet");
        }
    }
    
    #endregion
    
    #region Data Models
    
    /// <summary>
    /// Datos de usuario
    /// </summary>
    [System.Serializable]
    public class UserData
    {
        public string username;
        public int highScore;
        public int currentLevel;
        public float playtime;
        public DateTime lastPlayed;
    }
    
    /// <summary>
    /// Datos de configuración
    /// </summary>
    [System.Serializable]
    public class GameSettings
    {
        public float musicVolume = 1f;
        public float sfxVolume = 1f;
        public bool fullscreen = true;
        public int resolutionWidth = 1920;
        public int resolutionHeight = 1080;
    }
    
    /// <summary>
    /// Datos de progreso
    /// </summary>
    [System.Serializable]
    public class ProgressData
    {
        public int currentLevel;
        public int totalScore;
        public List<int> levelScores = new List<int>();
        public List<bool> levelCompleted = new List<bool>();
    }
    
    #endregion
}
