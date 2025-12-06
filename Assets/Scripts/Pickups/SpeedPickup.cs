#pragma warning disable CS0618 // Type or member is obsolete
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour, IPickup
{
    [SerializeField] private float speed = 0.25f;

    public void GrantEffect(Player player)
    {
        player.GetComponentInChildren<MoveComponent>().MoveSpeed += speed;
    }
}
