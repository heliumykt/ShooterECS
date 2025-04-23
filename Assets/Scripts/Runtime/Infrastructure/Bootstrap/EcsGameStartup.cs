using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using MyProject.Runtime.Gameplay;


namespace MyProject.Runtime.Infrastructure
{
    public sealed class EcsGameStartup : MonoBehaviour
    {
        private EcsWorld world;
        private EcsSystems systems;
        private EcsSystems lateSystems;

        private void Start()
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);
            lateSystems = new EcsSystems(world);

            systems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();

            systems.Init();
            lateSystems.Init();
        }
        private void AddInjections()
        {

        }
        private void AddSystems()
        {
            systems.
                Add(new PlayerInputSystem()).
                Add(new PlayerJumpSendInputSystem()).
                Add(new MovementSystem()).
                Add(new GravitySystem()).
                Add(new PlayerGroundCheckSystem()).
                Add(new PlayerJumpSystem());



            lateSystems
                .Add(new PlayerMouseInputSystem()).
                Add(new MouseMovementSystem());
        }
        private void AddOneFrames()
        {
            systems.OneFrame<JumpEvent>();
        }
        private void Update()
        {
            systems.Run();
        }
        private void LateUpdate()
        {
            var systemsList = lateSystems.GetAllSystems();

            for (int i = 0; i < systemsList.Count; i++)
            {
                if (systemsList.Items[i] is IEcsRunLateSystem lateSystem)
                {
                    lateSystem.RunLate(lateSystems);
                }
            }
        }
        private void OnDestroy()
        {
            if (systems == null) return;

            systems.Destroy();
            systems = null;
            world.Destroy();
            world = null;
        }
    }
}