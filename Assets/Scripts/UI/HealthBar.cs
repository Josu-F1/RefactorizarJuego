using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Legacy HealthBar - Use HealthBarPresenter from Clean Architecture instead
/// </summary>
[System.Obsolete("Use HealthBarPresenter from CleanArchitecture.Presentation.Presenters instead")]
public class HealthBar : MonoBehaviour
{
    [Header("Optional - Auto GetComponentInParent")]
    [SerializeField] private Health health;
    private Image healthBar;
    private void Awake()
    {
        // Check if HealthBarPresenter exists
        var presenter = GetComponent<CleanArchitecture.Presentation.Presenters.HealthBarPresenter>();
        if (presenter != null)
        {
            // Clean Architecture presenter exists, disable this legacy component
            enabled = false;
            return;
        }

        healthBar = GetComponent<Image>();
        health = GetComponentInParent<Health>();
    }
    private void Start()
    {
        if (!enabled) return;
        health.OnHealthChanged += UpdateHealthBar;
        UpdateHealthBar(0);
    }
    private void UpdateHealthBar(float changedAmount)
    {
        if (health == null) return;
        healthBar.fillAmount = health.Percentage;
    }
    private void OnDestroy()
    {
        if (health != null)
            health.OnHealthChanged -= UpdateHealthBar;
    }
}
