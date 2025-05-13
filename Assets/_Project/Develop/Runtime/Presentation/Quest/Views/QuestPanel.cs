using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    [SerializeField] private Transform _questsContainer;

    public QuestView CreateQuest(QuestView questPrefab)
    {
        var view = Instantiate(questPrefab, _questsContainer);
        return view;
    }
}
