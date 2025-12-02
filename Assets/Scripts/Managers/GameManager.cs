using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// OBSOLETO: Esta clase viola principios SOLID.
/// Usar GameManagerComposer con sistemas especializados
/// TEMPORALMENTE REACTIVADO para compatibilidad con escenas existentes
/// </summary>
public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField]
    private int requiredScore = 200;

    [SerializeField]
    private float endGameDelay = 2;

    [SerializeField]
    private int levelNumber = 1;

    public Action OnVictory { get; set; }
    public Action OnDefeat { get; set; }
    public Action OnScoreUpdated { get; set; }
    private int currentScore = 0;
    private bool isPlaying = true;

    private void Start()
    {
        // Asegurar que el juego esté en estado normal al inicio
        Time.timeScale = 1f;
        
        Enemy.OnAnyEnemyKilled += IncreaseScore;
        
        // Asegurar que el Player existe antes de suscribirse
        if (Player.Instance != null)
        {
            Player.Instance.OnPlayerDead += Defeat;
        }
    }

    private void IncreaseScore(int score)
    {
        if (!isPlaying)
            return;
        currentScore += score;
        OnScoreUpdated?.Invoke();
        if (currentScore >= requiredScore)
            Victory();
    }

    private void Victory()
    {
        if (!isPlaying)
            return;
        print("Victory");
        isPlaying = false;
        StartCoroutine(VictoryCoroutine());
    }

    private IEnumerator VictoryCoroutine()
    {
        yield return new WaitForSeconds(endGameDelay);
        OnVictory?.Invoke();
        Time.timeScale = 0;

        // USAR EL NUEVO SISTEMA REFACTORIZADO
        string username = DataManagerComposer.CurrentUsername;
        int actualLevel = DataManagerComposer.GetPlayerLevel(username);

        Debug.Log($"[GameManager] GUARDANDO PROGRESO - Usuario: {username}, Nivel actual: {actualLevel}, Nivel completado: {levelNumber}");

        if (levelNumber > actualLevel)
        {
            DataManagerComposer.SavePlayerLevel(username, levelNumber);
            Debug.Log($"[GameManager] ✅ Progreso guardado! Nuevo nivel: {levelNumber}");
        }
        else
        {
            Debug.Log($"[GameManager] Nivel ya completado anteriormente");
        }
        
        // Verificar que se guardó
        int newLevel = DataManagerComposer.GetPlayerLevel(username);
        Debug.Log($"[GameManager] Verificación final - Nivel del jugador: {newLevel}");
    }

    private void Defeat()
    {
        if (!isPlaying)
            return;
        print("Defeat");
        isPlaying = false;
        StartCoroutine(DefeatCoroutine());
    }

    private IEnumerator DefeatCoroutine()
    {
        yield return new WaitForSeconds(endGameDelay);
        OnDefeat?.Invoke();
        Time.timeScale = 0;
    }

    public int RequiredScore => requiredScore;
    public int CurrentScore => currentScore;
    public float Progress => (float)currentScore / (float)requiredScore;

    private void OnDestroy()
    {
        Enemy.OnAnyEnemyKilled -= IncreaseScore;
    }
}
