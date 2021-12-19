using System;
using UnityEngine;

namespace Platformer2D
{
    public sealed class InputController : IUpdatable, IController
    {
        public event Action<float> OnHorizontalInput = delegate { };
        public event Action OnClickShootButton;
        public event Action<bool> OnClickAimButton;
        public event Action OnClickSave;
        public event Action OnClickLoad;
        public event Action OnClickJump;

        private readonly InputKeys _inputKeys;
        private readonly InputAxis _inputAxis;
        private readonly InputKeysConfig _inputKeysData;
        private readonly InputMousePosition _inputMousePosition;

        private Vector3 _mousePosition;

        public Vector3 MousePosition => _mousePosition;

        public InputController(GameData gameData)
        {
            _inputKeys = new InputKeys();
            _inputAxis = new InputAxis();
            _inputMousePosition = new InputMousePosition();
            _inputKeysData = gameData.UserInput;
        }

        public void LocalUpdate(float deltaTime)
        {
            if (Time.timeScale == Mathf.Round(0)) return;

            OnHorizontalInput.Invoke(_inputAxis.GetHorisontalAxis());

            _mousePosition = _inputMousePosition.GetMousePosition();

            _inputKeys.GetKeyShoot(_inputKeysData, OnClickShootButton);
            _inputKeys.GetKeyAimDown(_inputKeysData, OnClickAimButton);
            _inputKeys.GetKeyAimUp(_inputKeysData, OnClickAimButton);
            _inputKeys.GetKeySaveDown(_inputKeysData, OnClickSave);
            _inputKeys.GetKeyLoadDown(_inputKeysData, OnClickLoad);
            _inputKeys.GetKeyJumpDown(_inputKeysData, OnClickJump);
        }        
    }
}
