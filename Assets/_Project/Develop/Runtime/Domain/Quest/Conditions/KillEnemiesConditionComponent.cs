using _Project.Develop.Runtime.Domain.Quest.Models;
using _Project.Develop.Runtime.Domain.Shared.Interfaces;

namespace _Project.Develop.Runtime.Domain.Quest.Conditions
{
    public struct KillEnemiesConditionComponent : IConditionComponent<KillEnemiesQuestData>
    {
        public int TargetKillCount;
        public int CurrentKillCount;

        public void Initialize(KillEnemiesQuestData data)
        {
            TargetKillCount = data.EnemyCount;
            CurrentKillCount = 0;
        }
    }
}