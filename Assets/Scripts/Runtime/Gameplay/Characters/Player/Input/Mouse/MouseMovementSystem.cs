using Leopotam.Ecs;
using UnityEngine;


namespace MyProject.Runtime.Gameplay
{
    sealed class MouseMovementSystem : IEcsInitSystem, IEcsRunLateSystem
    {
        private readonly EcsFilter<PlayerTag> _playerFilter = null;
        private readonly EcsFilter<PlayerTag, MouseLookDirectionComponent> _lookFilter = null;

        private Transform _modelTransform;
        private float _rotationX = 0f;
        private float _rotationY = 0f;
        
        public void Init()
        {
            foreach (var i in _playerFilter)
            {
                ref var entity = ref _playerFilter.GetEntity(i);
                ref var model = ref entity.Get<ModelComponent>();

                _modelTransform = model.ModelTransform;
            }
        }
        public void RunLate(EcsSystems systems)
        {
            foreach (var i in _lookFilter)
            {
                ref var lookComponent = ref _lookFilter.Get2(i);

                float axisX = lookComponent.Direction.x;
                float axisY = lookComponent.Direction.y;

                _rotationY += axisX * lookComponent.Sensitivity;
                _rotationX -= axisY * lookComponent.Sensitivity;
                _rotationX = Mathf.Clamp(_rotationX, -lookComponent.MaxAngle, lookComponent.MaxAngle);

                lookComponent.CameraTransform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0f);
                _modelTransform.rotation = Quaternion.Euler(0, _rotationY, 0);
            }
        }
    }
}