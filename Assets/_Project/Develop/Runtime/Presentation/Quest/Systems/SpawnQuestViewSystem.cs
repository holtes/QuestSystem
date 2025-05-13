using _Project.Develop.Runtime.Domain.Quest.Components;
using _Project.Develop.Runtime.Domain.Shared.Requests;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Presentation.Quest.Systems
{
    public sealed class SpawnQuestViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<QuestComponent, SpawnQuestViewRequest> _questsFilter;

        private readonly QuestPanel _questPanel;
        private readonly QuestView _questPrefab;
        private readonly Dictionary<int, QuestView> _idToQuestViewMap;

        public SpawnQuestViewSystem(QuestPanel questPanel, QuestView questPrefab, Dictionary<int, QuestView> idToQuestViewMap)
        {
            _questPanel = questPanel;
            _questPrefab = questPrefab;
            _idToQuestViewMap = idToQuestViewMap;
        }

        public void Run()
        {
            foreach (var i in _questsFilter)
            {
                ref var quest = ref _questsFilter.Get1(i);

                var questView = _questPanel.CreateQuest(_questPrefab);
                questView.SetDescription(quest.Description);
                questView.SetProgress(0);

                _idToQuestViewMap.Add(quest.QuestId, questView);
            }
        }
    }
}