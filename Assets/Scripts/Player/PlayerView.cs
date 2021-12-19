using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _groundDetector;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private SpriteRenderer _shootEffect;
        private float _groundDetectorRadius = 0.2f;

        public Transform Transform => _transform;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Collider2D Collider => _collider;
        public Rigidbody2D Rigidbody => _rigidbody;
        public SpriteRenderer ShootEffect => _shootEffect;

        public bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundDetector.position, _groundDetectorRadius, _groundMask);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetRightDirection()
        {
            var scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }

        public void SetLeftDirection()
        {
            var scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
        }
    }
}
