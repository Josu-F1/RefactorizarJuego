using System.Collections.Generic;
using UnityEngine;
using PoolSystem;

/// <summary>
/// OBSOLETO: Usar PoolSystemComposer en su lugar
/// Mantenido solo para compatibilidad temporal
/// </summary>
[System.Obsolete("Use PoolSystemComposer instead. This will be removed in future versions.")]
[System.Serializable]
public class Pool
{
    [SerializeField]
    private PoolObjectType type;
    public PoolObjectType Type => type;
    [SerializeField]
    private GameObject prefab;
    public GameObject Prefab => prefab;
    [SerializeField]
    private int initialCount;
    public int InitialCount => initialCount;
    public GameObject Container { get; set; }
    public Queue<GameObject> Queue { get; set; }
}
/// <summary>
/// OBSOLETO: Usar PoolSystemComposer en su lugar
/// Redirige automáticamente al nuevo sistema si está disponible
/// </summary>
[System.Obsolete("Use PoolSystemComposer instead. This will be removed in future versions.")]
public class PoolManager : MonoBehaviourSingleton<PoolManager>
{
    [SerializeField] private Pool[] pools;
    private Dictionary<PoolObjectType, Pool> poolDictionary;
    
    // Compatibilidad con nuevo sistema
    private bool useNewSystem => PoolSystemComposer.Instance != null;
    protected override void Awake()
    {
        base.Awake();
        poolDictionary = new Dictionary<PoolObjectType, Pool>();
        foreach (var pool in pools)
        {
            pool.Container = new GameObject();
            pool.Container.name = pool.Type.ToString() + " Pool";
            pool.Queue = new Queue<GameObject>();
            poolDictionary[pool.Type] = pool;
            AddToPool(pool.Type, pool.InitialCount);
        }
    }
    public GameObject Get(PoolObjectType type, Vector3 position, Quaternion quaternion)
    {
        // Redirigir al nuevo sistema si está disponible
        if (useNewSystem)
        {
            return PoolSystemComposer.PoolManagerCompat.Get(type, position, quaternion);
        }
        
        // Lógica legacy
        if (!poolDictionary.ContainsKey(type))
        {
            Debug.Log("Pool of type " + type + " does not exist");
            return null;
        }
        Queue<GameObject> queue = poolDictionary[type].Queue;
        if (queue.Count == 0)
        {
            AddToPool(type);
        }
        GameObject g = queue.Dequeue();
        g.transform.position = position;
        g.transform.rotation = quaternion;
        g.SetActive(true);
        return g;
    }
    public GameObject Get(PoolObjectType type, Vector3 position)
    {
        return Get(type, position, Quaternion.identity);
    }
    private void AddToPool(PoolObjectType type, int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject g = Instantiate(poolDictionary[type].Prefab, transform);
            PoolObject poolObject = g.GetComponent<PoolObject>();
            if (poolObject == null)
            {
                Debug.LogWarning("Expecting PoolObject component on " + type);
                continue;
            }
            poolObject.Type = type;
            g.transform.SetParent(poolDictionary[type].Container.transform);
            ReturnToPool(type, g);
        }
    }
    public void ReturnToPool(PoolObjectType type, GameObject g)
    {
        // Redirigir al nuevo sistema si está disponible
        if (useNewSystem)
        {
            PoolSystemComposer.PoolManagerCompat.ReturnToPool(type, g);
            return;
        }
        
        // Lógica legacy
        g.SetActive(false);
        g.transform.SetParent(poolDictionary[type].Container.transform);
        poolDictionary[type].Queue.Enqueue(g);
    }
}
