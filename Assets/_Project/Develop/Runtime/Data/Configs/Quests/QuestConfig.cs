using _Project.Develop.Runtime.Domain.Quest.Initializers;
using Sirenix.OdinInspector;

namespace _Project.Develop.Runtime.Data.Configs
{
    [HideReferenceObjectPicker]
    [System.Serializable]
    public abstract class QuestConfig
    {
        [ReadOnly, ShowInInspector]
        public abstract string QuestDescription { get; }

        public abstract IQuestInitializer ToInitializer();
    }
}