using _Project.Develop.Runtime.Domain.Combat.Systems;
using _Project.Develop.Runtime.Domain.Enemy.Systems;
using _Project.Develop.Runtime.Domain.Movement.Systems;
using _Project.Develop.Runtime.Domain.Quest.Events;
using _Project.Develop.Runtime.Domain.Quest.Systems;
using _Project.Develop.Runtime.Domain.Shared.Events;
using _Project.Develop.Runtime.Domain.Shared.Requests;
using _Project.Develop.Runtime.Presentation.Enemy.Systems;
using _Project.Develop.Runtime.Presentation.Movement.Systems;
using _Project.Develop.Runtime.Presentation.Quest.Systems;
using _Project.Develop.Runtime.Startup.Data;
using Leopotam.Ecs;
using System.Linq;

namespace _Project.Develop.Runtime.Startup.Installers
{
    public class SystemsInstaller
    {
        public void Init(EcsSystems systems, SceneData sceneData, ServicesInstaller servicesInstaller, DataInstaller dataInstaller)
        {
            systems
                .Add(new InitQuestsDataSystem(dataInstaller.Quest.QuestInitializers))
                .Add(new InitEnemiesDataSystem(dataInstaller.Enemy.InitData, dataInstaller.Mapping.EnemyEntityMap))

                .Add(new SpawnQuestViewSystem(sceneData.UIRoot.QuestPanel, sceneData.QuestPrefab, dataInstaller.Mapping.QuestViewMap))
                .Add(new SpawnEnemiesSystem(dataInstaller.Enemy.EnemyFactory, dataInstaller.Mapping.EnemyViewMap))

                .Add(new MovementSystem(servicesInstaller.TimeService))
                .Add(new ApplyMovementSystem(sceneData.SceneRoot))

                .Add(new KillEnemiesOfTypeQuestSystem())
                .Add(new KillEnemiesQuestSystem())
                .Add(new EnemyKillSystem(dataInstaller.Mapping.EnemyEntityMap))

                .Add(new PlayTimeQuestSystem(servicesInstaller.TimeService))

                .Add(new QuestCompleteSystem())

                .Add(new UpdateQuestViewSystem(dataInstaller.Mapping.QuestViewMap))
                .Add(new MarkCompletedQuestSystem(dataInstaller.Mapping.QuestViewMap))
                .Add(new DestroyEnemyViewSystem(dataInstaller.Enemy.EnemyFactory, dataInstaller.Mapping.EnemyViewMap))

                .OneFrame<SpawnQuestViewRequest>()
                .OneFrame<SpawnRequest>()
                .OneFrame<QuestProgressUpdatedEvent>()
                .OneFrame<QuestCompletedEvent>();
        }
    }
}