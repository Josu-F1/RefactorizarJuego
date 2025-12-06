#pragma warning disable CS0618 // El tipo o miembro está obsoleto
using UnityEngine;

/// <summary>
/// Configuración de dificultad progresiva por nivel
/// Define cuántos enemigos deben haber en cada nivel
/// </summary>
public class LevelDifficultyConfig : MonoBehaviour
{
    [Header("Enemy Spawn Configuration")]
    [SerializeField] private int levelNumber = 1;
    [SerializeField] private int minimumEnemiesRequired = 5;
    [SerializeField] private bool autoSpawnEnemies = false;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    
    [Header("Difficulty Scaling")]
    [SerializeField] private int baseEnemiesLevel1 = 8;
    [SerializeField] private int enemiesIncreasePerLevel = 5;
    
    private void Start()
    {
        ValidateLevelEnemies();
        
        if (autoSpawnEnemies)
        {
            SpawnAdditionalEnemies();
        }
    }
    
    private void ValidateLevelEnemies()
    {
        Enemy[] existingEnemies = FindObjectsOfType<Enemy>();
        int currentEnemyCount = existingEnemies.Length;
        int requiredEnemies = GetRequiredEnemiesForLevel(levelNumber);
        
        Debug.Log($"[LevelDifficulty] Nivel {levelNumber}: {currentEnemyCount}/{requiredEnemies} enemigos");
        
        if (currentEnemyCount < minimumEnemiesRequired)
        {
            Debug.LogWarning($"[LevelDifficulty] ⚠️ Nivel {levelNumber} tiene muy pocos enemigos! " +
                           $"Actual: {currentEnemyCount}, Recomendado: {requiredEnemies}");
        }
    }
    
    private int GetRequiredEnemiesForLevel(int level)
    {
        // Nivel 1: 8 enemigos
        // Nivel 2: 13 enemigos
        // Nivel 3: 18 enemigos
        // Nivel 4: 23 enemigos
        return baseEnemiesLevel1 + ((level - 1) * enemiesIncreasePerLevel);
    }
    
    private void SpawnAdditionalEnemies()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0)
        {
            Debug.LogWarning("[LevelDifficulty] No hay prefabs de enemigos asignados");
            return;
        }
        
        int requiredEnemies = GetRequiredEnemiesForLevel(levelNumber);
        Enemy[] existingEnemies = FindObjectsOfType<Enemy>();
        int enemiesToSpawn = requiredEnemies - existingEnemies.Length;
        
        if (enemiesToSpawn <= 0)
        {
            Debug.Log($"[LevelDifficulty] Nivel ya tiene suficientes enemigos");
            return;
        }
        
        Debug.Log($"[LevelDifficulty] Spawneando {enemiesToSpawn} enemigos adicionales...");
        
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnRandomEnemy();
        }
    }
    
    private void SpawnRandomEnemy()
    {
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Vector3 spawnPosition = GetRandomSpawnPosition();
        
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
    
    private Vector3 GetRandomSpawnPosition()
    {
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            return randomPoint.position;
        }
        
        // Si no hay spawn points, usar posiciones aleatorias
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-10f, 10f);
        return new Vector3(x, y, 0);
    }
}
