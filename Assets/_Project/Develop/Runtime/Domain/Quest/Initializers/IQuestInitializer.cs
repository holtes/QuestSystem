using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.Quest.Initializers
{
    public interface IQuestInitializer
    {
        EcsEntity Init(EcsWorld world, int id);
    }
}