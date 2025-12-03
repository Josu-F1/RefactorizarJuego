using System;

namespace CleanArchitecture.Domain.Score
{
    /// <summary>
    /// Entidad de dominio para puntaje. No depende de Unity ni de infraestructura.
    /// </summary>
    public class Score
    {
        public int Current { get; private set; }
        public int Required { get; private set; }

        public float Progress => Required > 0 ? (float)Current / Required : 0f;
        public bool GoalReached => Current >= Required;

        public Score(int required, int initialScore = 0)
        {
            if (required < 0) throw new ArgumentOutOfRangeException(nameof(required), "Required score cannot be negative");
            Required = required;
            Current = Math.Max(0, initialScore);
        }

        public void AddPoints(int points)
        {
            if (points <= 0) return;
            Current += points;
        }

        public void Reset()
        {
            Current = 0;
        }

        public ScoreSnapshot ToSnapshot()
        {
            return new ScoreSnapshot(Current, Required, Progress, GoalReached);
        }
    }

    /// <summary>
    /// DTO inmutable para exponer el estado del puntaje sin permitir mutaciones externas.
    /// </summary>
    public readonly struct ScoreSnapshot
    {
        public int Current { get; }
        public int Required { get; }
        public float Progress { get; }
        public bool GoalReached { get; }

        public ScoreSnapshot(int current, int required, float progress, bool goalReached)
        {
            Current = current;
            Required = required;
            Progress = progress;
            GoalReached = goalReached;
        }
    }
}
