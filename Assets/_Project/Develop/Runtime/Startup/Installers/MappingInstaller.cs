using _Project.Develop.Runtime.Presentation.Enemy.Views;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Startup.Installers
{
    public class MappingInstaller
    {
        public Dictionary<int, EcsEntity> EnemyEntityMap { get; private set; }
        public Dictionary<int, EnemyView> EnemyViewMap { get; private set; }
        public Dictionary<int, QuestView> QuestViewMap { get; private set; }

        public void Init()
        {
            EnemyEntityMap = new();
            EnemyViewMap = new();
            QuestViewMap = new();
        }
    }
}