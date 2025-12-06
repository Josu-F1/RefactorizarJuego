using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Sistema de cheats refactorizado aplicando Command Pattern
/// Patrón: Command Pattern - Encapsula acciones como objetos
/// Principio: Single Responsibility Principle (SRP) - Solo maneja comandos de cheat
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevos cheats
/// Principio: Dependency Inversion Principle (DIP) - Usa interfaces
/// </summary>

/// <summary>
/// Interfaz para comandos de cheat
/// Patrón: Command Pattern - Interfaz común para todos los comandos
/// </summary>
public interface ICheatCommand
{
    string Name { get; }
    string Description { get; }
    void Execute();
    bool CanExecute();
}

/// <summary>
/// Comando para matar todos los enemigos
/// </summary>
public class KillAllEnemiesCommand : ICheatCommand
{
    public string Name => "Kill All Enemies";
    public string Description => "Elimina todos los enemigos en la escena";
    
    private CharacterSystemComposer characterSystem;
    
    public KillAllEnemiesCommand(CharacterSystemComposer characterSystem)
    {
        this.characterSystem = characterSystem;
    }
    
    public bool CanExecute()
    {
        return characterSystem != null && UnityEngine.Object.FindObjectsOfType<Enemy>().Length > 0;
    }
    
    public void Execute()
    {
        if (!CanExecute()) 
        {
            Debug.LogWarning("[KillAllEnemiesCommand] No se puede ejecutar - sin enemigos o sin sistema");
            return;
        }
        
        characterSystem.ExecuteEnemyKillCheat();
        Debug.Log("[KillAllEnemiesCommand] Comando ejecutado exitosamente");
    }
}

/// <summary>
/// Comando para curar al jugador
/// </summary>
public class HealPlayerCommand : ICheatCommand
{
    public string Name => "Heal Player";
    public string Description => "Cura completamente al jugador";
    
    private CharacterSystemComposer characterSystem;
    
    public HealPlayerCommand(CharacterSystemComposer characterSystem)
    {
        this.characterSystem = characterSystem;
    }
    
    public bool CanExecute()
    {
        return characterSystem != null && Player.Instance != null;
    }
    
    public void Execute()
    {
        if (!CanExecute())
        {
            Debug.LogWarning("[HealPlayerCommand] No se puede ejecutar - sin jugador o sin sistema");
            return;
        }
        
        characterSystem.ExecutePlayerHealCheat();
        Debug.Log("[HealPlayerCommand] Comando ejecutado exitosamente");
    }
}

/// <summary>
/// Comando para dar puntos al jugador
/// </summary>
public class AddScoreCommand : ICheatCommand
{
    public string Name => "Add Score";
    public string Description => "Añade puntos al jugador";
    
    private int scoreAmount;
    
    public AddScoreCommand(int amount = 1000)
    {
        scoreAmount = amount;
    }
    
    public bool CanExecute()
    {
        // Verificar si existe ScoreService (Clean Architecture)
        var scoreService = CleanArchitecture.Infrastructure.DependencyInjection.ServiceLocator.Instance.Get<CleanArchitecture.Application.Services.IScoreService>();
        return scoreService != null;
    }
    
    public void Execute()
    {
        if (!CanExecute())
        {
            Debug.LogWarning("[AddScoreCommand] No se puede ejecutar - sin ScoreService");
            return;
        }
        
        // Usar ScoreService de Clean Architecture
        var scoreService = CleanArchitecture.Infrastructure.DependencyInjection.ServiceLocator.Instance.Get<CleanArchitecture.Application.Services.IScoreService>();
        if (scoreService != null)
        {
            scoreService.AddScore(scoreAmount);
            Debug.Log($"[AddScoreCommand] Añadidos {scoreAmount} puntos via ScoreService");
        }
    }
}

/// <summary>
/// Composer del sistema de cheats con Command Pattern
/// Patrón: Facade Pattern - Simplifica el acceso a los comandos
/// Patrón: Command Pattern - Gestiona y ejecuta comandos
/// </summary>
[System.Obsolete("CheatSystemComposer is deprecated. Cheats should use ServiceLocator to access Clean Architecture services.")]
public class CheatSystemComposer : MonoBehaviourSingleton<CheatSystemComposer>
{
    [Header("Cheat System Configuration")]
    [SerializeField] private bool enableCheats = true;
    [SerializeField] private KeyCode cheatMenuKey = KeyCode.F1;
    
    // Sistema de comandos
    private Dictionary<string, ICheatCommand> availableCommands;
    private CharacterSystemComposer characterSystem;
    
    // UI simple para testing (opcional)
    [Header("Debug UI")]
    [SerializeField] private bool showDebugUI = false;
    private bool showCheatMenu = false;
    
    protected override void Awake()
    {
        base.Awake();
        InitializeCheatSystem();
    }
    
    private void InitializeCheatSystem()
    {
        if (!enableCheats)
        {
            Debug.Log("[CheatSystemComposer] Cheats deshabilitados");
            return;
        }
        
        // Obtener referencia al sistema de personajes
        characterSystem = CharacterSystemComposer.Instance;
        
        // Inicializar comandos
        availableCommands = new Dictionary<string, ICheatCommand>();
        
        RegisterCommand(new KillAllEnemiesCommand(characterSystem));
        RegisterCommand(new HealPlayerCommand(characterSystem));
        RegisterCommand(new AddScoreCommand(1000));
        
        Debug.Log($"[CheatSystemComposer] Sistema inicializado con {availableCommands.Count} comandos");
    }
    
    private void Update()
    {
        if (!enableCheats) return;
        
        // Toggle cheat menu con tecla
        if (Input.GetKeyDown(cheatMenuKey))
        {
            showCheatMenu = !showCheatMenu;
        }
    }
    
    /// <summary>
    /// Registra un nuevo comando de cheat
    /// </summary>
    public void RegisterCommand(ICheatCommand command)
    {
        if (command != null)
        {
            availableCommands[command.Name] = command;
            Debug.Log($"[CheatSystemComposer] Comando registrado: {command.Name}");
        }
    }
    
    /// <summary>
    /// Ejecuta un comando por nombre
    /// </summary>
    public bool ExecuteCommand(string commandName)
    {
        if (!enableCheats)
        {
            Debug.LogWarning("[CheatSystemComposer] Cheats deshabilitados");
            return false;
        }
        
        if (availableCommands.TryGetValue(commandName, out ICheatCommand command))
        {
            if (command.CanExecute())
            {
                command.Execute();
                return true;
            }
            else
            {
                Debug.LogWarning($"[CheatSystemComposer] No se puede ejecutar: {commandName}");
                return false;
            }
        }
        
        Debug.LogError($"[CheatSystemComposer] Comando no encontrado: {commandName}");
        return false;
    }
    
    /// <summary>
    /// API pública para compatibilidad con código existente
    /// </summary>
    public void ExecuteKillAllEnemies()
    {
        ExecuteCommand("Kill All Enemies");
    }
    
    public void ExecuteHealPlayer()
    {
        ExecuteCommand("Heal Player");
    }
    
    public void ExecuteAddScore(int amount = 1000)
    {
        // Crear comando temporal con cantidad específica
        var command = new AddScoreCommand(amount);
        if (command.CanExecute())
        {
            command.Execute();
        }
    }
    
    /// <summary>
    /// Obtiene lista de comandos disponibles
    /// </summary>
    public string[] GetAvailableCommands()
    {
        var commands = new string[availableCommands.Count];
        availableCommands.Keys.CopyTo(commands, 0);
        return commands;
    }
    
    /// <summary>
    /// UI simple para testing (solo en Development builds)
    /// </summary>
    private void OnGUI()
    {
        if (!showDebugUI || !enableCheats || !showCheatMenu) return;
        
        GUILayout.BeginArea(new Rect(10, 10, 300, 400));
        GUILayout.BeginVertical("box");
        
        GUILayout.Label("=== CHEAT MENU ===");
        GUILayout.Label($"Presiona {cheatMenuKey} para alternar");
        GUILayout.Space(10);
        
        foreach (var kvp in availableCommands)
        {
            var command = kvp.Value;
            GUI.enabled = command.CanExecute();
            
            if (GUILayout.Button($"{command.Name}"))
            {
                command.Execute();
            }
            
            GUILayout.Label(command.Description, GUI.skin.GetStyle("label"));
            GUILayout.Space(5);
        }
        
        GUI.enabled = true;
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}