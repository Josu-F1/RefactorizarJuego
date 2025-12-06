using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ❌ DEPRECATED: Use PickupSystemComposer with BombLimitPickupEffect instead
/// </summary>
[System.Obsolete("❌ DEPRECATED: Use PickupSystemComposer (Clean Architecture) instead. This legacy class is NO LONGER SUPPORTED.", true)]
public class BombLimitPickup : MonoBehaviour, IPickup
{
    public void GrantEffect(Player player)
    {
        player.GetComponentInChildren<BombSpawner>().BombLimit++;
    }
}
