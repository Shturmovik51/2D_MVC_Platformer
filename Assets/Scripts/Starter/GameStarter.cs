using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private float _animationSpeed;
        [SerializeField] private float _playerMoveSpeed;
        [SerializeField] private Transform _arm;
        [SerializeField] Transform _water;
        [SerializeField] GameObject _barrelsContainer;

        private SpriteRenderer[] _waterSpriteRenderers;
        private ControllersManager _controllersManager;
        private GameData _gameData;
        private SpriteRenderer[] _barrels;

        private void Start()
        {
            _controllersManager = new ControllersManager();
            _gameData = (GameData) Resources.Load("GameData");
            _waterSpriteRenderers = _water.GetComponentsInChildren<SpriteRenderer>();
            _barrels = _barrelsContainer.GetComponentsInChildren<SpriteRenderer>();

            new GameInitializator(_controllersManager, _gameData, _playerView, _animationSpeed, _playerMoveSpeed, _arm, 
                                    _waterSpriteRenderers, _barrels);

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

