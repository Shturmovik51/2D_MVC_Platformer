using System;
using UnityEngine;

namespace Platformer2D
{
    public class PlayerController : IInitializable, ICleanable, IUpdatable, IFixedUpdatable, IController
    {
        private PlayerView _playerView;
        private InputController _inputController;
        private StateController _stateController;
        private PlayerModel _playerModel;
        private float _moveStep;

        private Transform _reviewPosition;
        private float _groundDetectionDelayTimer = 0.4f;
        private float _groundDetectionDelayTimerCountDoun;
        private float _ignoreGroundLayerDelayTime = 0.4f;
        private float _ignoreGroundLayerDelayTimerCountDoun;
        private bool _isGroundLayerIgnored;

        public PlayerController(StarterGameData starterGameData, InputController inputController, StateController stateController, 
                    PlayerModel playerModel)
        {
            _playerView = starterGameData.PlayerView;
            _inputController = inputController;
            _stateController = stateController;
            _playerModel = playerModel;            
        }

        public void Initialization()
        {
            _inputController.OnHorizontalInput += Move;
            _inputController.OnClickJump += Jump;
            _playerView.OnSetSavePoint += SetReviewPosition;

            _stateController.SetIdleState(_playerView, _playerModel);
            _groundDetectionDelayTimerCountDoun = _groundDetectionDelayTimer;
            _ignoreGroundLayerDelayTimerCountDoun = _ignoreGroundLayerDelayTime;
        }

        public void CleanUp()
        {
            _inputController.OnHorizontalInput -= Move;
            _inputController.OnClickJump -= Jump;
            _playerView.OnSetSavePoint -= SetReviewPosition;
        }

        public void LocalUpdate(float deltaTime)
        {
            if (_playerView.IsGroundDetectionDelay)
            {
                _groundDetectionDelayTimerCountDoun -= deltaTime;

                if(_groundDetectionDelayTimerCountDoun <= 0)
                {
                    _groundDetectionDelayTimerCountDoun = _groundDetectionDelayTimer;
                    _playerView.SetGroundDetectionDelayStatus(false);
                }
            }

            GroundLayerIgnoreTimer(deltaTime);

            if (_playerView.Transform.position.y < -8)
                TeleportPlayer();
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

            if (_moveStep == Mathf.Round(0) && !_playerModel.IsStay && _playerView.IsGrounded())
            {
                _stateController.SetIdleState(_playerView, _playerModel);

                var velocity = _playerView.Rigidbody.velocity;
                velocity.x = 0;
                _playerView.Rigidbody.velocity = velocity;
            }

            if (_moveStep != 0 && !_playerModel.IsRun && _playerView.IsGrounded())
            {
                _stateController.SetRunState(_playerView, _playerModel);                
            }

            
        }

        private void Jump(bool isUpJump)
        {
            if (!_playerView.IsGrounded())
                return;

            if (!_playerModel.IsJump)
            {
                _playerView.SetGroundDetectionDelayStatus(true);
                _stateController.SetJumpState(_playerView, _playerModel);

                if (isUpJump)
                    _playerView.Rigidbody.AddForce(_playerModel.JumpForce * Time.fixedDeltaTime * Vector2.up, ForceMode2D.Impulse);
                else
                {
                    Physics2D.IgnoreLayerCollision(8, 3, true);
                    _isGroundLayerIgnored = true;
                }
            }
        }   
        
        private void SetReviewPosition(Transform transform)
        {
            _reviewPosition = transform;
        }

        private void TeleportPlayer()
        {
            _playerView.Rigidbody.velocity = Vector2.zero;
            _playerView.Transform.position = _reviewPosition.position;
        }

        private void GroundLayerIgnoreTimer(float deltaTime)
        {
            if (_isGroundLayerIgnored)
            {
                _ignoreGroundLayerDelayTimerCountDoun -= deltaTime;

                if (_ignoreGroundLayerDelayTimerCountDoun <= 0)
                {
                    _ignoreGroundLayerDelayTimerCountDoun = _ignoreGroundLayerDelayTime;
                    _isGroundLayerIgnored = false;
                    Physics2D.IgnoreLayerCollision(8, 3, false);
                }
            }
        }
    }
}