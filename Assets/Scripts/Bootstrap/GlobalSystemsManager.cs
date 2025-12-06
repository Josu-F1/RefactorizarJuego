using UnityEngine;

/// <summary>
/// Gestor de sistemas globales que deben persistir entre escenas
/// Crea automáticamente los sistemas necesarios si no existen
/// </summary>
[DefaultExecutionOrder(-200)]
public class GlobalSystemsManager : MonoBehaviour
{
    private static GlobalSystemsManager instance;
    
    [Header("Auto-Create Systems")]
    [SerializeField] private bool autoCreateCharacterSystem = true;
    [SerializeField] private bool autoInitializeDataSystem = true;
    
    private void Awake()
    {
        // Singleton pattern
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
        
        InitializeGlobalSystems();
    }
    
    private void InitializeGlobalSystems()
    {
        Debug.Log("[GlobalSystemsManager] Inicializando sistemas globales...");
        
        // Crear CharacterSystemComposer si no existe
        if (autoCreateCharacterSystem && CharacterSystemComposer.Instance == null)
        {
            GameObject composerObj = new GameObject("[CharacterSystemComposer]");
            composerObj.transform.SetParent(transform);
            composerObj.AddComponent<CharacterSystemComposer>();
            Debug.Log("[GlobalSystemsManager] ✅ CharacterSystemComposer creado");
        }
        
        // Inicializar DataManagerComposer (es estático, solo se inicializa)
        if (autoInitializeDataSystem)
        {
            DataManagerComposer.Initialize();
            Debug.Log("[GlobalSystemsManager] ✅ DataManagerComposer inicializado");
        }
        
        Debug.Log("[GlobalSystemsManager] ✅ Todos los sistemas globales inicializados");
    }
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void CreateGlobalSystems()
    {
        if (instance == null)
        {
            GameObject managerObj = new GameObject("[GlobalSystemsManager]");
            managerObj.AddComponent<GlobalSystemsManager>();
            Debug.Log("[GlobalSystemsManager] Bootstrap automático ejecutado");
        }
    }
}
