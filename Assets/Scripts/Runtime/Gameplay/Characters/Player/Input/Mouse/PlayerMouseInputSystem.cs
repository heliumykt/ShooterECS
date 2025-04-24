using Leopotam.Ecs;
using UnityEngine;


namespace MyProject.Runtime.Gameplay
{
    sealed class PlayerMouseInputSystem : IEcsRunLateSystem
    {
        private readonly EcsFilter<PlayerTag, MouseLookDirectionComponent> _playerFilter = null;

        private float _axisX;
        private float _axisY;

        public void RunLate(EcsSystems systems)
        {
            GetAxis();

            foreach (var i in _playerFilter)
            {
                ref var mouseLookComponent = ref _playerFilter.Get2(i);
                ref var direction = ref mouseLookComponent.Direction;

                direction.x = _axisX;
                direction.y = _axisY;
            }
        }

        private void GetAxis()
        {
            _axisX = Input.GetAxis("Mouse X");
            _axisY = Input.GetAxis("Mouse Y");
        }
    }
}