using System.Collections.Generic;
using _Project.Develop.Runtime.Domain.Shared.Types;
using _Project.Develop.Runtime.Presentation.Enemy.Views;
using UnityEngine;

namespace _Project.Develop.Runtime.Presentation.Enemy.Pools
{
    public class EnemyPool
    {
        private readonly Dictionary<EnemyType, Stack<EnemyView>> _pools = new();
        private readonly Dictionary<EnemyType, EnemyView> _prefabs;
        private readonly RectTransform _parent;

        public EnemyPool(Dictionary<EnemyType, EnemyView> prefabs, RectTransform parent)
        {
            _prefabs = prefabs;
            _parent = parent;

            foreach (var pair in prefabs)
            {
                _pools[pair.Key] = new Stack<EnemyView>();
            }
        }

        public EnemyView Get(EnemyType type)
        {
            if (!_pools.ContainsKey(type))
            {
                Debug.LogError($"No pool for type: {type}");
                return null;
            }

            if (_pools[type].Count > 0)
            {
                var obj = _pools[type].Pop();
                obj.gameObject.SetActive(true);
                return obj;
            }

            return Object.Instantiate(_prefabs[type], _parent.transform);
        }

        public void Return(EnemyType type, EnemyView obj)
        {
            obj.gameObject.SetActive(false);
            _pools[type].Push(obj);
        }
    }
}