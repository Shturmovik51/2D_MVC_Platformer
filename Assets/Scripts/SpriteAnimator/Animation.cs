using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class Animation
    {
        private AnimationType _animationType;
        private List<Sprite> _sprites;
        private bool _loop = false;
        private float _speed = 10;
        private bool _sleep;
        private bool _isForward;
        private int _startSprite;
        private float _spriteCounter = 0;

        public List<Sprite> Sprites => _sprites;
        public float SpriteCounter => _spriteCounter;
        public AnimationType AnimationType => _animationType;

        public Animation(AnimationType animationType, List<Sprite> sprites, bool loop, float speed, bool isForward, int startSprite)
        {
            _animationType = animationType;
            _sprites = sprites;
            _loop = loop;
            _speed = speed;
            _isForward = isForward;
            _spriteCounter = _startSprite;
        }

        public void ResetAnimation()
        {
            _spriteCounter = _startSprite;
            _sleep = false;
        }

        public void PlayAnimation(float deltatime)
        {
            if (_sleep) return;
            if (_isForward)
                PlayForward(deltatime);
            if (!_isForward)
                PlayReverse(deltatime);
        }

        private void PlayForward(float deltatime)
        {
            _spriteCounter += deltatime * _speed;

            if (_loop)
            {
                while (_spriteCounter > _sprites.Count)
                {
                    _spriteCounter -= _sprites.Count;
                }
            }
            else if (_spriteCounter > _sprites.Count)
            {
                _spriteCounter = _sprites.Count - 1;
                _sleep = true;
            }
        }

        private void PlayReverse(float deltatime)
        {
            _spriteCounter -= deltatime * _speed;

            if (_loop)
            {
                while (_spriteCounter < 0)
                {
                    _spriteCounter += _sprites.Count;
                }
            }
            else if (_spriteCounter < 0)
            {
                _spriteCounter = 0;
                _sleep = true;
            }
        }
    }
}
