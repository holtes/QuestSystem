using UnityEngine;
using Sirenix.OdinInspector;

namespace _Project.Develop.Runtime.Data.Configs
{
    [System.Serializable]
    [InlineProperty]
    public class EnemyGroupConfig
    {
        [BoxGroup("Группа врагов")]
        [LabelText("Количество врагов")]
        [MinValue(1)]
        [SerializeField] private int _enemiesCount = 1;

        [BoxGroup("Группа врагов")]
        [LabelText("Конфиг врага")]
        [SerializeField] private EnemyConfig _enemyConfig;

        public int EnemiesCount => _enemiesCount;
        public EnemyConfig EnemyConfig => _enemyConfig;
    }
}