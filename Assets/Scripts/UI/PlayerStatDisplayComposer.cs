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
        BombSpawner bombSpawner = player.GetComponentInChildren<BombSpawner>();
        MoveComponent moveComponent = player.GetComponent<MoveComponent>();
        
        IBombStats bombStats = bombSpawner != null ? new BombStatsAdapter(bombSpawner) : null;
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