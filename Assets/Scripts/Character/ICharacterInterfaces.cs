using UnityEngine;
using System;

/// <summary>
/// Interfaces para el sistema de personajes refactorizado
/// Principio: Interface Segregation Principle (ISP) - Interfaces específicas y pequeñas
/// Principio: Dependency Inversion Principle (DIP) - Abstracciones, no concreciones
/// </summary>

/// <summary>
/// Interfaz base para componentes de personaje
/// Patrón: Component Pattern - Comportamientos modulares
/// </summary>
public interface ICharacterComponent
{
    void Initialize(ICharacterController controller);
    void OnDestroy();
    bool IsActive { get; }
}

/// <summary>
/// Controlador principal de personaje
/// Principio: Single Responsibility Principle (SRP) - Solo coordina componentes
/// </summary>
public interface ICharacterController
{
    CharacterType CharacterType { get; }
    GameObject GameObject { get; }
    T GetComponent<T>() where T : class, ICharacterComponent;
    void RegisterComponent<T>(T component) where T : class, ICharacterComponent;
    void NotifyEvent(CharacterEvent eventType, object data = null);
}

/// <summary>
/// Proveedor de puntuación
/// Principio: Single Responsibility Principle (SRP) - Solo maneja score
/// </summary>
public interface IScoreProvider : ICharacterComponent
{
    int Score { get; }
    event Action<int> OnScoreAwarded;
    void AwardScore();
}

/// <summary>
/// Manejador de muerte de personaje
/// Principio: Single Responsibility Principle (SRP) - Solo maneja muerte
/// Patrón: Strategy Pattern - Diferentes estrategias de muerte
/// </summary>
public interface IDeathHandler : ICharacterComponent
{
    event Action OnDeath;
    void HandleDeath();
}

/// <summary>
/// Manejador de eventos de salud
/// Principio: Single Responsibility Principle (SRP) - Solo bridge entre Health y Character
/// </summary>
public interface IHealthEventHandler : ICharacterComponent
{
    event Action OnHealthDepleted;
    void SubscribeToHealth();
    void UnsubscribeFromHealth();
}

/// <summary>
/// Factory para crear controladores de personaje
/// Patrón: Factory Pattern - Creación centralizada
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevos tipos
/// </summary>
public interface ICharacterControllerFactory
{
    ICharacterController CreateCharacterController(CharacterType type, GameObject gameObject);
}

/// <summary>
/// Eventos de personaje
/// </summary>
public enum CharacterEvent
{
    HealthDepleted,
    Death,
    ScoreAwarded,
    Spawned,
    Destroyed
}

/// <summary>
/// Configuración de personaje
/// Principio: Single Responsibility Principle (SRP) - Solo datos de configuración
/// </summary>
[System.Serializable]
public class CharacterConfig
{
    [Header("Character Settings")]
    public CharacterType characterType;
    
    [Header("Score Settings")]
    public int scoreValue = 0;
    public bool providesScore = false;
    
    [Header("Death Settings")]
    public DeathBehaviorType deathBehavior = DeathBehaviorType.Destroy;
    public float deathDelay = 0f;
    
    [Header("Event Settings")]
    public bool notifyGlobalEvents = true;
}

/// <summary>
/// Tipos de comportamiento de muerte
/// Patrón: Strategy Pattern - Diferentes estrategias
/// </summary>
public enum DeathBehaviorType
{
    Destroy,
    Deactivate,
    Respawn,
    Custom
}