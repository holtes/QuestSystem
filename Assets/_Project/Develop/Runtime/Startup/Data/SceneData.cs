using _Project.Develop.Runtime.Presentation.UI.Views;
using UnityEngine;

namespace _Project.Develop.Runtime.Startup.Data
{
    public class SceneData : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private UIRoot _uiRoot;
        [SerializeField] private QuestView _questPrefab;

        [Header("Настройки игры")]
        [SerializeField] private RectTransform _sceneRoot;

        public UIRoot UIRoot => _uiRoot;
        public QuestView QuestPrefab => _questPrefab;
        public RectTransform SceneRoot => _sceneRoot;
    }
}