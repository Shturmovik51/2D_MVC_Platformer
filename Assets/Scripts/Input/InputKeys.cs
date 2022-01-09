using System;
using UnityEngine;

namespace Platformer2D
{
    public sealed class InputKeys
    {
        public void GetKeyShoot(InputKeysConfig _inputKeysData, Action action)
        {
            if (Input.GetKey(_inputKeysData.Shoot)) action?.Invoke();
        }

        public void GetKeyAimDown(InputKeysConfig _inputKeysData, Action<bool> action)
        {
            if (Input.GetKeyDown(_inputKeysData.Aim)) action?.Invoke(true);
        }

        public void GetKeyAimUp(InputKeysConfig _inputKeysData, Action<bool> action)
        {
            if (Input.GetKeyUp(_inputKeysData.Aim)) action?.Invoke(false);
        }

        public void GetKeySaveDown(InputKeysConfig _inputKeysData, Action action)
        {
            if (Input.GetKeyDown(_inputKeysData.Save)) action?.Invoke();
        }

        public void GetKeyLoadDown(InputKeysConfig _inputKeysData, Action action)
        {
            if (Input.GetKeyDown(_inputKeysData.Load)) action?.Invoke();
        }

        public void GetKeyJumpDown(InputKeysConfig _inputKeysData, Action<bool> onJump)
        {
            if (Input.GetKeyDown(_inputKeysData.Jump) && Input.GetKey(_inputKeysData.Down)) onJump?.Invoke(false);
            else if (Input.GetKeyDown(_inputKeysData.Jump)) onJump?.Invoke(true);
        }

    }
}
