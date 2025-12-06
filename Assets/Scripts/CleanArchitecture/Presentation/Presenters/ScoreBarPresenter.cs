using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.DependencyInjection;

namespace CleanArchitecture.Presentation.Presenters
{
    /// <summary>
    /// Presenter para la barra y texto de score - Clean Architecture
    /// Sigue el patrón MVP (Model-View-Presenter)
    /// </summary>
    public class ScoreBarPresenter : MonoBehaviour
    {
        [Header("View Components")]
        [SerializeField] private Image scoreBarImage;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI goalText;

        [Header("Configuration")]
        [SerializeField] private bool showProgress = true;
        [SerializeField] private string scoreFormat = "Score: {0}";
        [SerializeField] private string goalFormat = "Goal: {0}";

        private IScoreService scoreService;

        private void Start()
        {
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            // Obtener ScoreService del ServiceLocator
            scoreService = ServiceLocator.Instance.Get<IScoreService>();

            if (scoreService != null)
            {
                SubscribeToEvents();
                UpdateUI();
            }
            else
            {
                Debug.LogError("[ScoreBarPresenter] ScoreService no encontrado en ServiceLocator");
            }
        }

        private void SubscribeToEvents()
        {
            if (scoreService != null)
            {
                scoreService.OnScoreChanged += OnScoreChanged;
            }
        }

        private void OnScoreChanged(int newScore)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (scoreService == null) return;

            // Actualizar barra de progreso
            if (scoreBarImage != null && showProgress)
            {
                scoreBarImage.fillAmount = scoreService.Progress;
            }

            // Actualizar texto de score
            if (scoreText != null)
            {
                scoreText.text = string.Format(scoreFormat, scoreService.CurrentScore);
            }

            // Actualizar texto de objetivo
            if (goalText != null)
            {
                goalText.text = string.Format(goalFormat, scoreService.RequiredScore);
            }
        }

        private void OnDestroy()
        {
            if (scoreService != null)
            {
                scoreService.OnScoreChanged -= OnScoreChanged;
            }
        }

        /// <summary>
        /// Permite cambiar el formato del texto en runtime
        /// </summary>
        public void SetScoreFormat(string format)
        {
            scoreFormat = format;
            UpdateUI();
        }

        /// <summary>
        /// Permite cambiar el formato del objetivo en runtime
        /// </summary>
        public void SetGoalFormat(string format)
        {
            goalFormat = format;
            UpdateUI();
        }
    }
}
