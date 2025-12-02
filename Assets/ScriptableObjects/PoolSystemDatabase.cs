using UnityEngine;
using PoolSystem.Models;

/// <summary>
/// Configuración de la base de datos del Pool System
/// Crear mediante: Assets > Create > Pool System > Pool Database
/// </summary>
[CreateAssetMenu(fileName = "PoolSystemDatabase", menuName = "Pool System/Pool Database")]
public class PoolSystemDatabase : ScriptableObject
{
    [Header("Pool Configurations")]
    [SerializeField] private PoolConfiguration[] poolConfigurations = new PoolConfiguration[]
    {
        // Configuraciones predeterminadas basadas en PoolObjectType
    };
    
    [Header("System Settings")]
    [SerializeField] private bool enableDebugLogging = false;
    [SerializeField] private PoolSystem.Factories.PoolStrategyFactory.StrategyType defaultStrategy = 
        PoolSystem.Factories.PoolStrategyFactory.StrategyType.Standard;
    [SerializeField] private int defaultPrewarmCount = 5;
    
    public PoolConfiguration[] PoolConfigurations => poolConfigurations;
    public bool EnableDebugLogging => enableDebugLogging;
    public PoolSystem.Factories.PoolStrategyFactory.StrategyType DefaultStrategy => defaultStrategy;
    public int DefaultPrewarmCount => defaultPrewarmCount;
    
    private void OnValidate()
    {
        // Validar configuraciones
        if (poolConfigurations != null)
        {
            for (int i = 0; i < poolConfigurations.Length; i++)
            {
                var config = poolConfigurations[i];
                if (config != null && config.Prefab == null)
                {
                    Debug.LogWarning($"[PoolSystemDatabase] Pool configuration {i} for {config.Type} has null prefab");
                }
            }
        }
    }
    
    /// <summary>
    /// Inicializa configuraciones predeterminadas basadas en PoolObjectType
    /// </summary>
    [ContextMenu("Initialize Default Configurations")]
    public void InitializeDefaultConfigurations()
    {
        var poolTypes = System.Enum.GetValues(typeof(PoolObjectType));
        poolConfigurations = new PoolConfiguration[poolTypes.Length];
        
        for (int i = 0; i < poolTypes.Length; i++)
        {
            var poolType = (PoolObjectType)poolTypes.GetValue(i);
            poolConfigurations[i] = new PoolConfiguration(poolType, null, 5, 20);
        }
        
        Debug.Log($"[PoolSystemDatabase] Initialized {poolConfigurations.Length} default configurations");
        
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
    
    /// <summary>
    /// Obtiene configuración para un tipo específico de pool
    /// </summary>
    public PoolConfiguration GetConfigurationForType(PoolObjectType type)
    {
        if (poolConfigurations != null)
        {
            foreach (var config in poolConfigurations)
            {
                if (config != null && config.Type == type)
                {
                    return config;
                }
            }
        }
        return null;
    }
}