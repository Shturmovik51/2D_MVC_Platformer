using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer2D
{
    public class QuestObjectView : MonoBehaviour
    {
        public Action<PlayerView> OnLevelObjectContact;

        [SerializeField] private int _id;
        [SerializeField] private Color _completedColor;
        [SerializeField] private Color _defaultColor;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Image _saveZoneQuestPanel;
        //private TextMeshProUGUI _saveZoneQuestDiscription;
        private Toggle _saveZoneQuestToggle;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out PlayerView view))
                OnLevelObjectContact?.Invoke(view);
        }

        public int Id { get => _id; set => _id = value; }

        void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }

        public void ProcessComplete()
        {
            _saveZoneQuestPanel.color = _completedColor;
            _saveZoneQuestToggle.isOn = true;
        }

        public void ProcessActivate(QuestsData questsData)
        {
            _spriteRenderer.color = _defaultColor;
            _saveZoneQuestPanel = questsData.SaveZoneQuestPanel;
            //_saveZoneQuestDiscription = questsData.SaveZoneQuestDiscription;
            _saveZoneQuestToggle = questsData.SaveZoneQuestToggle;
        }
    }
}
