using System;
using CleanArchitecture.Domain.Targeting;
using UnityEngine;

namespace CleanArchitecture.Application.Targeting
{
    /// <summary>
    /// Caso de uso: hace que un transform siga a un target provider.
    /// </summary>
    public class FollowService
    {
        private readonly Transform follower;
        private readonly ITargetProvider targetProvider;

        public FollowService(Transform follower, ITargetProvider targetProvider)
        {
            this.follower = follower ? follower : throw new ArgumentNullException(nameof(follower));
            this.targetProvider = targetProvider ?? throw new ArgumentNullException(nameof(targetProvider));
        }

        public void Tick()
        {
            follower.position = targetProvider.GetTargetPosition();
        }
    }
}
