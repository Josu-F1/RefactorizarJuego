#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ✅ Migrado a Clean Architecture - Usa CharacterSystemComposer
/// </summary>
public class PlayerHealthBar : MonoBehaviour
{
    private ICharacterController characterController;
    private Image healthBar;
    private global::Health health; // transitional: leer porcentaje directo
    
    private void Awake()
    {
        healthBar = GetComponent<Image>();
    }
    
    private void Start()
    {
        Player player = Player.Instance;
        if (player == null) return;

        // Fallback legacy: obtener componente Health y suscribirse
        health = player.GetComponent<global::Health>();
        if (health != null)
        {
            health.OnHealthChanged += OnHealthChanged;
        }
        
        // Usar CharacterSystemComposer
        var characterSystem = CharacterSystemComposer.Instance;
        if (characterSystem != null)
        {
            characterController = characterSystem.GetController(player.gameObject);
            if (characterController != null)
            {
                // TODO: Suscribirse a EventBus (CharacterDamagedEvent, CharacterHealedEvent)
                InvokeRepeating(nameof(UpdateHealthBar), 0f, 0.1f);
            }
        }
    }
    
    private void UpdateHealthBar()
    {
        // TODO: Implementar con EventBus
        // Por ahora usar Health legacy como fuente
        if (healthBar == null) return;

        if (health != null)
        {
            healthBar.fillAmount = health.Percentage;
            return;
        }

        // Si no hay Health, mantener sin cambios
    }
    
    private void OnDestroy()
    {
        if (health != null)
        {
            health.OnHealthChanged -= OnHealthChanged;
        }
        CancelInvoke(nameof(UpdateHealthBar));
    }

    private void OnHealthChanged(float delta)
    {
        if (healthBar != null && health != null)
        {
            healthBar.fillAmount = health.Percentage;
        }
    }
}

