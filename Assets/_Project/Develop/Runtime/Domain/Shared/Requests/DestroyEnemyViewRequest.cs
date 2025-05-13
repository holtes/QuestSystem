using _Project.Develop.Runtime.Domain.Shared;
using _Project.Develop.Runtime.Domain.Shared.Types;

namespace _Project.Develop.Runtime.Domain.Shared.Requests
{
    public struct DestroyEnemyViewRequest
    {
        public EnemyType EnemyType;
        public int EnemyId;
    }
}