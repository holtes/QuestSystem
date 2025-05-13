using _Project.Develop.Runtime.Domain.Shared;
using UnityEngine;
using Sirenix.OdinInspector;
using _Project.Develop.Runtime.Domain.Shared.Types;

namespace _Project.Develop.Runtime.Data.Configs
{
    [System.Serializable]
    [InlineProperty]
    public class EnemyConfig
    {
        [VerticalGroup("EnemyBox")]
        [BoxGroup("EnemyBox/Параметры врага")]
        [LabelText("Тип врага")]
        [SerializeField]
        private EnemyType _enemyType;

        [VerticalGroup("EnemyBox")]
        [BoxGroup("EnemyBox/Параметры врага")]
        [LabelText("Префаб врага")]
        [PreviewField(60), HideLabel]
        [SerializeField]
        private GameObject _enemyPrefab;

        [VerticalGroup("EnemyBox")]
        [BoxGroup("EnemyBox/Параметры врага")]
        [LabelText("Скорость врага")]
        [SerializeField]
        private float _enemySpeed;

        public EnemyType EnemyType => _enemyType;
        public GameObject EnemyPrefab => _enemyPrefab;
        public float EnemySpeed => _enemySpeed;
    }
}