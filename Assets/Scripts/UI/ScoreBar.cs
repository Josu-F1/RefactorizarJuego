using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.DependencyInjection;

/// <summary>
/// Legacy ScoreBar - Use ScoreBarPresenter from Clean Architecture instead
/// </summary>
[System.Obsolete("Use ScoreBarPresenter from CleanArchitecture.Presentation.Presenters instead")]
public class ScoreBar : MonoBehaviour
{
    private GameManager gameManager;
    private IScoreService scoreService;
    private Image scoreBar;
    
    private void Awake()
    {
        // Check if ScoreBarPresenter exists
        var presenter = GetComponent<CleanArchitecture.Presentation.Presenters.ScoreBarPresenter>();
        if (presenter != null)
        {
            // Clean Architecture presenter exists, disable this legacy component
            enabled = false;
            return;
        }

        scoreBar = GetComponent<Image>();
    }
    
    private void Start()
    {
        if (!enabled) return;

        // Try Clean Architecture first (silencioso si no está disponible)
        scoreService = ServiceLocator.Instance.GetSilent<IScoreService>();
        if (scoreService != null)
        {
            scoreService.OnScoreChanged += OnScoreChanged;
            UpdateScoreBar();
        }
        else
        {
            // Fallback to legacy
            gameManager = GameManager.Instance;
            if (gameManager != null)
            {
                gameManager.OnScoreUpdated += UpdateScoreBar;
                UpdateScoreBar();
            }
        }
    }

    private void OnScoreChanged(int newScore)
    {
        UpdateScoreBar();
    }
    
    private void UpdateScoreBar()
    {
        if (scoreService != null)
        {
            scoreBar.fillAmount = scoreService.Progress;
        }
        else if (gameManager != null)
        {
            scoreBar.fillAmount = gameManager.Progress;
        }
    }
    
    private void OnDestroy()
    {
        if (scoreService != null)
            scoreService.OnScoreChanged -= OnScoreChanged;
        if (gameManager != null)
            gameManager.OnScoreUpdated -= UpdateScoreBar;
    }
}
