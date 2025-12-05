using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Sistema de spawn de bombas refactorizado usando Factory Pattern y principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo coordina el spawn de bombas
/// Principio: Dependency Inversion Principle (DIP) - Depende de interfaces
/// Patrón: Factory Pattern - Delega creación a fábricas especializadas
/// </summary>
public class BombSpawnerComposer : MonoBehaviour, IBombSpawnerReference
{
    [Header("Configuration")]
    [SerializeField] private BombConfiguration bombConfig = new BombConfiguration();
    
    [Header("Pools")]
    [SerializeField] private ObjectPool bombPool;
    [SerializeField] private ObjectPool explosionPool;
    
    [Header("Events")]
    [SerializeField] private UnityEvent onBombPlaced;
    
    // Sistemas especializados
    private IBombFactory bombFactory;
    private IBombPositionManager positionManager;
    private CharacterType characterType;
    
    // Eventos para compatibilidad con sistema anterior
    public Action OnDamageChanged { get; set; }
    public Action OnLengthChanged { get; set; }
    public Action OnBombLimitChanged { get; set; }
    
    // Propiedades públicas para compatibilidad (ahora delegan a configuración)
    public float Damage
    {
        get => bombConfig.Damage;
        set
        {
            bombConfig.Damage = value;
            OnDamageChanged?.Invoke();
        }
    }
    
    public int Length
    {
        get => bombConfig.Length;
        set
        {
            bombConfig.Length = value;
            OnLengthChanged?.Invoke();
        }
    }
    
    public int BombLimit
    {
        get => bombConfig.BombLimit;
        set
        {
            bombConfig.BombLimit = value;
            OnBombLimitChanged?.Invoke();
        }
    }
    
    private void Awake()
    {
        InitializeSystems();
        characterType = GetComponentInParent<ICharacter>()?.CharacterType ?? CharacterType.Player;
    }
    
    private void InitializeSystems()
    {
        // Crear fábrica de bombas
        bombFactory = new PooledBombFactory(bombPool, explosionPool);
        
        // Crear gestor de posiciones
        positionManager = new ListBombPositionManager();
    }
    
    /// <summary>
    /// Coloca una bomba en la posición especificada
    /// </summary>
    public void PlaceBomb(Vector2 position)
    {
        if (!CanPlaceBomb(position)) return;
        
        Bomb bomb = bombFactory.CreateBomb(position, bombConfig, characterType);
        if (bomb != null)
        {
            // Configurar referencia para cleanup
            bomb.BombSpawner = this;
            
            positionManager.AddBombPosition(position);
            onBombPlaced?.Invoke();
        }
    }
    
    /// <summary>
    /// Arroja una bomba hacia el destino especificado
    /// </summary>
    public void ThrowBomb(Vector2 destination, float throwSpeed)
    {
        Bomb bomb = bombFactory.CreateThrowableBomb(destination, throwSpeed, bombConfig, characterType);
        if (bomb != null)
        {
            bomb.BombSpawner = this;
        }
    }
    
    /// <summary>
    /// Coloca una bomba en la posición actual del spawner
    /// </summary>
    public void PlaceBomb()
    {
        PlaceBomb(transform.position);
    }
    
    /// <summary>
    /// Verifica si se puede colocar una bomba en la posición
    /// </summary>
    private bool CanPlaceBomb(Vector2 position)
    {
        if (positionManager.HasReachedLimit(bombConfig.BombLimit))
            return false;
            
        return positionManager.CanPlaceBombAt(position);
    }
    
    /// <summary>
    /// Llamado por las bombas cuando explotan para limpiar la posición
    /// </summary>
    public void RemoveBombPosition(Vector3 position)
    {
        positionManager.RemoveBombPosition(position);
    }
    
    /// <summary>
    /// Permite cambiar la fábrica de bombas en runtime (para testing o diferentes tipos)
    /// </summary>
    public void SetBombFactory(IBombFactory factory)
    {
        bombFactory = factory ?? new PooledBombFactory(bombPool, explosionPool);
    }
    
    /// <summary>
    /// Permite cambiar el gestor de posiciones en runtime
    /// </summary>
    public void SetPositionManager(IBombPositionManager manager)
    {
        positionManager = manager ?? new ListBombPositionManager();
    }
    
    /// <summary>
    /// Obtiene el número actual de bombas activas
    /// </summary>
    public int GetActiveBombCount()
    {
        return positionManager.CurrentBombCount;
    }
}