using _Project.Develop.Runtime.Domain.Movement.Components;
using _Project.Develop.Runtime.Presentation.Movement.Components;
using UnityEngine;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Presentation.Movement.Systems
{
    public sealed class ApplyMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PositionComponent, RectViewRef> _objFilter = null;
        private readonly RectTransform _sceneRoot;

        public ApplyMovementSystem(RectTransform sceneRoot)
        {
            _sceneRoot = sceneRoot;
        }

        public void Run()
        {

            foreach (var i in _objFilter)
            {
                ref var position = ref _objFilter.Get1(i);
                ref var view = ref _objFilter.Get2(i);

                float x = (position.Position.X - 0.5f) * _sceneRoot.rect.width;
                float y = (position.Position.Y - 0.5f) * _sceneRoot.rect.height;

                view.RectTransform.anchoredPosition = new Vector2(x, y);
            }
        }
    }
}