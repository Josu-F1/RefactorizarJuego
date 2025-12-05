using System;
using ScoreEntity = CleanArchitecture.Domain.Score.Score;
using ScoreSnapshot = CleanArchitecture.Domain.Score.ScoreSnapshot;
using CleanArchitecture.Domain.Score;

namespace CleanArchitecture.Application.Score
{
    /// <summary>
    /// Caso de uso principal para administrar el puntaje desde UI/controladores.
    /// No depende de Unity; orquesta dominio + repositorio.
    /// </summary>
    public class ScoreService
    {
        private readonly IScoreRepository repository;
        private readonly ScoreEntity score;

        public event Action<ScoreSnapshot> OnScoreChanged;

        public ScoreService(IScoreRepository repository, int requiredScore)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));

            // Cargar estado inicial desde infraestructura/legado
            var loaded = this.repository.Load(requiredScore);
            score = loaded ?? new ScoreEntity(requiredScore);

            Notify();
        }

        public ScoreSnapshot GetSnapshot()
        {
            return score.ToSnapshot();
        }

        public void AddScore(int points)
        {
            if (points <= 0) return;

            score.AddPoints(points);
            repository.Save(score);
            Notify();
        }

        public void ResetScore()
        {
            score.Reset();
            repository.Save(score);
            Notify();
        }

        private void Notify()
        {
            OnScoreChanged?.Invoke(score.ToSnapshot());
        }
    }
}
