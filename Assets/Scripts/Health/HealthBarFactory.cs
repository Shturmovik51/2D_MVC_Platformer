using UnityEngine;
using UnityEngine.UI;

namespace Platformer2D
{
    public class HealthBarFactory
    {
        private GameObject _healthBarPrototype;
        private GameObject _healthBarObject;
        private Image _barImage;
        private Canvas _canvas;

        public HealthBarFactory(GameData gameData, Canvas canvas)
        {
            _healthBarPrototype = gameData.PrefabsData.HealthBarPrefab;
            _canvas = canvas;
        }

        public HealthBar GetHealthBar()
        {
            var canvas = Object.FindObjectOfType<Canvas>();

            _healthBarObject = Object.Instantiate(_healthBarPrototype, canvas.transform);
            var images = _healthBarObject.GetComponentsInChildren<Image>();  

            for (int i = 0; i < images.Length; i++)
            {
                if (images[i].type == Image.Type.Filled)
                    _barImage = images[i];
            }

            var healthBar = new HealthBar(_healthBarObject.transform, _barImage);           

            return healthBar;
        }
    }
}
