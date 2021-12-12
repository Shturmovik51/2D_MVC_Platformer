using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class PlayerController : IInitializable, ICleanable, IController
    {
        private ObjectView _playerView;
        private InputController _inputController;

        public PlayerController(ObjectView playerView, InputController inputController)
        {
            _playerView = playerView;
            _inputController = inputController;
        }

        public void Initialization()
        {
            _inputController.OnHorizontalInput += Move;
        }

        public void CleanUp()
        {
            _inputController.OnHorizontalInput -= Move;
        }

        public void Move(float step)
        {
            var position = _playerView.transform.position;
            position.x += step * 3f * Time.deltaTime;
            _playerView.SetPosition(position);

            if (step > 0)
            {
                _playerView.SetRightDirection();
            }

            if (step < 0)
            {
                _playerView.SetLeftDirection();
            }
        }
    }
}