using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class HaloAnimationsFactoty
    {
        private List<SpritesSet> _haloSprites;
        private List<Animation> _haloAnimations;
        private List<SpriteRenderer> _haloSpriteRenderers;
        private float _animationSpeed;

        public HaloAnimationsFactoty(GameData gameData, StarterGameData starterGameData)
        {
            _haloSprites = gameData.HaloAnimationConfig.SpritesSet;
            _animationSpeed = starterGameData.AnimationSpeed;

            var savePoints = starterGameData.SavePointsContainer.GetComponentsInChildren<SavePoint>();

            _haloAnimations = new List<Animation>(savePoints.Length);
            _haloSpriteRenderers = new List<SpriteRenderer>(savePoints.Length);

            foreach (var savePoint in savePoints)
            {
                _haloSpriteRenderers.Add(savePoint.HaloSpriteRenderer);

                var animation = new Animation(AnimationType.Halo, GetSprites(AnimationType.Halo), true, _animationSpeed * 0.5f, true, 0);

                _haloAnimations.Add(animation);
            }
        }

        private List<Sprite> GetSprites(AnimationType type)
        {
            return _haloSprites.Find(spriteSet => spriteSet.Type == type).Sprites;
        }

        public (List<Animation> haloAnimstions, List<SpriteRenderer> haloSpriteRenderers) GetHaloAnimations()
        {
            return (_haloAnimations, _haloSpriteRenderers);
        }
    }
}
