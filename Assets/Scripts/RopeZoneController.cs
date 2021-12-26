using UnityEngine;

namespace Platformer2D
{
    public class RopeZoneController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _wheelRigidbody;
        [SerializeField] private Transform _beam;
        [SerializeField] private Collider2D _capsuleCollider;
        [SerializeField] private Collider2D _boxCollider;

        private bool _isOnRope;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_isOnRope)
            {
                _isOnRope = true;
                collision.transform.parent = _beam;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                _wheelRigidbody.bodyType = RigidbodyType2D.Dynamic;
                _capsuleCollider.enabled = false;
            }
            else if (_isOnRope)
            {
                collision.transform.parent = null;
                collision.transform.rotation = Quaternion.identity;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                _boxCollider.enabled = false;
            }
        }
    }
}
