using UnityEngine;
using System.Collections.Generic;
using CleanArchitecture.Application.Services;
using ShootingSystem.Interfaces;
using ShootingSystem.Strategies;
using ShootingSystem.Factory;

namespace CleanArchitecture.Infrastructure.Services
{
    /// <summary>
    /// Servicio de sistema de disparos - Clean Architecture
    /// Migrado desde ShootingSystemComposer
    /// </summary>
    public class ShootingService : CleanArchitecture.Application.Services.IShootingService
    {
        private readonly List<object> registeredShooters;
        private readonly object weaponFactory;
        private readonly object targetingFactory;
        private readonly object projectileFactory;

        public int RegisteredShooterCount => registeredShooters.Count;

        public ShootingService()
        {
            registeredShooters = new List<object>();
            
            // Crear las factories internas
            try
            {
                var weaponFactoryType = System.Type.GetType("ShootingSystem.Factory.WeaponFactory, Assembly-CSharp");
                weaponFactory = weaponFactoryType != null ? System.Activator.CreateInstance(weaponFactoryType) : null;

                var targetingFactoryType = System.Type.GetType("ShootingSystem.Factory.TargetingFactory, Assembly-CSharp");
                targetingFactory = targetingFactoryType != null ? System.Activator.CreateInstance(targetingFactoryType) : null;
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"[ShootingService] Error creating factories: {ex.Message}");
            }
        }

        public void RegisterShooter(object shooter)
        {
            if (shooter != null && !registeredShooters.Contains(shooter))
            {
                registeredShooters.Add(shooter);
                Debug.Log($"[ShootingService] Shooter registered. Total: {registeredShooters.Count}");
            }
        }

        public void UnregisterShooter(object shooter)
        {
            if (registeredShooters.Remove(shooter))
            {
                Debug.Log($"[ShootingService] Shooter unregistered. Total: {registeredShooters.Count}");
            }
        }

        public object GetWeaponStrategy(string weaponType)
        {
            if (weaponFactory == null)
            {
                Debug.LogWarning("[ShootingService] WeaponFactory not initialized");
                return null;
            }

            try
            {
                var method = weaponFactory.GetType().GetMethod("CreateWeapon");
                return method?.Invoke(weaponFactory, new object[] { weaponType });
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"[ShootingService] Error getting weapon strategy: {ex.Message}");
                return null;
            }
        }

        public object GetTargetingStrategy(string targetingType)
        {
            if (targetingFactory == null)
            {
                Debug.LogWarning("[ShootingService] TargetingFactory not initialized");
                return null;
            }

            try
            {
                var method = targetingFactory.GetType().GetMethod("CreateTargeting");
                return method?.Invoke(targetingFactory, new object[] { targetingType });
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"[ShootingService] Error getting targeting strategy: {ex.Message}");
                return null;
            }
        }

        public GameObject CreateProjectile(Vector3 position, Quaternion rotation)
        {
            // Por ahora retorna null - esto se mejorará cuando migremos el pool system
            Debug.LogWarning("[ShootingService] CreateProjectile not yet implemented - requires PoolService integration");
            return null;
        }

        public void ClearAllShooters()
        {
            registeredShooters.Clear();
            Debug.Log("[ShootingService] All shooters cleared");
        }
    }
}
