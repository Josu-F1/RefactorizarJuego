using System;
using ScoreEntity = CleanArchitecture.Domain.Score.Score;
using CleanArchitecture.Domain.Score;

/// <summary>
/// Adaptador de infraestructura que reutiliza el sistema de puntuación legado (IScoreSystem)
/// para cumplir el contrato de repositorio de dominio.
/// No modifica el sistema antiguo, solo sincroniza estados.
/// </summary>
namespace CleanArchitecture.Infrastructure.Score
{
    public class ScoreSystemRepository : IScoreRepository
    {
        private readonly IScoreSystem legacyScoreSystem;

        public ScoreSystemRepository(IScoreSystem legacyScoreSystem)
        {
            this.legacyScoreSystem = legacyScoreSystem ?? throw new ArgumentNullException(nameof(legacyScoreSystem));
        }

        public ScoreEntity Load(int requiredScore)
        {
            int targetRequired = legacyScoreSystem.RequiredScore > 0
                ? legacyScoreSystem.RequiredScore
                : requiredScore;

            return new ScoreEntity(targetRequired, legacyScoreSystem.CurrentScore);
        }

        public void Save(ScoreEntity score)
        {
            if (score == null) return;

            int delta = score.Current - legacyScoreSystem.CurrentScore;

            // Si el delta es negativo, el sistema legado no soporta decremento, así que reiniciamos y sumamos.
            if (delta < 0)
            {
                legacyScoreSystem.ResetScore();
                if (score.Current > 0)
                {
                    legacyScoreSystem.AddScore(score.Current);
                }
            }
            else if (delta > 0)
            {
                legacyScoreSystem.AddScore(delta);
            }
            // Si delta == 0 no hacemos nada.
        }
    }
}
