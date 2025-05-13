using _Project.Develop.Runtime.Domain.Quest.Components;
using _Project.Develop.Runtime.Domain.Quest.Conditions;
using _Project.Develop.Runtime.Domain.Quest.Events;
using _Project.Develop.Runtime.Domain.Shared;
using _Project.Develop.Runtime.Domain.Shared.Events;
using _Project.Develop.Runtime.Domain.Shared.Services;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.Quest.Systems
{
    public sealed class PlayTimeQuestSystem : IEcsRunSystem
    {
        private readonly EcsFilter<QuestComponent, PlayTimeConditionComponent> _questsFilter;

        private readonly TimeService _timeService;

        public PlayTimeQuestSystem(TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Run()
        {

            foreach (var i in _questsFilter)
            {
                var questEntity = _questsFilter.GetEntity(i);
                ref var quest = ref _questsFilter.Get1(i);
                ref var condition = ref _questsFilter.Get2(i);

                if (quest.IsCompleted) continue;

                condition.TimePlayed += _timeService.DeltaTime;

                ref var progressEvent = ref questEntity.Get<QuestProgressUpdatedEvent>();
                progressEvent.Progress = condition.TimePlayed / condition.TargetTime;

                if (condition.TimePlayed >= condition.TargetTime) questEntity.Get<QuestCompletedEvent>();
            }
        }
    }
}