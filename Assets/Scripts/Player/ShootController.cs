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
        private Transform _shootRayStartPosition;
        private LayerMask _layerMask = LayerMask.GetMask("Destroible");
        private bool _isReadyToShoot = true;
        private float _delayTime = 0.1f;
        private float _timer;
        private int _shootForse = 5;
        private float _shootDistance = 11;
        public ShootController(InputController inputController, SpriteAnimatorController animatorController, StarterGameData starterGameData,
                    ArmController armController)
        {
            _inputController = inputController;
            _animatorController = animatorController;
            _shootEffect = starterGameData.PlayerView.ShootEffect;
            _armController = armController;
            _shootRayStartPosition = starterGameData.PlayerView.ShootEffect.transform;
        }

        public void Initialization()
        {
            _inputController.OnClickShootButton += Shoot;
        }

        public void CleanUp()
        {
            _inputController.OnClickShootButton -= Shoot;
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

            var collider = Physics2D.Raycast(_shootRayStartPosition.position, _shootRayStartPosition.right, _shootDistance, _layerMask).collider;

            if(collider != null)
                OnHitSomeThing?.Invoke(collider, _shootForse);
        }
    }
}
