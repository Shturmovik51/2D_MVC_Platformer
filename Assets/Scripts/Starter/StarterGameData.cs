using UnityEngine;

namespace Platformer2D
{
    [System.Serializable]
    public struct StarterGameData
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private float _animationSpeed;
        [SerializeField] private float _playerMoveSpeed;
        [SerializeField] private int _zombiesCountInCollection;

        [Header("OnSceneObjectCollections")]
        [SerializeField] private Transform _enemies;
        [SerializeField] private Transform _arm;
        [SerializeField] private Transform _waterContainer;
        [SerializeField] private Transform _barrelsContainer;

        public float AnimationSpeed { get => _animationSpeed; set => _animationSpeed = value; }/*=> _animationSpeed;*/
        public float PlayerMoveSpeed => _playerMoveSpeed;
        public int ZombiesCountInCollection => _zombiesCountInCollection;
        public PlayerView PlayerView => _playerView;
        public Transform WaterContainer => _waterContainer;
        public Transform Arm => _arm;
        public Transform BarrelsContainer => _barrelsContainer;
        public Transform Enemies => _enemies;


    }
}