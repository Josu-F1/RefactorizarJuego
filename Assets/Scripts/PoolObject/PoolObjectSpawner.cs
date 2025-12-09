#pragma warning disable CS0618 // Type or member is obsolete
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    public void Spawn()
    {
        objectPool.Spawn(transform.position);
    }
}
