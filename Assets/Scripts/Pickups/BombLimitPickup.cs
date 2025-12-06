#pragma warning disable CS0618 // El tipo o miembro está obsoleto
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ⚠️ TRANSITIONAL: Use PickupSystemComposer with BombLimitPickupEffect instead
/// </summary>
[System.Obsolete("⚠️ TRANSITIONAL: Use PickupSystemComposer when possible. Legacy support enabled.", false)]
public class BombLimitPickup : MonoBehaviour, IPickup
{
    public void GrantEffect(Player player)
    {
        player.GetComponentInChildren<BombSpawner>().BombLimit++;
    }
}
