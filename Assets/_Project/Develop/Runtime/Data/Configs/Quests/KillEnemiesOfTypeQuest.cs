using _Project.Develop.Runtime.Domain.Quest.Conditions;
using _Project.Develop.Runtime.Domain.Quest.Initializers;
using _Project.Develop.Runtime.Domain.Quest.Models;
using _Project.Develop.Runtime.Domain.Shared;
using _Project.Develop.Runtime.Domain.Shared.Types;
using Sirenix.OdinInspector;

namespace _Project.Develop.Runtime.Data.Configs
{
    [InlineProperty]
    [System.Serializable]
    public class KillEnemiesOfTypeQuest : QuestConfig
    {
        [LabelText("Тип врага")]
        public EnemyType enemyType;

        [LabelText("Количество")]
        public int count;

        public override string QuestDescription => $"Убей {count} врагов типа {enemyType}.";

        public override IQuestInitializer ToInitializer()
        {
            return new GenericQuestInitializer<KillEnemiesOfTypeQuestData, KillEnemiesOfTypeConditionComponent>(
                new KillEnemiesOfTypeQuestData
                {
                    EnemyType = enemyType,
                    EnemyCount = count,
                    Description = QuestDescription
                });
        }
    }
}