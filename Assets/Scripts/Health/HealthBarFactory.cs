using UnityEngine;
using UnityEngine.UI;

namespace Platformer2D
{
    public class HealthBarFactory
    {
        private GameObject _healthBarPrototype;
        private GameObject _healthBarObject;
        private Image _barImage;

        public HealthBarFactory(GameData gameData)
        {
            _healthBarPrototype = gameData.PrefabsData.HealthBarPrefab;
        }

        public HealthBar GetHealthBar()
        {
            _healthBarObject = Object.Instantiate(_healthBarPrototype);
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
