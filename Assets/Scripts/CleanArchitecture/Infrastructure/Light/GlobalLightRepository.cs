#pragma warning disable CS0618 // Type or member is obsolete
using CleanArchitecture.Domain.Light;
using UnityEngine;

/// <summary>
/// Adaptador que reutiliza GlobalLight legacy (o LightSystemComposer si existiera en escena).
/// </summary>
namespace CleanArchitecture.Infrastructure.Light
{
    public class GlobalLightRepository : ILightRepository
    {
        private readonly global::GlobalLight globalLight;

        public GlobalLightRepository(global::GlobalLight globalLight)
        {
            this.globalLight = globalLight;
        }

        public void SetEnabled(bool enabled)
        {
            if (globalLight == null) return;
            globalLight.gameObject.SetActive(enabled);
        }

        public LightState GetState()
        {
            bool enabled = globalLight != null && globalLight.gameObject.activeSelf;
            return new LightState(enabled);
        }
    }
}
