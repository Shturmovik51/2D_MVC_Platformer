using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class HealthBarsInitializator
    {
        private List<HealthBar> _healthBars;

        public HealthBarsInitializator(StarterGameData starterGameData, GameData gameData)
        {
            _healthBars = new List<HealthBar>(starterGameData.ZombiesCountInCollection);

            var canvas = Object.FindObjectOfType<Canvas>();
            var healthBarContainer = new GameObject("HealthBars");
            var healthBarFactory = new HealthBarFactory(gameData, canvas);
            healthBarContainer.transform.parent = canvas.transform;

            for (int i = 0; i < starterGameData.ZombiesCountInCollection; i++)
            {
                var healthBar = healthBarFactory.GetHealthBar();
                healthBar.HealhBarObject.transform.parent = healthBarContainer.transform;
                healthBar.HealhBarObject.gameObject.SetActive(false);

                _healthBars.Add(healthBar);
            }
        }

        public List<HealthBar> GetHealthBars()
        {
            return _healthBars;
        }
    }
}
