using System;

namespace CleanArchitecture.Domain.Health
{
    /// <summary>
    /// Lógica pura de salud: agrega/quita HP, expone eventos de dominio.
    /// </summary>
    public class HealthAggregate
    {
        public float Current { get; private set; }
        public float Max { get; private set; }
        public bool IsDead => Current <= 0;
        public bool IsFull => Math.Abs(Current - Max) < 0.0001f;
        public float Percentage => Max > 0 ? Current / Max : 0f;

        public event Action<HealthSnapshot> OnChanged;
        public event Action OnDeath;

        public HealthAggregate(float maxHp, float? initialHp = null)
        {
            if (maxHp <= 0) throw new ArgumentOutOfRangeException(nameof(maxHp), "Max HP must be positive");
            Max = maxHp;
            Current = Math.Clamp(initialHp ?? maxHp, 0, Max);
        }

        public void ApplyDamage(float amount)
        {
            if (amount <= 0 || IsDead) return;
            Current = Math.Max(0, Current - amount);
            Notify();
            if (IsDead) OnDeath?.Invoke();
        }

        public void ApplyHeal(float amount)
        {
            if (amount <= 0 || IsDead) return;
            Current = Math.Min(Max, Current + amount);
            Notify();
        }

        public void ResetFull()
        {
            Current = Max;
            Notify();
        }

        public HealthSnapshot ToSnapshot()
        {
            return new HealthSnapshot(Current, Max, Percentage, IsDead, IsFull);
        }

        private void Notify()
        {
            OnChanged?.Invoke(ToSnapshot());
        }
    }

    /// <summary>
    /// DTO inmutable para exponer estado de salud a capas superiores.
    /// </summary>
    public readonly struct HealthSnapshot
    {
        public float Current { get; }
        public float Max { get; }
        public float Percentage { get; }
        public bool IsDead { get; }
        public bool IsFull { get; }

        public HealthSnapshot(float current, float max, float percentage, bool isDead, bool isFull)
        {
            Current = current;
            Max = max;
            Percentage = percentage;
            IsDead = isDead;
            IsFull = isFull;
        }
    }
}
