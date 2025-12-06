using UnityEngine;
using CleanArchitecture.Infrastructure.DependencyInjection;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.Services;

namespace CleanArchitecture.Presentation
{
    /// <summary>
    /// Punto de entrada de la aplicación
    /// Inicializa todos los servicios y el ServiceLocator
    /// DEBE estar en la primera escena que se carga
    /// </summary>
    public class GameBootstrapper : MonoBehaviour
    {
        [Header("Configuración del Juego")]
        [SerializeField] private int requiredScore = 200;
        [SerializeField] private float endGameDelay = 2f;

        [Header("Debug")]
        [SerializeField] private bool showDebugLogs = true;

        private void Awake()
        {
            // Asegurar que solo hay una instancia
            if (FindObjectsOfType<GameBootstrapper>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            InitializeServices();
        }

        private void InitializeServices()
        {
            if (showDebugLogs)
                Debug.Log("[GameBootstrapper] 🚀 Inicializando servicios...");

            var locator = ServiceLocator.Instance;

            // Registrar servicios core
            var gameStateService = new GameStateService(endGameDelay);
            locator.Register<IGameStateService>(gameStateService);

            var scoreService = new ScoreService(requiredScore);
            locator.Register<IScoreService>(scoreService);

            // Conectar Score con GameState (cuando se alcance el objetivo, victoria)
            scoreService.OnGoalReached += () => gameStateService.TriggerVictory();

            // Registrar AudioService
            var audioService = new Infrastructure.Services.AudioService(transform);
            locator.Register<CleanArchitecture.Application.Services.IAudioService>(audioService);

            // Registrar PoolService
            var poolService = new Infrastructure.Services.PoolService(transform);
            locator.Register<CleanArchitecture.Application.Services.IPoolService>(poolService);

            // Registrar PlayerService
            var playerService = new Infrastructure.Services.PlayerService();
            locator.Register<CleanArchitecture.Application.Services.IPlayerService>(playerService);

            // TODO: Descomentar cuando Unity recompile (FASE 1)
            // Registrar ShootingService
            //var shootingService = new Infrastructure.Services.ShootingService();
            //locator.Register<CleanArchitecture.Application.Services.IShootingService>(shootingService);

            // Registrar LightService (necesita coroutineRunner)
            //var lightService = new Infrastructure.Services.LightService(this);
            //locator.Register<CleanArchitecture.Application.Services.ILightService>(lightService);

            // Registrar BlockService
            //var blockService = new Infrastructure.Services.BlockService();
            //locator.Register<CleanArchitecture.Application.Services.IBlockService>(blockService);

            if (showDebugLogs)
            {
                Debug.Log("[GameBootstrapper] ✅ GameStateService registrado");
                Debug.Log("[GameBootstrapper] ✅ ScoreService registrado");
                Debug.Log("[GameBootstrapper] ✅ AudioService registrado");
                Debug.Log("[GameBootstrapper] ✅ PoolService registrado");
                Debug.Log("[GameBootstrapper] ✅ PlayerService registrado");
                //Debug.Log("[GameBootstrapper] ✅ ShootingService registrado"); // TODO: Descomentar FASE 1
                //Debug.Log("[GameBootstrapper] ✅ LightService registrado"); // TODO: Descomentar FASE 1
                //Debug.Log("[GameBootstrapper] ✅ BlockService registrado"); // TODO: Descomentar FASE 1
                Debug.Log($"[GameBootstrapper] 📊 Objetivo: {requiredScore} puntos");
            }

            // TODO: Registrar InputService cuando esté implementado

            // Conectar eventos legacy a servicios
            SetupLegacyAdapters();

            if (showDebugLogs)
                Debug.Log("[GameBootstrapper] 🎮 Sistema iniciado correctamente");
        }

        private void SetupLegacyAdapters()
        {
            // Añadir EnemyScoreConnector
            if (GetComponent<Adapters.EnemyScoreConnector>() == null)
            {
                gameObject.AddComponent<Adapters.EnemyScoreConnector>();
                if (showDebugLogs)
                    Debug.Log("[GameBootstrapper] ✅ EnemyScoreConnector añadido");
            }

            // Añadir LegacySoundAdapter
            if (GetComponent<Adapters.LegacySoundAdapter>() == null)
            {
                gameObject.AddComponent<Adapters.LegacySoundAdapter>();
                if (showDebugLogs)
                    Debug.Log("[GameBootstrapper] ✅ LegacySoundAdapter añadido");
            }

            // Añadir LegacyPoolAdapter
            if (GetComponent<Adapters.LegacyPoolAdapter>() == null)
            {
                gameObject.AddComponent<Adapters.LegacyPoolAdapter>();
                if (showDebugLogs)
                    Debug.Log("[GameBootstrapper] ✅ LegacyPoolAdapter añadido");
            }

            // Añadir PlayerDeathConnector
            if (GetComponent<Adapters.PlayerDeathConnector>() == null)
            {
                gameObject.AddComponent<Adapters.PlayerDeathConnector>();
                if (showDebugLogs)
                    Debug.Log("[GameBootstrapper] ✅ PlayerDeathConnector añadido");
            }
        }

        private void OnDestroy()
        {
            // Limpiar servicios al destruir
            ServiceLocator.Reset();
        }

#if UNITY_EDITOR
        [ContextMenu("Test Victory")]
        private void TestVictory()
        {
            var gameState = ServiceLocator.Instance.Get<IGameStateService>();
            gameState?.TriggerVictory();
        }

        [ContextMenu("Test Defeat")]
        private void TestDefeat()
        {
            var gameState = ServiceLocator.Instance.Get<IGameStateService>();
            gameState?.TriggerDefeat();
        }

        [ContextMenu("Add 50 Score")]
        private void TestAddScore()
        {
            var score = ServiceLocator.Instance.Get<IScoreService>();
            score?.AddScore(50);
        }
#endif
    }
}
