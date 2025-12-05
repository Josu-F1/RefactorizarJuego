using UnityEngine;

/// <summary>
/// Composer que integra el sistema de progreso refactorizado
/// Patrón: Facade Pattern - Simplifica el acceso a múltiples subsistemas
/// Principio: Dependency Inversion Principle (DIP) - Usa interfaces
/// Principio: Single Responsibility Principle (SRP) - Solo coordina componentes
/// </summary>
public class ProgressDisplayComposer : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private ProgressDisplayUI displayUI;
    
    private ProgressSystem progressSystem;
    private IUserProgressRepository repository;
    
    void Awake()
    {
        InitializeSystem();
    }
    
    void Start()
    {
        LoadCurrentUser();
    }
    
    private void InitializeSystem()
    {
        // Crear dependencias (aplicando DIP)
        repository = new UserProgressRepository();
        
        // Crear sistema de progreso con observer UI
        progressSystem = new ProgressSystem(repository, displayUI);
        
        Debug.Log("[ProgressDisplayComposer] Sistema de progreso inicializado");
    }
    
    private void LoadCurrentUser()
    {
        // Usar el sistema DataManagerComposer refactorizado
        string currentUser = DataManagerComposer.CurrentUsername;
        
        if (!string.IsNullOrEmpty(currentUser))
        {
            progressSystem.LoadUser(currentUser);
            Debug.Log($"[ProgressDisplayComposer] Usuario cargado: {currentUser}");
        }
        else
        {
            Debug.LogWarning("[ProgressDisplayComposer] No hay usuario actual");
        }
    }
    
    // Métodos públicos para compatibilidad
    public void LoadUser(string userName)
    {
        progressSystem.LoadUser(userName);
    }
    
    public void AddPoints(int points)
    {
        progressSystem.AddPoints(points);
    }
    
    public void NextLevel()
    {
        progressSystem.NextLevel();
    }
    
    public void SaveProgress()
    {
        progressSystem.SaveProgress();
    }
    
    // Propiedades para acceso externo
    public string UserName => progressSystem.UserName;
    public int Level => progressSystem.Level;
    public int Points => progressSystem.Points;
}