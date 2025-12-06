using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Sistema de movimiento refactorizado usando Command Pattern y SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo orquesta el movimiento
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevos tipos de movimiento
/// Patrón: Command Pattern - Comandos de movimiento desacoplados
/// Patrón: Strategy Pattern - Diferentes estrategias de movimiento
/// Patrón: Facade Pattern - Simplifica acceso al sistema de movimiento
/// </summary>
public class MovementSystemComposer : MonoBehaviourSingleton<MovementSystemComposer>
{
    [Header("Movement Configuration")]
    [SerializeField] private bool enableDebugLogging = false;
    [SerializeField] private float defaultMoveSpeed = 5f;
    
    // Registry de controllers
    private Dictionary<GameObject, IMovementController> movementControllers = new Dictionary<GameObject, IMovementController>();
    
    protected override void Awake()
    {
        base.Awake();
        if (enableDebugLogging)
            Debug.Log("[MovementSystemComposer] ✅ Sistema inicializado");
    }
    
    #region Public API
    
    /// <summary>
    /// Crea un controller de movimiento para un GameObject
    /// </summary>
    public IMovementController CreateMovementController(GameObject target, MovementConfig config = null)
    {
        if (target == null)
        {
            Debug.LogError("[MovementSystemComposer] Target GameObject es null");
            return null;
        }
        
        // Si ya existe, retornarlo
        if (movementControllers.ContainsKey(target))
        {
            if (enableDebugLogging)
                Debug.Log($"[MovementSystemComposer] Controller ya existe para {target.name}");
            return movementControllers[target];
        }
        
        // Configuración por defecto si no se proporciona
        if (config == null)
        {
            config = new MovementConfig
            {
                moveSpeed = defaultMoveSpeed,
                movementType = MovementType.Grid,
                useRigidbody = true,
                enableRotation = true
            };
        }
        
        // Crear controller según tipo
        IMovementController controller = CreateController(target, config);
        
        if (controller != null)
        {
            movementControllers[target] = controller;
            if (enableDebugLogging)
                Debug.Log($"[MovementSystemComposer] ✅ Controller creado para {target.name}");
        }
        
        return controller;
    }
    
    /// <summary>
    /// Obtiene un controller existente
    /// </summary>
    public IMovementController GetController(GameObject target)
    {
        if (target == null) return null;
        
        movementControllers.TryGetValue(target, out var controller);
        return controller;
    }
    
    /// <summary>
    /// Mueve un GameObject usando su controller
    /// </summary>
    public void Move(GameObject target, Vector2 direction)
    {
        var controller = GetController(target);
        if (controller != null)
        {
            controller.Move(direction);
        }
        else if (enableDebugLogging)
        {
            Debug.LogWarning($"[MovementSystemComposer] No hay controller para {target.name}");
        }
    }
    
    /// <summary>
    /// Cambia la velocidad de movimiento
    /// </summary>
    public void SetSpeed(GameObject target, float newSpeed)
    {
        var controller = GetController(target);
        if (controller != null)
        {
            controller.SetSpeed(newSpeed);
        }
    }
    
    /// <summary>
    /// Detiene el movimiento de un GameObject
    /// </summary>
    public void Stop(GameObject target)
    {
        var controller = GetController(target);
        controller?.Stop();
    }
    
    /// <summary>
    /// Limpia un controller cuando el GameObject se destruye
    /// </summary>
    public void CleanupController(GameObject target)
    {
        if (target != null && movementControllers.ContainsKey(target))
        {
            movementControllers.Remove(target);
            if (enableDebugLogging)
                Debug.Log($"[MovementSystemComposer] Controller limpiado para {target.name}");
        }
    }
    
    #endregion
    
    #region Private Methods
    
    private IMovementController CreateController(GameObject target, MovementConfig config)
    {
        switch (config.movementType)
        {
            case MovementType.Grid:
                return new GridMovementController(target, config);
            
            case MovementType.Free:
                return new FreeMovementController(target, config);
            
            case MovementType.Physics:
                return new PhysicsMovementController(target, config);
            
            default:
                Debug.LogError($"[MovementSystemComposer] Tipo de movimiento no soportado: {config.movementType}");
                return null;
        }
    }
    
    #endregion
    
    #region Compatibility API (Legacy Integration)
    
    /// <summary>
    /// API de compatibilidad para MoveComponent legacy
    /// </summary>
    public void RegisterLegacyMoveComponent(MoveComponent moveComponent)
    {
        if (moveComponent == null) return;
        
        var config = new MovementConfig
        {
            moveSpeed = moveComponent.MoveSpeed,
            movementType = MovementType.Grid,
            useRigidbody = true,
            enableRotation = true
        };
        
        CreateMovementController(moveComponent.gameObject, config);
    }
    
    #endregion
}

#region Movement Interfaces

public interface IMovementController
{
    void Move(Vector2 direction);
    void Stop();
    void SetSpeed(float speed);
    float GetSpeed();
}

#endregion

#region Movement Configurations

[System.Serializable]
public class MovementConfig
{
    public float moveSpeed = 5f;
    public MovementType movementType = MovementType.Grid;
    public bool useRigidbody = true;
    public bool enableRotation = true;
    public bool canMoveWhileAttacking = true;
}

public enum MovementType
{
    Grid,       // Movimiento en grilla (Bomberman style)
    Free,       // Movimiento libre continuo
    Physics     // Movimiento con física (fuerzas)
}

#endregion

#region Movement Controllers

/// <summary>
/// Controller para movimiento en grilla
/// </summary>
public class GridMovementController : IMovementController
{
    private GameObject target;
    private Rigidbody2D rb;
    private MovementConfig config;
    private Vector2 currentDirection;
    
    public GridMovementController(GameObject target, MovementConfig config)
    {
        this.target = target;
        this.config = config;
        this.rb = target.GetComponent<Rigidbody2D>();
        
        if (rb == null && config.useRigidbody)
        {
            rb = target.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    
    public void Move(Vector2 direction)
    {
        currentDirection = direction.normalized;
        
        if (rb != null)
        {
            rb.velocity = currentDirection * config.moveSpeed;
        }
        else
        {
            target.transform.Translate(currentDirection * config.moveSpeed * Time.deltaTime);
        }
    }
    
    public void Stop()
    {
        currentDirection = Vector2.zero;
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
    }
    
    public void SetSpeed(float speed)
    {
        config.moveSpeed = speed;
    }
    
    public float GetSpeed()
    {
        return config.moveSpeed;
    }
}

/// <summary>
/// Controller para movimiento libre
/// </summary>
public class FreeMovementController : IMovementController
{
    private GameObject target;
    private Rigidbody2D rb;
    private MovementConfig config;
    
    public FreeMovementController(GameObject target, MovementConfig config)
    {
        this.target = target;
        this.config = config;
        this.rb = target.GetComponent<Rigidbody2D>();
    }
    
    public void Move(Vector2 direction)
    {
        Vector2 movement = direction.normalized * config.moveSpeed;
        
        if (rb != null)
        {
            rb.velocity = movement;
        }
        else
        {
            target.transform.Translate(movement * Time.deltaTime);
        }
    }
    
    public void Stop()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
    }
    
    public void SetSpeed(float speed)
    {
        config.moveSpeed = speed;
    }
    
    public float GetSpeed()
    {
        return config.moveSpeed;
    }
}

/// <summary>
/// Controller para movimiento basado en física
/// </summary>
public class PhysicsMovementController : IMovementController
{
    private GameObject target;
    private Rigidbody2D rb;
    private MovementConfig config;
    
    public PhysicsMovementController(GameObject target, MovementConfig config)
    {
        this.target = target;
        this.config = config;
        this.rb = target.GetComponent<Rigidbody2D>();
        
        if (rb == null)
        {
            rb = target.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
        }
    }
    
    public void Move(Vector2 direction)
    {
        Vector2 force = direction.normalized * config.moveSpeed;
        rb.AddForce(force, ForceMode2D.Force);
    }
    
    public void Stop()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
    
    public void SetSpeed(float speed)
    {
        config.moveSpeed = speed;
    }
    
    public float GetSpeed()
    {
        return config.moveSpeed;
    }
}

#endregion
