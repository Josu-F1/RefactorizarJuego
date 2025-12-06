#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;
using System.Collections.Generic;
using ShootingSystem.Interfaces;
using ShootingSystem.Strategies;
using ShootingSystem.Factory;
using ShootingSystem.Controllers;

namespace ShootingSystem
{
    // ============= SHOOTING SYSTEM DATABASE =============
    [CreateAssetMenu(fileName = "ShootingSystemDatabase", menuName = "Shooting System/Database")]
    public class ShootingSystemDatabase : ScriptableObject
    {
        [Header("Default Configurations")]
        [SerializeField] private WeaponConfigData[] defaultWeaponConfigs;
        [SerializeField] private TargetingConfigData[] defaultTargetingConfigs;
        
        [Header("Projectile Pools")]
        [SerializeField] private ObjectPool defaultProjectilePool;
        [SerializeField] private ObjectPool defaultExplosionVFXPool;

        public WeaponConfigData[] DefaultWeaponConfigs => defaultWeaponConfigs;
        public TargetingConfigData[] DefaultTargetingConfigs => defaultTargetingConfigs;
        public ObjectPool DefaultProjectilePool => defaultProjectilePool;
        public ObjectPool DefaultExplosionVFXPool => defaultExplosionVFXPool;
    }

    // ============= SHOOTING SERVICE =============
    [System.Serializable]
    public class ShootingService : IShootingService
    {
        private readonly List<IShooterController> registeredShooters;
        private readonly IWeaponFactory weaponFactory;
        private readonly ITargetingFactory targetingFactory;

        public ShootingService(IWeaponFactory weaponFactory, ITargetingFactory targetingFactory)
        {
            this.weaponFactory = weaponFactory ?? throw new System.ArgumentNullException(nameof(weaponFactory));
            this.targetingFactory = targetingFactory ?? throw new System.ArgumentNullException(nameof(targetingFactory));
            registeredShooters = new List<IShooterController>();
        }

        public void RegisterShooter(IShooterController shooter)
        {
            if (shooter != null && !registeredShooters.Contains(shooter))
            {
                registeredShooters.Add(shooter);
            }
        }

        public void UnregisterShooter(IShooterController shooter)
        {
            registeredShooters.Remove(shooter);
        }

        public IWeaponStrategy GetWeaponStrategy(string weaponType)
        {
            return weaponFactory.CreateWeapon(weaponType);
        }

        public ITargetingStrategy GetTargetingStrategy(string targetingType)
        {
            return targetingFactory.CreateTargeting(targetingType);
        }

        public void UpdateShooters()
        {
            // This could be used for centralized updates if needed
            // For now, individual components update themselves
        }

        public int RegisteredShooterCount => registeredShooters.Count;

        public void ClearAllShooters()
        {
            registeredShooters.Clear();
        }
    }

    // ============= ENHANCED PROJECTILE FACTORY =============
    [System.Serializable]
    public class EnhancedProjectileFactory : IProjectileFactory
    {
        private readonly ObjectPool defaultProjectilePool;
        private readonly ObjectPool defaultExplosionVFXPool;

        public EnhancedProjectileFactory(ObjectPool projectilePool, ObjectPool explosionVFXPool)
        {
            defaultProjectilePool = projectilePool;
            defaultExplosionVFXPool = explosionVFXPool;
        }

        public IProjectile CreateProjectile(Vector3 position, Quaternion rotation, IProjectileData data)
        {
            // Use data's pool if available, otherwise default
            var poolToUse = data.ExplosionVFXPool ?? defaultExplosionVFXPool;
            
            // For now, use default projectile pool (could be enhanced to use projectile-specific pools)
            var projectileObj = defaultProjectilePool?.Get(position, rotation);
            
            if (projectileObj != null)
            {
                var adapter = projectileObj.GetComponent<ProjectileAdapter>();
                if (adapter == null)
                {
                    adapter = projectileObj.AddComponent<ProjectileAdapter>();
                }
                adapter.Initialize(data);
                return adapter;
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
    }

    // ============= MAIN SHOOTING SYSTEM COMPOSER =============
    [System.Obsolete("ShootingSystemComposer is deprecated. Use IShootingService from ServiceLocator instead.")]
    public class ShootingSystemComposer : MonoBehaviour, IShootingSystemComposer
    {
        [Header("System Configuration")]
        [SerializeField] private ShootingSystemDatabase systemDatabase;

        // ============= SYSTEM COMPONENTS =============
        private WeaponFactory weaponFactory;
        private TargetingFactory targetingFactory;
        private EnhancedProjectileFactory projectileFactory;
        private ShootingService shootingService;
        private ProjectileCollisionHandler collisionHandler;

        // ============= INTERFACE PROPERTIES =============
        public IShootingService ShootingService => shootingService;
        public IWeaponFactory WeaponFactory => weaponFactory;
        public IProjectileFactory ProjectileFactory => projectileFactory;
        public ITargetingFactory TargetingFactory => targetingFactory;

        // ============= UNITY LIFECYCLE =============
        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            shootingService?.UpdateShooters();
        }

        private void OnDestroy()
        {
            Cleanup();
        }

        // ============= INITIALIZATION =============
        public void Initialize()
        {
            if (!ValidateConfiguration())
                return;

            // Create Factory Layer
            weaponFactory = new WeaponFactory();
            targetingFactory = new TargetingFactory();
            projectileFactory = new EnhancedProjectileFactory(
                systemDatabase.DefaultProjectilePool, 
                systemDatabase.DefaultExplosionVFXPool
            );

            // Create Service Layer
            shootingService = new ShootingService(weaponFactory, targetingFactory);
            
            // Create Collision Handler
            collisionHandler = new ProjectileCollisionHandler();

            // Load default configurations
            LoadDefaultConfigurations();

            Debug.Log("ShootingSystemComposer initialized successfully with Strategy + Factory Pattern");
        }

        public void Cleanup()
        {
            shootingService?.ClearAllShooters();
            
            weaponFactory = null;
            targetingFactory = null;
            projectileFactory = null;
            shootingService = null;
            collisionHandler = null;
        }

        // ============= VALIDATION =============
        private bool ValidateConfiguration()
        {
            if (systemDatabase == null)
            {
                Debug.LogError("ShootingSystemComposer: systemDatabase is null!");
                return false;
            }

            if (systemDatabase.DefaultProjectilePool == null)
            {
                Debug.LogError("ShootingSystemComposer: DefaultProjectilePool in database is null!");
                return false;
            }

            return true;
        }

        // ============= CONFIGURATION LOADING =============
        private void LoadDefaultConfigurations()
        {
            // Register additional weapon types from database
            foreach (var weaponConfig in systemDatabase.DefaultWeaponConfigs)
            {
                if (!string.IsNullOrEmpty(weaponConfig.weaponType))
                {
                    // Custom weapon types could be registered here
                }
            }

            // Register additional targeting types from database
            foreach (var targetingConfig in systemDatabase.DefaultTargetingConfigs)
            {
                if (!string.IsNullOrEmpty(targetingConfig.targetingType))
                {
                    // Custom targeting types could be registered here
                }
            }

            Debug.Log($"Loaded {systemDatabase.DefaultWeaponConfigs.Length} weapon configs and {systemDatabase.DefaultTargetingConfigs.Length} targeting configs");
        }

        // ============= PUBLIC API =============
        public IWeaponConfiguration CreateWeaponConfig(WeaponConfigData configData)
        {
            return weaponFactory.CreateWeaponConfig(configData);
        }

        public ITargetingConfiguration CreateTargetingConfig(TargetingConfigData configData)
        {
            return targetingFactory.CreateTargetingConfig(configData);
        }

        public void RegisterCustomWeapon(string weaponType, System.Func<IWeaponStrategy> creator)
        {
            weaponFactory.RegisterWeaponType(weaponType, creator);
        }

        public void RegisterCustomTargeting(string targetingType, System.Func<ITargetingStrategy> creator)
        {
            targetingFactory.RegisterTargetingType(targetingType, creator);
        }

        // ============= LEGACY COMPATIBILITY =============
        // Singleton pattern removed to follow SOLID principles
        // Use FindObjectOfType<ShootingSystemComposer>() or dependency injection instead

        // ============= EDITOR SUPPORT =============
        [ContextMenu("Validate Setup")]
        private void ValidateSetup()
        {
            bool isValid = ValidateConfiguration();
            Debug.Log($"ShootingSystemComposer setup validation: {(isValid ? "PASSED" : "FAILED")}");
        }

        [ContextMenu("Initialize System")]
        private void InitializeFromEditor()
        {
            Initialize();
        }

        [ContextMenu("Show Registered Shooters")]
        private void ShowRegisteredShooters()
        {
            if (shootingService != null)
            {
                Debug.Log($"Registered shooters: {shootingService.RegisteredShooterCount}");
            }
        }
    }

    // ============= COMPATIBILITY BRIDGE =============
    [System.Obsolete("ShootComponent is deprecated. Use ShooterComponent instead.")]
    public class ShootComponentCompat : MonoBehaviour
    {
        private ShootingSystemComposer composer;
        private ShooterComponent shooterComponent;

        [SerializeField] private ObjectPool projectilePool;
        [SerializeField] private ObjectPool explosionVFXPool;
        [SerializeField] private float shootForce = 15;
        [SerializeField] private float damage = 15;

        private void Awake()
        {
            composer = FindObjectOfType<ShootingSystemComposer>();
            if (composer == null)
            {
                Debug.LogError("ShootComponentCompat: No ShootingSystemComposer found in scene!");
                return;
            }

            // Create new ShooterComponent and configure it
            shooterComponent = gameObject.AddComponent<ShooterComponent>();
            
            // Transfer configuration
            var weaponConfigData = new WeaponConfigData
            {
                weaponType = "SingleShot",
                shootForce = shootForce,
                damage = damage,
                projectilePool = projectilePool,
                explosionVFXPool = explosionVFXPool
            };

            // Set configuration via reflection or public methods if available
        }

        public void Shoot(Vector2 direction, float angleOffset = 0)
        {
            shooterComponent?.ShooterController?.Shoot(direction, angleOffset);
        }

        public void Shoot()
        {
            shooterComponent?.ShooterController?.Shoot();
        }
    }

    [System.Obsolete("AIShooter is deprecated. Use ShooterComponent with AI settings instead.")]
    public class AIShooterCompat : MonoBehaviour
    {
        private ShooterComponent shooterComponent;

        [SerializeField] private float shootRange = 30;

        private void Awake()
        {
            // Create new ShooterComponent and configure for AI
            shooterComponent = gameObject.AddComponent<ShooterComponent>();
            shooterComponent.SetAI(true);
            shooterComponent.SetTargetingType("Player");
        }

        public void Shoot(float angleOffset = 0)
        {
            shooterComponent?.ShooterController?.Shoot();
        }
    }
}