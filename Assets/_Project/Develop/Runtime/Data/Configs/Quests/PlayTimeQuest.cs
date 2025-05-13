using _Project.Develop.Runtime.Domain.Quest.Conditions;
using _Project.Develop.Runtime.Domain.Quest.Initializers;
using _Project.Develop.Runtime.Domain.Quest.Models;
using Sirenix.OdinInspector;

namespace _Project.Develop.Runtime.Data.Configs
{
    [InlineProperty]
    [System.Serializable]
    public class PlayTimeQuest : QuestConfig
    {
        [LabelText("Время в секундах")]
        public float timeSeconds;

        public override string QuestDescription => $"Пробудь в игре {timeSeconds} сек.";

        public override IQuestInitializer ToInitializer()
        {
            return new GenericQuestInitializer<PlayTimeQuestData, PlayTimeConditionComponent>(
                new PlayTimeQuestData
                {
                    TimeSeconds = timeSeconds,
                    Description = QuestDescription
                });
        }
    }
}