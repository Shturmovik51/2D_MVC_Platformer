using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class EffectsAnimationsFactory
    {
        private List<SpritesSet> _spritesSet;
        private List<Animation> _effectsAnimations;
        private float _animationSpeed;

        public EffectsAnimationsFactory(GameData gameData, float animationSpeed)
        {
            _spritesSet = gameData.ShootAnimationConfig.SpritesSet;
            _animationSpeed = animationSpeed;

            _effectsAnimations = new List<Animation>
            {
                new Animation(AnimationType.Shoot, GetSprites(AnimationType.Shoot), false, _animationSpeed * 2, true)                
            };
        }

        private List<Sprite> GetSprites(AnimationType type)
        {
            return _spritesSet.Find(spriteSet => spriteSet.Type == type).Sprites;
        }

        public List<Animation> GetEffectsAnimations()
        {
            return _effectsAnimations;
        }
    }
}