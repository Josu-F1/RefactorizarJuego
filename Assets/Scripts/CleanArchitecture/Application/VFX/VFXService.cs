using System;
using UnityEngine;
using CleanArchitecture.Domain.VFX;

namespace CleanArchitecture.Application.VFX
{
    /// <summary>
    /// Caso de uso para solicitar efectos visuales por id/posición.
    /// </summary>
    public class VFXService
    {
        private readonly IVFXRepository repository;

        public VFXService(IVFXRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public GameObject Spawn(string effectId, Vector3 position)
        {
            if (string.IsNullOrWhiteSpace(effectId)) return null;
            return repository.Spawn(new EffectRequest(effectId, position));
        }
    }
}
