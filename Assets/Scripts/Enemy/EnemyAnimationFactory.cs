using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class EnemyAnimationFactory
    {
        private List<SpritesSet> _spritesSet;
        private List<Animation> _enemyAnimations;
        private float _animationSpeed;

        public EnemyAnimationFactory(GameData gameData, StarterGameData _starterGameData)
        {
            _spritesSet = gameData.EnemiesAnimationConfig.SpritesSet;
            _animationSpeed = _starterGameData.AnimationSpeed;

            _enemyAnimations = new List<Animation>(_starterGameData.ZombiesCountInCollection);

            for (int i = 0; i < _starterGameData.ZombiesCountInCollection; i++)
            {
                var type1 = AnimationType.GreenEnemyWalk;
                var type2 = AnimationType.BlueEnemyWalk;

                var animation1 = new Animation(type1, GetSprites(type1), true, _animationSpeed, true, 0);
                var animation2 = new Animation(type2, GetSprites(type2), true, _animationSpeed, true, 0);

                _enemyAnimations.Add(animation1);
                _enemyAnimations.Add(animation2);
            }
        }

        private List<Sprite> GetSprites(AnimationType type)
        {
            return _spritesSet.Find(spriteSet => spriteSet.Type == type).Sprites;
        }

        public List<Animation> GetEnemiesAnimations()
        {
            return _enemyAnimations;
        }

    }
}
