#pragma warning disable CS0618 // Type or member is obsolete
using System;
using CleanArchitecture.Application.Player;
using UnityEngine;

/// <summary>
/// Adaptador hacia sistemas legacy de movimiento/disparo/bombas existentes.
/// No modifica scripts viejos; reusa sus componentes si están presentes.
/// </summary>
namespace CleanArchitecture.Infrastructure.Player
{
    public class LegacyPlayerExecutor : IPlayerExecutor
    {
        private readonly GameObject owner;
        private readonly IMovementExecutor movementExecutor;
        private readonly ShootComponent shootComponent;
        private readonly BombSpawner bombSpawner;

        public LegacyPlayerExecutor(GameObject owner)
        {
            this.owner = owner ?? throw new ArgumentNullException(nameof(owner));
            movementExecutor = owner.GetComponent<IMovementExecutor>();
            shootComponent = owner.GetComponent<ShootComponent>();
            bombSpawner = owner.GetComponent<BombSpawner>();
        }

        public void Move(float x, float y)
        {
            if (movementExecutor == null) return;
            var cmd = new DirectionalMoveCommand(new Vector2(x, y).normalized);
            cmd.Execute(movementExecutor);
        }

        public void Stop()
        {
            if (movementExecutor == null) return;
            var cmd = new StopMoveCommand();
            cmd.Execute(movementExecutor);
        }

        public void Shoot()
        {
            shootComponent?.Shoot();
        }

        public void DropBomb()
        {
            bombSpawner?.PlaceBomb();
        }
    }
}
