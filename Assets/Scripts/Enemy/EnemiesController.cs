using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class EnemiesController: IInitializable, ICleanable, IUpdatable, IFixedUpdatable, IController, IDamagableObjectController
    {
        public event Action<EnemyView, EnemyModel> OnEnemyDeath;

        private List<EnemyView> _activeEnemiesViews;
        private List<EnemyModel> _activeEnemiesModels;
        private EnemiesPoolController _enemiesPoolController;
        private SpriteAnimatorController _spriteAnimatorController;
        private Transform _playerTransform;

        private float _agroCheckTimer = 1;
        private float _agroCheckCounter;
        private int _jumpForce = 10;
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
            OnEnemyDeath += _enemiesPoolController.ReturnEnemyToPool;
        }

        public void CleanUp()
        {
            _enemiesPoolController.OnSpawnEnemy -= AddActiveEnemy;
            OnEnemyDeath -= _enemiesPoolController.ReturnEnemyToPool;
        }

        public void LocalUpdate(float deltaTime)
        {
            if (_activeEnemiesViews.Count == 0) return;

            for (int i = 0; i < _activeEnemiesViews.Count; i++)
                _activeEnemiesViews[i].SetHealthBarPosition();
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
                    Jump(i);
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

            var number = UnityEngine.Random.Range(1, 3);

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
                var enemyVelosity = _activeEnemiesViews[i].Rigidbody.velocity;
                enemyVelosity.x = 0;
                _activeEnemiesViews[i].Rigidbody.velocity = enemyVelosity;
                var direction = _activeEnemiesModels[i].MoveSpeed * fixedDeltatime * Vector2.right;
                _activeEnemiesViews[i].Rigidbody.AddForce(direction, ForceMode2D.Impulse);
            }
            if (_activeEnemiesViews[i].Transform.localScale.x < 0)
            {
                var enemyVelosity = _activeEnemiesViews[i].Rigidbody.velocity;
                enemyVelosity.x = 0;
                _activeEnemiesViews[i].Rigidbody.velocity = enemyVelosity;
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

           // if(enemyPosX == Mathf.Round(_playerTransform.position.x)) // добавить ожидание

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
        }

        public void GetDamage(Collider2D collider, int value)
        {
            for (int i = 0; i < _activeEnemiesViews.Count; i++)
            {
                if (_activeEnemiesViews[i].Collider == collider)
                {
                    _activeEnemiesModels[i].ZombieHealth.TakeDamage(value);
                    _activeEnemiesViews[i].HealthBar.BarImage.fillAmount = _activeEnemiesModels[i].ZombieHealth.GetFillAmountValue();

                    if (_activeEnemiesModels[i].ZombieHealth.HP <= 0)
                    {
                        EnemyDeath(i);
                    }
                }
            }
        }

        private void EnemyDeath(int i)
        {
            OnEnemyDeath?.Invoke(_activeEnemiesViews[i], _activeEnemiesModels[i]);

            _activeEnemiesViews.Remove(_activeEnemiesViews[i]);
            _activeEnemiesModels.Remove(_activeEnemiesModels[i]);
        }

        private void Jump(int i)
        {
            if (_activeEnemiesViews[i].ObstacleDetector())
            {
                if (_activeEnemiesModels[i].IsOnChasing)
                {
                    if (_activeEnemiesViews[i].Transform.position.y < _playerTransform.position.y)
                        AddJumpForce(i);

                }
                else
                {
                    if (_activeEnemiesViews[i].Transform.position.y < _activeEnemiesModels[i].LeftPatrolBorder.position.y ||
                        _activeEnemiesViews[i].Transform.position.y < _activeEnemiesModels[i].RightPatrolBorder.position.y)
                        AddJumpForce(i);
                }
            } 
            
            void AddJumpForce(int i)
            {
                _activeEnemiesViews[i].Rigidbody.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);    //todo сделать проверку на ifJump
            }
        }
    }
}
