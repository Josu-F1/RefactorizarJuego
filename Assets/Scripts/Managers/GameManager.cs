#pragma warning disable CS0618 // Type or member is obsolete
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
    private Player subscribedPlayer;
    
    // Sistema de victoria por kills acumulados (solo Nivel 1-2)
    private int requiredKills = 0;
    private int enemiesKilled = 0;

    private void Start()
    {
        // Asegurar que el juego esté en estado normal al inicio
        Time.timeScale = 1f;
        
        // Establecer meta de kills según el nivel
        SetRequiredKillsForLevel();
        
        // Conectar el evento de muerte de enemigos
        Enemy.OnAnyEnemyKilled += IncreaseScore;
        
        var player = Player.Instance;
        if (player != null)
        {
            subscribedPlayer = player;
            subscribedPlayer.OnPlayerDead += Defeat;
            // Debug.Log("[GameManager] ✅ Conectado a eventos de Player (muerte) y Enemy (score)");
        }
        else
        {
            Debug.LogWarning("[GameManager] ⚠️ Player.Instance es NULL! No se puede conectar evento de muerte");
        }
    }
    
    private void SetRequiredKillsForLevel()
    {
        requiredKills = levelNumber switch
        {
            1 => 15,  // Nivel 1: 15 kills (3-4 min)
            2 => 25,  // Nivel 2: 25 kills (5-6 min)
            _ => 0    // Nivel 3, 4 y otros: sin límite (usa sistema original)
        };
        
        if (requiredKills > 0)
        {
            Debug.Log($"[GameManager] 🎯 Nivel {levelNumber}: Necesitas {requiredKills} kills para ganar");
        }
        
        // Forzar actualización del UI
        OnScoreUpdated?.Invoke();
    }

    
    /// <summary>
    /// OBSOLETO: Ahora lo maneja ScoreService
    /// </summary>
    [System.Obsolete("Use ScoreService.AddScore instead")]
    private void IncreaseScore(int score)
    {
        if (!isPlaying)
            return;
        currentScore += score;
        enemiesKilled++;
        OnScoreUpdated?.Invoke();
        
        // Victoria solo para Nivel 1-2 (Nivel 3-4 sin condición de victoria)
        if (requiredKills > 0 && enemiesKilled >= requiredKills)
        {
            Victory();
        }
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

        if (string.IsNullOrEmpty(username))
        {
            Debug.LogWarning("[GameManager] No hay usuario activo. Se omite guardado de progreso en este nivel.");
            yield break;
        }

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

    /// <summary>
    /// OBSOLETO: Ahora lo maneja GameStateService
    /// </summary>
    [System.Obsolete("Use GameStateService.TriggerDefeat instead")]
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
    
    // Propiedades para sistema de victoria (solo Nivel 1-2)
    public int TotalEnemies => requiredKills;
    public int EnemiesKilled => enemiesKilled;
    public float EnemyProgress => requiredKills > 0 ? (float)enemiesKilled / (float)requiredKills : 0f;

    protected override void OnDestroy()
    {
        base.OnDestroy();
        
        // Cleanup de eventos
        Enemy.OnAnyEnemyKilled -= IncreaseScore;
        
        if (subscribedPlayer != null)
        {
            subscribedPlayer.OnPlayerDead -= Defeat;
            subscribedPlayer = null;
        }
    }
}
