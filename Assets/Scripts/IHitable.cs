using UnityEngine;

namespace Platformer2D
{
    public interface IHitable
    {
        public Collider2D Collider { get; }
    }
}
