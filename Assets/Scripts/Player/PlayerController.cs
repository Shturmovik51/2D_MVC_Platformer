using UnityEngine;

namespace Platformer2D
{
    public class PlayerController : IInitializable, ICleanable, IFixedUpdatable, IController
    {
        private ObjectView _playerView;
        private InputController _inputController;
        private StateController _stateController;
        private PlayerModel _playerModel;
        private Vector3 _rightDir = new Vector3(1, 1, 1);
        private Vector3 _leftDir = new Vector3(-1, 1, 1);

        public PlayerController(ObjectView playerView, InputController inputController, StateController stateController, 
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

                var direction = _playerModel.MoveSpeed * _playerView.transform.localScale.x * fixedDeltatime * Vector2.right;
                _playerView.Rigidbody.AddForce(direction, ForceMode2D.Impulse);
            }
            
        }

        private void Move(float step)
        {
            DirectionController(step);

            if (step == Mathf.Round(0) && !_playerModel.IsStay && _playerView.Rigidbody.velocity.y == Mathf.Round(0))
            {
                _stateController.SetIdleState(_playerView, _playerModel);

                var velocity = _playerView.Rigidbody.velocity;
                velocity.x = 0;
                _playerView.Rigidbody.velocity = velocity;
            }

            if (step != 0 && !_playerModel.IsRun && _playerView.Rigidbody.velocity.y == Mathf.Round(0))
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

        private void DirectionController(float step)
        {
            if (step > 0 && _playerView.Transform.localScale != _rightDir)
            {
                _playerView.Transform.localScale = _rightDir;
                _playerModel.IsRightDirection = true;
            }
            if (step < 0 && _playerView.Transform.localScale != _leftDir)
            {
                _playerView.Transform.localScale = _leftDir;
                _playerModel.IsRightDirection = false;
            }
        }
    }
}