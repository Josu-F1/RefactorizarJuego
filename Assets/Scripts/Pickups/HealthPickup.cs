#pragma warning disable CS0618 // El tipo o miembro está obsoleto
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ⚠️ TRANSITIONAL: Use PickupSystemComposer with HealthPickupEffect instead
/// </summary>
[System.Obsolete("⚠️ TRANSITIONAL: Use PickupSystemComposer when possible. Legacy support enabled.", false)]
public class HealthPickup : MonoBehaviour, IPickup
{
    [SerializeField] private float healAmount = 20;
    public void GrantEffect(Player player)
    {
        player.GetComponent<global::Health>().Heal(healAmount);
    }
}
