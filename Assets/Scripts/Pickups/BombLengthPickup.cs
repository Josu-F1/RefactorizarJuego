using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ❌ DEPRECATED: Use PickupSystemComposer with BombLengthPickupEffect instead
/// </summary>
[System.Obsolete("❌ DEPRECATED: Use PickupSystemComposer (Clean Architecture) instead. This legacy class is NO LONGER SUPPORTED.", true)]
public class BombLengthPickup : MonoBehaviour, IPickup
{
    public void GrantEffect(Player player)
    {
        BombSpawner bombSpawner = player.GetComponentInChildren<BombSpawner>();
        if (bombSpawner != null) bombSpawner.Length++;
    }
}
