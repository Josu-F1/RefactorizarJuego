using UnityEngine;

/// <summary>
/// Controlador de movimiento refactorizado usando Command Pattern y principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo coordina input y movimiento
/// Principio: Dependency Inversion Principle (DIP) - Depende de interfaces
/// Patrón: Command Pattern - Usa comandos para separar input de ejecución
/// </summary>
[RequireComponent(typeof(MoveComponent))]
public class MovementController : MonoBehaviour
{
    [Header("Input Configuration")]
    [SerializeField] private KeyboardMovementConfig keyboardConfig = new KeyboardMovementConfig();
    [SerializeField] private bool useKeyboardInput = true;
    
    // Sistemas especializados
    private IInputHandler inputHandler;
    private IMovementExecutor movementExecutor;
    
    private void Awake()
    {
        InitializeSystems();
    }
    
    private void InitializeSystems()
    {
        // Configurar ejecutor de movimiento
        movementExecutor = GetComponent<IMovementExecutor>();
        if (movementExecutor == null)
        {
            Debug.LogError($"MovementController: No IMovementExecutor found on {gameObject.name}");
            return;
        }
        
        // Configurar handler de input
        if (useKeyboardInput)
        {
            inputHandler = new KeyboardMovementInputHandler(keyboardConfig);
        }
    }
    
    private void Update()
    {
        if (inputHandler == null || movementExecutor == null) return;
        
        // Obtener comando de input y ejecutarlo
        IMovementCommand command = inputHandler.GetMovementCommand();
        command?.Execute(movementExecutor);
    }
    
    /// <summary>
    /// Permite cambiar el handler de input en runtime
    /// Útil para cambiar entre teclado, gamepad, touch, etc.
    /// </summary>
    public void SetInputHandler(IInputHandler newInputHandler)
    {
        inputHandler = newInputHandler;
    }
    
    /// <summary>
    /// Permite cambiar la configuración de teclado en runtime
    /// </summary>
    public void SetKeyboardConfig(KeyboardMovementConfig newConfig)
    {
        keyboardConfig = newConfig;
        if (useKeyboardInput)
        {
            inputHandler = new KeyboardMovementInputHandler(keyboardConfig);
        }
    }
    
    /// <summary>
    /// Ejecuta un comando de movimiento directamente
    /// Útil para IA, cutscenes, o input programático
    /// </summary>
    public void ExecuteMovementCommand(IMovementCommand command)
    {
        command?.Execute(movementExecutor);
    }
}