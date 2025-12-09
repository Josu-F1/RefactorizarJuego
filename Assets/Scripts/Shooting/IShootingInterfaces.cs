#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;

namespace ShootingSystem.Interfaces
{
    // ============= WEAPON STRATEGY INTERFACES =============
    public interface IWeaponStrategy
    {
        void Shoot(IProjectileFactory projectileFactory, Transform shootPoint, Vector2 direction, IWeaponConfiguration config);
        bool CanShoot(IWeaponConfiguration config);
        string WeaponType { get; }
    }

    public interface IWeaponConfiguration
    {
        float ShootForce { get; }
        float Damage { get; }
        float FireRate { get; }
        float Range { get; }
        int AmmoCount { get; }
        ObjectPool ProjectilePool { get; }
        ObjectPool ExplosionVFXPool { get; }
        CharacterType OwnerType { get; }
    }

    // ============= PROJECTILE INTERFACES =============
    public interface IProjectile
    {
        void Initialize(IProjectileData data);
        void SetVelocity(Vector2 velocity);
        void DestroyProjectile();
        bool IsActive { get; }
    }

    public interface IProjectileData
    {
        float Damage { get; }
        float Lifetime { get; }
        CharacterType OwnerType { get; }
        ObjectPool ExplosionVFXPool { get; }
    }

    public interface IProjectileFactory
    {
        IProjectile CreateProjectile(Vector3 position, Quaternion rotation, IProjectileData data);
        void ReturnProjectile(IProjectile projectile);
    }

    // ============= TARGETING INTERFACES =============
    public interface ITargetingStrategy
    {
        Vector2 GetTargetDirection(Transform shooter, ITargetingConfiguration config);
        bool HasValidTarget(Transform shooter, ITargetingConfiguration config);
        Transform CurrentTarget { get; }
    }

    public interface ITargetingConfiguration
    {
        float Range { get; }
        LayerMask TargetLayers { get; }
        bool RequireLineOfSight { get; }
        float UpdateFrequency { get; }
    }

    // ============= SHOOTER INTERFACES =============
    public interface IShooterController
    {
        void Shoot(Vector2 direction, float angleOffset = 0);
        void Shoot();
        bool CanShoot();
        void SetWeaponStrategy(IWeaponStrategy strategy);
        void SetTargetingStrategy(ITargetingStrategy targeting);
        IWeaponConfiguration WeaponConfig { get; set; }
    }

    public interface IShooterInput
    {
        bool ShouldShoot();
        Vector2 GetShootDirection(Transform shooter);
        bool HasManualControl { get; }
    }

    // ============= COLLISION INTERFACES =============
    public interface IProjectileCollisionHandler
    {
        void HandleCollision(IProjectile projectile, Collider2D other);
        bool ShouldDestroyOnCollision(Collider2D other, IProjectileData data);
    }

    public interface ICollisionStrategy
    {
        bool ProcessCollision(Collider2D collider, IProjectileData projectileData);
        int Priority { get; }
    }

    // ============= SERVICE INTERFACES =============
    public interface IShootingService
    {
        void RegisterShooter(IShooterController shooter);
        void UnregisterShooter(IShooterController shooter);
        IWeaponStrategy GetWeaponStrategy(string weaponType);
        ITargetingStrategy GetTargetingStrategy(string targetingType);
        void UpdateShooters();
    }

    // ============= FACTORY INTERFACES =============
    public interface IWeaponFactory
    {
        IWeaponStrategy CreateWeapon(string weaponType);
        IWeaponConfiguration CreateWeaponConfig(WeaponConfigData configData);
    }

    public interface ITargetingFactory
    {
        ITargetingStrategy CreateTargeting(string targetingType);
        ITargetingConfiguration CreateTargetingConfig(TargetingConfigData configData);
    }

    // ============= COMPOSER INTERFACE =============
    public interface IShootingSystemComposer
    {
        IShootingService ShootingService { get; }
        IWeaponFactory WeaponFactory { get; }
        IProjectileFactory ProjectileFactory { get; }
        void Initialize();
        void Cleanup();
    }

    // ============= CONFIGURATION DATA =============
    [System.Serializable]
    public class WeaponConfigData
    {
        public string weaponType;
        public float shootForce = 15f;
        public float damage = 15f;
        public float fireRate = 1f;
        public float range = 30f;
        public int ammoCount = -1; // -1 = infinite
        public ObjectPool projectilePool;
        public ObjectPool explosionVFXPool;
        public CharacterType ownerType;
    }

    [System.Serializable]
    public class TargetingConfigData
    {
        public string targetingType;
        public float range = 30f;
        public LayerMask targetLayers = -1;
        public bool requireLineOfSight = true;
        public float updateFrequency = 0.1f;
    }
}