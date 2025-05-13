using _Project.Develop.Runtime.Domain.Enemy.Components;
using _Project.Develop.Runtime.Domain.Shared.Events;
using _Project.Develop.Runtime.Domain.Shared.Requests;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Domain.Combat.Systems
{
    public sealed class EnemyKillSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<EnemyKilledEvent> _eventFilter;

        private readonly Dictionary<int, EcsEntity> _idToEnemyEntityMap;

        public EnemyKillSystem(Dictionary<int, EcsEntity> idToEnemyEntityMap)
        {
            _idToEnemyEntityMap = idToEnemyEntityMap;
        }

        public void Run()
        {
            foreach (var i in _eventFilter)
            {
                ref var killEvent = ref _eventFilter.Get1(i);

                if (!_idToEnemyEntityMap.TryGetValue(killEvent.EnemyId, out var enemyEntity)) continue;

                _idToEnemyEntityMap.Remove(killEvent.EnemyId);

                ref var destoryRequest = ref _world.NewEntity().Get<DestroyEnemyViewRequest>();
                ref var enemy = ref enemyEntity.Get<EnemyComponent>();
                destoryRequest.EnemyId = enemy.EnemyId;
                destoryRequest.EnemyType = enemy.EnemyType;

                enemyEntity.Destroy();
                _eventFilter.GetEntity(i).Destroy();
            }
        }
    }
}