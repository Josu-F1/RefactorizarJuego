using UnityEngine;

namespace CleanArchitecture.Domain.Bomb
{
    /// <summary>
    /// Solicitud de colocación/lanza de bomba en dominio puro.
    /// </summary>
    public readonly struct BombRequest
    {
        public readonly Vector2 Position;
        public readonly Vector2? Destination;
        public readonly float ThrowSpeed;
        public readonly float Damage;
        public readonly int Length;
        public readonly float Lifetime;
        public readonly CharacterType CharacterType;

        public BombRequest(Vector2 position, float damage, int length, float lifetime, CharacterType characterType)
        {
            Position = position;
            Destination = null;
            ThrowSpeed = 0f;
            Damage = damage;
            Length = length;
            Lifetime = lifetime;
            CharacterType = characterType;
        }

        public BombRequest(Vector2 position, Vector2 destination, float throwSpeed, float damage, int length, float lifetime, CharacterType characterType)
        {
            Position = position;
            Destination = destination;
            ThrowSpeed = throwSpeed;
            Damage = damage;
            Length = length;
            Lifetime = lifetime;
            CharacterType = characterType;
        }

        public bool IsThrowable => Destination.HasValue;
    }
}
