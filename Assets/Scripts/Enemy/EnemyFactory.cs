using UnityEngine;

namespace Platformer2D
{
    public class EnemyFactory
    {
        private EnemyView _enemyView;
        private EnemyModel _enemyModel;

        public EnemyFactory(GameData gameData)
        {
            _enemyView = Object.Instantiate(gameData.EnemyConfig.EnemyPrefab).GetComponent<EnemyView>();
            _enemyModel = new EnemyModel(gameData);
        }

        public EnemyView GetZombieView()
        {
            return _enemyView;
        }

        public EnemyModel GetZombieModel()
        {
            return _enemyModel;
        }
    }
}
