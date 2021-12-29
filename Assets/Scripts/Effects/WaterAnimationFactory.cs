using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class WaterAnimationFactory   // todo затупил, переделать
    {
        private List<SpritesSet> _waterSprites;
        private List<Animation> _waterAnimations;
        private float _animationSpeed;

        public WaterAnimationFactory(GameData gameData, StarterGameData starterGameData)
        {
            _waterSprites = gameData.WaterAnimationConfig.SpritesSet;
            _animationSpeed = starterGameData.AnimationSpeed;

            _waterAnimations = new List<Animation>(GetSprites(AnimationType.Water).Count);

            for (int i = 0; i < GetSprites(AnimationType.Water).Count; i++)
            {
                var animation = new Animation(AnimationType.Water, GetSprites(AnimationType.Water), true, _animationSpeed, true, i);

                _waterAnimations.Add(animation);                
            }
        }

        private List<Sprite> GetSprites(AnimationType type)
        {
            return _waterSprites.Find(spriteSet => spriteSet.Type == type).Sprites;
        }

        public List<Animation> GetWaterAnimations()
        {
            return _waterAnimations;
        }
    }
}
