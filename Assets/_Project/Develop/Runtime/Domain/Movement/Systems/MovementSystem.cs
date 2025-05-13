using _Project.Develop.Runtime.Domain.Movement.Components;
using _Project.Develop.Runtime.Domain.Shared.Services;
using System.Numerics;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.Movement.Systems
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PositionComponent, MovementComponent> _movementFilter;

        private readonly TimeService _timeService;

        public MovementSystem(TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Run()
        {
            foreach (var i in _movementFilter)
            {
                ref var position = ref _movementFilter.Get1(i);
                ref var movement = ref _movementFilter.Get2(i);

                position.Position += movement.Direction * movement.Speed * _timeService.DeltaTime;

                bool bounced = false;

                if (position.Position.X < 0f)
                {
                    position.Position.X = 0f;
                    movement.Direction.X *= -1f;
                    bounced = true;
                }
                else if (position.Position.X > 1f)
                {
                    position.Position.X = 1f;
                    movement.Direction.X *= -1f;
                    bounced = true;
                }

                if (position.Position.Y < 0f)
                {
                    position.Position.Y = 0f;
                    movement.Direction.Y *= -1f;
                    bounced = true;
                }
                else if (position.Position.Y > 1f)
                {
                    position.Position.Y = 1f;
                    movement.Direction.Y *= -1f;
                    bounced = true;
                }

                if (bounced)
                {
                    if (movement.Direction.LengthSquared() > 0.001f)
                        movement.Direction = Vector2.Normalize(movement.Direction);
                }
            }
        }
    }
}