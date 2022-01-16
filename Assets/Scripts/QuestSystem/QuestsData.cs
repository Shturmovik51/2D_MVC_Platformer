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


        public QuestObjectView QuestObjectView => _questObjectView;
        public Image SaveZoneQuestPanel => _saveZoneQuestPanel;
        public TextMeshProUGUI SaveZoneQuestDiscription => _saveZoneQuestDiscription;
        public Toggle SaveZoneQuestToggle => _saveZoneQuestToggle;
    }
}
