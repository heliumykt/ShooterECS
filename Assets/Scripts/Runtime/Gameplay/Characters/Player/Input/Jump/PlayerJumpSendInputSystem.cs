using Leopotam.Ecs;
using UnityEngine;

namespace MyProject.Runtime.Gameplay
{
    sealed class PlayerJumpSendInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, JumpComponent> jumpFilter = null;

        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            foreach (var i in jumpFilter)
            {
                ref var entity = ref jumpFilter.GetEntity(i);
                entity.Get<JumpEvent>();
            }
        }
    }
}