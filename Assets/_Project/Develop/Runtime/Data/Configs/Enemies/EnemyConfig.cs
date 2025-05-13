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
        [BoxGroup("EnemyBox/��������� �����")]
        [LabelText("��� �����")]
        [SerializeField]
        private EnemyType _enemyType;

        [VerticalGroup("EnemyBox")]
        [BoxGroup("EnemyBox/��������� �����")]
        [LabelText("������ �����")]
        [PreviewField(60), HideLabel]
        [SerializeField]
        private GameObject _enemyPrefab;

        [VerticalGroup("EnemyBox")]
        [BoxGroup("EnemyBox/��������� �����")]
        [LabelText("�������� �����")]
        [SerializeField]
        private float _enemySpeed;

        public EnemyType EnemyType => _enemyType;
        public GameObject EnemyPrefab => _enemyPrefab;
        public float EnemySpeed => _enemySpeed;
    }
}