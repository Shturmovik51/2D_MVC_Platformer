using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class EnemiesSpawner : MonoBehaviour, IUpdatable, IController
    {
        [SerializeField] private Transform _leftPatrolBorder;
        [SerializeField] private Transform _rightpatrolBotder;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private bool _isLeftSpawn;
        [SerializeField] private bool _isHavePatrolZone;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private int _spawnCount;

        private Vector3 _rightDir = new Vector3(1, 1, 1);
        private Vector3 _leftDir = new Vector3(-1, 1, 1);

        private bool _isSpawn;
        private EnemiesPoolController _enemiesPoolController;
        private float _currentInterval;

        public void InitSpawner(EnemiesPoolController enemiesPoolController)
        {
            _enemiesPoolController = enemiesPoolController;
            _isSpawn = true;
        }

        public void LocalUpdate(float deltaTime)
        {
            if (!_isSpawn) return;

            if (_currentInterval <= 0)
            {
                _currentInterval = _spawnInterval;
                SpawnEnemy();
            }

            _currentInterval -= deltaTime;
        }

        private void SpawnEnemy()
        {
            _spawnCount--;
            if (_spawnCount <= 0)
            {
                _isSpawn = false;
                return;
            }

            var enemy = _enemiesPoolController.ProvideZombie();
            enemy.Transform.parent = null;
            enemy.Transform.position = _spawnPoint.position;
            enemy.gameObject.SetActive(true);

            if (_isLeftSpawn)
                enemy.Transform.localScale = _leftDir;
            if (!_isLeftSpawn)
                enemy.Transform.localScale = _rightDir;

        }
    }
}
