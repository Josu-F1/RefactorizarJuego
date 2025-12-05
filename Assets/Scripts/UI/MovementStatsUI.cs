using TMPro;
using UnityEngine;

/// <summary>
/// Componente UI responsable ÚNICAMENTE de mostrar estadísticas de movimiento
/// Principio: Single Responsibility Principle (SRP)
/// </summary>
public class MovementStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moveSpeedText;
    
    private IMovementStats movementStats;

    public void Initialize(IMovementStats movementStats)
    {
        this.movementStats = movementStats;
        
        if (movementStats != null)
        {
            movementStats.OnMoveSpeedChanged += UpdateMoveSpeedText;
            UpdateMoveSpeedText(); // Actualizar UI inicial
        }
    }

    private void UpdateMoveSpeedText()
    {
        if (moveSpeedText != null && movementStats != null)
            moveSpeedText.text = (movementStats.MoveSpeed * 100).ToString();
    }

    private void OnDestroy()
    {
        if (movementStats != null)
        {
            movementStats.OnMoveSpeedChanged -= UpdateMoveSpeedText;
        }
    }
}