
using _Project.Develop.Runtime.Domain.Shared.Types;

namespace _Project.Develop.Runtime.Domain.Shared.Events
{
    public struct EnemyKilledEvent
    {
        public int EnemyId;
        public EnemyType EnemyType;
    }
}