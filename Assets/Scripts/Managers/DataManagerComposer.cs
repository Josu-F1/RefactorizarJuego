/// <summary>
/// Facade para el sistema de datos refactorizado usando Repository Pattern
/// Principio: Single Responsibility Principle (SRP) - Solo coordina repositorios
/// Principio: Dependency Inversion Principle (DIP) - Depende de interfaces
/// Patrón: Facade Pattern - Simplifica el acceso a múltiples repositorios
/// Patrón: Repository Pattern - Abstrae la persistencia
/// </summary>
public static class DataManagerComposer
{
    private static IUserRepository userRepository;
    private static IProgressRepository progressRepository;
    private static ISessionManager sessionManager;
    private static IPersistenceProvider persistenceProvider;
    
    // Inicialización lazy
    private static bool isInitialized = false;
    
    private static void EnsureInitialized()
    {
        if (!isInitialized)
        {
            Initialize();
        }
    }
    
    /// <summary>
    /// Inicializa el sistema con implementaciones por defecto
    /// </summary>
    public static void Initialize()
    {
        // Configurar provider de persistencia
        persistenceProvider = new PlayerPrefsPersistenceProvider();
        
        // Configurar repositorios
        userRepository = new UserRepository(persistenceProvider);
        progressRepository = new ProgressRepository(persistenceProvider);
        sessionManager = new SessionManager();
        
        isInitialized = true;
        UnityEngine.Debug.Log("DataManagerComposer: System initialized");
    }
    
    /// <summary>
    /// Permite inyectar dependencias personalizadas (útil para testing)
    /// </summary>
    public static void Initialize(IUserRepository userRepo, IProgressRepository progressRepo, 
                                 ISessionManager sessionMgr, IPersistenceProvider persistenceProvider)
    {
        userRepository = userRepo;
        progressRepository = progressRepo;
        sessionManager = sessionMgr;
        DataManagerComposer.persistenceProvider = persistenceProvider;
        
        isInitialized = true;
        UnityEngine.Debug.Log("DataManagerComposer: System initialized with custom dependencies");
    }
    
    // API pública para compatibilidad con el DataManager original
    public static string CurrentUsername
    {
        get
        {
            EnsureInitialized();
            return sessionManager.CurrentUsername;
        }
        set
        {
            EnsureInitialized();
            sessionManager.CurrentUsername = value;
        }
    }
    
    public static void SaveUsername(string username)
    {
        EnsureInitialized();
        userRepository.CreateUser(username);
        userRepository.AddRecentUsername(username);
        sessionManager.StartSession(username);
    }
    
    public static void SavePlayerLevel(string username, int level)
    {
        EnsureInitialized();
        UnityEngine.Debug.Log($"[DataManagerComposer] Guardando nivel {level} para usuario {username}");
        progressRepository.SavePlayerLevel(username, level);
        
        // Verificación inmediata
        int savedLevel = progressRepository.GetPlayerLevel(username);
        UnityEngine.Debug.Log($"[DataManagerComposer] Verificación - Nivel guardado: {savedLevel}");
        
        if (savedLevel == level)
        {
            UnityEngine.Debug.Log($"[DataManagerComposer] ✅ Guardado exitoso!");
        }
        else
        {
            UnityEngine.Debug.LogError($"[DataManagerComposer] ❌ Error en guardado! Esperado: {level}, Obtenido: {savedLevel}");
        }
    }
    
    public static bool UsernameExists(string username)
    {
        EnsureInitialized();
        return userRepository.UserExists(username);
    }
    
    public static int GetPlayerLevel(string username)
    {
        EnsureInitialized();
        return progressRepository.GetPlayerLevel(username);
    }
    
    // APIs adicionales del nuevo sistema
    public static bool HasActiveSession()
    {
        EnsureInitialized();
        return sessionManager.HasActiveSession;
    }
    
    public static void StartSession(string username)
    {
        EnsureInitialized();
        if (userRepository.ValidateUser(username))
        {
            sessionManager.StartSession(username);
        }
        else
        {
            UnityEngine.Debug.LogWarning($"DataManagerComposer: Cannot start session for invalid user '{username}'");
        }
    }
    
    public static void EndSession()
    {
        EnsureInitialized();
        sessionManager.EndSession();
    }
    
    public static void ResetUserProgress(string username)
    {
        EnsureInitialized();
        progressRepository.ResetProgress(username);
    }
    
    // Métodos para usuarios recientes
    public static string[] GetRecentUsernames(int maxCount = 3)
    {
        EnsureInitialized();
        return userRepository.GetRecentUsernames(maxCount);
    }
    
    public static void AddRecentUsername(string username)
    {
        EnsureInitialized();
        userRepository.AddRecentUsername(username);
    }
    
    // Acceso a repositorios para funcionalidades avanzadas
    public static IUserRepository GetUserRepository()
    {
        EnsureInitialized();
        return userRepository;
    }
    
    public static IProgressRepository GetProgressRepository()
    {
        EnsureInitialized();
        return progressRepository;
    }
    
    public static ISessionManager GetSessionManager()
    {
        EnsureInitialized();
        return sessionManager;
    }
}