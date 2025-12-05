using System;

namespace CleanArchitecture.Domain.Enemy
{
    /// <summary>
    /// Agregado de dominio para un enemigo: estado básico y eventos.
    /// </summary>
    public class EnemyAgent
    {
        public Guid Id { get; }
        public int ScoreOnDeath { get; }
        public EnemyState State { get; private set; }

        public event Action<EnemyState> OnStateChanged;
        public event Action OnDeath;

        public EnemyAgent(int scoreOnDeath)
        {
            Id = Guid.NewGuid();
            ScoreOnDeath = scoreOnDeath;
            State = EnemyState.Idle;
        }

        public void SetState(EnemyState newState)
        {
            if (State == newState) return;
            State = newState;
            OnStateChanged?.Invoke(State);
        }

        public void MarkDead()
        {
            if (State == EnemyState.Dead) return;
            State = EnemyState.Dead;
            OnStateChanged?.Invoke(State);
            OnDeath?.Invoke();
        }
    }

    public enum EnemyState
    {
        Idle,
        Chasing,
        Attacking,
        Dead
    }
}
