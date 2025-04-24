using Leopotam.Ecs;
using UnityEngine;

namespace MyProject.Runtime.Gameplay
{
    sealed class PlayerJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, JumpComponent, JumpEvent> _jumpFilter = null;

        public void Run()
        {
            foreach (var i in _jumpFilter)
            {
                ref var entity = ref _jumpFilter.GetEntity(i);
                ref var movable = ref entity.Get<MovableComponent>();
                ref var jumpComponent = ref _jumpFilter.Get2(i);
                ref var groundComponent = ref _jumpFilter.Get3(i);

                if (!entity.Has<IsGroundedComponent>()) continue;
                movable.Velocity.y = Mathf.Sqrt(jumpComponent.Force);
            }
        }
    }
}