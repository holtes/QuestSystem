using _Project.Develop.Runtime.Domain.Quest.Components;
using _Project.Develop.Runtime.Domain.Shared.Events;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Presentation.Quest.Systems
{
    public sealed class UpdateQuestViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<QuestComponent, QuestProgressUpdatedEvent> _questFilter;

        private readonly Dictionary<int, QuestView> _idToQuestViewMap;

        public UpdateQuestViewSystem(Dictionary<int, QuestView> idToQuestViewMap)
        {
            _idToQuestViewMap = idToQuestViewMap;
        }

        public void Run()
        {
            foreach (var i in _questFilter)
            {
                ref var quest = ref _questFilter.Get1(i);
                ref var progress = ref _questFilter.Get2(i);

                if (!_idToQuestViewMap.TryGetValue(quest.QuestId, out var questView)) continue;

                questView.SetProgress(progress.Progress);
            }
        }
    }
}