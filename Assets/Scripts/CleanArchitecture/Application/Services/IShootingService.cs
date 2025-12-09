using UnityEngine;

namespace CleanArchitecture.Application.Services
{
    /// <summary>
    /// Servicio de sistema de disparos
    /// </summary>
    public interface IShootingService
    {
        /// <summary>
        /// Registra un shooter en el sistema
        /// </summary>
        void RegisterShooter(object shooter);

        /// <summary>
        /// Desregistra un shooter
        /// </summary>
        void UnregisterShooter(object shooter);

        /// <summary>
        /// Obtiene una estrategia de arma por tipo
        /// </summary>
        object GetWeaponStrategy(string weaponType);

        /// <summary>
        /// Obtiene una estrategia de targeting por tipo
        /// </summary>
        object GetTargetingStrategy(string targetingType);

        /// <summary>
        /// Crea un proyectil
        /// </summary>
        GameObject CreateProjectile(Vector3 position, Quaternion rotation);

        /// <summary>
        /// Número de shooters registrados
        /// </summary>
        int RegisteredShooterCount { get; }

        /// <summary>
        /// Limpia todos los shooters
        /// </summary>
        void ClearAllShooters();
    }
}
