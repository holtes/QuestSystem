using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Develop.Runtime.Data.Configs
{
    [CreateAssetMenu(menuName = "Configs/GameConfig")]
    public class GameConfig : SerializedScriptableObject
    {
        [TableList]
        [SerializeField] private List<EnemyGroupConfig> _enemyGroups;

        [SerializeReference]
        [ListDrawerSettings(Expanded = true, DraggableItems = false, ShowPaging = false)]
        [LabelText(" весты")]
        [TypeFilter("GetFilteredQuestTypes")]
        public List<QuestConfig> _quests = new();

        public EnemyGroupConfig[] EnemyGroups => _enemyGroups.ToArray();
        public QuestConfig[] Quests => _quests.ToArray();

        private static IEnumerable<System.Type> GetFilteredQuestTypes()
        {
            yield return typeof(KillEnemiesQuest);
            yield return typeof(PlayTimeQuest);
            yield return typeof(KillEnemiesOfTypeQuest);
        }
    }
}