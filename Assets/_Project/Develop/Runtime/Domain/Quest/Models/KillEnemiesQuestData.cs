using _Project.Develop.Runtime.Domain.Shared.Interfaces;

namespace _Project.Develop.Runtime.Domain.Quest.Models
{
    public struct KillEnemiesQuestData : IQuestData
    {
        public int EnemyCount;
        public string Description;

        string IQuestData.Description => Description;
    }
}