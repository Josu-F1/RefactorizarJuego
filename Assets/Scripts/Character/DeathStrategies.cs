using UnityEngine;

/// <summary>
/// Estrategia de muerte por destrucción - destruye el GameObject
/// Patrón: Strategy Pattern
/// </summary>
[System.Serializable]
public class DestroyDeathStrategy : IDeathStrategy
{
    [SerializeField] private float destroyDelay = 0f;
    
    public DestroyDeathStrategy(float delay = 0f)
    {
        destroyDelay = delay;
    }
    
    public void OnDeath(GameObject character)
    {
        if (destroyDelay > 0)
        {
            Object.Destroy(character, destroyDelay);
        }
        else
        {
            Object.Destroy(character);
        }
    }
}

/// <summary>
/// Estrategia de muerte por desactivación - desactiva el GameObject
/// </summary>
[System.Serializable]
public class DeactivateDeathStrategy : IDeathStrategy
{
    public void OnDeath(GameObject character)
    {
        character.SetActive(false);
    }
}

/// <summary>
/// Estrategia de muerte para enemigos - notifica puntuación y destruye
/// </summary>
[System.Serializable]
public class EnemyDeathStrategy : IDeathStrategy
{
    public void OnDeath(GameObject character)
    {
        // Notificar puntuación si es un enemigo
        Enemy enemy = character.GetComponent<Enemy>();
        if (enemy != null)
        {
            // Usar el score directamente del Enemy a través de reflexión o serialización
            // Como Enemy tiene [SerializeField] private int score, necesitamos obtenerlo
            var scoreField = typeof(Enemy).GetField("score", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            int scoreValue = scoreField != null ? (int)scoreField.GetValue(enemy) : 5;
            
            Debug.Log($"[EnemyDeathStrategy] Enemigo {enemy.name} murió. Score otorgado: {scoreValue}");
            Enemy.OnAnyEnemyKilled?.Invoke(scoreValue);
        }
        
        Object.Destroy(character);
    }
}