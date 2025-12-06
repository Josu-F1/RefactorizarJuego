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
        [SerializeField] private bool autoFindHealth = true;

        private IPlayerService playerService;
        private global::Health playerHealth;

        private void Start()
        {
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            // Obtener PlayerService
            playerService = ServiceLocator.Instance.Get<IPlayerService>();

            if (autoFindHealth)
            {
                FindPlayerHealth();
            }

            if (playerHealth != null)
            {
                SubscribeToHealthEvents();
                UpdateHealthBar(0);
            }
            else
            {
                Debug.LogWarning("[HealthBarPresenter] No se encontró Health component");
            }
        }

        private void FindPlayerHealth()
        {
            // Intentar obtener del PlayerService
            if (playerService != null)
            {
                var playerTransform = playerService.PlayerTransform;
                if (playerTransform != null)
                {
                    playerHealth = playerTransform.GetComponent<global::Health>();
                }
            }

            // Fallback: buscar Player.Instance
            if (playerHealth == null)
            {
                var player = global::Player.Instance;
                if (player != null)
                {
                    playerHealth = player.GetComponent<global::Health>();
                }
            }
        }

        private void SubscribeToHealthEvents()
        {
            if (playerHealth != null)
            {
                playerHealth.OnHealthChanged += UpdateHealthBar;
            }
        }

        private void UpdateHealthBar(float changedAmount)
        {
            if (playerHealth == null || healthBarImage == null) return;
            
            healthBarImage.fillAmount = playerHealth.Percentage;
        }

        private void OnDestroy()
        {
            if (playerHealth != null)
            {
                playerHealth.OnHealthChanged -= UpdateHealthBar;
            }
        }

        /// <summary>
        /// Permite establecer el Health manualmente (útil para testing)
        /// </summary>
        public void SetHealth(global::Health health)
        {
            if (playerHealth != null)
            {
                playerHealth.OnHealthChanged -= UpdateHealthBar;
            }

            playerHealth = health;
            
            if (playerHealth != null)
            {
                SubscribeToHealthEvents();
                UpdateHealthBar(0);
            }
        }
    }
}
