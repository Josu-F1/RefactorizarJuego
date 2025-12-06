using UnityEngine;

/// <summary>
/// Singleton pattern mejorado para MonoBehaviour
/// Asegura una sola instancia y permite encontrarla o crearla dinámicamente
/// </summary>
public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    
    public static T Instance
    {
        get
        {
            // Si ya existe, retornar
            if (instance != null)
                return instance;
            
            // Buscar en la escena
            instance = FindObjectOfType<T>();
            
            // Si encontramos una instancia, retornarla
            if (instance != null)
            {
                return instance;
            }
            
            // Si no existe, crear una nueva (solo en modo de juego)
            if (Application.isPlaying)
            {
                Debug.LogWarning($"[MonoBehaviourSingleton] No se encontró instancia de {typeof(T).Name}, creando una nueva automáticamente");
                GameObject singletonObj = new GameObject($"[{typeof(T).Name}]");
                instance = singletonObj.AddComponent<T>();
                DontDestroyOnLoad(singletonObj);
            }
            
            return instance;
        }
        private set => instance = value;
    }
    
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<T>();
        }
        else if (instance != this)
        {
            Debug.LogWarning($"[MonoBehaviourSingleton] Destruyendo instancia duplicada de {typeof(T).Name}");
            Destroy(gameObject);
        }
    }
    
    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
