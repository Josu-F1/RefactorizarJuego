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
        [SerializeField] private bool showEnemyCount = true;
        [SerializeField] private string scoreFormat = "Score: {0}";
        [SerializeField] private string goalFormat = "Goal: {0}";
        [SerializeField] private string enemyFormat = "Enemigos: {0}/{1}";

        private IScoreService scoreService;
        private GameManager gameManager;

        private void Start()
        {
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            // Obtener ScoreService del ServiceLocator
            scoreService = ServiceLocator.Instance.Get<IScoreService>();
            
            // Obtener GameManager para conteo de enemigos
            gameManager = GameManager.Instance;

            if (scoreService != null || gameManager != null)
            {
                SubscribeToEvents();
                UpdateUI();
            }
            else
            {
                Debug.LogError("[ScoreBarPresenter] ScoreService y GameManager no encontrados");
            }
        }

        private void SubscribeToEvents()
        {
            if (scoreService != null)
            {
                scoreService.OnScoreChanged += OnScoreChangedFromService;
            }
            
            if (gameManager != null)
            {
                gameManager.OnScoreUpdated += OnScoreChangedFromGameManager;
            }
        }
        
        private void OnScoreChangedFromService(int newScore)
        {
            UpdateUI();
        }
        
        private void OnScoreChangedFromGameManager()
        {
            UpdateUI();
        }
        
        private void UpdateUI()
        {
            // Priorizar GameManager si está disponible
            if (gameManager != null)
            {
                UpdateUIFromGameManager();
            }
            else if (scoreService != null)
            {
                UpdateUIFromScoreService();
            }
        }
        
        private void UpdateUIFromGameManager()
        {
            // Actualizar barra de progreso basada en enemigos muertos
            if (scoreBarImage != null && showProgress)
            {
                float progress = gameManager.EnemyProgress;
                scoreBarImage.fillAmount = progress;
                Debug.LogWarning($"[ScoreBarPresenter] 📊 PROGRESO ACTUALIZADO: {progress:P0} ({gameManager.EnemiesKilled}/{gameManager.TotalEnemies})");
            }

            // Mostrar conteo de enemigos si está habilitado
            if (scoreText != null)
            {
                if (showEnemyCount)
                {
                    scoreText.text = string.Format(enemyFormat, 
                        gameManager.EnemiesKilled, 
                        gameManager.TotalEnemies);
                }
                else
                {
                    scoreText.text = string.Format(scoreFormat, gameManager.CurrentScore);
                }
            }

            // Actualizar texto de objetivo
            if (goalText != null)
            {
                if (showEnemyCount)
                {
                    goalText.text = $"Meta: {gameManager.TotalEnemies} enemigos";
                }
                else
                {
                    goalText.text = string.Format(goalFormat, gameManager.RequiredScore);
                }
            }
        }
        
        private void UpdateUIFromScoreService()
        {
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
                scoreService.OnScoreChanged -= OnScoreChangedFromService;
            }
            
            if (gameManager != null)
            {
                gameManager.OnScoreUpdated -= OnScoreChangedFromGameManager;
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
