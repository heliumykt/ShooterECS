using Leopotam.Ecs;
using UnityEngine;


namespace MyProject.Runtime.Gameplay
{
    sealed class MouseMovementSystem : IEcsInitSystem, IEcsRunLateSystem
    {
        private readonly EcsFilter<PlayerTag> playerFilter = null;
        private readonly EcsFilter<PlayerTag, MouseLookDirectionComponent> lookFilter = null;

        private Transform modelTransform;
        private float rotationX = 0f;
        private float rotationY = 0f;
        public void Init()
        {
            foreach (var i in playerFilter)
            {
                ref var entity = ref playerFilter.GetEntity(i);
                ref var model = ref entity.Get<ModelComponent>();

                modelTransform = model.ModelTransform;
            }
        }
        public void RunLate(EcsSystems systems)
        {
            foreach (var i in lookFilter)
            {
                ref var lookComponent = ref lookFilter.Get2(i);

                float axisX = lookComponent.Direction.x;
                float axisY = lookComponent.Direction.y;

                rotationY += axisX * lookComponent.Sensitivity;
                rotationX -= axisY * lookComponent.Sensitivity;
                rotationX = Mathf.Clamp(rotationX, -lookComponent.MaxAngle, lookComponent.MaxAngle);

                lookComponent.CameraTransform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
                modelTransform.rotation = Quaternion.Euler(0, rotationY, 0);
            }
        }
    }
}