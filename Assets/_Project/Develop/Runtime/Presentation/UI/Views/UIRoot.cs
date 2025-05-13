using UnityEngine;

namespace _Project.Develop.Runtime.Presentation.UI.Views
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] QuestPanel _questPanel;

        public QuestPanel QuestPanel => _questPanel;
    }
}