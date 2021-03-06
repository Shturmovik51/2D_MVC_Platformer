using System;
using UnityEngine;

namespace Platformer2D
{
    public class PlayerView : MonoBehaviour
    {
        public event Action<Transform> OnSetSavePoint;

        [SerializeField] private Transform _transform;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _groundDetector;
        [SerializeField] private SpriteRenderer _shootEffect;
        [SerializeField] private Transform _arm;
        [SerializeField] private Transform _bulletShellPosition;

        private LayerMask _groundMask = 1 << 3 | 1 << 7 | 1 << 9;  // 3 - Ground, 7 - Enemy, 9 - Barrel
        private float _groundDetectorRadius = 0.4f;
        private bool _isGroundDetectionDelay;
        public Transform Transform => _transform;
        public Transform Arm => _arm;
        public Transform BulletShellPosition => _bulletShellPosition;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Collider2D Collider => _collider;
        public Rigidbody2D Rigidbody => _rigidbody;
        public SpriteRenderer ShootEffect => _shootEffect;
        public bool IsGroundDetectionDelay => _isGroundDetectionDelay;

        public bool IsGrounded()
        {
            if (!_isGroundDetectionDelay) 
                return Physics2D.OverlapCircle(_groundDetector.position, _groundDetectorRadius, _groundMask);
            else
                return false;
        }

        public void SetGroundDetectionDelayStatus(bool status)
        {
            _isGroundDetectionDelay = status;
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

        public void SetSavePoint(Transform pointTransform)
        {
            OnSetSavePoint?.Invoke(pointTransform);
        }
    }
}
