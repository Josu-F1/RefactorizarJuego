using UnityEngine;
using PoolSystem;

/// <summary>
/// OBSOLETO: Usar PoolSystemComposer.PoolComponent en su lugar
/// Mantenido solo para compatibilidad temporal
/// </summary>
[System.Obsolete("Use PoolSystemComposer.PoolComponent instead. This will be removed in future versions.")]
[System.Serializable]
public class ObjectPool
{
    [SerializeField] private PoolObjectType type;
    [SerializeField] private Color color = Color.white;
    public Color Color { get => color; set => color = value; }

    public GameObject Get(Vector3 position, Quaternion quaternion)
    {
        // Prioridad 1: Clean Architecture
        var legacyAdapter = CleanArchitecture.Presentation.Adapters.LegacyPoolAdapter.Instance;
        if (legacyAdapter != null)
        {
            GameObject g = legacyAdapter.Get(type, position, quaternion);
            if (g != null)
            {
                var sr = g.GetComponentInChildren<SpriteRenderer>();
                if (sr != null) sr.color = color;
                return g;
            }
        }
        
        // Fallback al sistema legacy
        GameObject legacyObj = PoolManager.Instance?.Get(type, position, quaternion);
        var legacySr = legacyObj?.GetComponentInChildren<SpriteRenderer>();
        if (legacySr != null) legacySr.color = color;
        return legacyObj;
    }
    public GameObject Get(Vector3 position)
    {
        return Get(position, Quaternion.identity);
    }
    public void Spawn(Vector3 position)
    {
        Get(position, Quaternion.identity);
    }
}
