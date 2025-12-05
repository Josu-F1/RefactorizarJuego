using UnityEngine;
using CleanArchitecture.Application.Targeting;
using CleanArchitecture.Infrastructure.Targeting;

namespace CleanArchitecture.Presentation.Targeting
{
    /// <summary>
    /// MonoBehaviour opcional para reemplazar FollowPlayer legacy sin tocar escenas.
    /// Añádelo a un GO y seguirá al Player.Instance.
    /// </summary>
    public class FollowAdapter : MonoBehaviour
    {
        private FollowService service;

        private void Awake()
        {
            var targetProvider = new PlayerInstanceTargetProvider();
            service = new FollowService(transform, targetProvider);
        }

        private void LateUpdate()
        {
            service?.Tick();
        }
    }
}
