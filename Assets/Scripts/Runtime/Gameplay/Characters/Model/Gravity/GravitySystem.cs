using Leopotam.Ecs;
using UnityEngine;


namespace MyProject.Runtime.Gameplay
{
    sealed class GravitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableComponent, GravityComponent> groundFilter = null;

        public void Run()
        {
            foreach (var i in groundFilter)
            {
                ref var movableComponent = ref groundFilter.Get1(i);
                ref var gravityComponent = ref groundFilter.Get2(i);
                ref var characterController = ref movableComponent.CharacterController;
                ref var velocity = ref movableComponent.Velocity;

                velocity.y += gravityComponent.Gravity * Time.deltaTime;

                characterController.Move(velocity * Time.deltaTime);
            }
        }
    }
}