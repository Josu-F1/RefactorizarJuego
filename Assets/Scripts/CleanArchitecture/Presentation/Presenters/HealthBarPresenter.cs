using UnityEngine;
using UnityEngine.UI;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.DependencyInjection;

namespace CleanArchitecture.Presentation.Presenters
{
    /// <summary>
    /// Presenter para la barra de vida - Clean Architecture
    /// Sigue el patrón MVP (Model-View-Presenter)
    /// </summary>
    #pragma warning disable CS0618 // Type or member is obsolete
    public class HealthBarPresenter : MonoBehaviour
    {
        [Header("View Components")]
        [SerializeField] private Image healthBarImage;
        
        [Header("Configuration")]
        [SerializeField] private bool autoFind = true;

        private IPlayerService playerService;
        private ICharacterController characterController;

        private void Start()
        {
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            // Obtener PlayerService
            playerService = ServiceLocator.Instance.Get<IPlayerService>();

            if (autoFind)
            {
                FindPlayerCharacter();
            }

            if (characterController != null)
            {
                SubscribeToHealthEvents();
                UpdateHealthBar(0);
            }
            else
            {
                Debug.LogWarning("[HealthBarPresenter] No se encontró CharacterController");
            }
        }

        private void FindPlayerCharacter()
        {
            // Usar CharacterSystemComposer (Clean Architecture)
            var characterSystem = CharacterSystemComposer.Instance;
            if (characterSystem != null)
            {
                var player = global::Player.Instance;
                if (player != null)
                {
                    characterController = characterSystem.GetController(player.gameObject);
                }
            }
            
            if (characterController == null)
            {
                Debug.LogError("[HealthBarPresenter] ❌ CharacterSystemComposer no encontrado!");
            }
        }

        private void SubscribeToHealthEvents()
        {
            // Actualizar periódicamente (TODO: usar EventBus cuando esté disponible)
            InvokeRepeating(nameof(UpdateHealthBarPeriodic), 0f, 0.1f);
        }

        private void UpdateHealthBarPeriodic()
        {
            // TODO: Implementar con EventBus (CharacterDamagedEvent, CharacterHealedEvent)
            // Por ahora, mantener fillAmount estático
            if (healthBarImage != null && characterController != null)
            {
                // healthBarImage.fillAmount se actualizará desde EventBus
            }
        }

        private void UpdateHealthBar(float percentage)
        {
            if (healthBarImage == null) return;
            healthBarImage.fillAmount = percentage;
        }

        private void OnDestroy()
        {
            CancelInvoke(nameof(UpdateHealthBarPeriodic));
        }

        /// <summary>
        /// Permite establecer el CharacterController manualmente (útil para testing)
        /// </summary>
        public void SetCharacterController(ICharacterController controller)
        {
            characterController = controller;
            if (characterController != null)
            {
                SubscribeToHealthEvents();
            }
        }
    }
}
