using System;
using UnityEngine;

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
        // Crear sistemas especializados
        scoreSystem = new ScoreSystem(requiredScore);
        progressPersistence = new DataManagerProgressAdapter();
        
        // Si no hay GameStateManager, crear uno
        if (gameStateManager == null)
        {
            gameStateManager = gameObject.AddComponent<GameStateManager>();
        }
    }
    
    private void Start()
    {
        SubscribeToEvents();
        ConnectGameSystems();
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
        gameStateManager?.TriggerVictory();
    }
    
    private void HandleVictoryComplete()
    {
        // Guardar progreso del nivel
        progressPersistence?.SaveLevelCompletion(levelNumber);
        OnVictory?.Invoke();
    }
    
    private void HandleDefeatComplete()
    {
        OnDefeat?.Invoke();
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