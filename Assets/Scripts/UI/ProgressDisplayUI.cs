using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Componente UI que observa y muestra el progreso del usuario
/// Patrón: Observer Pattern - Observa cambios en el progreso
/// Principio: Single Responsibility Principle (SRP) - Solo actualiza UI
/// Principio: Dependency Inversion Principle (DIP) - Depende de interfaces
/// </summary>
public class ProgressDisplayUI : MonoBehaviour, IProgressObserver
{
    [Header("UI Components")]
    [SerializeField] private Text userNameText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text pointsText;
    
    private UserProgress currentProgress;
    
    public void OnProgressChanged(UserProgress progress)
    {
        currentProgress = progress;
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        if (currentProgress == null) return;
        
        if (userNameText != null)
            userNameText.text = $"Usuario: {currentProgress.userName}";
            
        if (levelText != null)
            levelText.text = $"Nivel: {currentProgress.level}";
            
        if (pointsText != null)
            pointsText.text = $"Puntos: {currentProgress.points}";
    }
    
    /// <summary>
    /// Actualizar UI manualmente si es necesario
    /// </summary>
    public void RefreshUI()
    {
        UpdateUI();
    }
}