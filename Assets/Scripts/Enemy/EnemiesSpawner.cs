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
        [SerializeField] private bool _isNoMove;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private int _spawnCount;

        private Vector3 _rightDir = new Vector3(1, 1, 1);
        private Vector3 _leftDir = new Vector3(-1, 1, 1);

        private bool _isSpawn;
        private EnemiesPoolController _enemiesPoolController;
        private HealthBarPoolController _healthBarPoolController;
        private float _currentInterval;

        public void InitSpawner(EnemiesPoolController enemiesPoolController, HealthBarPoolController healthBarPoolController)
        {
            _enemiesPoolController = enemiesPoolController;
            _healthBarPoolController = healthBarPoolController;
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
            if (_spawnCount < 0)
            {
                _isSpawn = false;
                return;
            }

            var enemy = _enemiesPoolController.ProvideZombie();
            var healthBar = _healthBarPoolController.ProvideHealthBar();

            enemy.view.InitHealthBar(healthBar);
            enemy.view.Transform.parent = null;
            enemy.view.Transform.position = _spawnPoint.position;
            enemy.view.SpriteRenderer.sortingOrder = Random.Range(3, 11);   //todo хардкод

            if (_isLeftSpawn)
                enemy.view.Transform.localScale = _leftDir;
            if (!_isLeftSpawn)
                enemy.view.Transform.localScale = _rightDir;

            if (_isHavePatrolZone)
                enemy.model.SetPatrolZone(_leftPatrolBorder, _rightpatrolBotder);

            if (_isNoMove)
                enemy.view.Rigidbody.freezeRotation = false;

            enemy.view.gameObject.SetActive(true);
        }
    }
}
