using _Project.Develop.Runtime.Domain.Shared.Interfaces;

namespace _Project.Develop.Runtime.Domain.Quest.Models
{
    public struct PlayTimeQuestData : IQuestData
    {
        public float TimeSeconds;
        public string Description;

        string IQuestData.Description => Description;
    }
}