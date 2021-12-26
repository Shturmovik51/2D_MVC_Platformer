using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class FlipController: IUpdatable, IController
    {
        private ArmController _armController;
        private PlayerView _playerView;
        private InputController _inputController;
        private Transform _shootEffectTransform;

        private Vector3 _rightShootRotation = new Vector3 (0,0,0);
        private Vector3 _leftShootRotation = new Vector3 (0,0,-180);

        private Vector3 _rightDir = new Vector3(1, 1, 1);
        private Vector3 _leftDir = new Vector3(-1, 1, 1);
        public FlipController(ArmController armController, PlayerView playerView, InputController inputController)
        {
            _armController = armController;
            _playerView = playerView;
            _inputController = inputController;
            _shootEffectTransform = playerView.ShootEffect.transform;
        }

        public void LocalUpdate(float deltaTime)
        {
            if(_playerView.Transform.position.x - _inputController.MousePosition.x < 0 && _playerView.Transform.localScale != _rightDir)
            {
                _playerView.Transform.localScale = _rightDir;
                _shootEffectTransform.localScale = _rightDir;
                _shootEffectTransform.localRotation = Quaternion.Euler(_rightShootRotation);
            }
            if (_playerView.Transform.position.x - _inputController.MousePosition.x > 0 && _playerView.Transform.localScale != _leftDir)
            {
                _playerView.Transform.localScale = _leftDir;
                _shootEffectTransform.localScale = _leftDir;
                _shootEffectTransform.localRotation = Quaternion.Euler(_leftShootRotation);
            }
        }
    }
}
