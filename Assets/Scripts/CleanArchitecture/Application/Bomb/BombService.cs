using System;
using CleanArchitecture.Domain.Bomb;

namespace CleanArchitecture.Application.Bomb
{
    /// <summary>
    /// Caso de uso: coordina solicitudes de bombas hacia el repositorio.
    /// </summary>
    public class BombService
    {
        private readonly IBombRepository repository;
        private readonly Func<BombRequest> defaultRequestProvider;

        public BombService(IBombRepository repository, Func<BombRequest> defaultRequestProvider)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.defaultRequestProvider = defaultRequestProvider ?? throw new ArgumentNullException(nameof(defaultRequestProvider));
        }

        public void PlaceBomb()
        {
            var request = defaultRequestProvider();
            repository.PlaceBomb(request);
        }

        public void PlaceBomb(BombRequest request)
        {
            repository.PlaceBomb(request);
        }
    }
}
