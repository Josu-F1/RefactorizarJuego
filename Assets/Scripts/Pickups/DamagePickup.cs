using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ❌ DEPRECATED: Use PickupSystemComposer with DamagePickupEffect instead
/// </summary>
[System.Obsolete("❌ DEPRECATED: Use PickupSystemComposer (Clean Architecture) instead. This legacy class is NO LONGER SUPPORTED.", true)]
public class DamagePickup : MonoBehaviour, IPickup
{
    [SerializeField] private float damage = 5;
    public void GrantEffect(Player player)
    {
        player.GetComponentInChildren<BombSpawner>().Damage += damage;
    }
}
