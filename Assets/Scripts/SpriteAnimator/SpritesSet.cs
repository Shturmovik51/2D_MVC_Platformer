using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    [System.Serializable]
    public class SpritesSet
    {
        [SerializeField] private AnimationType _type;
        [SerializeField] private List<Sprite> _sprites;

        public SpritesSet()
        {
            _sprites = new List<Sprite>();
        }

        public AnimationType Type => _type;
        public List<Sprite> Sprites => _sprites;
    }
}