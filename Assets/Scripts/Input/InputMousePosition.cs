using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class InputMousePosition
    {
        private Camera _mainCamera;

        public InputMousePosition()
        {
            _mainCamera = Camera.main;
        }

        public Vector3 GetMousePosition()
        {
            var mousePos = Input.mousePosition;
            return _mainCamera.ScreenToWorldPoint(mousePos);
        }
    }
}