using UnityEngine;
using CleanArchitecture.Presentation.Score;
using CleanArchitecture.Presentation.Health;
using CleanArchitecture.Presentation.Shooting;
using CleanArchitecture.Presentation.Bomb;
using CleanArchitecture.Presentation.Pool;

namespace CleanArchitecture.Presentation.Bootstrap
{
    /// <summary>
    /// Componente opcional para centralizar referencias a los adapters Clean Architecture.
    /// No hace wiring automático para no alterar escenas; sirve como punto único en una escena piloto.
    /// </summary>
    public class CleanArchitecturePilot : MonoBehaviour
    {
        [Header("Adapters (opcionales)")]
        [SerializeField] private ScoreServiceAdapter scoreAdapter;
        [SerializeField] private HealthServiceAdapter healthAdapter;
        [SerializeField] private ShootingServiceAdapter shootingAdapter;
        [SerializeField] private BombServiceAdapter bombAdapter;
        [SerializeField] private PoolServiceAdapter poolAdapter;

        private void Awake()
        {
            // Solo loguea para indicar que los adapters están presentes; no cambia comportamiento legacy.
            if (scoreAdapter != null) Debug.Log("[CA Pilot] Score adapter listo");
            if (healthAdapter != null) Debug.Log("[CA Pilot] Health adapter listo");
            if (shootingAdapter != null) Debug.Log("[CA Pilot] Shooting adapter listo");
            if (bombAdapter != null) Debug.Log("[CA Pilot] Bomb adapter listo");
            if (poolAdapter != null) Debug.Log("[CA Pilot] Pool adapter listo");
        }
    }
}
