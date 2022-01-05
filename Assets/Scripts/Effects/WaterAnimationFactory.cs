using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class WaterAnimationFactory
    {
        private List<SpritesSet> _waterSprites;
        private List<Animation> _waterAnimations;
        private SpriteRenderer[] _waterSpriteRenderers;
        private float _animationSpeed;

        public WaterAnimationFactory(GameData gameData, StarterGameData starterGameData)
        {
            _waterSprites = gameData.WaterAnimationConfig.SpritesSet;
            _animationSpeed = starterGameData.AnimationSpeed;
            
            _waterAnimations = new List<Animation>(GetSprites(AnimationType.Water).Count);

            _waterSpriteRenderers = starterGameData.WaterContainer.GetComponentsInChildren<SpriteRenderer>();

            for (int i = 0; i < _waterSpriteRenderers.Length; i++)
            {
                var animation = new Animation(AnimationType.Water, GetSprites(AnimationType.Water), true, _animationSpeed, false, 0);

                _waterAnimations.Add(animation);                
            }
        }

        private List<Sprite> GetSprites(AnimationType type)
        {
            return _waterSprites.Find(spriteSet => spriteSet.Type == type).Sprites;
        }

        public (List<Animation> waterAnimstions, SpriteRenderer[] waterSpriteRenderers) GetWaterAnimations()
        {
            return (_waterAnimations, _waterSpriteRenderers);
        }
    }
}
