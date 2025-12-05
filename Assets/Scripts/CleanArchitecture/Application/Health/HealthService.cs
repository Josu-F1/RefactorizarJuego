using System;
using CleanArchitecture.Domain.Health;

namespace CleanArchitecture.Application.Health
{
    /// <summary>
    /// Caso de uso para orquestar salud: daño, curación y reseteo.
    /// </summary>
    public class HealthService
    {
        private readonly IHealthRepository repository;
        private readonly IHealthNotifier notifier;
        private readonly HealthAggregate health;

        public event Action<HealthSnapshot> OnChanged;
        public event Action OnDeath;

        public HealthService(IHealthRepository repository, float maxHp, IHealthNotifier notifier = null)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.notifier = notifier;

            var loaded = this.repository.Load(maxHp);
            health = loaded ?? new HealthAggregate(maxHp);

            WireDomainEvents();
            RaiseSnapshot();
        }

        public HealthSnapshot GetSnapshot() => health.ToSnapshot();

        public void Damage(float amount)
        {
            health.ApplyDamage(amount);
            repository.Save(health);
        }

        public void Heal(float amount)
        {
            health.ApplyHeal(amount);
            repository.Save(health);
        }

        public void ResetFull()
        {
            health.ResetFull();
            repository.Save(health);
        }

        private void WireDomainEvents()
        {
            health.OnChanged += snapshot =>
            {
                OnChanged?.Invoke(snapshot);
                notifier?.OnHealthChanged(snapshot);
            };

            health.OnDeath += () =>
            {
                OnDeath?.Invoke();
                notifier?.OnDeath();
            };
        }

        private void RaiseSnapshot()
        {
            var snap = health.ToSnapshot();
            OnChanged?.Invoke(snap);
            notifier?.OnHealthChanged(snap);
            if (snap.IsDead)
            {
                OnDeath?.Invoke();
                notifier?.OnDeath();
            }
        }
    }
}
