using System;
using System.Collections.Generic;

namespace Platformer2D
{
    public class EnemiesPoolController
    {
        public event Action<EnemyView, EnemyModel> OnSpawnEnemy;

        private List<IEnemyView> _enemyViews;
        private List<IEnemyModel> _enemyModels;

        public EnemiesPoolController(EnemiesInitialisator enemiesInitialisator)
        {
            _enemyViews = enemiesInitialisator.GetEnemies().views;
            _enemyModels = enemiesInitialisator.GetEnemies().models;            
        }

        public (EnemyView view, EnemyModel model) ProvideZombie()
        {
            var enemyView = (EnemyView) _enemyViews[0];
            var enemyModel = (EnemyModel) _enemyModels[0];

            _enemyViews.Remove(enemyView);
            _enemyModels.Remove(enemyModel);

            OnSpawnEnemy.Invoke(enemyView, enemyModel);

            return (enemyView, enemyModel);
        }

        public void ReturnEnemyToPool(EnemyView view, EnemyModel model)
        {
            view.gameObject.SetActive(false);
            model.ZombieHealth.ResetHealth();

            _enemyViews.Add(view);
            _enemyModels.Add(model);
        }
    }
}
