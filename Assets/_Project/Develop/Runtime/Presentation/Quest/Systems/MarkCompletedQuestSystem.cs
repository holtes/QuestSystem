using _Project.Develop.Runtime.Domain.Shared.Requests;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Presentation.Quest.Systems
{
    public sealed class MarkCompletedQuestSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MarkQuestViewRequest> _requestFilter;

        private readonly Dictionary<int, QuestView> _idToQuestViewMap;

        public MarkCompletedQuestSystem(Dictionary<int, QuestView> idToQuestViewMap)
        {
            _idToQuestViewMap = idToQuestViewMap;
        }

        public void Run()
        {
            foreach (var i in _requestFilter)
            {
                ref var request = ref _requestFilter.Get1(i);

                if (!_idToQuestViewMap.TryGetValue(request.QuestId, out var questView)) continue;

                questView.CompleteQuest();
                _requestFilter.GetEntity(i).Destroy();
            }
        }
    }
}