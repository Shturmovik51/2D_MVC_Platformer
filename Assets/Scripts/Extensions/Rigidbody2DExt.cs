using UnityEngine;

namespace Platformer2D
{
    public static class Rigidbody2DExt
    {
        public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, 
                                                float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Impulse)
        {
            var explosionDir = rb.position - explosionPosition;
            var explosionDistance = explosionDir.magnitude;

            if (upwardsModifier == 0)
                explosionDir /= explosionDistance;
            else
            {
                explosionDir.y += upwardsModifier;
                explosionDir.Normalize();
            }

            rb.AddForce(Mathf.Lerp(0, explosionForce, (1 - explosionDistance)) * explosionDir, mode);
        }
    }
}