using _Project.Develop.Runtime.Domain.Quest.Components;
using _Project.Develop.Runtime.Domain.Quest.Events;
using _Project.Develop.Runtime.Domain.Shared.Requests;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.Quest.Systems
{
    public sealed class QuestCompleteSystem : IEcsRunSystem
    {
        private readonly EcsFilter<QuestComponent, QuestCompletedEvent> _questFilter;
        private readonly EcsWorld _world;

        public void Run()
        {
            foreach (var i in _questFilter)
            {
                ref var quest = ref _questFilter.Get1(i);
                quest.IsCompleted = true;

                ref var request = ref _world.NewEntity().Get<MarkQuestViewRequest>();
                request.QuestId = quest.QuestId;
            }
        }
    }
}