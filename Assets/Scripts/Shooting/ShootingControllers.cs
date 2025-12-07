#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;
using ShootingSystem.Interfaces;
using ShootingSystem.Strategies;
using ShootingSystem.Factory;

namespace ShootingSystem.Controllers
{
    // ============= SHOOTER CONTROLLER =============
    [System.Serializable]
    public class ShooterController : IShooterController
    {
        private IWeaponStrategy weaponStrategy;
        private ITargetingStrategy targetingStrategy;
        private IWeaponConfiguration weaponConfig;
        private ITargetingConfiguration targetingConfig;
        private IProjectileFactory projectileFactory;
        private Transform shootPoint;

        public IWeaponConfiguration WeaponConfig 
        { 
            get => weaponConfig;
            set => weaponConfig = value;
        }

        public ShooterController(Transform shootPoint, IProjectileFactory factory)
        {
            this.shootPoint = shootPoint ?? throw new System.ArgumentNullException(nameof(shootPoint));
            this.projectileFactory = factory ?? throw new System.ArgumentNullException(nameof(factory));
            
            // Default strategies
            weaponStrategy = new SingleShotWeaponStrategy();
            targetingStrategy = new DirectionalTargetingStrategy();
        }

        public void SetWeaponStrategy(IWeaponStrategy strategy)
        {
            weaponStrategy = strategy ?? throw new System.ArgumentNullException(nameof(strategy));
        }

        public void SetTargetingStrategy(ITargetingStrategy targeting)
        {
            targetingStrategy = targeting ?? throw new System.ArgumentNullException(nameof(targeting));
        }

        public void SetTargetingConfiguration(ITargetingConfiguration config)
        {
            targetingConfig = config;
        }

        public bool CanShoot()
        {
            return weaponStrategy != null && 
                   weaponConfig != null && 
                   weaponStrategy.CanShoot(weaponConfig) &&
                   targetingStrategy.HasValidTarget(shootPoint, targetingConfig);
        }

        public void Shoot(Vector2 direction, float angleOffset = 0)
        {
            if (!CanShoot()) return;

            // Apply angle offset to direction
            if (angleOffset != 0)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) + angleOffset * Mathf.Deg2Rad;
                direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            }

            weaponStrategy.Shoot(projectileFactory, shootPoint, direction, weaponConfig);
        }

        public void Shoot()
        {
            if (!CanShoot()) return;

            Vector2 direction = targetingStrategy.GetTargetDirection(shootPoint, targetingConfig);
            weaponStrategy.Shoot(projectileFactory, shootPoint, direction, weaponConfig);
        }
    }

    // ============= SHOOTER INPUT HANDLERS =============
    [System.Serializable]
    public class AIShooterInput : IShooterInput
    {
        [SerializeField] private float shootInterval = 2f;
        [SerializeField] private bool continuousFire = false;
        
        private float lastShootTime = 0f;

        public bool HasManualControl => false;

        public bool ShouldShoot()
        {
            if (continuousFire)
                return Time.time >= lastShootTime + shootInterval;
            
            // Add some randomization for AI
            bool shouldShoot = Time.time >= lastShootTime + shootInterval + Random.Range(0f, 1f);
            if (shouldShoot)
                lastShootTime = Time.time;
            
            return shouldShoot;
        }

        public Vector2 GetShootDirection(Transform shooter)
        {
            // AI doesn't provide manual direction, uses targeting strategy instead
            return shooter.up;
        }

        public void SetShootInterval(float interval)
        {
            shootInterval = interval;
        }

        public void SetContinuousFire(bool continuous)
        {
            continuousFire = continuous;
        }
    }

    [System.Serializable]
    public class PlayerShooterInput : IShooterInput
    {
        [SerializeField] private KeyCode shootKey = KeyCode.Space;
        [SerializeField] private bool useMouseDirection = true;

        public bool HasManualControl => true;

        public bool ShouldShoot()
        {
            return Input.GetKey(shootKey) || Input.GetMouseButton(0);
        }

        public Vector2 GetShootDirection(Transform shooter)
        {
            if (useMouseDirection)
            {
                // Verificar que existe cámara antes de usarla (importante para tests)
                if (Camera.main == null)
                {
                    Debug.LogWarning("[ShootingControllers] Camera.main no disponible - usando dirección por defecto");
                    return shooter.up;
                }
                
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = ((Vector2)mousePos - (Vector2)shooter.position).normalized;
                return direction;
            }

            return shooter.up;
        }

        public void SetShootKey(KeyCode key)
        {
            shootKey = key;
        }

        public void SetUseMouseDirection(bool useMouse)
        {
            useMouseDirection = useMouse;
        }
    }

    // ============= SHOOTER COMPONENT =============
    public class ShooterComponent : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private WeaponConfigData weaponConfigData;
        [SerializeField] private TargetingConfigData targetingConfigData;
        [SerializeField] private string weaponType = "SingleShot";
        [SerializeField] private string targetingType = "Player";
        [SerializeField] private bool isAI = true;

        [Header("AI Settings")]
        [SerializeField] private float aiShootInterval = 2f;
        [SerializeField] private bool aiContinuousFire = false;

        [Header("Player Settings")]
        [SerializeField] private KeyCode playerShootKey = KeyCode.Space;
        [SerializeField] private bool useMouseDirection = true;

        private IShooterController shooterController;
        private IShooterInput shooterInput;
        private IShootingService shootingService;

        public IShooterController ShooterController => shooterController;
        
        private void Awake()
        {
            InitializeComponent();
        }

        private void Start()
        {
            // Find the shooting service
            shootingService = FindObjectOfType<ShootingSystemComposer>()?.ShootingService;
            
            if (shootingService != null)
            {
                shootingService.RegisterShooter(shooterController);
            }
        }

        private void Update()
        {
            if (shooterInput?.ShouldShoot() == true)
            {
                if (shooterInput.HasManualControl)
                {
                    Vector2 direction = shooterInput.GetShootDirection(transform);
                    shooterController.Shoot(direction);
                }
                else
                {
                    shooterController.Shoot();
                }
            }
        }

        private void OnDestroy()
        {
            shootingService?.UnregisterShooter(shooterController);
        }

        private void InitializeComponent()
        {
            // Create shooting service dependency
            var composer = FindObjectOfType<ShootingSystemComposer>();
            if (composer == null)
            {
                Debug.LogError("ShooterComponent requires a ShootingSystemComposer in the scene!");
                return;
            }

            // Create controller
            shooterController = new ShooterController(transform, composer.ProjectileFactory);
            
            // Set weapon strategy
            var weaponStrategy = composer.WeaponFactory.CreateWeapon(weaponType);
            shooterController.SetWeaponStrategy(weaponStrategy);

            // Set weapon configuration
            var weaponConfig = composer.WeaponFactory.CreateWeaponConfig(weaponConfigData);
            shooterController.WeaponConfig = weaponConfig;

            // Set targeting strategy
            var targetingFactory = composer.GetComponent<ShootingSystemComposer>().TargetingFactory;
            var targetingStrategy = targetingFactory.CreateTargeting(targetingType);
            shooterController.SetTargetingStrategy(targetingStrategy);

            // Create input handler
            if (isAI)
            {
                var aiInput = new AIShooterInput();
                aiInput.SetShootInterval(aiShootInterval);
                aiInput.SetContinuousFire(aiContinuousFire);
                shooterInput = aiInput;
            }
            else
            {
                var playerInput = new PlayerShooterInput();
                playerInput.SetShootKey(playerShootKey);
                playerInput.SetUseMouseDirection(useMouseDirection);
                shooterInput = playerInput;
            }
        }

        // ============= PUBLIC API =============
        public void SetWeaponType(string type)
        {
            weaponType = type;
            if (Application.isPlaying)
            {
                var composer = FindObjectOfType<ShootingSystemComposer>();
                var strategy = composer?.WeaponFactory.CreateWeapon(type);
                shooterController?.SetWeaponStrategy(strategy);
            }
        }

        public void SetTargetingType(string type)
        {
            targetingType = type;
            if (Application.isPlaying)
            {
                var composer = FindObjectOfType<ShootingSystemComposer>();
                var targetingFactory = composer?.GetComponent<ShootingSystemComposer>().TargetingFactory;
                var strategy = targetingFactory?.CreateTargeting(type);
                shooterController?.SetTargetingStrategy(strategy);
            }
        }

        public void SetAI(bool ai)
        {
            isAI = ai;
            if (Application.isPlaying)
            {
                InitializeComponent();
            }
        }
    }
}