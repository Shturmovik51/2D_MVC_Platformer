using System;
using UnityEngine;

namespace Platformer2D
{
    public class PlayerController : IInitializable, ICleanable, IFixedUpdatable, IController
    {
        private PlayerView _playerView;
        private InputController _inputController;
        private StateController _stateController;
        private PlayerModel _playerModel;
        private float _moveStep;

        public PlayerController(PlayerView playerView, InputController inputController, StateController stateController, 
                    PlayerModel playerModel)
        {
            _playerView = playerView;
            _inputController = inputController;
            _stateController = stateController;
            _playerModel = playerModel;
        }

        public void Initialization()
        {
            _inputController.OnHorizontalInput += Move;
            _inputController.OnClickJump += Jump;
            _stateController.SetIdleState(_playerView, _playerModel);
        }

        public void CleanUp()
        {
            _inputController.OnHorizontalInput -= Move;
            _inputController.OnClickJump -= Jump;
        }

        public void LocalFixedUpdate(float fixedDeltatime)
        {
            if (_playerModel.IsRun)
            {
                var velocity = _playerView.Rigidbody.velocity;
                velocity.x = 0;
                _playerView.Rigidbody.velocity = velocity;

                var direction = _playerModel.MoveSpeed * _moveStep * fixedDeltatime * Vector2.right;
                _playerView.Rigidbody.AddForce(direction, ForceMode2D.Impulse);
            }            
        }

        private void Move(float step)
        {
            _moveStep = step;

            if (_moveStep == Mathf.Round(0) && !_playerModel.IsStay && _playerView.Rigidbody.velocity.y == Mathf.Round(0) && _playerView.IsGrounded())
            {
                _stateController.SetIdleState(_playerView, _playerModel);

                var velocity = _playerView.Rigidbody.velocity;
                velocity.x = 0;
                _playerView.Rigidbody.velocity = velocity;
            }

            if (_moveStep != 0 && !_playerModel.IsRun && _playerView.Rigidbody.velocity.y == Mathf.Round(0) && _playerView.IsGrounded())
            {
                _stateController.SetRunState(_playerView, _playerModel);                
            }

            
        }

        private void Jump()
        {
            if (!_playerView.IsGrounded())
                return;

            if (!_playerModel.IsJump)
            {
                _stateController.SetJumpState(_playerView, _playerModel);
            }

            _playerView.Rigidbody.AddForce(400f * Time.fixedDeltaTime * Vector2.up, ForceMode2D.Impulse);            
        }
    }
}