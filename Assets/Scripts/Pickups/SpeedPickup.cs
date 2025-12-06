#pragma warning disable CS0618 // El tipo o miembro está obsoleto
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ⚠️ TRANSITIONAL: Use PickupSystemComposer with SpeedPickupEffect instead
/// </summary>
[System.Obsolete("⚠️ TRANSITIONAL: Use PickupSystemComposer when possible. Legacy support enabled.", false)]
public class SpeedPickup : MonoBehaviour, IPickup
{
    [SerializeField] private float speed = 0.25f;

    public void GrantEffect(Player player)
    {
        player.GetComponentInChildren<MoveComponent>().MoveSpeed += speed;
    }
}
