namespace CleanArchitecture.Domain.Light
{
    /// <summary>
    /// Contrato para encender/apagar luces globales.
    /// </summary>
    public interface ILightRepository
    {
        void SetEnabled(bool enabled);
        LightState GetState();
    }
}
