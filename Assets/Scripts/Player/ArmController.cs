using UnityEngine;

namespace Platformer2D
{
    public class ArmController : IInitializable, ICleanable, IFixedUpdatable, IController
    {
        private Transform _arm;
        private Quaternion _idleRot;
        private InputController _inputController;
        private Vector3 _mousePos;
        private PlayerView _playerView;
        private Transform _shootPosition;

        private bool _isAim;

        public Transform Arm => _arm;
        public bool IsAim => _isAim;
        public ArmController(Transform arm, InputController inputController, PlayerView playerView)
        {
            _arm = arm;
            _inputController = inputController;
            _playerView = playerView;
        }

        public void Initialization()
        {
            _idleRot = _arm.localRotation;
            _inputController.OnClickAimButton += AimState;
        }

        public void CleanUp()
        {
            _inputController.OnClickAimButton -= AimState;
        }

        public void LocalFixedUpdate(float fixedDeltatime)
        {
            if (_isAim)
            { 
                if(_playerView.Transform.localScale.x > 0)
                {
                    _playerView.ShootEffect.enabled = true;
                    _mousePos = _inputController.MousePosition;
                    var dir = new Vector3 (_mousePos.x - _arm.position.x, _mousePos.y - _arm.position.y, _arm.position.z);
                    var angle = Vector3.Angle(Vector3.right, dir);
                    var axis = Vector3.Cross(Vector3.right, dir);

                    _arm.rotation = Quaternion.AngleAxis(angle, axis);
                }

                if (_playerView.Transform.localScale.x < 0)
                {
                    _playerView.ShootEffect.enabled = true;
                    _mousePos = _inputController.MousePosition;
                    var dir = new Vector3(_mousePos.x - _arm.position.x, _mousePos.y - _arm.position.y, _arm.position.z);
                    var angle = Vector3.Angle(Vector3.left, dir);
                    var axis = Vector3.Cross(Vector3.left, dir);

                    _arm.rotation = Quaternion.AngleAxis(angle, axis);
                }

            }
            else if (_arm.localRotation != _idleRot)
            {
                _arm.localRotation = _idleRot;
                _playerView.ShootEffect.enabled = false;
            }
        }

        private void SetArmRotation(Vector3 direction) // todo закрасивить DRY
        {

        }

        private void AimState(bool isAim)
        {
            _isAim = isAim;
        }

    }
}
