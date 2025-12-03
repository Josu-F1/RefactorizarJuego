using System;
using CleanArchitecture.Domain.Light;

namespace CleanArchitecture.Application.Light
{
    /// <summary>
    /// Caso de uso: controla el estado de luz global.
    /// </summary>
    public class LightService
    {
        private readonly ILightRepository repository;

        public LightService(ILightRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void TurnOn() => repository.SetEnabled(true);
        public void TurnOff() => repository.SetEnabled(false);
        public LightState GetState() => repository.GetState();
    }
}
