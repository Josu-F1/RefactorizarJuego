namespace CleanArchitecture.Domain.Shooting
{
    /// <summary>
    /// Contrato para ejecutar disparos; la infraestructura usa componentes legacy.
    /// </summary>
    public interface IShootingRepository
    {
        void Shoot(ShootingRequest request);
        void ShootDefault();
    }
}
