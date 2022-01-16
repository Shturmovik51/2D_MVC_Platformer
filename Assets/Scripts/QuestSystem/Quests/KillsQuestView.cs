using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Platformer2D
{
    public class KillsQuestView
    {
        private int _id;
        private Color _completedColor;
        private Color _defaultColor;
        //private SpriteRenderer _spriteRenderer;
        private Image _killsQuestPanel;
        private Toggle _killsQuestToggle;
        private TextMeshProUGUI _killsCount;
        private StarterGameData _starterGameData;

        public int Id { get => _id; set => _id = value; }

        public KillsQuestView(StarterGameData starterGameData)
        {
            _starterGameData = starterGameData;
        }

        public void ProcessComplete(QuestsData questsData)
        {
            _killsQuestPanel.color = questsData.CompletedColor;
            _killsQuestToggle.isOn = true;
        }

        public void ProcessActivate(QuestsData questsData)
        {
            //_spriteRenderer.color = _defaultColor;
            _killsQuestPanel = questsData.KillQuestPanel;
            _killsQuestToggle = questsData.KillQuestToggle;
            _killsCount = questsData.KillsCountText;
            _killsCount.text = _starterGameData.KillsToWin.ToString();
        }

        public void SetKillsCount(int count)
        {
            _killsCount.text = count.ToString();
        }
    }
}
