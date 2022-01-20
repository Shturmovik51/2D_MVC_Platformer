using UnityEngine;
using UnityEngine.Tilemaps;

namespace Platformer2D
{
    [System.Serializable]
    public struct StarterGameData
    {
        [SerializeField] private float _animationSpeed;
        [SerializeField] private int _killsToWin;

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

        [Header("MapGeneratorProperties")]
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Tile _groundTile;
        [SerializeField] private Tile _grassTile;
        [SerializeField] private int _mapHeight;
        [SerializeField] private int _mapWidth;
        [SerializeField] private bool _borders;
        [SerializeField] [Range(0, 100)] private int _fillPercent;
        [SerializeField] [Range(0, 100)] private int _factorSmooth;

        public int aaa;
            
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
        public Tilemap Tilemap => _tilemap;
        public Tile GroundTile => _groundTile;
        public Tile GrassTile => _grassTile;
        public int MapHeight => _mapHeight;
        public int MapWidth => _mapWidth;
        public bool Borders => _borders;
        public int FillPercent => _fillPercent;
        public int FactorSmooth => _factorSmooth;
        public int KillsToWin => _killsToWin;
    }
}