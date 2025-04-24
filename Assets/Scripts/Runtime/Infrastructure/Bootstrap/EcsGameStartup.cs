using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using MyProject.Runtime.Gameplay;


namespace MyProject.Runtime.Infrastructure
{
    public sealed class EcsGameStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _lateSystems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _lateSystems = new EcsSystems(_world);

            _systems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();

            _systems.Init();
            _lateSystems.Init();
        }
        private void AddInjections()
        {

        }
        private void AddSystems()
        {
            _systems.
                Add(new PlayerInputSystem()).
                Add(new PlayerJumpSendInputSystem()).
                Add(new MovementSystem()).
                Add(new GravitySystem()).
                Add(new PlayerGroundCheckSystem()).
                Add(new PlayerJumpSystem());



            _lateSystems
                .Add(new PlayerMouseInputSystem()).
                Add(new MouseMovementSystem());
        }
        private void AddOneFrames()
        {
            _systems.OneFrame<JumpEvent>();
        }
        private void Update()
        {
            _systems.Run();
        }
        private void LateUpdate()
        {
            var systemsList = _lateSystems.GetAllSystems();

            for (int i = 0; i < systemsList.Count; i++)
            {
                if (systemsList.Items[i] is IEcsRunLateSystem lateSystem)
                {
                    lateSystem.RunLate(_lateSystems);
                }
            }
        }
        private void OnDestroy()
        {
            if (_systems == null) return;

            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }
}