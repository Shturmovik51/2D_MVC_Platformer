using System;
using System.Collections.Generic;

namespace Platformer2D
{
    public class EnemiesPoolController: IInitializable, ICleanable, IController
    {
        public event Action<EnemyView, EnemyModel> OnSpawnEnemy;

        private int _enemiesCount;
        private List<IEnemyView> _enemyViews;
        private List<IEnemyModel> _enemyModels;

        public EnemiesPoolController(GameData gameData, StarterGameData starterGameData)
        {
            _enemiesCount = starterGameData.ZombiesCountInCollection;
            _enemyViews = new List<IEnemyView>(_enemiesCount);
            _enemyModels = new List<IEnemyModel>(_enemiesCount);

            for (int i = 0; i < _enemiesCount; i++)
            {
                var enemyFactory = new EnemyFactory(gameData);

                var enemy = enemyFactory.GetZombieView();
                enemy.transform.parent = starterGameData.Enemies;
                enemy.gameObject.SetActive(false);
                _enemyViews.Add(enemy);

                _enemyModels.Add(enemyFactory.GetZombieModel());
            }
        }

        public void Initialization()
        {

        }

        public void CleanUp()
        {

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
            _enemyViews.Add(view);
            _enemyModels.Add(model);
        }
    }
}
