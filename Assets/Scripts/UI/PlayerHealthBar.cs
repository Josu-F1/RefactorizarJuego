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
    
    private void Awake()
    {
        healthBar = GetComponent<Image>();
    }
    
    private void Start()
    {
        Player player = Player.Instance;
        if (player == null) return;
        
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
        // Por ahora mantener fillAmount estático
        if (healthBar != null && characterController != null)
        {
            // healthBar.fillAmount se actualizará desde EventBus
        }
    }
    
    private void OnDestroy()
    {
        CancelInvoke(nameof(UpdateHealthBar));
    }
}

