using System;

namespace CleanArchitecture.Domain.Player
{
    /// <summary>
    /// Agregado simple para controlar la intención de movimiento/disparo del jugador.
    /// No depende de Unity; recibe comandos abstractos.
    /// </summary>
    public class PlayerControl
    {
        public event Action<PlayerIntent> OnIntentChanged;

        private PlayerIntent currentIntent;

        public PlayerIntent CurrentIntent => currentIntent;

        public PlayerControl()
        {
            currentIntent = PlayerIntent.Idle;
        }

        public void SetIntent(PlayerIntent intent)
        {
            if (intent.Equals(currentIntent)) return;
            currentIntent = intent;
            OnIntentChanged?.Invoke(currentIntent);
        }
    }

    /// <summary>
    /// Representa la intención de control a alto nivel (para que capas superiores decidan cómo ejecutar).
    /// </summary>
    public enum PlayerIntent
    {
        Idle,
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        Shoot,
        DropBomb
    }
}
