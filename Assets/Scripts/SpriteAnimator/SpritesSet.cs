using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    [System.Serializable]
    public class SpritesSet
    {
        [SerializeField] private AnimationType _track;
        [SerializeField] private List<Sprite> _sprites;

        public SpritesSet()
        {
            _sprites = new List<Sprite>();
        }

        public AnimationType Track => _track;
        public List<Sprite> Sprites => _sprites;
    }
}