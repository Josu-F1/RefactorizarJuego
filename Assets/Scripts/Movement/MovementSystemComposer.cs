using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Sistema de movimiento refactorizado aplicando Clean Architecture
/// Patrón: Facade + Strategy + Command
/// Principios: SRP, OCP, DIP
/// </summary>
public class MovementSystemComposer : MonoBehaviourSingleton<MovementSystemComposer>
{
    [Header("Configuration")]
    [SerializeField] private bool enableDebugLogging = false;
    
    private Dictionary<GameObject, IMovementController> controllers = new Dictionary<GameObject, IMovementController>();
    private MovementService movementService;
    
    protected override void Awake()
    {
        base.Awake();
        InitializeSystem();
    }
    
    private void InitializeSystem()
    {
        movementService = new MovementService();
        
        if (enableDebugLogging)
            Debug.Log("[MovementSystemComposer] ✅ Sistema inicializado");
    }
    
    /// <summary>
    /// Crea un controlador de movimiento para un GameObject
    /// </summary>
    public IMovementController CreateMovementController(GameObject target, MovementConfig config = null)
    {
        if (target == null)
        {
            Debug.LogError("[MovementSystemComposer] Target GameObject es null");
            return null;
        }
        
        if (controllers.ContainsKey(target))
        {
            if (enableDebugLogging)
                Debug.LogWarning($"[MovementSystemComposer] Ya existe un controller para {target.name}");
            return controllers[target];
        }
        
        // Configuración por defecto si no se proporciona
        if (config == null)
        {
            config = new MovementConfig
            {
                moveSpeed = 5f,
                movementType = MovementType.GridBased,
                useRigidbody = false,
                smoothMovement = true
            };
        }
        
        // Crear controller basado en tipo
        IMovementController controller = CreateControllerByType(target, config);
        
        if (controller != null)
        {
            controllers[target] = controller;
            
            if (enableDebugLogging)
                Debug.Log($"[MovementSystemComposer] ✅ Controller creado para {target.name}");
        }
        
        return controller;
    }
    
    private IMovementController CreateControllerByType(GameObject target, MovementConfig config)
    {
        // Obtener o agregar componente de movimiento
        var moveComponent = target.GetComponent<MoveComponent>();
        if (moveComponent == null)
        {
            moveComponent = target.AddComponent<MoveComponent>();
        }
        
        // Configurar velocidad
        moveComponent.SetMoveSpeed(config.moveSpeed);
        
        // Crear estrategia de movimiento
        IMovementStrategy strategy = config.movementType switch
        {
            MovementType.GridBased => new GridMovementStrategy(),
            MovementType.Smooth => new SmoothMovementStrategy(),
            MovementType.Physics => new PhysicsMovementStrategy(),
            _ => new GridMovementStrategy()
        };
        
        // Crear input handler con configuración por defecto
        var inputConfig = new KeyboardMovementConfig(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D);
        IInputHandler inputHandler = new KeyboardMovementInputHandler(inputConfig);
        
        // Crear y retornar controller
        return new ModernMovementController(target, moveComponent, strategy, inputHandler);
    }
    
    /// <summary>
    /// Obtiene el controller de un GameObject
    /// </summary>
    public IMovementController GetController(GameObject target)
    {
        if (target == null) return null;
        controllers.TryGetValue(target, out var controller);
        return controller;
    }
    
    /// <summary>
    /// Mueve un GameObject usando el servicio
    /// </summary>
    public void MoveObject(GameObject target, Vector2 direction, float speed)
    {
        if (target == null) return;
        
        var controller = GetController(target);
        if (controller != null)
        {
            controller.Move(direction);
        }
        else
        {
            // Fallback directo
            target.transform.Translate(direction * speed * Time.deltaTime);
        }
    }
    
    /// <summary>
    /// Limpia el controller de un GameObject
    /// </summary>
    public void CleanupController(GameObject target)
    {
        if (target == null) return;
        
        if (controllers.ContainsKey(target))
        {
            controllers.Remove(target);
            
            if (enableDebugLogging)
                Debug.Log($"[MovementSystemComposer] Controller limpiado para {target.name}");
        }
    }
    
    /// <summary>
    /// Limpia todos los controllers
    /// </summary>
    public void CleanupAll()
    {
        controllers.Clear();
        if (enableDebugLogging)
            Debug.Log("[MovementSystemComposer] Todos los controllers limpiados");
    }
    
    protected override void OnDestroy()
    {
        CleanupAll();
    }
}

/// <summary>
/// Configuración para crear un MovementController
/// </summary>
public class MovementConfig
{
    public float moveSpeed = 5f;
    public MovementType movementType = MovementType.GridBased;
    public bool useRigidbody = false;
    public bool smoothMovement = true;
}

/// <summary>
/// Tipos de movimiento disponibles
/// </summary>
public enum MovementType
{
    GridBased,
    Smooth,
    Physics
}

/// <summary>
/// Servicio de movimiento (Application Layer)
/// </summary>
public class MovementService
{
    public void Move(GameObject target, Vector2 direction, float speed)
    {
        if (target == null) return;
        target.transform.Translate(direction * speed * Time.deltaTime);
    }
    
    public void MoveTowards(GameObject target, Vector3 destination, float speed)
    {
        if (target == null) return;
        target.transform.position = Vector3.MoveTowards(
            target.transform.position,
            destination,
            speed * Time.deltaTime
        );
    }
}

/// <summary>
/// Controller de movimiento (Presentation Layer)
/// </summary>
public class ModernMovementController : IMovementController
{
    private GameObject target;
    private MoveComponent moveComponent;
    private IMovementStrategy strategy;
    private IInputHandler inputHandler;
    
    public ModernMovementController(GameObject target, MoveComponent moveComponent, IMovementStrategy strategy, IInputHandler inputHandler)
    {
        this.target = target;
        this.moveComponent = moveComponent;
        this.strategy = strategy;
        this.inputHandler = inputHandler;
    }
    
    public void Move(Vector2 direction)
    {
        strategy?.Execute(target, direction, moveComponent.MoveSpeed);
    }
    
    public void SetStrategy(IMovementStrategy newStrategy)
    {
        strategy = newStrategy;
    }
    
    public GameObject GetTarget() => target;
}

/// <summary>
/// Interface para controllers de movimiento
/// </summary>
public interface IMovementController
{
    void Move(Vector2 direction);
    void SetStrategy(IMovementStrategy newStrategy);
    GameObject GetTarget();
}

/// <summary>
/// Estrategias de movimiento (Strategy Pattern)
/// </summary>
public interface IMovementStrategy
{
    void Execute(GameObject target, Vector2 direction, float speed);
}

public class GridMovementStrategy : IMovementStrategy
{
    public void Execute(GameObject target, Vector2 direction, float speed)
    {
        if (target == null) return;
        
        // Movimiento basado en grid (snap to grid)
        Vector3 movement = new Vector3(
            Mathf.Round(direction.x),
            Mathf.Round(direction.y),
            0
        ) * speed * Time.deltaTime;
        
        target.transform.Translate(movement);
    }
}

public class SmoothMovementStrategy : IMovementStrategy
{
    public void Execute(GameObject target, Vector2 direction, float speed)
    {
        if (target == null) return;
        
        // Movimiento suave continuo
        Vector3 movement = new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        target.transform.Translate(movement);
    }
}

public class PhysicsMovementStrategy : IMovementStrategy
{
    public void Execute(GameObject target, Vector2 direction, float speed)
    {
        if (target == null) return;
        
        var rb = target.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Movimiento basado en física
            rb.velocity = direction * speed;
        }
        else
        {
            // Fallback a movimiento normal
            target.transform.Translate(new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime);
        }
    }
}
