using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class SpriteAnimatorController : IUpdatable, IInitializable, ICleanable, IController
    { 
        private SpriteAnimationsConfig _config;
        private Dictionary<SpriteRenderer, Animation> _activeAnimations = new Dictionary<SpriteRenderer, Animation>();

        public SpriteAnimatorController(SpriteAnimationsConfig config)
        {
            _config = config;
        }

        public void Initialization()
        {

        }

        public void CleanUp()
        {
            _activeAnimations.Clear();
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, AnimationType track, bool loop, float speed)
        {
            if (_activeAnimations.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = speed;
                animation.Sleep = false;

                if (animation.AnimationType != track)
                {
                    animation.AnimationType = track;
                    animation.Sprites = _config.SpritesSet.Find(sequence => sequence.Track == track).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimations.Add(spriteRenderer, new Animation()
                {
                    AnimationType = track,
                    Sprites = _config.SpritesSet.Find(sequence => sequence.Track == track).Sprites,
                    Loop = loop,
                    Speed = speed
                });
            }
        }

        public void StopAnimation(SpriteRenderer sprite)
        {
            if (_activeAnimations.ContainsKey(sprite))
            {
                _activeAnimations.Remove(sprite);
            }
        }

        public void LocalUpdate(float deltatime)
        {
            foreach (var animation in _activeAnimations)
            {
                animation.Value.Update();
                animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
            }
        }       
    }
}