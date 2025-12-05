using UnityEngine;

namespace CleanArchitecture.Domain.VFX
{
    public readonly struct EffectRequest
    {
        public readonly string EffectId;
        public readonly Vector3 Position;

        public EffectRequest(string effectId, Vector3 position)
        {
            EffectId = effectId;
            Position = position;
        }
    }
}
