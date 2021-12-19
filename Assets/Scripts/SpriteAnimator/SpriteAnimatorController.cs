using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class SpriteAnimatorController : IUpdatable, ICleanable, IController
    { 
        private List<Animation> _allAnimations;
        private Dictionary<SpriteRenderer, Animation> _activeAnimations;

        public SpriteAnimatorController(PlayerAnimationsFactory playerAnimationsFactory)
        {
            _allAnimations = new List<Animation>();
            _activeAnimations = new Dictionary<SpriteRenderer, Animation>();

            _allAnimations.AddRange(playerAnimationsFactory.GetPlayerAnimations());
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