using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Controlador de personaje refactorizado aplicando SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo coordina componentes
/// Principio: Open/Closed Principle (OCP) - Extensible con nuevos componentes
/// Principio: Dependency Inversion Principle (DIP) - Usa interfaces
/// Patrón: Component Pattern - Composición sobre herencia
/// </summary>
public class CharacterController : ICharacterController
{
    public CharacterType CharacterType { get; private set; }
    public GameObject GameObject { get; private set; }
    
    private Dictionary<Type, ICharacterComponent> components;
    private CharacterConfig config;
    
    public CharacterController(CharacterType characterType, GameObject gameObject, CharacterConfig config)
    {
        CharacterType = characterType;
        GameObject = gameObject;
        this.config = config;
        components = new Dictionary<Type, ICharacterComponent>();
        
        InitializeComponents();
    }
    
    private void InitializeComponents()
    {
        // Crear componentes según configuración
        if (config.providesScore && config.scoreValue > 0)
        {
            var scoreProvider = new ScoreProvider(config.scoreValue);
            RegisterComponent<IScoreProvider>(scoreProvider);
            
            // Conectar eventos globales si está habilitado
            if (config.notifyGlobalEvents)
            {
                scoreProvider.OnScoreAwarded += NotifyGlobalScore;
            }
        }
        
        // Crear manejador de muerte
        var deathHandler = new DeathHandler(config.deathBehavior, config.deathDelay);
        RegisterComponent<IDeathHandler>(deathHandler);
        
        // Crear manejador de eventos de salud
        var healthHandler = new HealthEventHandler();
        RegisterComponent<IHealthEventHandler>(healthHandler);
        
        // Conectar eventos entre componentes
        healthHandler.OnHealthDepleted += () => deathHandler.HandleDeath();
        
        // Si es Enemy, conectar score con muerte
        if (CharacterType == CharacterType.Enemy && config.providesScore)
        {
            deathHandler.OnDeath += () => GetComponent<IScoreProvider>()?.AwardScore();
        }
        
        Debug.Log($"[CharacterController] Initialized {CharacterType} with {components.Count} components");
    }
    
    public T GetComponent<T>() where T : class, ICharacterComponent
    {
        components.TryGetValue(typeof(T), out ICharacterComponent component);
        return component as T;
    }
    
    public void RegisterComponent<T>(T component) where T : class, ICharacterComponent
    {
        components[typeof(T)] = component;
        component.Initialize(this);
        
        Debug.Log($"[CharacterController] Registered component: {typeof(T).Name}");
    }
    
    public void NotifyEvent(CharacterEvent eventType, object data = null)
    {
        Debug.Log($"[CharacterController] Event: {eventType} for {CharacterType}");
        
        // Notificar eventos globales si está habilitado
        if (config.notifyGlobalEvents)
        {
            switch (eventType)
            {
                case CharacterEvent.Death:
                    if (CharacterType == CharacterType.Player)
                    {
                        // Mantener compatibilidad con sistema existente
                        var player = GameObject?.GetComponent<Player>();
                        player?.OnPlayerDead?.Invoke();
                    }
                    break;
            }
        }
    }
    
    private void NotifyGlobalScore(int score)
    {
        if (CharacterType == CharacterType.Enemy)
        {
            // Mantener compatibilidad con sistema existente
            Enemy.OnAnyEnemyKilled?.Invoke(score);
        }
    }
    
    public void Cleanup()
    {
        foreach (var component in components.Values)
        {
            component?.OnDestroy();
        }
        components.Clear();
        
        Debug.Log($"[CharacterController] Cleaned up {CharacterType}");
    }
}

/// <summary>
/// Factory para crear controladores de personaje
/// Patrón: Factory Pattern - Creación centralizada y configurable
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevos tipos
/// </summary>
public class CharacterControllerFactory : ICharacterControllerFactory
{
    private Dictionary<CharacterType, CharacterConfig> defaultConfigs;
    
    public CharacterControllerFactory()
    {
        InitializeDefaultConfigs();
    }
    
    private void InitializeDefaultConfigs()
    {
        defaultConfigs = new Dictionary<CharacterType, CharacterConfig>
        {
            [CharacterType.Player] = new CharacterConfig
            {
                characterType = CharacterType.Player,
                providesScore = false,
                scoreValue = 0,
                deathBehavior = DeathBehaviorType.Deactivate,
                deathDelay = 0f,
                notifyGlobalEvents = true
            },
            [CharacterType.Enemy] = new CharacterConfig
            {
                characterType = CharacterType.Enemy,
                providesScore = true,
                scoreValue = 5, // Valor por defecto del Enemy original
                deathBehavior = DeathBehaviorType.Destroy,
                deathDelay = 0f,
                notifyGlobalEvents = true
            }
        };
    }
    
    public ICharacterController CreateCharacterController(CharacterType type, GameObject gameObject)
    {
        return CreateCharacterController(type, gameObject, null);
    }
    
    public ICharacterController CreateCharacterController(CharacterType type, GameObject gameObject, CharacterConfig customConfig)
    {
        CharacterConfig config = customConfig ?? GetDefaultConfig(type);
        
        if (config == null)
        {
            Debug.LogError($"[CharacterControllerFactory] No config found for type: {type}");
            return null;
        }
        
        var controller = new CharacterController(type, gameObject, config);
        Debug.Log($"[CharacterControllerFactory] Created {type} controller");
        
        return controller;
    }
    
    private CharacterConfig GetDefaultConfig(CharacterType type)
    {
        return defaultConfigs.TryGetValue(type, out CharacterConfig config) ? config : null;
    }
    
    public void RegisterDefaultConfig(CharacterType type, CharacterConfig config)
    {
        defaultConfigs[type] = config;
        Debug.Log($"[CharacterControllerFactory] Registered config for {type}");
    }
}