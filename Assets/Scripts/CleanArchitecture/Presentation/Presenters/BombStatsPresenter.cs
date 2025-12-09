using UnityEngine;
using TMPro;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.DependencyInjection;

namespace CleanArchitecture.Presentation.Presenters
{
    #pragma warning disable CS0618 // Type or member is obsolete
    /// <summary>
    /// Presenter para estadísticas de bomba - Clean Architecture
    /// Sigue el patrón MVP (Model-View-Presenter)
    /// Reemplaza BombStatsUI con Clean Architecture
    /// </summary>
    public class BombStatsPresenter : MonoBehaviour
    {
        [Header("View Components")]
        [SerializeField] private TextMeshProUGUI bombLimitText;
        [SerializeField] private TextMeshProUGUI damageText;
        [SerializeField] private TextMeshProUGUI lengthText;

        [Header("Configuration")]
        [SerializeField] private bool autoFindBombStats = true;
        [SerializeField] private string bombLimitFormat = "{0}";
        [SerializeField] private string damageFormat = "{0:F0}";
        [SerializeField] private string lengthFormat = "{0}";

        private IPlayerService playerService;
        private IBombStats bombStats;

        private void Start()
        {
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            playerService = ServiceLocator.Instance.Get<IPlayerService>();

            if (autoFindBombStats)
            {
                FindBombStats();
            }

            if (bombStats != null)
            {
                SubscribeToEvents();
                UpdateAll();
            }
            else
            {
                Debug.LogWarning("[BombStatsPresenter] No se encontró IBombStats component");
            }
        }

        private void FindBombStats()
        {
            // Intentar obtener del PlayerService
            if (playerService != null)
            {
                var playerTransform = playerService.PlayerTransform;
                if (playerTransform != null)
                {
                    // Buscar BombSpawnerComposer primero
                    var newBombSpawner = playerTransform.GetComponentInChildren<BombSpawnerComposer>();
                    if (newBombSpawner != null)
                    {
                        bombStats = new BombSpawnerComposerStatsAdapter(newBombSpawner);
                        return;
                    }

                    // Fallback a BombSpawner antiguo
                    var oldBombSpawner = playerTransform.GetComponentInChildren<BombSpawner>();
                    if (oldBombSpawner != null)
                    {
                        bombStats = new BombStatsAdapter(oldBombSpawner);
                        return;
                    }
                }
            }

            // Fallback: buscar Player.Instance
            var player = global::Player.Instance;
            if (player != null)
            {
                var newBombSpawner = player.GetComponentInChildren<BombSpawnerComposer>();
                if (newBombSpawner != null)
                {
                    bombStats = new BombSpawnerComposerStatsAdapter(newBombSpawner);
                }
                else
                {
                    var oldBombSpawner = player.GetComponentInChildren<BombSpawner>();
                    if (oldBombSpawner != null)
                    {
                        bombStats = new BombStatsAdapter(oldBombSpawner);
                    }
                }
            }
        }

        private void SubscribeToEvents()
        {
            if (bombStats != null)
            {
                bombStats.OnBombLimitChanged += UpdateBombLimitText;
                bombStats.OnDamageChanged += UpdateDamageText;
                bombStats.OnLengthChanged += UpdateLengthText;
            }
        }

        private void UpdateBombLimitText()
        {
            if (bombLimitText != null && bombStats != null)
            {
                bombLimitText.text = string.Format(bombLimitFormat, bombStats.BombLimit);
            }
        }

        private void UpdateDamageText()
        {
            if (damageText != null && bombStats != null)
            {
                damageText.text = string.Format(damageFormat, bombStats.Damage);
            }
        }

        private void UpdateLengthText()
        {
            if (lengthText != null && bombStats != null)
            {
                lengthText.text = string.Format(lengthFormat, bombStats.Length);
            }
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

        /// <summary>
        /// Permite establecer IBombStats manualmente (útil para testing)
        /// </summary>
        public void SetBombStats(IBombStats stats)
        {
            if (bombStats != null)
            {
                bombStats.OnBombLimitChanged -= UpdateBombLimitText;
                bombStats.OnDamageChanged -= UpdateDamageText;
                bombStats.OnLengthChanged -= UpdateLengthText;
            }

            bombStats = stats;

            if (bombStats != null)
            {
                SubscribeToEvents();
                UpdateAll();
            }
        }
    }
}
