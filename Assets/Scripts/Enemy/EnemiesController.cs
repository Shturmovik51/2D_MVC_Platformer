using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class EnemiesController: IInitializable, ICleanable, IFixedUpdatable, IController
    {
        private List<EnemyView> _activeEnemiesViews;
        private List<EnemyModel> _activeEnemiesModels;
        private EnemiesPoolController _enemiesPoolController;
        private SpriteAnimatorController _spriteAnimatorController;
        private Transform _playerTransform;
        private AnimationType _animations;

        private float _agroCheckTimer = 1;
        private float _agroCheckCounter;
        private Vector3 _rightDir = new Vector3(1, 1, 1);
        private Vector3 _leftDir = new Vector3(-1, 1, 1);

        public EnemiesController(EnemiesPoolController enemiesPoolController, SpriteAnimatorController spriteAnimatorController, 
                                    StarterGameData starterGameData)
        {
            _activeEnemiesViews = new List<EnemyView>();
            _activeEnemiesModels = new List<EnemyModel>();
            _enemiesPoolController = enemiesPoolController;
            _spriteAnimatorController = spriteAnimatorController;
            _playerTransform = starterGameData.PlayerView.Transform;
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
            if (_activeEnemiesViews.Count == 0) return;

            _agroCheckCounter -= fixedDeltatime;
            if (_agroCheckCounter < 0)
            {
                for (int i = 0; i < _activeEnemiesViews.Count; i++)
                {
                    Agro(i);
                }
                _agroCheckCounter += _agroCheckTimer;
            }

            for (int i = 0; i < _activeEnemiesViews.Count; i++)
            {
                Move(fixedDeltatime, i);                

                if(_activeEnemiesModels[i].IsOnChasing)
                    Chasing(i);
                else
                    Patrol(i);
            }
        }

        private void AddActiveEnemy(EnemyView view, EnemyModel model)
        {
            _activeEnemiesViews.Add(view);
            _activeEnemiesModels.Add(model);

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

        private void Move(float fixedDeltatime, int i)
        {

            if (_activeEnemiesViews[i].Transform.localScale.x > 0)
            {
                _activeEnemiesViews[i].Rigidbody.velocity = Vector2.zero;
                var direction = _activeEnemiesModels[i].MoveSpeed * fixedDeltatime * Vector2.right;
                _activeEnemiesViews[i].Rigidbody.AddForce(direction, ForceMode2D.Impulse);
            }
            if (_activeEnemiesViews[i].Transform.localScale.x < 0)
            {
                _activeEnemiesViews[i].Rigidbody.velocity = Vector2.zero;
                var direction = _activeEnemiesModels[i].MoveSpeed * fixedDeltatime * Vector2.left;
                _activeEnemiesViews[i].Rigidbody.AddForce(direction, ForceMode2D.Impulse);
            }

        }

        private void Patrol(int i)
        {

            var enemyPosX = _activeEnemiesViews[i].Transform.position.x;

            if (enemyPosX < _activeEnemiesModels[i].LeftPatrolBorder.position.x && _activeEnemiesViews[i].Transform.localScale != _rightDir)
                _activeEnemiesViews[i].Transform.localScale = _rightDir;

            if (enemyPosX > _activeEnemiesModels[i].RightPatrolBorder.position.x && _activeEnemiesViews[i].Transform.localScale != _leftDir)
                _activeEnemiesViews[i].Transform.localScale = _leftDir;

        }

        private void Chasing(int i)
        {

            var enemyPosX = _activeEnemiesViews[i].Transform.position.x;

            if (enemyPosX < _playerTransform.position.x && _activeEnemiesViews[i].Transform.localScale != _rightDir)
                _activeEnemiesViews[i].Transform.localScale = _rightDir;

            if (enemyPosX > _playerTransform.position.x && _activeEnemiesViews[i].Transform.localScale != _leftDir)
                _activeEnemiesViews[i].Transform.localScale = _leftDir;

        }


        private void Agro(int i)
        {

            if (_activeEnemiesViews[i].AgroCheck() && !_activeEnemiesModels[i].IsOnChasing)
                _activeEnemiesModels[i].SetChasingStatus(true);
            if (!_activeEnemiesViews[i].AgroCheck() && _activeEnemiesModels[i].IsOnChasing)
                _activeEnemiesModels[i].SetChasingStatus(false);

            Debug.Log(_activeEnemiesModels[i].IsOnChasing);
        }
    }
}
