using UnityEngine;
using CleanArchitecture.Application.Enemy;
using CleanArchitecture.Domain.Enemy;
using CleanArchitecture.Infrastructure.Enemy;

namespace CleanArchitecture.Presentation.Enemy
{
    /// <summary>
    /// MonoBehaviour opcional para conectar AIPath + Player target con la capa de aplicación.
    /// No se usa en escenas actuales, así que no cambia gameplay hasta que se añada.
    /// </summary>
    [RequireComponent(typeof(CleanArchitecture.Infrastructure.Enemy.AstarNavigatorAdapter))]
    public class EnemyAIAdapter : MonoBehaviour
    {
        [SerializeField] private int scoreOnDeath = 5;
        [SerializeField] private float activationRange = 10f;

        private EnemyAgent agent;
        private EnemyAIService service;

        private void Awake()
        {
            var navigator = GetComponent<CleanArchitecture.Infrastructure.Enemy.AstarNavigatorAdapter>();
            var targetProvider = new PlayerTargetProvider();

            agent = new EnemyAgent(scoreOnDeath);
            service = new EnemyAIService(agent, navigator, targetProvider, activationRange);
        }

        private void Update()
        {
            service?.Tick();
        }

        /// <summary>
        /// Llamar desde eventos de muerte legacy (ej: Health) para sincronizar dominio.
        /// </summary>
        public void NotifyDeath()
        {
            service?.NotifyDeath();
        }
    }
}
