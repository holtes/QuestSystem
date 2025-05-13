using _Project.Develop.Runtime.Data.Configs;
using _Project.Develop.Runtime.Domain.Enemy.Models;
using _Project.Develop.Runtime.Presentation.Enemy.Factories;
using _Project.Develop.Runtime.Presentation.Enemy.Pools;
using _Project.Develop.Runtime.Presentation.Enemy.Views;
using System.Linq;
using UnityEngine;

namespace _Project.Develop.Runtime.Startup.Installers
{
    public class EnemyInstaller
    {
        public EnemyPool EnemyPool { get; private set; }
        public EnemyFactory EnemyFactory { get; private set; }
        public EnemyGroupInitData[] InitData { get; private set; }

        public void Init(EnemyGroupConfig[] groupConfigs, RectTransform sceneRoot)
        {
            InitEnemyGroupData(groupConfigs);
            InitEnemyPool(groupConfigs, sceneRoot);
            InitEnemyFactory(sceneRoot);
        }

        private void InitEnemyGroupData(EnemyGroupConfig[] enemyGroupConfig)
        {
            InitData = new EnemyGroupInitData[enemyGroupConfig.Length];

            for (int i = 0; i < enemyGroupConfig.Length; i++)
            {
                InitData[i] = new EnemyGroupInitData
                {
                    EnemiesCount = enemyGroupConfig[i].EnemiesCount,
                    EnemyType = enemyGroupConfig[i].EnemyConfig.EnemyType,
                    EnemySpeed = enemyGroupConfig[i].EnemyConfig.EnemySpeed
                };
            }
        }

        private void InitEnemyPool(EnemyGroupConfig[] enemyGroupConfig, RectTransform sceneRoot)
        {
            var prefabs = enemyGroupConfig
            .Select(g => g.EnemyConfig)
            .GroupBy(c => c.EnemyType)
            .ToDictionary(g => g.Key, g => g.First().EnemyPrefab.GetComponent<EnemyView>());

            EnemyPool = new EnemyPool(prefabs, sceneRoot);
        }

        private void InitEnemyFactory(RectTransform sceneRoot)
        {
            EnemyFactory = new EnemyFactory(EnemyPool, sceneRoot);
        }

    }
}