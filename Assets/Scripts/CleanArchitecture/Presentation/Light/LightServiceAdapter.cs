using UnityEngine;
using CleanArchitecture.Application.Light;
using CleanArchitecture.Infrastructure.Light;

namespace CleanArchitecture.Presentation.Light
{
    /// <summary>
    /// MonoBehaviour opcional para controlar la luz global usando LightService.
    /// </summary>
    public class LightServiceAdapter : MonoBehaviour
    {
        [SerializeField] private global::GlobalLight globalLight;

        private LightService service;

        private void Awake()
        {
            if (globalLight == null)
            {
                globalLight = FindObjectOfType<global::GlobalLight>();
            }

            if (globalLight != null)
            {
                var repo = new GlobalLightRepository(globalLight);
                service = new LightService(repo);
            }
        }

        public void TurnOn() => service?.TurnOn();
        public void TurnOff() => service?.TurnOff();
        public bool IsEnabled() => service?.GetState().Enabled ?? false;
    }
}
