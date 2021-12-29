using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class CameraPositionController: IFixedUpdatable, IController
    {
        private Camera _camera;
        private Transform _playerTransform;
        private Vector3 _newCameraPosition;
        private Vector2 _positionOffSet;

        public CameraPositionController(Camera camera, StarterGameData starterGameData)
        {
            _camera = camera;
            _playerTransform = starterGameData.PlayerView.Transform;
            _positionOffSet = new Vector2(3, 2);
        }

        public void LocalFixedUpdate(float fixedDeltatime)
        {
            if(_playerTransform.localScale.x > 0)
            {
                var position = _playerTransform.position;
                position.x += _positionOffSet.x;
                position.y += _positionOffSet.y;
                position.z = _camera.transform.position.z;

                _newCameraPosition = position;
            }

            if(_playerTransform.localScale.x < 0)
            {
                var position = _playerTransform.position;
                position.x -= _positionOffSet.x;
                position.y += _positionOffSet.y;
                position.z = _camera.transform.position.z;

                _newCameraPosition = position;
            }

            MoveCamera();
        }

        private void MoveCamera()
        {
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _newCameraPosition, 0.3f);
        }
    }
}
