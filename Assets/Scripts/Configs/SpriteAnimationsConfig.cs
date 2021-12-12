using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(fileName = "SpriteAnimationsConfig", menuName = "Configs/SpriteAnimationsConfig", order = 1)]
    public class SpriteAnimationsConfig : ScriptableObject
    {
        [SerializeField] private List<SpritesSet> _spritesSet = new List<SpritesSet>();

        public List<SpritesSet> SpritesSet => _spritesSet;
    }
}