using _Project.Develop.Runtime.Domain.Quest.Initializers;
using _Project.Develop.Runtime.Domain.Shared.Requests;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.Quest.Systems
{
    public sealed class InitQuestsDataSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;

        private readonly IQuestInitializer[] _questInitializers;

        public InitQuestsDataSystem(IQuestInitializer[] questInitializers)
        {
            _questInitializers = questInitializers;
        }

        public void Init()
        {
            for (int i = 0; i < _questInitializers.Length; i++)
            {
                var questEntity = _questInitializers[i].Init(_world, i);

                questEntity.Get<SpawnQuestViewRequest>();
            }
        }
    }
}