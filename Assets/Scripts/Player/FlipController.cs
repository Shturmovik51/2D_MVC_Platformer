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

        private Vector3 _rightDir = new Vector3(1, 1, 1);
        private Vector3 _leftDir = new Vector3(-1, 1, 1);
        public FlipController(ArmController armController, PlayerView playerView, InputController inputController)
        {
            _armController = armController;
            _playerView = playerView;
            _inputController = inputController;
        }

        public void LocalUpdate(float deltaTime)
        {
            var speed = _playerView.Rigidbody.velocity.x;

            if(_playerView.Transform.position.x - _inputController.MousePosition.x < 0)
            {
                _playerView.Transform.localScale = _rightDir;
            }
            else
            {
                _playerView.Transform.localScale = _leftDir;
            }


            //if (speed > 0 && _playerView.Transform.localScale != _rightDir)
            //{
            //    _playerView.Transform.localScale = _rightDir;
            //}
            //if (speed < 0 && _playerView.Transform.localScale != _leftDir)
            //{
            //    _playerView.Transform.localScale = _leftDir;
            //}
        }
    }
}
