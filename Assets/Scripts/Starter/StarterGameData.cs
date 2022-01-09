using UnityEngine;

namespace Platformer2D
{
    [System.Serializable]
    public struct StarterGameData
    {
        [SerializeField] private float _animationSpeed;
        [SerializeField] private int _zombiesCountInCollection;

        [Header("OnSceneObjectCollections")]
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private Transform _enemiesContainer;
        [SerializeField] private Transform _arm;
        [SerializeField] private Transform _waterContainer;
        [SerializeField] private Transform _barrelsContainer;
        [SerializeField] private Transform _savePointsContainer;

        public float AnimationSpeed { get => _animationSpeed; set => _animationSpeed = value; }
        public int ZombiesCountInCollection => _zombiesCountInCollection;
        public PlayerView PlayerView => _playerView;
        public Transform WaterContainer => _waterContainer;
        public Transform Arm => _arm;
        public Transform BarrelsContainer => _barrelsContainer;
        public Transform EnemiesContainer => _enemiesContainer;
        public Transform SavePointsContainer => _savePointsContainer;


    }
}