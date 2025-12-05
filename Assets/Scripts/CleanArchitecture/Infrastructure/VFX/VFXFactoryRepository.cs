using System;
using UnityEngine;
using CleanArchitecture.Domain.VFX;

/// <summary>
/// Adaptador que reutiliza una factory de VFX legacy vía reflexión (sin depender del tipo concreto).
/// </summary>
namespace CleanArchitecture.Infrastructure.VFX
{
    public class VFXFactoryRepository : IVFXRepository
    {
        private readonly UnityEngine.Object factory;

        public VFXFactoryRepository(UnityEngine.Object factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public GameObject Spawn(EffectRequest request)
        {
            var type = factory.GetType();
            var method = type.GetMethod("Spawn", new Type[] { typeof(string), typeof(Vector3) });
            if (method != null)
            {
                var result = method.Invoke(factory, new object[] { request.EffectId, request.Position }) as GameObject;
                return result;
            }
            return null;
        }
    }
}
