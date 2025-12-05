using System;
using UnityEngine;

/// <summary>
/// Adaptador que convierte BombSpawnerComposer en IBombStats
/// Patrón: Adapter Pattern para interface segregation
/// </summary>
[System.Serializable]
public class BombSpawnerComposerStatsAdapter : IBombStats
{
    private BombSpawnerComposer bombSpawnerComposer;

    public BombSpawnerComposerStatsAdapter(BombSpawnerComposer bombSpawnerComposer)
    {
        this.bombSpawnerComposer = bombSpawnerComposer;
    }

    public int BombLimit => bombSpawnerComposer.BombLimit;
    public float Damage => bombSpawnerComposer.Damage;
    public int Length => bombSpawnerComposer.Length;

    public event Action OnBombLimitChanged
    {
        add { bombSpawnerComposer.OnBombLimitChanged += value; }
        remove { bombSpawnerComposer.OnBombLimitChanged -= value; }
    }

    public event Action OnDamageChanged
    {
        add { bombSpawnerComposer.OnDamageChanged += value; }
        remove { bombSpawnerComposer.OnDamageChanged -= value; }
    }

    public event Action OnLengthChanged
    {
        add { bombSpawnerComposer.OnLengthChanged += value; }
        remove { bombSpawnerComposer.OnLengthChanged -= value; }
    }
}