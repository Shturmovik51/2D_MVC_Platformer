using UnityEngine;

namespace Platformer2D
{
    public interface IDamagable
    {
        public void GetDamage(Collider2D collider, int value);
    }
}
