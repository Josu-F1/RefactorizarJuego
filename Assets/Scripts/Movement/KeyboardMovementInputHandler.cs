using UnityEngine;

/// <summary>
/// Configuración de teclas para movimiento
/// Principio: Single Responsibility Principle (SRP) - Solo datos de configuración
/// </summary>
[System.Serializable]
public class KeyboardMovementConfig
{
    [SerializeField] private KeyCode upKey = KeyCode.W;
    [SerializeField] private KeyCode downKey = KeyCode.S;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    
    public KeyCode UpKey => upKey;
    public KeyCode DownKey => downKey;
    public KeyCode LeftKey => leftKey;
    public KeyCode RightKey => rightKey;
    
    public KeyboardMovementConfig(KeyCode up = KeyCode.W, KeyCode down = KeyCode.S, 
                                 KeyCode left = KeyCode.A, KeyCode right = KeyCode.D)
    {
        upKey = up;
        downKey = down;
        leftKey = left;
        rightKey = right;
    }
}

/// <summary>
/// Handler de input de teclado para movimiento
/// Principio: Single Responsibility Principle (SRP) - Solo captura input de teclado
/// </summary>
public class KeyboardMovementInputHandler : IInputHandler
{
    private KeyboardMovementConfig config;
    private KeyCode latestKey = KeyCode.None;
    
    public KeyboardMovementInputHandler(KeyboardMovementConfig config)
    {
        this.config = config;
    }
    
    public bool IsInputActive()
    {
        return Time.timeScale > 0;
    }
    
    public IMovementCommand GetMovementCommand()
    {
        if (!IsInputActive()) return new StopMoveCommand();
        
        UpdateLatestKey();
        
        Vector2 direction = Vector2.zero;
        int activeKeys = 0;
        
        // Contar teclas activas y sumar direcciones
        if (Input.GetKey(config.LeftKey))
        {
            activeKeys++;
            direction += Vector2.left;
        }
        if (Input.GetKey(config.RightKey))
        {
            activeKeys++;
            direction += Vector2.right;
        }
        if (Input.GetKey(config.UpKey))
        {
            activeKeys++;
            direction += Vector2.up;
        }
        if (Input.GetKey(config.DownKey))
        {
            activeKeys++;
            direction += Vector2.down;
        }
        
        // Si no hay teclas o solo una, usar dirección calculada
        if (activeKeys <= 1)
        {
            return new DirectionalMoveCommand(direction);
        }
        
        // Si hay múltiples teclas, usar prioridad de la última presionada
        Vector2 priorityDirection = GetDirectionFromKey(latestKey);
        return new PriorityMoveCommand(priorityDirection);
    }
    
    private void UpdateLatestKey()
    {
        if (Input.GetKeyDown(config.LeftKey)) latestKey = config.LeftKey;
        if (Input.GetKeyDown(config.RightKey)) latestKey = config.RightKey;
        if (Input.GetKeyDown(config.UpKey)) latestKey = config.UpKey;
        if (Input.GetKeyDown(config.DownKey)) latestKey = config.DownKey;
    }
    
    private Vector2 GetDirectionFromKey(KeyCode keyCode)
    {
        if (keyCode == config.LeftKey) return Vector2.left;
        if (keyCode == config.RightKey) return Vector2.right;
        if (keyCode == config.UpKey) return Vector2.up;
        if (keyCode == config.DownKey) return Vector2.down;
        return Vector2.zero;
    }
}