using System;
using UnityEngine;

namespace Platformer2D
{
    public class ShootController: IInitializable, ICleanable, IController, IUpdatable
    {
        public event Action<Collider2D, int> OnHitSomeThing;

        private InputController _inputController;
        private SpriteAnimatorController _animatorController;
        private ShootEffectsPoolController _shootEffectsPoolController;
        private SpriteRenderer _shootEffect;
        private ArmController _armController;
        private Transform _shootRayStartPosition;
        private Transform _bulletShellStartPosition;
        private Transform _playerView;
        private LayerMask _layerMask = 1<<7|1<<9;   // 7 - Enemy, 9 - Barrel
        private bool _isReadyToShoot = true;
        private float _delayTime = 0.1f;
        private float _timer;
        private int _shootForse = 5;
        private int _bulletShellDropForce = 3;
        private float _shootDistance = 12;
        public ShootController(InputController inputController, SpriteAnimatorController animatorController, StarterGameData starterGameData,
                    ArmController armController, ShootEffectsPoolController shootEffectsPoolController)
        {
            _inputController = inputController;
            _animatorController = animatorController;
            _shootEffect = starterGameData.PlayerView.ShootEffect;
            _armController = armController;
            _shootRayStartPosition = starterGameData.PlayerView.ShootEffect.transform;
            _shootEffectsPoolController = shootEffectsPoolController;
            _bulletShellStartPosition = starterGameData.PlayerView.BulletShellPosition;
            _playerView = starterGameData.PlayerView.Transform;
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

            var bulletShell = _shootEffectsPoolController.ProvideBulletShell();
            bulletShell.transform.rotation = _bulletShellStartPosition.rotation;
            bulletShell.transform.position = _bulletShellStartPosition.position;
            var bulletShellRigidbody = bulletShell.GetComponent<Rigidbody2D>();
            bulletShellRigidbody.velocity = Vector2.zero;
            bulletShell.SetActive(true);
            bulletShellRigidbody.AddTorque(UnityEngine.Random.Range(-5,5));

            if (_playerView.localScale.x > 0)
                bulletShellRigidbody.AddForce((bulletShell.transform.up * _bulletShellDropForce - bulletShell.transform.right), ForceMode2D.Impulse);
            if (_playerView.localScale.x < 0)
                bulletShellRigidbody.AddForce((bulletShell.transform.up * _bulletShellDropForce + bulletShell.transform.right), ForceMode2D.Impulse);

            var collider = Physics2D.Raycast(_shootRayStartPosition.position, _shootRayStartPosition.right, _shootDistance, _layerMask).collider;

            if(collider != null)
                OnHitSomeThing?.Invoke(collider, _shootForse);
        }
    }
}
