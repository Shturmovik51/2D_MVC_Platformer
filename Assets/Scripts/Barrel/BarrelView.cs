using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class BarrelView
    {
        private Collider2D _collider;
        private Transform _barrelTransform;
        private Rigidbody2D _barrelRigidbody;

        public Collider2D Collider => _collider;

        public BarrelView(Collider2D collider, Transform barrelTransform, Rigidbody2D barrelRigidbody)
        {
            _collider = collider;
            _barrelTransform = barrelTransform;
            _barrelRigidbody = barrelRigidbody;
        }

        public void Explosion()
        {
            Collider2D[] colliders = new Collider2D[60];
            Physics2D.OverlapCircleNonAlloc(_barrelTransform.position, 3, colliders);

            foreach (var hit in colliders)
            {
                if (hit == null) return;

                if (hit.TryGetComponent<Rigidbody2D>(out var hitRigidbody))
                {
                    if (hitRigidbody == _barrelRigidbody) return;

                    hitRigidbody.bodyType = RigidbodyType2D.Dynamic;
                    //hitRigidbody.AddExplosionForce(200000, _barrelTransform.position, 10, 3,ForceMode2D.Impulse);
                    hitRigidbody.AddForce((hitRigidbody.transform.position - _barrelTransform.position).normalized * 30, ForceMode2D.Impulse);
                }
            }
        }
    }
}
