using CleanArchitecture.Domain.Health;
using UnityEngine;

/// <summary>
/// Notificador opcional hacia sistemas Unity existentes (eventos globales, partículas, puntuación).
/// No modifica los scripts viejos; solo los invoca si existen.
/// </summary>
namespace CleanArchitecture.Infrastructure.Health
{
    public class HealthUnityNotifier : IHealthNotifier
    {
        private readonly GameObject owner;
        private readonly int scoreOnDeath;

        public HealthUnityNotifier(GameObject owner, int scoreOnDeath = 0)
        {
            this.owner = owner;
            this.scoreOnDeath = scoreOnDeath;
        }

        public void OnHealthChanged(HealthSnapshot snapshot)
        {
            // Ejemplo: logs o triggers de VFX futuros; aquí no hacemos nada para no romper.
        }

        public void OnDeath()
        {
            // Reutilizar flujo existente: si es Enemy, disparar score; si tiene eventos, se ejecutan.
            var enemy = owner != null ? owner.GetComponent<global::Enemy>() : null;
            if (enemy != null && scoreOnDeath > 0)
            {
                global::Enemy.OnAnyEnemyKilled?.Invoke(scoreOnDeath);
            }
        }
    }
}
