using _Project.Develop.Runtime.Domain.Shared.Events;
using _Project.Develop.Runtime.Domain.Shared.Types;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Develop.Runtime.Presentation.Enemy.Views
{
    public class EnemyView : MonoBehaviour, IPointerClickHandler
    {
        private EcsWorld _world;

        private int _enemyId;
        private EnemyType _enemyType;

        public void Init(EcsWorld world, int enemyId, EnemyType enemyType)
        {
            _world = world;
            _enemyId = enemyId;
            _enemyType = enemyType;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ref var killEvent = ref _world.NewEntity().Get<EnemyKilledEvent>();
            killEvent.EnemyId = _enemyId;
            killEvent.EnemyType = _enemyType;
        }
    }
}