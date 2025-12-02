using UnityEngine;

/// <summary>
/// Interface común para spawners de bomba
/// Permite que tanto BombSpawner como BombSpawnerComposer sean intercambiables
/// </summary>
public interface IBombSpawnerReference
{
    void RemoveBombPosition(Vector3 position);
}