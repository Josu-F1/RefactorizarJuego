using UnityEngine;
using CleanArchitecture.Application.Player;
using CleanArchitecture.Domain.Player;
using CleanArchitecture.Infrastructure.Player;

namespace CleanArchitecture.Presentation.Player
{
    /// <summary>
    /// MonoBehaviour opcional para mapear input a intenciones y ejecutarlas en sistemas legacy.
    /// No está en escenas, no altera gameplay; se puede añadir para probar el flujo nuevo.
    /// </summary>
    public class PlayerControllerAdapter : MonoBehaviour
    {
        [Header("Input keys")]
        [SerializeField] private KeyCode up = KeyCode.W;
        [SerializeField] private KeyCode down = KeyCode.S;
        [SerializeField] private KeyCode left = KeyCode.A;
        [SerializeField] private KeyCode right = KeyCode.D;
        [SerializeField] private KeyCode shoot = KeyCode.Space;
        [SerializeField] private KeyCode dropBomb = KeyCode.B;

        private PlayerControl control;
        private PlayerControlService service;

        private void Awake()
        {
            // Detectar sistemas legacy en el mismo GO
            var executor = new LegacyPlayerExecutor(gameObject);
            control = new PlayerControl();
            service = new PlayerControlService(control, executor);
        }

        private void Update()
        {
            // Solo lee teclado; no intercepta eventos legacy. No rompe nada si no se añade a escena.
            if (Input.GetKeyDown(up)) service.SetIntent(PlayerIntent.MoveUp);
            else if (Input.GetKeyDown(down)) service.SetIntent(PlayerIntent.MoveDown);
            else if (Input.GetKeyDown(left)) service.SetIntent(PlayerIntent.MoveLeft);
            else if (Input.GetKeyDown(right)) service.SetIntent(PlayerIntent.MoveRight);

            if (Input.GetKeyUp(up) || Input.GetKeyUp(down) || Input.GetKeyUp(left) || Input.GetKeyUp(right))
            {
                service.SetIntent(PlayerIntent.Idle);
            }

            if (Input.GetKeyDown(shoot)) service.SetIntent(PlayerIntent.Shoot);
            if (Input.GetKeyDown(dropBomb)) service.SetIntent(PlayerIntent.DropBomb);
        }
    }
}
