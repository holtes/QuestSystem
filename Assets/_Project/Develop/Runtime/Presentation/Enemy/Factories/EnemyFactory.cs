using _Project.Develop.Runtime.Domain.Shared.Types;
using _Project.Develop.Runtime.Presentation.Enemy.Pools;
using _Project.Develop.Runtime.Presentation.Enemy.Views;
using UnityEngine;

namespace _Project.Develop.Runtime.Presentation.Enemy.Factories
{
    public class EnemyFactory
    {
        private readonly EnemyPool _pool;
        private readonly RectTransform _canvasRect;

        public EnemyFactory(EnemyPool pool, RectTransform canvasRect)
        {
            _pool = pool;
            _canvasRect = canvasRect;
        }

        public EnemyView Create(EnemyType type, Vector2 normalizedPos)
        {
            var instance = _pool.Get(type);
            var rect = instance.GetComponent<RectTransform>();

            if (rect != null)
            {
                var canvasSize = _canvasRect.rect.size;
                var enemySize = rect.rect.size;

                var anchoredPos = new Vector2(
                    (normalizedPos.x - 0.5f) * canvasSize.x,
                    (normalizedPos.y - 0.5f) * canvasSize.y
                );

                var offset = new Vector2(
                    (rect.pivot.x - 0.5f) * enemySize.x,
                    (rect.pivot.y - 0.5f) * enemySize.y
                );

                rect.anchoredPosition = anchoredPos - offset;
            }

            return instance;
        }

        public void Recycle(EnemyType type, EnemyView instance)
        {
            _pool.Return(type, instance);
        }
    }
}