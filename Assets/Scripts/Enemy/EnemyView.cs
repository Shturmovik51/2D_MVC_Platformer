using UnityEngine;

namespace Platformer2D
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _targetDetector;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private SpriteRenderer _shootEffect;
        private float _targetDetectorRadius = 0.2f;
    }
}