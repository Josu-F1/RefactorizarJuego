#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;
using PoolSystem.Interfaces;
using PoolSystem;

/// <summary>
/// Clase base para objetos pooled - Compatible con ambos sistemas
/// Implementa IPoolable para el nuevo sistema
/// </summary>
public class PoolObject : MonoBehaviour, IPoolable
{
    [SerializeField] private PoolObjectType type;
    public PoolObjectType Type 
    { 
        get => type; 
        set => type = value; 
    }
    
    protected PoolManager poolManager;
    
    protected virtual void Start()
    {
        poolManager = PoolManager.Instance;
    }
    
    public void ReturnToPool()
    {
        // Prioridad 1: Clean Architecture
        var legacyAdapter = CleanArchitecture.Presentation.Adapters.LegacyPoolAdapter.Instance;
        if (legacyAdapter != null)
        {
            legacyAdapter.ReturnToPool(Type, gameObject);
            return;
        }
        
        // Prioridad 2: Sistema legacy
        if (poolManager != null)
        {
            poolManager.ReturnToPool(Type, gameObject);
        }
    }
    
    #region IPoolable Implementation
    
    public virtual void OnGetFromPool()
    {
        gameObject.SetActive(true);
        OnPoolActivated();
    }
    
    public virtual void OnReturnToPool()
    {
        OnPoolDeactivated();
        gameObject.SetActive(false);
    }
    
    public virtual void ResetState()
    {
        // Reiniciar transform
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
        
        OnPoolReset();
    }
    
    #endregion
    
    #region Template Methods
    
    /// <summary>
    /// Llamado cuando el objeto es activado desde el pool
    /// </summary>
    protected virtual void OnPoolActivated() { }
    
    /// <summary>
    /// Llamado cuando el objeto es devuelto al pool
    /// </summary>
    protected virtual void OnPoolDeactivated() { }
    
    /// <summary>
    /// Llamado cuando el objeto debe reiniciar su estado
    /// </summary>
    protected virtual void OnPoolReset() { }
    
    #endregion
}