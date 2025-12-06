#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;
using ShootingSystem.Interfaces;

namespace ShootingSystem.Strategies
{
    // ============= WEAPON CONFIGURATION =============
    [System.Serializable]
    public class WeaponConfiguration : IWeaponConfiguration
    {
        [SerializeField] private float shootForce = 15f;
        [SerializeField] private float damage = 15f;
        [SerializeField] private float fireRate = 1f;
        [SerializeField] private float range = 30f;
        [SerializeField] private int ammoCount = -1;
        [SerializeField] private ObjectPool projectilePool;
        [SerializeField] private ObjectPool explosionVFXPool;
        [SerializeField] private CharacterType ownerType;

        public float ShootForce => shootForce;
        public float Damage => damage;
        public float FireRate => fireRate;
        public float Range => range;
        public int AmmoCount => ammoCount;
        public ObjectPool ProjectilePool => projectilePool;
        public ObjectPool ExplosionVFXPool => explosionVFXPool;
        public CharacterType OwnerType => ownerType;

        public WeaponConfiguration(WeaponConfigData data)
        {
            shootForce = data.shootForce;
            damage = data.damage;
            fireRate = data.fireRate;
            range = data.range;
            ammoCount = data.ammoCount;
            projectilePool = data.projectilePool;
            explosionVFXPool = data.explosionVFXPool;
            ownerType = data.ownerType;
        }
    }

    // ============= BASE WEAPON STRATEGY =============
    public abstract class BaseWeaponStrategy : IWeaponStrategy
    {
        protected float lastShootTime = 0f;

        public abstract string WeaponType { get; }

        public virtual bool CanShoot(IWeaponConfiguration config)
        {
            if (config.AmmoCount == 0) return false;
            return Time.time >= lastShootTime + (1f / config.FireRate);
        }

        public virtual void Shoot(IProjectileFactory projectileFactory, Transform shootPoint, Vector2 direction, IWeaponConfiguration config)
        {
            if (!CanShoot(config)) return;

            lastShootTime = Time.time;
            CreateProjectiles(projectileFactory, shootPoint, direction, config);
        }

        protected abstract void CreateProjectiles(IProjectileFactory factory, Transform shootPoint, Vector2 direction, IWeaponConfiguration config);

        protected virtual IProjectileData CreateProjectileData(IWeaponConfiguration config)
        {
            return new ProjectileData(config.Damage, 5f, config.OwnerType, config.ExplosionVFXPool);
        }
    }

    // ============= SINGLE SHOT WEAPON =============
    [System.Serializable]
    public class SingleShotWeaponStrategy : BaseWeaponStrategy
    {
        public override string WeaponType => "SingleShot";

        protected override void CreateProjectiles(IProjectileFactory factory, Transform shootPoint, Vector2 direction, IWeaponConfiguration config)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            
            var projectileData = CreateProjectileData(config);
            var projectile = factory.CreateProjectile(shootPoint.position, rotation, projectileData);
            projectile.SetVelocity(shootPoint.up * config.ShootForce);
        }
    }

    // ============= BURST WEAPON =============
    [System.Serializable]
    public class BurstWeaponStrategy : BaseWeaponStrategy
    {
        [SerializeField] private int burstCount = 3;
        [SerializeField] private float burstDelay = 0.1f;
        [SerializeField] private float spreadAngle = 15f;

        public override string WeaponType => "Burst";

        protected override void CreateProjectiles(IProjectileFactory factory, Transform shootPoint, Vector2 direction, IWeaponConfiguration config)
        {
            for (int i = 0; i < burstCount; i++)
            {
                float angleOffset = (i - (burstCount - 1) * 0.5f) * spreadAngle / burstCount;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f + angleOffset;
                Quaternion rotation = Quaternion.Euler(0, 0, angle);

                var projectileData = CreateProjectileData(config);
                var projectile = factory.CreateProjectile(shootPoint.position, rotation, projectileData);
                projectile.SetVelocity(rotation * Vector3.up * config.ShootForce);
            }
        }
    }

    // ============= SPREAD SHOT WEAPON =============
    [System.Serializable]
    public class SpreadShotWeaponStrategy : BaseWeaponStrategy
    {
        [SerializeField] private int projectileCount = 5;
        [SerializeField] private float spreadAngle = 45f;

        public override string WeaponType => "SpreadShot";

        protected override void CreateProjectiles(IProjectileFactory factory, Transform shootPoint, Vector2 direction, IWeaponConfiguration config)
        {
            float angleStep = spreadAngle / (projectileCount - 1);
            float startAngle = -spreadAngle * 0.5f;

            for (int i = 0; i < projectileCount; i++)
            {
                float currentAngle = startAngle + (angleStep * i);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f + currentAngle;
                Quaternion rotation = Quaternion.Euler(0, 0, angle);

                var projectileData = CreateProjectileData(config);
                var projectile = factory.CreateProjectile(shootPoint.position, rotation, projectileData);
                projectile.SetVelocity(rotation * Vector3.up * config.ShootForce);
            }
        }
    }

    // ============= RAPID FIRE WEAPON =============
    [System.Serializable]
    public class RapidFireWeaponStrategy : SingleShotWeaponStrategy
    {
        public override string WeaponType => "RapidFire";

        public override bool CanShoot(IWeaponConfiguration config)
        {
            // Override fire rate for rapid fire
            var rapidFireRate = config.FireRate * 3f; // 3x faster
            if (config.AmmoCount == 0) return false;
            return Time.time >= lastShootTime + (1f / rapidFireRate);
        }
    }

    // ============= PROJECTILE DATA =============
    [System.Serializable]
    public class ProjectileData : IProjectileData
    {
        private readonly float damage;
        private readonly float lifetime;
        private readonly CharacterType ownerType;
        private readonly ObjectPool explosionVFXPool;

        public float Damage => damage;
        public float Lifetime => lifetime;
        public CharacterType OwnerType => ownerType;
        public ObjectPool ExplosionVFXPool => explosionVFXPool;

        public ProjectileData(float damage, float lifetime, CharacterType ownerType, ObjectPool explosionVFXPool)
        {
            this.damage = damage;
            this.lifetime = lifetime;
            this.ownerType = ownerType;
            this.explosionVFXPool = explosionVFXPool;
        }
    }
}