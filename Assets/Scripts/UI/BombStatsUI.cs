using TMPro;
using UnityEngine;
using System;

/// <summary>
/// Componente UI responsable ÚNICAMENTE de mostrar estadísticas de bomba
/// Principio: Single Responsibility Principle (SRP)
/// </summary>
public class BombStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bombLimitText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI lengthText;
    
    private IBombStats bombStats;

    public void Initialize(IBombStats bombStats)
    {
        this.bombStats = bombStats;
        
        if (bombStats != null)
        {
            bombStats.OnBombLimitChanged += UpdateBombLimitText;
            bombStats.OnDamageChanged += UpdateDamageText;
            bombStats.OnLengthChanged += UpdateLengthText;
            
            // Actualizar UI inicial
            UpdateAll();
        }
    }

    private void UpdateBombLimitText()
    {
        if (bombLimitText != null && bombStats != null)
            bombLimitText.text = bombStats.BombLimit.ToString();
    }

    private void UpdateDamageText()
    {
        if (damageText != null && bombStats != null)
            damageText.text = bombStats.Damage.ToString("F0");
    }

    private void UpdateLengthText()
    {
        if (lengthText != null && bombStats != null)
            lengthText.text = bombStats.Length.ToString();
    }

    private void UpdateAll()
    {
        UpdateBombLimitText();
        UpdateDamageText();
        UpdateLengthText();
    }

    private void OnDestroy()
    {
        if (bombStats != null)
        {
            bombStats.OnBombLimitChanged -= UpdateBombLimitText;
            bombStats.OnDamageChanged -= UpdateDamageText;
            bombStats.OnLengthChanged -= UpdateLengthText;
        }
    }
}