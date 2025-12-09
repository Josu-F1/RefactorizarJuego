#pragma warning disable CS0618 // Type or member is obsolete
using System;
using UnityEngine;

/// <summary>
/// Adaptador que convierte BombSpawner en IBombStats
/// Patrón: Adapter Pattern para interface segregation
/// </summary>
[System.Serializable]
public class BombStatsAdapter : IBombStats
{
    private BombSpawner bombSpawner;

    public BombStatsAdapter(BombSpawner bombSpawner)
    {
        this.bombSpawner = bombSpawner;
    }

    public int BombLimit => bombSpawner.BombLimit;
    public float Damage => bombSpawner.Damage;
    public int Length => bombSpawner.Length;

    public event Action OnBombLimitChanged
    {
        add { bombSpawner.OnBombLimitChanged += value; }
        remove { bombSpawner.OnBombLimitChanged -= value; }
    }

    public event Action OnDamageChanged
    {
        add { bombSpawner.OnDamageChanged += value; }
        remove { bombSpawner.OnDamageChanged -= value; }
    }

    public event Action OnLengthChanged
    {
        add { bombSpawner.OnLengthChanged += value; }
        remove { bombSpawner.OnLengthChanged -= value; }
    }
}