using System;
using UnityEngine;
using CleanArchitecture.Application.Health;
using CleanArchitecture.Domain.Health;
using CleanArchitecture.Infrastructure.Health;

namespace CleanArchitecture.Presentation.Health
{
    /// <summary>
    /// MonoBehaviour puente para exponer HealthService en el entorno Unity sin tocar scripts legacy.
    /// </summary>
    public class HealthServiceAdapter : MonoBehaviour
    {
        [SerializeField] private float maxHP = 200f;

        // Opcional: puntaje que otorga la muerte de este objeto (para enemigos)
        [SerializeField] private int scoreOnDeath = 0;

        // Si se habilita, creará y enlazará automáticamente a HealthSystemComposer del GameObject
        [SerializeField] private bool autoDetectHealthComponent = true;

        private HealthService service;

        public event Action<HealthSnapshot> OnChanged;
        public event Action OnDeath;

        public HealthSnapshot Snapshot => service?.GetSnapshot() ?? default;

        private void Awake()
        {
            TryBuildService();
        }

        /// <summary>
        /// Permite inicializar con un componente de salud específico (HealthSystemComposer o Health).
        /// </summary>
        public void Initialize(IHealthStats legacyStats)
        {
            TryBuildService(legacyStats);
        }

        public void Damage(float amount)
        {
            service?.Damage(amount);
        }

        public void Heal(float amount)
        {
            service?.Heal(amount);
        }

        public void ResetFull()
        {
            service?.ResetFull();
        }

        private void TryBuildService(IHealthStats legacy = null)
        {
            if (service != null) return;

            var legacyStats = legacy;

            if (legacyStats == null && autoDetectHealthComponent)
            {
                legacyStats = GetComponent<IHealthStats>();
            }

            if (legacyStats == null)
            {
                // Sin componente legacy no hacemos nada para no romper escenas.
                return;
            }

            var repository = new HealthComponentRepository(legacyStats);
            var notifier = new HealthUnityNotifier(gameObject, scoreOnDeath);
            service = new HealthService(repository, maxHP, notifier);

            service.OnChanged += snapshot => OnChanged?.Invoke(snapshot);
            service.OnDeath += () => OnDeath?.Invoke();
        }
    }
}
