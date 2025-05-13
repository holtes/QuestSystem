using _Project.Develop.Runtime.Domain.Movement.Components;
using _Project.Develop.Runtime.Domain.Enemy.Components;
using _Project.Develop.Runtime.Domain.Enemy.Models;
using _Project.Develop.Runtime.Domain.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Numerics;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.Enemy.Systems
{
    public sealed class InitEnemiesDataSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;

        private readonly EnemyGroupInitData[] _enemyGroupsInitData;
        private readonly Dictionary<int, EcsEntity> _idToEnemyEntityMap;
        private readonly Random _random = new();
        private int _enemyId = 0;

        public InitEnemiesDataSystem(EnemyGroupInitData[] enemyGroupsInitData, Dictionary<int, EcsEntity> idToEnemyEntityMap)
        {
            _enemyGroupsInitData = enemyGroupsInitData;
            _idToEnemyEntityMap = idToEnemyEntityMap;
        }

        public void Init()
        {
            foreach (var group in _enemyGroupsInitData)
            {
                for (int i = 0; i < group.EnemiesCount; i++)
                {
                    var enemyEntity = _world.NewEntity();

                    ref var enemy = ref enemyEntity.Get<EnemyComponent>();
                    enemy.EnemyType = group.EnemyType;
                    enemy.EnemyId = _enemyId;

                    ref var movement = ref enemyEntity.Get<MovementComponent>();
                    movement.Speed = group.EnemySpeed;

                    double angle = _random.NextDouble() * 2 * Math.PI;
                    float x = (float)Math.Cos(angle);
                    float y = (float)Math.Sin(angle);
                    movement.Direction = new Vector2(x, y);

                    enemyEntity.Get<PositionComponent>();

                    enemyEntity.Get<SpawnRequest>();

                    _idToEnemyEntityMap.Add(_enemyId, enemyEntity);

                    _enemyId++;
                }
            }
        }
    }
}