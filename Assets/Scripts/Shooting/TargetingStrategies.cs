using UnityEngine;
using ShootingSystem.Interfaces;

namespace ShootingSystem.Strategies
{
    // ============= TARGETING CONFIGURATION =============
    [System.Serializable]
    public class TargetingConfiguration : ITargetingConfiguration
    {
        [SerializeField] private float range = 30f;
        [SerializeField] private LayerMask targetLayers = -1;
        [SerializeField] private bool requireLineOfSight = true;
        [SerializeField] private float updateFrequency = 0.1f;

        public float Range => range;
        public LayerMask TargetLayers => targetLayers;
        public bool RequireLineOfSight => requireLineOfSight;
        public float UpdateFrequency => updateFrequency;

        public TargetingConfiguration(TargetingConfigData data)
        {
            range = data.range;
            targetLayers = data.targetLayers;
            requireLineOfSight = data.requireLineOfSight;
            updateFrequency = data.updateFrequency;
        }
    }

    // ============= BASE TARGETING STRATEGY =============
    public abstract class BaseTargetingStrategy : ITargetingStrategy
    {
        protected Transform currentTarget;
        protected float lastUpdateTime;

        public Transform CurrentTarget => currentTarget;

        public virtual bool HasValidTarget(Transform shooter, ITargetingConfiguration config)
        {
            return currentTarget != null && IsTargetInRange(shooter, currentTarget, config);
        }

        public virtual Vector2 GetTargetDirection(Transform shooter, ITargetingConfiguration config)
        {
            UpdateTarget(shooter, config);
            
            if (currentTarget == null)
                return shooter.up;

            Vector2 direction = (currentTarget.position - shooter.position).normalized;
            return direction;
        }

        protected virtual void UpdateTarget(Transform shooter, ITargetingConfiguration config)
        {
            if (Time.time < lastUpdateTime + config.UpdateFrequency) return;
            
            lastUpdateTime = Time.time;
            currentTarget = FindBestTarget(shooter, config);
        }

        protected abstract Transform FindBestTarget(Transform shooter, ITargetingConfiguration config);

        protected virtual bool IsTargetInRange(Transform shooter, Transform target, ITargetingConfiguration config)
        {
            if (target == null) return false;
            
            float distance = Vector2.Distance(shooter.position, target.position);
            if (distance > config.Range) return false;

            if (config.RequireLineOfSight)
            {
                return HasLineOfSight(shooter.position, target.position, config.TargetLayers);
            }

            return true;
        }

        protected virtual bool HasLineOfSight(Vector2 from, Vector2 to, LayerMask obstacleLayer)
        {
            Vector2 direction = to - from;
            float distance = direction.magnitude;
            
            RaycastHit2D hit = Physics2D.Raycast(from, direction.normalized, distance, obstacleLayer);
            return hit.collider == null;
        }
    }

    // ============= PLAYER TARGETING STRATEGY =============
    [System.Serializable]
    public class PlayerTargetingStrategy : BaseTargetingStrategy
    {
        #pragma warning disable 0618 // Suppress obsolete warning during migration
        protected override Transform FindBestTarget(Transform shooter, ITargetingConfiguration config)
        {
            // During migration, still use Player.Instance but wrapped
            var player = Player.Instance;
            if (player != null && IsTargetInRange(shooter, player.transform, config))
            {
                return player.transform;
            }
            return null;
        }
        #pragma warning restore 0618
    }

    // ============= NEAREST ENEMY TARGETING STRATEGY =============
    [System.Serializable]
    public class NearestEnemyTargetingStrategy : BaseTargetingStrategy
    {
        protected override Transform FindBestTarget(Transform shooter, ITargetingConfiguration config)
        {
            Transform bestTarget = null;
            float closestDistance = config.Range;

            #pragma warning disable 0618 // Suppress obsolete warning during migration
            var enemies = Object.FindObjectsOfType<Enemy>();
            foreach (var enemy in enemies)
            {
                if (enemy == null || enemy.transform == shooter) continue;

                float distance = Vector2.Distance(shooter.position, enemy.transform.position);
                if (distance < closestDistance && IsTargetInRange(shooter, enemy.transform, config))
                {
                    closestDistance = distance;
                    bestTarget = enemy.transform;
                }
            }
            #pragma warning restore 0618

            return bestTarget;
        }
    }

    // ============= AREA TARGETING STRATEGY =============
    [System.Serializable]
    public class AreaTargetingStrategy : BaseTargetingStrategy
    {
        [SerializeField] private float detectionRadius = 5f;

        protected override Transform FindBestTarget(Transform shooter, ITargetingConfiguration config)
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(shooter.position, detectionRadius, config.TargetLayers);
            
            Transform bestTarget = null;
            float closestDistance = config.Range;

            foreach (var target in targets)
            {
                if (target.transform == shooter) continue;

                float distance = Vector2.Distance(shooter.position, target.transform.position);
                if (distance < closestDistance && IsTargetInRange(shooter, target.transform, config))
                {
                    closestDistance = distance;
                    bestTarget = target.transform;
                }
            }

            return bestTarget;
        }
    }

    // ============= DIRECTIONAL TARGETING STRATEGY =============
    [System.Serializable]
    public class DirectionalTargetingStrategy : BaseTargetingStrategy
    {
        public override Vector2 GetTargetDirection(Transform shooter, ITargetingConfiguration config)
        {
            // Always shoot in the forward direction of the shooter
            return shooter.up;
        }

        protected override Transform FindBestTarget(Transform shooter, ITargetingConfiguration config)
        {
            // No specific target, just shoot forward
            return null;
        }

        public override bool HasValidTarget(Transform shooter, ITargetingConfiguration config)
        {
            // Always can shoot in a direction
            return true;
        }
    }

    // ============= PREDICTIVE TARGETING STRATEGY =============
    [System.Serializable]
    public class PredictiveTargetingStrategy : PlayerTargetingStrategy
    {
        [SerializeField] private float predictionFactor = 0.5f;

        public override Vector2 GetTargetDirection(Transform shooter, ITargetingConfiguration config)
        {
            UpdateTarget(shooter, config);
            
            if (currentTarget == null)
                return shooter.up;

            // Get target's velocity for prediction
            Rigidbody2D targetRb = currentTarget.GetComponent<Rigidbody2D>();
            Vector2 targetVelocity = targetRb != null ? targetRb.velocity : Vector2.zero;

            // Predict future position
            Vector2 predictedPosition = (Vector2)currentTarget.position + targetVelocity * predictionFactor;
            Vector2 direction = (predictedPosition - (Vector2)shooter.position).normalized;

            return direction;
        }
    }
}