using UnityEngine;

/// <summary>
/// Coordinador de estadísticas del jugador que compone diferentes UI components
/// Principio: Single Responsibility Principle (SRP) - Solo coordina/compone
/// Principio: Dependency Inversion Principle (DIP) - Depende de interfaces
/// Patrón: Composite Pattern - Compone diferentes UI elements
/// </summary>
public class PlayerStatDisplayComposer : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private BombStatsUI bombStatsUI;
    [SerializeField] private MovementStatsUI movementStatsUI;
    [SerializeField] private UserInfoUI userInfoUI;
    
    [Header("Dependency Injection")]
    [SerializeField] private bool autoFindPlayer = true;

    private void Start()
    {
        if (autoFindPlayer)
        {
            InitializeWithPlayer();
        }
    }

    /// <summary>
    /// Inicializa automáticamente buscando el Player
    /// </summary>
    private void InitializeWithPlayer()
    {
        Player player = Player.Instance;
        if (player == null)
        {
            Debug.LogWarning("PlayerStatDisplayComposer: Player.Instance not found!");
            return;
        }

        // Obtener componentes y crear adaptadores
        // Intentar primero el nuevo BombSpawnerComposer, luego el antiguo BombSpawner
        BombSpawnerComposer newBombSpawner = player.GetComponentInChildren<BombSpawnerComposer>();
        BombSpawner oldBombSpawner = newBombSpawner == null ? player.GetComponentInChildren<BombSpawner>() : null;
        
        MoveComponent moveComponent = player.GetComponent<MoveComponent>();
        
        IBombStats bombStats = null;
        if (newBombSpawner != null)
        {
            bombStats = new BombSpawnerComposerStatsAdapter(newBombSpawner);
        }
        else if (oldBombSpawner != null)
        {
            bombStats = new BombStatsAdapter(oldBombSpawner);
        }
        IMovementStats movementStats = moveComponent != null ? new MovementStatsAdapter(moveComponent) : null;
        IUserInfo userInfo = new GameUserInfo();

        Initialize(bombStats, movementStats, userInfo);
    }

    /// <summary>
    /// Inicialización manual con inyección de dependencias
    /// </summary>
    /// <param name="bombStats">Proveedor de estadísticas de bomba</param>
    /// <param name="movementStats">Proveedor de estadísticas de movimiento</param>
    /// <param name="userInfo">Proveedor de información de usuario</param>
    public void Initialize(IBombStats bombStats, IMovementStats movementStats, IUserInfo userInfo)
    {
        // Inicializar cada componente UI con sus respectivas dependencias
        if (bombStatsUI != null)
            bombStatsUI.Initialize(bombStats);
            
        if (movementStatsUI != null)
            movementStatsUI.Initialize(movementStats);
            
        if (userInfoUI != null)
            userInfoUI.Initialize(userInfo);
    }
}