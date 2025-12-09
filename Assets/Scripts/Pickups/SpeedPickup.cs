using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ❌ DEPRECATED: Use PickupSystemComposer with SpeedPickupEffect instead
/// </summary>
[System.Obsolete("❌ DEPRECATED: Use PickupSystemComposer (Clean Architecture) instead. This legacy class is NO LONGER SUPPORTED.", true)]
public class SpeedPickup : MonoBehaviour, IPickup
{
    [SerializeField] private float speed = 0.25f;

    public void GrantEffect(Player player)
    {
        player.GetComponentInChildren<MoveComponent>().MoveSpeed += speed;
    }
}
