using System;
using UnityEngine;

namespace Platformer2D
{
    public class ShootController: IInitializable, ICleanable, IController, IUpdatable
    {
        public event Action<Collider2D, int> OnHitSomeThing;

        private InputController _inputController;
        private SpriteAnimatorController _animatorController;
        private SpriteRenderer _shootEffect;
        private ArmController _armController;
        private bool _isReadyToShoot = true;
        private float _delayTime = 0.1f;
        private float _timer;
        private int _shootForse = 5;
        public ShootController(InputController inputController, SpriteAnimatorController animatorController, PlayerView playerView,
                    ArmController armController)
        {
            _inputController = inputController;
            _animatorController = animatorController;
            _shootEffect = playerView.ShootEffect;
            _armController = armController;
        }

        public void Initialization()
        {
            _inputController.OnClickShootButton += Shoot;
        }

        public void CleanUp()
        {
            
        }

        public void LocalUpdate(float deltaTime)
        {
            if (!_isReadyToShoot)
            {
                _timer -= deltaTime;

                if (_timer < 0)
                    _isReadyToShoot = true;
            }
        }

        private void Shoot()
        {
            if (!_armController.IsAim) return;
            if (!_isReadyToShoot) return;
            
            _isReadyToShoot = false;
            _timer = _delayTime;
            _animatorController.StartAnimation(_shootEffect, AnimationType.Shoot);

            if (Physics2D.Raycast(_armController.Arm.position, _armController.Arm.forward))
                Debug.Log("hit");
        }
    }
}
