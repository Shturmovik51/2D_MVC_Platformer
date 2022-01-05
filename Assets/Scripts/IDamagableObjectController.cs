using UnityEngine;

namespace Platformer2D
{
    public interface IDamagableObjectController
    {
        public void GetDamage(Collider2D collider, int value);
    }
}
