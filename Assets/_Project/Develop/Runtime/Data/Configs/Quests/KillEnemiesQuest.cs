using _Project.Develop.Runtime.Domain.Quest.Conditions;
using _Project.Develop.Runtime.Domain.Quest.Initializers;
using _Project.Develop.Runtime.Domain.Quest.Models;
using Sirenix.OdinInspector;

namespace _Project.Develop.Runtime.Data.Configs
{
    [InlineProperty]
    [System.Serializable]
    public class KillEnemiesQuest : QuestConfig
    {
        [LabelText("���������� ������")]
        public int count;

        public override string QuestDescription => $"���� {count} ������.";

        public override IQuestInitializer ToInitializer()
        {
            return new GenericQuestInitializer<KillEnemiesQuestData, KillEnemiesConditionComponent>(
                new KillEnemiesQuestData
                {
                    EnemyCount = count,
                    Description = QuestDescription
                });
        }
    }
}