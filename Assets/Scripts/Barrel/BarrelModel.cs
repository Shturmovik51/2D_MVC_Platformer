using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class BarrelModel
    {
        public Health _health { get; } 

        public BarrelModel()
        {
            _health = new Health(5,5);
        }
    }
}
