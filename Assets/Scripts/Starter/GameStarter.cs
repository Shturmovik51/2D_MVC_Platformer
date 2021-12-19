using UnityEngine;

namespace Platformer2D
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private float _animationSpeed;
        [SerializeField] private float _playerMoveSpeed;
        [SerializeField] private Transform _arm;

        private ControllersManager _controllersManager;
        private GameData _gameData;

        private void Start()
        {
            _controllersManager = new ControllersManager();
            _gameData = (GameData) Resources.Load("GameData");

            new GameInitializator(_controllersManager, _gameData, _playerView, _animationSpeed, _playerMoveSpeed, _arm);

            _controllersManager.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllersManager.LocalUpdate(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllersManager.LocalLateUpdate(deltaTime);
        }

        private void FixedUpdate()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            _controllersManager.LocalFixedUpdate(fixedDeltaTime);
        }

        private void OnDestroy()
        {
            _controllersManager.CleanUp();
        }
    }
}

