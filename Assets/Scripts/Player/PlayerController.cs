using UnityEngine;

namespace Platformer2D
{
    public class PlayerController : IInitializable, ICleanable, IController
    {
        private ObjectView _playerView;
        private InputController _inputController;
        private StateController _stateController;
        private PlayerModel _playerModel;

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
            _stateController.SetIdleState(_playerView, _playerModel);
        }

        public void CleanUp()
        {
            _inputController.OnHorizontalInput -= Move;
        }

        public void Move(float step)
        {
            if (step == 0)
            {
                if (!_playerModel.IsStay)
                    _stateController.SetIdleState(_playerView, _playerModel);
            }

            var position = _playerView.transform.position;
            position.x += step * 6f * Time.deltaTime;
            _playerView.SetPosition(position);

            if (step > 0)
            {
                _playerView.SetRightDirection();

                if (_playerModel.IsRun == false)
                    _stateController.SetRunState(_playerView, _playerModel);
            }

            if (step < 0)
            {
                _playerView.SetLeftDirection();

                if (_playerModel.IsRun == false)
                    _stateController.SetRunState(_playerView, _playerModel);
            }
        }
    }
}