using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// GameManager refactorizado usando composición y principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo coordina componentes
/// Principio: Dependency Inversion Principle (DIP) - Depende de interfaces
/// Patrón: Facade Pattern - Simplifica el acceso a múltiples subsistemas
/// </summary>
public class GameManagerComposer : MonoBehaviourSingleton<GameManagerComposer>
{
    [Header("Configuration")]
    [SerializeField] private int requiredScore = 200;
    [SerializeField] private int levelNumber = 1;
    
    [Header("Components")]
    [SerializeField] private GameStateManager gameStateManager;
    
    // Sistemas componentes (siguiendo SRP)
    private IScoreSystem scoreSystem;
    private IProgressPersistence progressPersistence;
    
    // Propiedades públicas para compatibilidad
    public int RequiredScore => scoreSystem?.RequiredScore ?? 0;
    public int CurrentScore => scoreSystem?.CurrentScore ?? 0;
    public float Progress => scoreSystem?.Progress ?? 0f;
    public bool IsPlaying => gameStateManager?.IsPlaying ?? false;
    
    // Events para compatibilidad
    public Action OnVictory { get; set; }
    public Action OnDefeat { get; set; }
    public Action OnScoreUpdated { get; set; }
    
    protected override void Awake()
    {
        base.Awake();
        InitializeSystems();
    }
    
    private void InitializeSystems()
    {
        // Detectar automáticamente el número de nivel basado en la escena
        DetectLevelNumber();
        
        // Crear sistemas especializados
        scoreSystem = new ScoreSystem(requiredScore);
        progressPersistence = new DataManagerProgressAdapter();
        
        // Si no hay GameStateManager, crear uno
        if (gameStateManager == null)
        {
            gameStateManager = gameObject.AddComponent<GameStateManager>();
        }
    }
    
    private void DetectLevelNumber()
    {
        // Obtener el nombre de la escena actual
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log($"[GameManagerComposer] Escena actual: {sceneName}");
        
        // Extraer el número del nivel del nombre de la escena
        if (sceneName.StartsWith("Level"))
        {
            string numberPart = sceneName.Substring(5); // Quitar "Level"
            if (int.TryParse(numberPart, out int detectedLevel))
            {
                levelNumber = detectedLevel;
                Debug.Log($"[GameManagerComposer] Nivel detectado automáticamente: {levelNumber}");
            }
            else
            {
                levelNumber = 1; // Default si no se puede parsear
                Debug.LogWarning($"[GameManagerComposer] No se pudo parsear el número del nivel de '{sceneName}', usando 1");
            }
        }
        else
        {
            // Si no se puede detectar, usar buildIndex como fallback
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            levelNumber = Mathf.Max(1, buildIndex);
            Debug.Log($"[GameManagerComposer] Escena no es Level*, usando buildIndex como nivel: {levelNumber}");
        }
        
        Debug.Log($"[GameManagerComposer] NIVEL FINAL ASIGNADO: {levelNumber}");
    }
    
    private void Start()
    {
        SubscribeToEvents();
        ConnectGameSystems();
        
        // Debug información de inicialización
        Debug.Log($"[GameManagerComposer] Sistema inicializado en escena: {UnityEngine.SceneManagement.SceneManager.GetActiveScene().name}");
        Debug.Log($"[GameManagerComposer] Nivel detectado: {levelNumber}");
        Debug.Log($"[GameManagerComposer] Score requerido: {requiredScore}");
        Debug.Log($"[GameManagerComposer] Usuario actual: {DataManagerComposer.CurrentUsername}");
    }
    
    private void SubscribeToEvents()
    {
        // Suscribirse a eventos de enemigos y jugador
        Enemy.OnAnyEnemyKilled += HandleEnemyKilled;
        
        if (Player.Instance != null)
        {
            Player.Instance.OnPlayerDead += HandlePlayerDead;
        }
    }
    
    private void ConnectGameSystems()
    {
        // Conectar sistema de puntuación con estados del juego
        if (scoreSystem != null)
        {
            scoreSystem.OnScoreUpdated += () => OnScoreUpdated?.Invoke();
            scoreSystem.OnScoreGoalReached += HandleVictory;
        }
        
        // Conectar eventos de estado del juego
        if (gameStateManager != null)
        {
            gameStateManager.OnVictory += HandleVictoryComplete;
            gameStateManager.OnDefeat += HandleDefeatComplete;
        }
    }
    
    private void HandleEnemyKilled(int score)
    {
        if (IsPlaying)
        {
            scoreSystem?.AddScore(score);
        }
    }
    
    private void HandlePlayerDead()
    {
        gameStateManager?.TriggerDefeat();
    }
    
    private void HandleVictory()
    {
        Debug.Log("[GameManagerComposer] HandleVictory llamado - Score objetivo alcanzado!");
        Debug.Log($"[GameManagerComposer] Score actual: {scoreSystem?.CurrentScore}, Requerido: {scoreSystem?.RequiredScore}");
        
        if (gameStateManager != null)
        {
            gameStateManager.TriggerVictory();
        }
        else
        {
            Debug.LogError("[GameManagerComposer] gameStateManager es NULL! Ejecutando HandleVictoryComplete directamente.");
            HandleVictoryComplete();
        }
    }
    
    private void HandleVictoryComplete()
    {
        Debug.Log($"[GameManagerComposer] *** VICTORIA DETECTADA ***");
        Debug.Log($"[GameManagerComposer] Nivel a completar: {levelNumber}");
        
        string username = DataManagerComposer.CurrentUsername;
        Debug.Log($"[GameManagerComposer] Usuario actual: {username}");
        
        // VERIFICAR ANTES DEL GUARDADO
        int levelBefore = DataManagerComposer.GetPlayerLevel(username);
        Debug.Log($"[GameManagerComposer] Nivel ANTES del guardado: {levelBefore}");
        
        // GUARDAR PROGRESO DIRECTAMENTE (sin adaptador por ahora)
        Debug.Log($"[GameManagerComposer] Guardando nivel {levelNumber} para usuario {username}");
        DataManagerComposer.SavePlayerLevel(username, levelNumber);
        
        // VERIFICAR DESPUÉS DEL GUARDADO
        int levelAfter = DataManagerComposer.GetPlayerLevel(username);
        Debug.Log($"[GameManagerComposer] Nivel DESPUÉS del guardado: {levelAfter}");
        
        if (levelAfter >= levelNumber)
        {
            Debug.Log($"[GameManagerComposer] ✅ ¡PROGRESO GUARDADO EXITOSAMENTE!");
        }
        else
        {
            Debug.LogError($"[GameManagerComposer] ❌ ERROR: No se guardó el progreso correctamente");
        }
        
        Debug.Log($"[GameManagerComposer] *** FIN PROCESAMIENTO VICTORIA ***");
        
        OnVictory?.Invoke();
    }
    
    private void HandleDefeatComplete()
    {
        OnDefeat?.Invoke();
    }
    
    [ContextMenu("Debug Player Progress")]
    private void DebugPlayerProgress()
    {
        string username = DataManagerComposer.CurrentUsername;
        int playerLevel = DataManagerComposer.GetPlayerLevel(username);
        
        Debug.Log($"=== PROGRESO DEL JUGADOR ===");
        Debug.Log($"Usuario actual: {username}");
        Debug.Log($"Nivel del jugador: {playerLevel}");
        Debug.Log($"Escena actual: {SceneManager.GetActiveScene().name}");
        Debug.Log($"Número de nivel detectado: {levelNumber}");
        Debug.Log($"===========================");
    }
    
    [ContextMenu("Force Save Level Progress")]
    private void ForceSaveLevelProgress()
    {
        Debug.Log("[GameManagerComposer] FORZANDO GUARDADO DEL PROGRESO...");
        progressPersistence?.SaveLevelCompletion(levelNumber);
        Debug.Log("[GameManagerComposer] Guardado forzado completado.");
    }
    
    [ContextMenu("Force Complete Level 1")]
    private void ForceCompleteLevel1()
    {
        Debug.Log("[GameManagerComposer] FORZANDO COMPLETAR LEVEL 1...");
        string username = DataManagerComposer.CurrentUsername;
        DataManagerComposer.SavePlayerLevel(username, 1);
        Debug.Log($"[GameManagerComposer] Level 1 marcado como completado para usuario: {username}");
        
        // Verificar inmediatamente
        int newLevel = DataManagerComposer.GetPlayerLevel(username);
        Debug.Log($"[GameManagerComposer] Verificación - Nivel actual: {newLevel}");
    }
    
    [ContextMenu("Force Complete Level 2")]
    private void ForceCompleteLevel2()
    {
        Debug.Log("[GameManagerComposer] FORZANDO COMPLETAR LEVEL 2...");
        string username = DataManagerComposer.CurrentUsername;
        DataManagerComposer.SavePlayerLevel(username, 2);
        Debug.Log($"[GameManagerComposer] Level 2 marcado como completado para usuario: {username}");
        
        // Verificar inmediatamente
        int newLevel = DataManagerComposer.GetPlayerLevel(username);
        Debug.Log($"[GameManagerComposer] Verificación - Nivel actual: {newLevel}");
    }
    
    [ContextMenu("Fix Current User Progress")]
    private void FixCurrentUserProgress()
    {
        string currentUser = DataManagerComposer.CurrentUsername;
        Debug.Log($"[GameManagerComposer] ARREGLANDO PROGRESO DE {currentUser}...");
        
        // Forzar que el usuario actual tenga el nivel actual completado
        DataManagerComposer.SavePlayerLevel(currentUser, levelNumber);
        
        // Verificar
        int level = DataManagerComposer.GetPlayerLevel(currentUser);
        Debug.Log($"[GameManagerComposer] {currentUser} ahora tiene nivel: {level}");
        
        // También agregarlo a usuarios recientes
        DataManagerComposer.AddRecentUsername(currentUser);
        
        Debug.Log($"[GameManagerComposer] ¡Progreso arreglado! {currentUser} puede acceder a niveles hasta {level+1}.");
    }
    
    [ContextMenu("Unlock Level 2 for ELLL")]
    private void UnlockLevel2ForELLL()
    {
        Debug.Log("[GameManagerComposer] DESBLOQUEANDO LEVEL 2 PARA ELLL...");
        
        // Marcar Level 1 como completado para ELLL
        DataManagerComposer.SavePlayerLevel("ELLL", 1);
        
        // Verificar
        int level = DataManagerComposer.GetPlayerLevel("ELLL");
        Debug.Log($"[GameManagerComposer] ELLL ahora tiene nivel: {level}");
        
        // Agregar a usuarios recientes
        DataManagerComposer.AddRecentUsername("ELLL");
        
        Debug.Log("[GameManagerComposer] ¡LISTO! ELLL puede acceder a Level 2. Ve al Lobby.");
    }
    
    [ContextMenu("Force Save Current Level")]
    private void ForceSaveCurrentLevel()
    {
        Debug.Log("[GameManagerComposer] FORZANDO GUARDADO DEL NIVEL ACTUAL...");
        HandleVictoryComplete();
    }
    
    private void OnDestroy()
    {
        // Cleanup de eventos
        Enemy.OnAnyEnemyKilled -= HandleEnemyKilled;
        
        if (Player.Instance != null)
        {
            Player.Instance.OnPlayerDead -= HandlePlayerDead;
        }
    }
}