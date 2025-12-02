using UnityEngine;

/// <summary>
/// Interface para fábricas de bombas
/// Patrón: Factory Pattern - Abstrae la creación de bombas
/// </summary>
public interface IBombFactory
{
    Bomb CreateBomb(Vector2 position, BombConfiguration config, CharacterType characterType);
    Bomb CreateThrowableBomb(Vector2 destination, float throwSpeed, BombConfiguration config, CharacterType characterType);
}