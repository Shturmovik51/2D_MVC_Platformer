using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class SpriteAnimatorController : IUpdatable, ICleanable, IController
    { 
        private List<Animation> _allAnimations;
        private Dictionary<SpriteRenderer, Animation> _activeAnimations;

        private int _waterAnimationsCounter;

        public SpriteAnimatorController(PlayerAnimationsFactory playerAnimFactory, EffectsAnimationsFactory effectsAnimFactory,
                                            WaterAnimationFactory waterAnimationFactory, SpriteRenderer[] waterSpriteRenderers)
        {
            _allAnimations = new List<Animation>();
            _activeAnimations = new Dictionary<SpriteRenderer, Animation>();

            _allAnimations.AddRange(playerAnimFactory.GetPlayerAnimations());
            _allAnimations.AddRange(effectsAnimFactory.GetEffectsAnimations());

            
            _waterAnimationsCounter = 0;

            for (int i = 0; i < waterSpriteRenderers.Length; i++)
            {
                _activeAnimations.Add(waterSpriteRenderers[i], waterAnimationFactory.GetWaterAnimations()[i]);
                _waterAnimationsCounter++;

                if (_waterAnimationsCounter == waterAnimationFactory.GetWaterAnimations().Count)
                    _waterAnimationsCounter = 0;
            }
        }

        public void CleanUp()
        {
            _activeAnimations.Clear();
        }
        
        public void LocalUpdate(float deltatime)
        {
            foreach (var animation in _activeAnimations)
            {
                animation.Value.PlayAnimation(deltatime);
                animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.SpriteCounter];
            }
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, AnimationType type)
        {
            if(_activeAnimations.TryGetValue(spriteRenderer, out var animation))
            {
                animation.ResetAnimation();
            }
            else
            {
                animation = _allAnimations.Find(animation => animation.AnimationType == type);
                animation.ResetAnimation();
                _activeAnimations.Add(spriteRenderer, animation);
            }
        }

        public void StopAnimation(SpriteRenderer sprite)
        {
            if (_activeAnimations.ContainsKey(sprite))
            {
                _activeAnimations.Remove(sprite);
            }
        }       
    }
}