#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;
using System.Collections.Generic;
using ShootingSystem.Interfaces;
using ShootingSystem.Strategies;

namespace ShootingSystem.Factory
{
    // ============= PROJECTILE FACTORY =============
    [System.Serializable]
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly Dictionary<ObjectPool, List<IProjectile>> pooledProjectiles;

        public ProjectileFactory()
        {
            pooledProjectiles = new Dictionary<ObjectPool, List<IProjectile>>();
        }

        public IProjectile CreateProjectile(Vector3 position, Quaternion rotation, IProjectileData data)
        {
            var pool = data.ExplosionVFXPool; // Using VFX pool as identifier, could be improved
            var projectileObj = GetProjectileFromPool(position, rotation, data);
            
            if (projectileObj != null)
            {
                var projectile = projectileObj.GetComponent<ProjectileAdapter>();
                if (projectile == null)
                {
                    projectile = projectileObj.AddComponent<ProjectileAdapter>();
                }
                projectile.Initialize(data);
                return projectile;
            }

            return null;
        }

        public void ReturnProjectile(IProjectile projectile)
        {
            if (projectile is ProjectileAdapter adapter)
            {
                adapter.ReturnToPool();
            }
        }

        private GameObject GetProjectileFromPool(Vector3 position, Quaternion rotation, IProjectileData data)
        {
            // This is simplified - in real implementation, you'd have a proper pool mapping
            // For now, we'll use a fallback approach
            return null; // Will be improved in the composer
        }
    }

    // ============= PROJECTILE ADAPTER =============
    public class ProjectileAdapter : MonoBehaviour, IProjectile
    {
        public IProjectileData projectileData { get; private set; } // Made public for collision handler access
        private Projectile originalProjectile;
        private bool isActive;

        public bool IsActive => isActive;

        private void Awake()
        {
            originalProjectile = GetComponent<Projectile>();
            if (originalProjectile == null)
            {
                Debug.LogError("ProjectileAdapter requires a Projectile component!");
            }
        }

        public void Initialize(IProjectileData data)
        {
            projectileData = data;
            isActive = true;

            if (originalProjectile != null)
            {
                originalProjectile.Damage = data.Damage;
                originalProjectile.CharacterType = data.OwnerType;
                originalProjectile.ExplosionVFXPool = data.ExplosionVFXPool;
            }
        }

        public void SetVelocity(Vector2 velocity)
        {
            originalProjectile?.SetVelocity(velocity);
        }

        public void DestroyProjectile()
        {
            isActive = false;
            // The original projectile will handle the destruction
        }

        public void ReturnToPool()
        {
            isActive = false;
            // Delegate to original projectile's pool system
        }
    }

    // ============= WEAPON FACTORY =============
    [System.Serializable]
    public class WeaponFactory : IWeaponFactory
    {
        private readonly Dictionary<string, System.Func<IWeaponStrategy>> weaponCreators;

        public WeaponFactory()
        {
            weaponCreators = new Dictionary<string, System.Func<IWeaponStrategy>>
            {
                { "SingleShot", () => new SingleShotWeaponStrategy() },
                { "Burst", () => new BurstWeaponStrategy() },
                { "SpreadShot", () => new SpreadShotWeaponStrategy() },
                { "RapidFire", () => new RapidFireWeaponStrategy() }
            };
        }

        public IWeaponStrategy CreateWeapon(string weaponType)
        {
            if (weaponCreators.ContainsKey(weaponType))
            {
                return weaponCreators[weaponType]();
            }

            Debug.LogWarning($"Unknown weapon type: {weaponType}. Using SingleShot as default.");
            return new SingleShotWeaponStrategy();
        }

        public IWeaponConfiguration CreateWeaponConfig(WeaponConfigData configData)
        {
            return new WeaponConfiguration(configData);
        }

        public void RegisterWeaponType(string weaponType, System.Func<IWeaponStrategy> creator)
        {
            weaponCreators[weaponType] = creator;
        }
    }

    // ============= TARGETING FACTORY =============
    [System.Serializable]
    public class TargetingFactory : ITargetingFactory
    {
        private readonly Dictionary<string, System.Func<ITargetingStrategy>> targetingCreators;

        public TargetingFactory()
        {
            targetingCreators = new Dictionary<string, System.Func<ITargetingStrategy>>
            {
                { "Player", () => new PlayerTargetingStrategy() },
                { "NearestEnemy", () => new NearestEnemyTargetingStrategy() },
                { "Area", () => new AreaTargetingStrategy() },
                { "Directional", () => new DirectionalTargetingStrategy() },
                { "Predictive", () => new PredictiveTargetingStrategy() }
            };
        }

        public ITargetingStrategy CreateTargeting(string targetingType)
        {
            if (targetingCreators.ContainsKey(targetingType))
            {
                return targetingCreators[targetingType]();
            }

            Debug.LogWarning($"Unknown targeting type: {targetingType}. Using Player as default.");
            return new PlayerTargetingStrategy();
        }

        public ITargetingConfiguration CreateTargetingConfig(TargetingConfigData configData)
        {
            return new TargetingConfiguration(configData);
        }

        public void RegisterTargetingType(string targetingType, System.Func<ITargetingStrategy> creator)
        {
            targetingCreators[targetingType] = creator;
        }
    }

    // ============= COLLISION STRATEGIES =============
    [System.Serializable]
    public class HealthCollisionStrategy : ICollisionStrategy
    {
        public int Priority => 10;

        public bool ProcessCollision(Collider2D collider, IProjectileData projectileData)
        {
            // Usar CharacterSystemComposer en lugar de Health legacy
            var characterSystem = CharacterSystemComposer.Instance;
            if (characterSystem != null)
            {
                var controller = characterSystem.GetController(collider.gameObject);
                var hitCharacter = collider.GetComponent<ICharacter>();
                if (controller != null && hitCharacter != null && hitCharacter.CharacterType != projectileData.OwnerType)
                {
                    controller.NotifyEvent(CharacterEvent.HealthDepleted, projectileData.Damage);
                    return true; // Collision handled, destroy projectile
                }
            }
            #pragma warning restore 0618
            return false;
        }
    }

    [System.Serializable]
    public class DestructibleTilemapCollisionStrategy : ICollisionStrategy
    {
        public int Priority => 5;

        public bool ProcessCollision(Collider2D collider, IProjectileData projectileData)
        {
            var destructibleTilemap = collider.GetComponent<DestructibleTilemap>();
            if (destructibleTilemap != null)
            {
                destructibleTilemap.DestroyTile(collider.transform.position);
                return true; // Collision handled, destroy projectile
            }
            return false;
        }
    }

    [System.Serializable]
    public class DestroyProjectileCollisionStrategy : ICollisionStrategy
    {
        public int Priority => 1;

        public bool ProcessCollision(Collider2D collider, IProjectileData projectileData)
        {
            return collider.GetComponent<IDestroyProjectile>() != null;
        }
    }

    // ============= COLLISION HANDLER =============
    [System.Serializable]
    public class ProjectileCollisionHandler : IProjectileCollisionHandler
    {
        private readonly List<ICollisionStrategy> collisionStrategies;

        public ProjectileCollisionHandler()
        {
            collisionStrategies = new List<ICollisionStrategy>
            {
                new HealthCollisionStrategy(),
                new DestructibleTilemapCollisionStrategy(),
                new DestroyProjectileCollisionStrategy()
            };

            // Sort by priority
            collisionStrategies.Sort((a, b) => b.Priority.CompareTo(a.Priority));
        }

        public void HandleCollision(IProjectile projectile, Collider2D other)
        {
            if (projectile is ProjectileAdapter adapter && adapter.projectileData != null)
            {
                foreach (var strategy in collisionStrategies)
                {
                    if (strategy.ProcessCollision(other, adapter.projectileData))
                    {
                        projectile.DestroyProjectile();
                        return;
                    }
                }
            }
        }

        public bool ShouldDestroyOnCollision(Collider2D other, IProjectileData data)
        {
            foreach (var strategy in collisionStrategies)
            {
                if (strategy.ProcessCollision(other, data))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddCollisionStrategy(ICollisionStrategy strategy)
        {
            collisionStrategies.Add(strategy);
            collisionStrategies.Sort((a, b) => b.Priority.CompareTo(a.Priority));
        }
    }
}