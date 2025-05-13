using _Project.Develop.Runtime.Domain.Quest.Components;
using _Project.Develop.Runtime.Domain.Quest.Conditions;
using _Project.Develop.Runtime.Domain.Quest.Events;
using _Project.Develop.Runtime.Domain.Shared.Events;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.Quest.Systems
{
    public sealed class KillEnemiesQuestSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EnemyKilledEvent> _eventsFilter;
        private readonly EcsFilter<QuestComponent, KillEnemiesConditionComponent> _questsFilter;

        public void Run()
        {
            foreach (var i in _eventsFilter)
            {
                foreach (var j in _questsFilter)
                {
                    var questEntity = _questsFilter.GetEntity(j);
                    ref var quest = ref _questsFilter.Get1(j);
                    ref var condition = ref _questsFilter.Get2(j);

                    if (quest.IsCompleted) continue;

                    condition.CurrentKillCount++;

                    ref var progressEvent = ref questEntity.Get<QuestProgressUpdatedEvent>();
                    progressEvent.Progress = (float)condition.CurrentKillCount / condition.TargetKillCount;

                    if (condition.CurrentKillCount >= condition.TargetKillCount) questEntity.Get<QuestCompletedEvent>();
                }
            }
        }
    }
}