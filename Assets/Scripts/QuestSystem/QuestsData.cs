using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer2D
{
    [System.Serializable]
    public struct QuestsData
    {
        [SerializeField] private QuestObjectView _questObjectView;
        [SerializeField] private Image _saveZoneQuestPanel;
        [SerializeField] private TextMeshProUGUI _saveZoneQuestDiscription;
        [SerializeField] private Toggle _saveZoneQuestToggle;

        [SerializeField] private Image _killQuestPanel;
        [SerializeField] private TextMeshProUGUI _killQuestDiscription;
        [SerializeField] private TextMeshProUGUI _killsCountText;
        [SerializeField] private Toggle _killQuestToggle;

        [SerializeField] private Color _completedColor;


        public QuestObjectView QuestObjectView => _questObjectView;
        public Image SaveZoneQuestPanel => _saveZoneQuestPanel;
        public TextMeshProUGUI SaveZoneQuestDiscription => _saveZoneQuestDiscription;
        public Toggle SaveZoneQuestToggle => _saveZoneQuestToggle;

        public Image KillQuestPanel => _killQuestPanel;
        public TextMeshProUGUI KillQuestDiscription => _killQuestDiscription;
        public TextMeshProUGUI KillsCountText => _killsCountText;
        public Toggle KillQuestToggle => _killQuestToggle;
        public Color CompletedColor => _completedColor;
    }
}
