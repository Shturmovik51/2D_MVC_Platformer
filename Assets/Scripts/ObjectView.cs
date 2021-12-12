using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class ObjectView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;

        public Transform Transform => _transform;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Collider2D Collider => _collider;
        public Rigidbody2D Rigidbody => _rigidbody;

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
