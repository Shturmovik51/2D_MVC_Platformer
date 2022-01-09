using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class SpriteAnimatorController : IInitializable, IUpdatable, ICleanable, IController
    { 
        private List<Animation> _allAnimations;
        private Dictionary<SpriteRenderer, Animation> _activeAnimations;

        public SpriteAnimatorController(AnimationsInitializator animationsInitializator, StarterGameData starterGameData)
        {
            _allAnimations = new List<Animation>();
            _activeAnimations = new Dictionary<SpriteRenderer, Animation>();

            var playerAnims = animationsInitializator.PlayerAnimationsFactory.GetPlayerAnimations();
            var effectsAnims = animationsInitializator.EffectsAnimationFactory.GetEffectsAnimations();
            var waterAnim = animationsInitializator.WaterAnimationFactory.GetWaterAnimations();
            var enemiesAnims = animationsInitializator.EnemiesAnimationsFactory.GetEnemiesAnimations();
            var haloAnim = animationsInitializator.HaloAnimationsFactoty.GetHaloAnimations();

            _allAnimations.AddRange(playerAnims);
            _allAnimations.AddRange(effectsAnims);
            _allAnimations.AddRange(enemiesAnims);

            for (int i = 0; i < waterAnim.waterAnimstions.Count; i++)
            {
                _activeAnimations.Add(waterAnim.waterSpriteRenderers[i], waterAnim.waterAnimstions[i]); 
            }

            for (int i = 0; i < haloAnim.haloAnimstions.Count; i++)
            {
                _activeAnimations.Add(haloAnim.haloSpriteRenderers[i], haloAnim.haloAnimstions[i]);
            }
        }

        public void Initialization()
        {
            
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
                _allAnimations.Remove(animation);
                _activeAnimations.Add(spriteRenderer, animation);
                animation.ResetAnimation();
            }
        }       

        public void StopAnimation(SpriteRenderer spriteRenderer)
        {
            if (_activeAnimations.ContainsKey(spriteRenderer))
            {
                _allAnimations.Add(_activeAnimations[spriteRenderer]);
                _activeAnimations.Remove(spriteRenderer);
            }
        }       
    }
}