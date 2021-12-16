using System;
using UnityEngine;

namespace Platformer2D
{
    public sealed class InputController : IUpdatable, IController
    {
        public event Action<float> OnHorizontalInput = delegate { };
        public event Action OnClickShootButton;
        public event Action OnClickSave;
        public event Action OnClickLoad;
        public event Action OnClickJump;

        private readonly InputKeys _inputKeys;
        private readonly InputAxis _inputAxis;
        private readonly InputKeysConfig _inputKeysData;

        public InputController(GameData gameData)
        {
            _inputKeys = new InputKeys();
            _inputAxis = new InputAxis();
            _inputKeysData = gameData.UserInput;
        }

        public void LocalUpdate(float deltaTime)
        {
            if (Time.timeScale == Mathf.Round(0)) return;

            OnHorizontalInput.Invoke(_inputAxis.GetHorisontalAxis());

            _inputKeys.GetKeyShoot(_inputKeysData, OnClickShootButton);
            _inputKeys.GetKeySaveDown(_inputKeysData, OnClickSave);
            _inputKeys.GetKeyLoadDown(_inputKeysData, OnClickLoad);
            _inputKeys.GetKeyJumpDown(_inputKeysData, OnClickJump);
        }        
    }
}
