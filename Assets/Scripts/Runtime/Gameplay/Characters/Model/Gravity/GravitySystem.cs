using Leopotam.Ecs;
using UnityEngine;


namespace MyProject.Runtime.Gameplay
{
    sealed class GravitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableComponent, GravityComponent> _groundFilter = null;

        public void Run()
        {
            foreach (var i in _groundFilter)
            {
                ref var movableComponent = ref _groundFilter.Get1(i);
                ref var gravityComponent = ref _groundFilter.Get2(i);
                ref var characterController = ref movableComponent.CharacterController;
                ref var velocity = ref movableComponent.Velocity;

                velocity.y += gravityComponent.Gravity * Time.deltaTime;

                characterController.Move(velocity * Time.deltaTime);
            }
        }
    }
}