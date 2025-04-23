using Leopotam.Ecs;
using UnityEngine;


namespace MyProject.Runtime.Gameplay
{
    sealed class PlayerMouseInputSystem : IEcsRunLateSystem
    {
        private readonly EcsFilter<PlayerTag, MouseLookDirectionComponent> playerFilter = null;

        private float axisX;
        private float axisY;

        public void RunLate(EcsSystems systems)
        {
            GetAxis();

            foreach (var i in playerFilter)
            {
                ref var mouseLookComponent = ref playerFilter.Get2(i);
                ref var direction = ref mouseLookComponent.Direction;

                direction.x = axisX;
                direction.y = axisY;
            }
        }

        private void GetAxis()
        {
            axisX = Input.GetAxis("Mouse X");
            axisY = Input.GetAxis("Mouse Y");
        }
    }
}