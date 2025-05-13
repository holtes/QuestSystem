using _Project.Develop.Runtime.Data.Configs;
using _Project.Develop.Runtime.Domain.Quest.Initializers;
using System.Linq;

namespace _Project.Develop.Runtime.Startup.Installers
{
    public class QuestInstaller
    {
        public IQuestInitializer[] QuestInitializers { get; private set; }

        public void Init(QuestConfig[] configs)
        {
            InitQuestInitializers(configs);
        }

        private void InitQuestInitializers(QuestConfig[] questConfigs)
        {
            QuestInitializers = questConfigs.Select(el => el.ToInitializer()).ToArray();
        }
    }
}