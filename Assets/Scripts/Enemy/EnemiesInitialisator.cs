using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class EnemiesInitialisator
    {
        private int _enemiesCount;
        private List<IEnemyView> _enemyViews;
        private List<IEnemyModel> _enemyModels;

        public EnemiesInitialisator(GameData gameData, StarterGameData starterGameData)
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

        public (List<IEnemyView> views, List<IEnemyModel> models) GetEnemies()
        {
            return (_enemyViews, _enemyModels);
        }
    }
}
