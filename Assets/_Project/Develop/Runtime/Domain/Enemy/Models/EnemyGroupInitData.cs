using _Project.Develop.Runtime.Domain.Shared;
using _Project.Develop.Runtime.Domain.Shared.Types;

namespace _Project.Develop.Runtime.Domain.Enemy.Models
{
    public struct EnemyGroupInitData
    {
        public int EnemiesCount;
        public EnemyType EnemyType;
        public float EnemySpeed;
    }
}