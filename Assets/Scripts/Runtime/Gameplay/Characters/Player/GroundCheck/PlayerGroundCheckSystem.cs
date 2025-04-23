using Leopotam.Ecs;
using UnityEngine;


namespace MyProject.Runtime.Gameplay
{
    sealed class PlayerGroundCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, MovableComponent> groundFilter = null;

        public void Run()
        {
            foreach (var i in groundFilter)
            {
                ref var entity = ref groundFilter.GetEntity(i);
                ref var movableComponent = ref groundFilter.Get2(i);

                if (movableComponent.CharacterController.isGrounded)
                {
                    if (!entity.Has<IsGroundedComponent>())
                        entity.Get<IsGroundedComponent>();
                }
                else
                {
                    if (entity.Has<IsGroundedComponent>())
                        entity.Del<IsGroundedComponent>();
                }
            }
        }
    }
}