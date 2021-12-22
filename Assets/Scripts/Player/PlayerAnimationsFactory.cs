using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class PlayerAnimationsFactory
    {
        private List<SpritesSet> _spritesSet;
        private List<Animation> _playerAnimations;
        private float _animationSpeed;

        public PlayerAnimationsFactory(GameData gameData, float animationSpeed)
        {
            _spritesSet = gameData.PlayerAnimationsConfig.SpritesSet;
            _animationSpeed = animationSpeed;

            _playerAnimations = new List<Animation>
            {
                new Animation(AnimationType.Idle, GetSprites(AnimationType.Idle), true, _animationSpeed, true, 0),
                new Animation(AnimationType.RunForward, GetSprites(AnimationType.RunForward), true, _animationSpeed, true, 0),
                new Animation(AnimationType.RunReverse, GetSprites(AnimationType.RunForward), true, _animationSpeed, false, 0),
                new Animation(AnimationType.Jump, GetSprites(AnimationType.Jump), false, _animationSpeed, true, 0),
            };
        }

        private List<Sprite> GetSprites(AnimationType type)
        {
            return _spritesSet.Find(spriteSet => spriteSet.Type == type).Sprites;
        }

        public List<Animation> GetPlayerAnimations()
        {
            return _playerAnimations;
        }

    }
}