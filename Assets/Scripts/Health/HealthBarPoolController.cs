using System.Collections.Generic;

namespace Platformer2D
{
    public class HealthBarPoolController : IInitializable, ICleanable, IController
    {
        private List<HealthBar> _healthBars;
        private EnemiesController _enemiesController;

        public HealthBarPoolController(HealthBarsInitializator healthBarsInitializator, EnemiesController enemiesController)
        {
            _healthBars = healthBarsInitializator.GetHealthBars();
            _enemiesController = enemiesController;
        }

        public void Initialization()
        {
            _enemiesController.OnEnemyDeath += ReturnHealthBar;
        }

        public void CleanUp()
        {
            _enemiesController.OnEnemyDeath -= ReturnHealthBar;
        }

        public HealthBar ProvideHealthBar()
        {
            if(_healthBars.Count != 0)
            {
                var healthBar = _healthBars[0];
                _healthBars.Remove(healthBar);
                healthBar.HealhBarObject.gameObject.SetActive(true);

                return healthBar;
            }
            else
            {
                throw new System.Exception("no healthBars in pool");
            }
        }

        public void ReturnHealthBar(EnemyView view, EnemyModel model)
        {
            var healthBar = view.HealthBar;
            healthBar.HealhBarObject.gameObject.SetActive(false);

            _healthBars.Add(view.HealthBar);
        }
    }
}
