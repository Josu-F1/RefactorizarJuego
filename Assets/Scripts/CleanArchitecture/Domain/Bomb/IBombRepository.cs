using UnityEngine;

namespace CleanArchitecture.Domain.Bomb
{
    /// <summary>
    /// Contrato de dominio para colocar/arrojar bombas.
    /// Implementaciones en infraestructura (usa BombSpawner/BombSpawnerComposer).
    /// </summary>
    public interface IBombRepository
    {
        void PlaceBomb(BombRequest request);
    }
}
