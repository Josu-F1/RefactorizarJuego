using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ❌ DEPRECATED: Use PickupSystemComposer with HealthPickupEffect instead
/// </summary>
[System.Obsolete("❌ DEPRECATED: Use PickupSystemComposer (Clean Architecture) instead. This legacy class is NO LONGER SUPPORTED.", true)]
public class HealthPickup : MonoBehaviour, IPickup
{
    [SerializeField] private float healAmount = 20;
    public void GrantEffect(Player player)
    {
        player.GetComponent<global::Health>().Heal(healAmount);
    }
}
