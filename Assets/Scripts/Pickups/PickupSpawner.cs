using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ✅ Migrado a Clean Architecture - Usa PickupSystemComposer
/// </summary>
public class PickupSpawner : MonoBehaviour
{
    // [REMOVED] private PickupFactory pickupFactory; // Legacy class deprecated
    
    public void Spawn()
    {
        // TODO: Usar PickupSystemComposer.Instance para crear pickups
        Debug.LogWarning("[PickupSpawner] ⚠️ Legacy PickupFactory removed. Use PickupSystemComposer instead.");
        
        // Ejemplo de uso:
        // var pickupSystem = PickupSystemComposer.Instance;
        // pickupSystem.SpawnPickup(PickupType.Health, transform.position);
    }
}
