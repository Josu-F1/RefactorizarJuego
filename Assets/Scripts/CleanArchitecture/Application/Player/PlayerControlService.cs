using System;
using CleanArchitecture.Domain.Player;

namespace CleanArchitecture.Application.Player
{
    /// <summary>
    /// Caso de uso: traduce inputs externos a intenciones y notifica a los ejecutores.
    /// </summary>
    public class PlayerControlService
    {
        private readonly PlayerControl control;
        private readonly IPlayerExecutor executor;

        public PlayerControlService(PlayerControl control, IPlayerExecutor executor)
        {
            this.control = control ?? throw new ArgumentNullException(nameof(control));
            this.executor = executor ?? throw new ArgumentNullException(nameof(executor));

            this.control.OnIntentChanged += HandleIntentChanged;
        }

        public void SetIntent(PlayerIntent intent)
        {
            control.SetIntent(intent);
        }

        private void HandleIntentChanged(PlayerIntent intent)
        {
            switch (intent)
            {
                case PlayerIntent.MoveUp:
                    executor.Move(0, 1);
                    break;
                case PlayerIntent.MoveDown:
                    executor.Move(0, -1);
                    break;
                case PlayerIntent.MoveLeft:
                    executor.Move(-1, 0);
                    break;
                case PlayerIntent.MoveRight:
                    executor.Move(1, 0);
                    break;
                case PlayerIntent.Shoot:
                    executor.Shoot();
                    break;
                case PlayerIntent.DropBomb:
                    executor.DropBomb();
                    break;
                case PlayerIntent.Idle:
                default:
                    executor.Stop();
                    break;
            }
        }
    }

    /// <summary>
    /// Contrato que implementan los adaptadores hacia sistemas legacy (movimiento/disparo/bombas).
    /// </summary>
    public interface IPlayerExecutor
    {
        void Move(float x, float y);
        void Stop();
        void Shoot();
        void DropBomb();
    }
}
