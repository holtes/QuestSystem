using _Project.Develop.Runtime.Domain.Shared.Requests;
using _Project.Develop.Runtime.Presentation.Enemy.Factories;
using _Project.Develop.Runtime.Presentation.Enemy.Views;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Presentation.Enemy.Systems
{
    public sealed class DestroyEnemyViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DestroyEnemyViewRequest> _requestFilter;

        private readonly EnemyFactory _enemyFactory;
        private readonly Dictionary<int, EnemyView> _idToEnemyViewMap;

        public DestroyEnemyViewSystem(EnemyFactory enemyFactory, Dictionary<int, EnemyView> idToEnemyViewMap)
        {
            _enemyFactory = enemyFactory;
            _idToEnemyViewMap = idToEnemyViewMap;
        }

        public void Run()
        {
            foreach (var i in _requestFilter)
            {
                ref var request = ref _requestFilter.Get1(i);

                if (!_idToEnemyViewMap.TryGetValue(request.EnemyId, out var enemyView)) continue;

                _idToEnemyViewMap.Remove(request.EnemyId);
                _enemyFactory.Recycle(request.EnemyType, enemyView);

                _requestFilter.GetEntity(i).Destroy();
            }
        }
    }
}