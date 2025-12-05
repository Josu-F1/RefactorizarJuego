using System;
using CleanArchitecture.Domain.Enemy;

namespace CleanArchitecture.Application.Enemy
{
    /// <summary>
    /// Caso de uso: orquesta navegación simple de enemigo hacia un objetivo.
    /// </summary>
    public class EnemyAIService
    {
        private readonly EnemyAgent agent;
        private readonly IEnemyNavigator navigator;
        private readonly IEnemyTargetProvider targetProvider;
        private readonly float activationRange;

        public EnemyAIService(EnemyAgent agent, IEnemyNavigator navigator, IEnemyTargetProvider targetProvider, float activationRange = 10f)
        {
            this.agent = agent ?? throw new ArgumentNullException(nameof(agent));
            this.navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            this.targetProvider = targetProvider ?? throw new ArgumentNullException(nameof(targetProvider));
            this.activationRange = activationRange;
        }

        /// <summary>
        /// Llamar en update para procesar la lógica básica de persecución.
        /// </summary>
        public void Tick()
        {
            if (agent.State == EnemyState.Dead) return;

            var targetPos = targetProvider.GetTargetPosition();
            var distance = (navigator as IEnemyNavigatorWithPosition)?.DistanceTo(targetPos);

            if (distance.HasValue && distance.Value > activationRange)
            {
                navigator.EnableMovement(false);
                agent.SetState(EnemyState.Idle);
                return;
            }

            navigator.EnableMovement(true);
            navigator.SetDestination(targetPos);
            agent.SetState(EnemyState.Chasing);
        }

        /// <summary>
        /// Marca muerte en dominio y deshabilita navegación.
        /// </summary>
        public void NotifyDeath()
        {
            agent.MarkDead();
            navigator.EnableMovement(false);
        }
    }

    /// <summary>
    /// Contrato opcional para navegadores que pueden reportar distancia actual.
    /// </summary>
    public interface IEnemyNavigatorWithPosition : IEnemyNavigator
    {
        float DistanceTo(UnityEngine.Vector3 position);
    }
}
