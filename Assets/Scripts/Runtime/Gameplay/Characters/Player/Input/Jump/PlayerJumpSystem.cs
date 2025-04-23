using Leopotam.Ecs;
using UnityEngine;

namespace MyProject.Runtime.Gameplay
{
    sealed class PlayerJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, JumpComponent, JumpEvent> jumpFilter = null;

        public void Run()
        {
            foreach (var i in jumpFilter)
            {
                ref var entity = ref jumpFilter.GetEntity(i);
                ref var movable = ref entity.Get<MovableComponent>();
                ref var jumpComponent = ref jumpFilter.Get2(i);
                ref var groundComponent = ref jumpFilter.Get3(i);

                if (!entity.Has<IsGroundedComponent>()) continue;
                movable.Velocity.y = Mathf.Sqrt(jumpComponent.Force);
                Debug.Log("Jump" + movable.Velocity.y.ToString());
            }
        }
    }
}