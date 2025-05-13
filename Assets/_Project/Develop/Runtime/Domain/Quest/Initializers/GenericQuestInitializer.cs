using _Project.Develop.Runtime.Domain.Quest.Components;
using _Project.Develop.Runtime.Domain.Quest.Models;
using _Project.Develop.Runtime.Domain.Shared.Interfaces;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.Quest.Initializers
{
    public class GenericQuestInitializer<TData, TCondition> : IQuestInitializer
        where TData : IQuestData
        where TCondition : struct, IConditionComponent<TData>
    {
        private readonly TData _data;

        public GenericQuestInitializer(TData data)
        {
            _data = data;
        }

        public EcsEntity Init(EcsWorld world, int id)
        {
            var questEntity = world.NewEntity();
            ref var quest = ref questEntity.Get<QuestComponent>();
            quest.QuestId = id;
            quest.Description = _data.Description;

            ref var condition = ref questEntity.Get<TCondition>();
            condition.Initialize(_data);

            return questEntity;
        }
    }
}