using _Project.Develop.Runtime.Domain.Quest.Models;
using _Project.Develop.Runtime.Domain.Shared.Interfaces;

namespace _Project.Develop.Runtime.Domain.Quest.Conditions
{
    public struct PlayTimeConditionComponent : IConditionComponent<PlayTimeQuestData>
    {
        public float TargetTime;
        public float TimePlayed;

        public void Initialize(PlayTimeQuestData data)
        {
            TargetTime = data.TimeSeconds;
            TimePlayed = 0;
        }
    }
}