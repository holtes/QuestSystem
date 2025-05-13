using _Project.Develop.Runtime.Domain.Shared;
using _Project.Develop.Runtime.Domain.Shared.Interfaces;
using _Project.Develop.Runtime.Domain.Shared.Types;

namespace _Project.Develop.Runtime.Domain.Quest.Models
{
    public struct KillEnemiesOfTypeQuestData : IQuestData
    {
        public EnemyType EnemyType;
        public int EnemyCount;
        public string Description;

        string IQuestData.Description => Description;
    }
}