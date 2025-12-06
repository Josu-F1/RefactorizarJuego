#pragma warning disable CS0618 // Type or member is obsolete
using System;
using CleanArchitecture.Domain.Health;
using UnityEngine;

/// <summary>
/// Adaptador de infraestructura que usa componentes existentes (HealthSystemComposer o Health)
/// para cumplir el contrato de repositorio sin modificarlos.
/// </summary>
namespace CleanArchitecture.Infrastructure.Health
{
    public class HealthComponentRepository : IHealthRepository
    {
        private readonly IHealthStats legacyStats;
        private readonly IDamageStrategy damageStrategy;
        private readonly IHealingStrategy healingStrategy;
        private readonly IDeathStrategy deathStrategy;

        public HealthComponentRepository(IHealthStats legacyStats,
            IDamageStrategy damageStrategy = null,
            IHealingStrategy healingStrategy = null,
            IDeathStrategy deathStrategy = null)
        {
            this.legacyStats = legacyStats ?? throw new ArgumentNullException(nameof(legacyStats));
            this.damageStrategy = damageStrategy;
            this.healingStrategy = healingStrategy;
            this.deathStrategy = deathStrategy;
        }

        public HealthAggregate Load(float maxHp)
        {
            // Si el componente expone MaxHP/CurrentHP, lo reflejamos; si no, usamos maxHp.
            float current = (legacyStats as HealthSystemComposer)?.CurrentHP ?? maxHp;
            float max = (legacyStats as HealthSystemComposer)?.MaxHP ?? maxHp;
            return new HealthAggregate(max, current);
        }

        public void Save(HealthAggregate aggregate)
        {
            // Sincronizar con sistema legado si es HealthSystemComposer
            if (legacyStats is HealthSystemComposer composer)
            {
                if (aggregate.IsDead && !composer.IsDead)
                {
                    composer.Die();
                    return;
                }

                float delta = aggregate.Current - composer.CurrentHP;
                if (delta < 0)
                {
                    composer.TakeDamage(Mathf.Abs(delta));
                }
                else if (delta > 0)
                {
                    composer.Heal(delta);
                }
            }
            // Si fuese el componente viejo Health, intentamos mapear a sus métodos públicos.
            else if (legacyStats is global::Health oldHealth)
            {
                if (aggregate.IsDead && !oldHealth.IsDead)
                {
                    oldHealth.Die();
                    return;
                }

                float delta = aggregate.Current - oldHealth.Percentage * aggregate.Max; // aproximación
                if (delta < 0)
                {
                    oldHealth.TakeDamage(Mathf.Abs(delta));
                }
                else if (delta > 0)
                {
                    oldHealth.Heal(delta);
                }
            }
        }
    }
}
