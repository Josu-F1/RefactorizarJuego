using UnityEngine;

namespace CleanArchitecture.Domain.VFX
{
    public interface IVFXRepository
    {
        GameObject Spawn(EffectRequest request);
    }
}
