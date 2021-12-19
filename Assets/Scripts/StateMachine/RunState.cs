using UnityEngine;

namespace Platformer2D
{
    public class RunState : IState
    {
        public bool IsRun { get; }
        public bool IsJump { get; }
        public bool IsStay { get; }

        private PlayerView _playerView;
        private SpriteAnimatorController _animatorController;
        private float _currentScale;

        public RunState()
        {
            IsRun = true;
            IsJump = false;
            IsStay = false;
        }

        public void EnterState(PlayerView playerView, SpriteAnimatorController animatorController)
        {
            _playerView = playerView;
            _animatorController = animatorController;
            _currentScale = 0;            
        }

        public void BeingInState()
        {
            if (_playerView.Transform.localScale.x != _currentScale)
            {
                _currentScale = _playerView.Transform.localScale.x;
                _animatorController.StopAnimation(_playerView.SpriteRenderer);

                if (_currentScale > 0 && _playerView.Rigidbody.velocity.x > 0)
                    _animatorController.StartAnimation(_playerView.SpriteRenderer, AnimationType.RunForward);
                if (_currentScale > 0 && _playerView.Rigidbody.velocity.x < 0)
                    _animatorController.StartAnimation(_playerView.SpriteRenderer, AnimationType.RunReverse);
                if (_currentScale < 0 && _playerView.Rigidbody.velocity.x > 0)
                    _animatorController.StartAnimation(_playerView.SpriteRenderer, AnimationType.RunReverse);
                if (_currentScale < 0 && _playerView.Rigidbody.velocity.x < 0)
                    _animatorController.StartAnimation(_playerView.SpriteRenderer, AnimationType.RunForward);
            }
        }

        public void ExitState(PlayerView playerView, SpriteAnimatorController animatorController)
        {
            animatorController.StopAnimation(playerView.SpriteRenderer);
        }
    }
}
