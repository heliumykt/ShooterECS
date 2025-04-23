using Leopotam.Ecs;

namespace MyProject
{
    public interface IEcsRunLateSystem : IEcsSystem
    {
        void RunLate(EcsSystems systems);
    }
}