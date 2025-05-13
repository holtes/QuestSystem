namespace _Project.Develop.Runtime.Domain.Shared.Interfaces
{
    public interface IConditionComponent<T> where T : IQuestData
    {
        void Initialize(T data);
    }
}