using _Project.Develop.Runtime.Data.Configs;
using _Project.Develop.Runtime.Startup.Data;

namespace _Project.Develop.Runtime.Startup.Installers
{
    public class DataInstaller
    {
        public EnemyInstaller Enemy { get; private set; }
        public QuestInstaller Quest { get; private set; }
        public MappingInstaller Mapping { get; private set; }

        public void Init(GameConfig config, SceneData sceneData)
        {
            Enemy = new EnemyInstaller();
            Enemy.Init(config.EnemyGroups, sceneData.SceneRoot);

            Quest = new QuestInstaller();
            Quest.Init(config.Quests);

            Mapping = new MappingInstaller();
            Mapping.Init();
        }
    }
}