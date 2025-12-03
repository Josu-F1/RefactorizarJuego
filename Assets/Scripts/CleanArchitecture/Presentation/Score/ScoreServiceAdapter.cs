using System;
using UnityEngine;
using CleanArchitecture.Application.Score;
using CleanArchitecture.Domain.Score;
using CleanArchitecture.Infrastructure.Score;

namespace CleanArchitecture.Presentation.Score
{
    /// <summary>
    /// MonoBehaviour conector para exponer ScoreService al mundo Unity.
    /// Permite reutilizar IScoreSystem legado sin modificarlo.
    /// </summary>
    public class ScoreServiceAdapter : MonoBehaviour
    {
        [SerializeField] private int requiredScore = 200;

        // Si se marca, se crea un ScoreSystem propio (no toca escenas existentes mientras no se añada este componente).
        [SerializeField] private bool createLocalLegacyScoreSystem = false;

        private ScoreService scoreService;
        private IScoreSystem legacyScoreSystem;

        public event Action<ScoreSnapshot> OnScoreChanged;

        public ScoreSnapshot Snapshot => scoreService?.GetSnapshot() ?? default;

        /// <summary>
        /// Inicializa el adaptador con un sistema legado existente (ej: ScoreSystem usado por GameManagerComposer).
        /// </summary>
        public void Initialize(IScoreSystem legacySystem)
        {
            legacyScoreSystem = legacySystem;
            BuildServiceIfPossible();
        }

        private void Awake()
        {
            // Opción para pruebas/instalación incremental: crear un sistema de puntaje local aislado.
            if (createLocalLegacyScoreSystem)
            {
                legacyScoreSystem = new ScoreSystem(requiredScore);
                BuildServiceIfPossible();
            }
        }

        public void AddScore(int points)
        {
            scoreService?.AddScore(points);
        }

        public void ResetScore()
        {
            scoreService?.ResetScore();
        }

        private void BuildServiceIfPossible()
        {
            if (legacyScoreSystem == null || scoreService != null)
            {
                return;
            }

            var repository = new ScoreSystemRepository(legacyScoreSystem);
            scoreService = new ScoreService(repository, requiredScore);
            scoreService.OnScoreChanged += snapshot => OnScoreChanged?.Invoke(snapshot);
        }
    }
}
