using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class EnemiesController: IInitializable, ICleanable, IFixedUpdatable, IController
    {
        private List<EnemyView> _activeEnemiesViews;
        private List<EnemyModel> _activeEnemyModels;
        private EnemiesPoolController _enemiesPoolController;
        private SpriteAnimatorController _spriteAnimatorController;
        private AnimationType _animations;

        public EnemiesController(EnemiesPoolController enemiesPoolController, SpriteAnimatorController spriteAnimatorController)
        {
            _activeEnemiesViews = new List<EnemyView>();
            _activeEnemyModels = new List<EnemyModel>();
            _enemiesPoolController = enemiesPoolController;
            _spriteAnimatorController = spriteAnimatorController;
        }

        public void Initialization()
        {
            _enemiesPoolController.OnSpawnEnemy += AddActiveEnemy;
        }

        public void CleanUp()
        {
            _enemiesPoolController.OnSpawnEnemy -= AddActiveEnemy;
        }

        public void LocalFixedUpdate(float fixedDeltatime)
        {
           
        }

        private void AddActiveEnemy(EnemyView view, EnemyModel model)
        {
            _activeEnemiesViews.Add(view);
            _activeEnemyModels.Add(model);

            var number = Random.Range(1, 3);

            switch (number)
            {               
                case 1:
                    _spriteAnimatorController.StartAnimation(view.SpriteRenderer, AnimationType.GreenEnemyWalk);
                    break;
                case 2:
                    _spriteAnimatorController.StartAnimation(view.SpriteRenderer, AnimationType.BlueEnemyWalk);
                    break;
                default:
                    break;
            }            
        }
    }
}
