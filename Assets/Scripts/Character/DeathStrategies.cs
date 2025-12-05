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
    [SerializeField] private int scoreValue = 5;
    
    public EnemyDeathStrategy(int score = 5)
    {
        scoreValue = score;
    }
    
    public void OnDeath(GameObject character)
    {
        // Notificar puntuación si es un enemigo
        Enemy enemy = character.GetComponent<Enemy>();
        if (enemy != null)
        {
            Enemy.OnAnyEnemyKilled?.Invoke(scoreValue);
        }
        
        Object.Destroy(character);
    }
}