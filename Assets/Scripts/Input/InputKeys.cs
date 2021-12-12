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

        public void GetKeySaveDown(InputKeysConfig _inputKeysData, Action action)
        {
            if (Input.GetKeyDown(_inputKeysData.Save)) action?.Invoke();
        }

        public void GetKeyLoadDown(InputKeysConfig _inputKeysData, Action action)
        {
            if (Input.GetKeyDown(_inputKeysData.Load)) action?.Invoke();
        }
    }
}
