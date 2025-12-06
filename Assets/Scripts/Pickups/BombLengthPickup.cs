#pragma warning disable CS0618 // El tipo o miembro está obsoleto
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ⚠️ TRANSITIONAL: Use PickupSystemComposer with BombLengthPickupEffect instead
/// </summary>
[System.Obsolete("⚠️ TRANSITIONAL: Use PickupSystemComposer when possible. Legacy support enabled.", false)]
public class BombLengthPickup : MonoBehaviour, IPickup
{
    public void GrantEffect(Player player)
    {
        BombSpawner bombSpawner = player.GetComponentInChildren<BombSpawner>();
        if (bombSpawner != null) bombSpawner.Length++;
    }
}
