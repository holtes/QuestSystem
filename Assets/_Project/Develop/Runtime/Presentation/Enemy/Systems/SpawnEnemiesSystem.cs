using _Project.Develop.Runtime.Domain.Enemy.Components;
using _Project.Develop.Runtime.Domain.Movement.Components;
using _Project.Develop.Runtime.Domain.Shared.Requests;
using _Project.Develop.Runtime.Presentation.Enemy.Factories;
using _Project.Develop.Runtime.Presentation.Enemy.Views;
using _Project.Develop.Runtime.Presentation.Movement.Components;
using UnityEngine;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Presentation.Enemy.Systems
{
    public sealed class SpawnEnemiesSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<EnemyComponent, SpawnRequest> _enemiesFilter;

        private readonly EnemyFactory _factory;
        private readonly Dictionary<int, EnemyView> _idToEnemyViewMap;

        public SpawnEnemiesSystem(EnemyFactory factory, Dictionary<int, EnemyView> idToEnemyViewMap)
        {
            _factory = factory;
            _idToEnemyViewMap = idToEnemyViewMap;
        }

        public void Run()
        {
            foreach (var i in _enemiesFilter)
            {
                ref var enemyEntity = ref _enemiesFilter.GetEntity(i);
                ref var enemy = ref _enemiesFilter.Get1(i);

                var normalizedPos = new Vector2(Random.value, Random.value);

                var instance = _factory.Create(enemy.EnemyType, normalizedPos);
                instance.Init(_world, enemy.EnemyId, enemy.EnemyType);

                var rectTransform = instance.GetComponent<RectTransform>();
                enemyEntity.Get<RectViewRef>().RectTransform = rectTransform;

                ref var position = ref enemyEntity.Get<PositionComponent>();
                position.Position = new System.Numerics.Vector2(normalizedPos.x, normalizedPos.y);

                _idToEnemyViewMap.Add(enemy.EnemyId, instance);
            }
        }
    }
}