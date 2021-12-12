using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class Animation
    {
        public AnimationType AnimationType;
        public List<Sprite> Sprites;
        public bool Loop = false;
        public float Speed = 10;
        public float Counter = 0;
        public bool Sleep;

        public void PlayAnimation(float deltatime)
        {
            if (Sleep) return;
            Counter += deltatime * Speed;
            if (Loop)
            {
                while (Counter > Sprites.Count)
                {
                    Counter -= Sprites.Count;
                }
            }
            else if (Counter > Sprites.Count)
            {
                Counter = Sprites.Count - 1;
                Sleep = true;
            }
        }
    }
}
