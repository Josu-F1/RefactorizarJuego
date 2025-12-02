using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Sistema simple para trackear progreso de niveles sin GameManagerComposer
/// Se ejecuta automáticamente cuando se detecta victoria
/// </summary>
public class LevelProgressTracker : MonoBehaviour
{
    private bool levelCompleted = false;
    
    void Start()
    {
        Debug.Log($"[LevelProgressTracker] Iniciado en escena: {SceneManager.GetActiveScene().name}");
        
        // Suscribirse a eventos de victoria
        Enemy.OnAnyEnemyKilled += CheckForVictory;
    }
    
    private void CheckForVictory(int score)
    {
        if (levelCompleted) return;
        
        // Verificar si quedan enemigos
        Enemy[] remainingEnemies = FindObjectsOfType<Enemy>();
        
        Debug.Log($"[LevelProgressTracker] Enemigos restantes: {remainingEnemies.Length}");
        
        if (remainingEnemies.Length <= 1) // <= 1 porque el que acaba de morir aún puede estar en la lista
        {
            levelCompleted = true;
            Debug.Log("[LevelProgressTracker] ¡NIVEL COMPLETADO!");
            SaveLevelProgress();
        }
    }
    
    private void SaveLevelProgress()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string username = DataManagerComposer.CurrentUsername;
        
        Debug.Log($"[LevelProgressTracker] Guardando progreso para {username} en {sceneName}");
        
        // Extraer número de nivel del nombre de la escena
        int levelNumber = 1;
        if (sceneName.StartsWith("Level"))
        {
            string numberPart = sceneName.Substring(5);
            if (int.TryParse(numberPart, out int detectedLevel))
            {
                levelNumber = detectedLevel;
            }
        }
        
        Debug.Log($"[LevelProgressTracker] Nivel detectado: {levelNumber}");
        
        // Guardar progreso
        DataManagerComposer.SavePlayerLevel(username, levelNumber);
        
        // Verificar que se guardó
        int currentLevel = DataManagerComposer.GetPlayerLevel(username);
        Debug.Log($"[LevelProgressTracker] ✅ Progreso guardado! Nivel actual: {currentLevel}");
        
        // Agregar a usuarios recientes
        DataManagerComposer.AddRecentUsername(username);
        
        Debug.Log("[LevelProgressTracker] ¡Ve al Lobby para ver el siguiente nivel desbloqueado!");
    }
    
    void OnDestroy()
    {
        Enemy.OnAnyEnemyKilled -= CheckForVictory;
    }
    
    [ContextMenu("Force Complete Current Level")]
    private void ForceCompleteCurrentLevel()
    {
        Debug.Log("[LevelProgressTracker] Forzando completar nivel actual...");
        SaveLevelProgress();
    }
}