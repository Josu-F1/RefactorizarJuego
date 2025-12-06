#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;
using System;

/// <summary>
/// Composer principal del sistema de personajes refactorizado
/// Patrón: Facade Pattern - Simplifica el acceso al sistema de componentes
/// Principio: Single Responsibility Principle (SRP) - Solo orquesta el sistema de personajes
/// Principio: Dependency Inversion Principle (DIP) - Usa interfaces, no implementaciones
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevos tipos de personajes
/// </summary>
public class CharacterSystemComposer : MonoBehaviourSingleton<CharacterSystemComposer>
{
    [Header("Character System Configuration")]
    [SerializeField] private CharacterConfig[] characterConfigs;
    
    // Sistemas SOLID
    private ICharacterControllerFactory controllerFactory;
    
    // Cache de controladores activos
    private System.Collections.Generic.Dictionary<GameObject, ICharacterController> activeControllers;
    
    protected override void Awake()
    {
        base.Awake();
        InitializeCharacterSystem();
    }
    
    private void InitializeCharacterSystem()
    {
        // Crear factory
        controllerFactory = new CharacterControllerFactory();
        
        // Registrar configuraciones personalizadas si existen
        if (characterConfigs != null)
        {
            foreach (var config in characterConfigs)
            {
                RegisterCharacterConfig(config.characterType, config);
            }
        }
        
        // Inicializar cache
        activeControllers = new System.Collections.Generic.Dictionary<GameObject, ICharacterController>();
        
        Debug.Log("[CharacterSystemComposer] Sistema de personajes inicializado con principios SOLID");
    }
    
    /// <summary>
    /// Registra una configuración personalizada para un tipo de personaje
    /// </summary>
    public void RegisterCharacterConfig(CharacterType type, CharacterConfig config)
    {
        if (controllerFactory is CharacterControllerFactory factory)
        {
            factory.RegisterDefaultConfig(type, config);
        }
    }
    
    /// <summary>
    /// Crea un controlador de personaje con el sistema refactorizado
    /// </summary>
    public ICharacterController CreateCharacterController(CharacterType type, GameObject gameObject)
    {
        if (gameObject == null)
        {
            Debug.LogError("[CharacterSystemComposer] GameObject no puede ser null");
            return null;
        }
        
        var controller = controllerFactory.CreateCharacterController(type, gameObject);
        
        if (controller != null)
        {
            activeControllers[gameObject] = controller;
            Debug.Log($"[CharacterSystemComposer] Controller creado para {type}: {gameObject.name}");
        }
        
        return controller;
    }
    
    /// <summary>
    /// Obtiene el controlador de un GameObject específico
    /// </summary>
    public ICharacterController GetController(GameObject gameObject)
    {
        activeControllers.TryGetValue(gameObject, out ICharacterController controller);
        return controller;
    }
    
    /// <summary>
    /// Limpia un controlador específico
    /// </summary>
    public void CleanupController(GameObject gameObject)
    {
        if (activeControllers.TryGetValue(gameObject, out ICharacterController controller))
        {
            if (controller is CharacterController concreteController)
            {
                concreteController.Cleanup();
            }
            activeControllers.Remove(gameObject);
            
            Debug.Log($"[CharacterSystemComposer] Controller limpiado: {gameObject.name}");
        }
    }
    
    /// <summary>
    /// API de compatibilidad para obtener componente específico
    /// </summary>
    public T GetCharacterComponent<T>(GameObject gameObject) where T : class, ICharacterComponent
    {
        var controller = GetController(gameObject);
        return controller?.GetComponent<T>();
    }
    
    /// <summary>
    /// API de compatibilidad para score de enemigos (mantiene el static event original)
    /// </summary>
    public void ExecuteEnemyKillCheat()
    {
        var enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            var controller = GetController(enemy.gameObject);
            if (controller != null)
            {
                // Usar el sistema refactorizado
                var deathHandler = controller.GetComponent<IDeathHandler>();
                deathHandler?.HandleDeath();
            }
            else
            {
                Debug.LogWarning($"[CharacterSystemComposer] Enemy {enemy.name} sin controller - no se puede matar");
            }
        }
        
        Debug.Log("[CharacterSystemComposer] Enemy kill cheat executed");
    }
    
    /// <summary>
    /// API de compatibilidad para heal del player
    /// </summary>
    public void ExecutePlayerHealCheat()
    {
        var player = Player.Instance;
        if (player != null)
        {
            var controller = GetController(player.gameObject);
            if (controller != null)
            {
                Debug.LogWarning("[CharacterSystemComposer] Player no tiene controller registrado");
            }
        }
    }
    
    /// <summary>
    /// Cleanup cuando se destruye el objeto
    /// </summary>
    private void OnDestroy()
    {
        if (activeControllers != null)
        {
            foreach (var kvp in activeControllers)
            {
                if (kvp.Value is CharacterController controller)
                {
                    controller.Cleanup();
                }
            }
            activeControllers.Clear();
        }
    }
    
    /// <summary>
    /// Método de utilidad para migrar personajes existentes al nuevo sistema
    /// </summary>
    [ContextMenu("Migrate Existing Characters")]
    public void MigrateExistingCharacters()
    {
        // Migrar Players
        var players = FindObjectsOfType<Player>();
        foreach (var player in players)
        {
            CreateCharacterController(CharacterType.Player, player.gameObject);
        }
        
        // Migrar Enemies
        var enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            CreateCharacterController(CharacterType.Enemy, enemy.gameObject);
        }
        
        Debug.Log($"[CharacterSystemComposer] Migrados {players.Length} players y {enemies.Length} enemies");
    }
}