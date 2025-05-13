using _Project.Develop.Runtime.Domain.Quest.Models;
using _Project.Develop.Runtime.Domain.Shared.Interfaces;
using _Project.Develop.Runtime.Domain.Shared.Types;

namespace _Project.Develop.Runtime.Domain.Quest.Conditions
{
    public struct KillEnemiesOfTypeConditionComponent : IConditionComponent<KillEnemiesOfTypeQuestData>
    {
        public EnemyType EnemyType;
        public int TargetKillCount;
        public int CurrentKillCount;

        public void Initialize(KillEnemiesOfTypeQuestData data)
        {
            EnemyType = data.EnemyType;
            TargetKillCount = data.EnemyCount;
            CurrentKillCount = 0;
        }
    }
}