using UnityEngine;

namespace Platformer2D
{
    [System.Serializable]
    public struct StarterGameData
    {
        [SerializeField] private float _animationSpeed;

        [Header("PoolsSettings")]
        [SerializeField] private Transform _pools;
        [SerializeField] private int _zombiesCountInPool;
        [SerializeField] private int _bulletShellsCountInPool;
        [SerializeField] private float _bulletShellLifeTime;
        [SerializeField] private int _hitEffectsCountInPool;
        [SerializeField] private float _hitEffectLifeTime;

        [Header("OnSceneObjectCollections")]
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private Transform _enemiesContainer;
        [SerializeField] private Transform _waterContainer;
        [SerializeField] private Transform _barrelsContainer;
        [SerializeField] private Transform _savePointsContainer;
        [SerializeField] private Transform _spawnersContainer;

        public float AnimationSpeed { get => _animationSpeed; set => _animationSpeed = value; }
        public int ZombiesCountInCollection => _zombiesCountInPool;
        public PlayerView PlayerView => _playerView;
        public Transform WaterContainer => _waterContainer;
        public Transform BarrelsContainer => _barrelsContainer;
        public Transform EnemiesContainer => _enemiesContainer;
        public Transform SavePointsContainer => _savePointsContainer;
        public Transform SpawnersContainer => _spawnersContainer;
        public Transform Pools => _pools;
        public int BulletShellsCountInPool => _bulletShellsCountInPool;
        public int HitEffectsCountInPool => _hitEffectsCountInPool;
        public float BulletShellLifeTime => _bulletShellLifeTime;
        public float HitEffectLifeTime => _hitEffectLifeTime;
    }
}