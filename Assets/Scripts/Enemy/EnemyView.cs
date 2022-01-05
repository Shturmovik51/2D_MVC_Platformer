using UnityEngine;

namespace Platformer2D
{
    public class EnemyView : MonoBehaviour, IEnemyView, IHitable
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private LayerMask _groundMask;

        private Camera _camera;
        private float _targetDetectorRadius = 6;
        public HealthBar HealthBar { get; private set; }

        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Transform Transform => _transform;
        public Rigidbody2D Rigidbody => _rigidbody;
        public Collider2D Collider => _collider;

        public void InitHealthBar(HealthBar healthBar)
        {
            HealthBar = healthBar;
        }

        public bool AgroCheck()
        {
            return Physics2D.OverlapCircle(_transform.position, _targetDetectorRadius, _groundMask);
        }

        public void SetHealthBarPosition()
        {
            if (_camera == null)
                _camera = Camera.main;

            HealthBar.HealhBarObject.position = _camera.WorldToScreenPoint(_transform.position + (Vector3.up));
        }
    }
}