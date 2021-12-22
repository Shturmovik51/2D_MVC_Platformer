using UnityEngine;

namespace Platformer2D
{
    public class RopeZoneController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _wheelRigidbody;
        [SerializeField] private Transform _beam;

        private bool _isOnRope;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_isOnRope)
            {
                _isOnRope = true;
                collision.transform.parent = _beam;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                _wheelRigidbody.bodyType = RigidbodyType2D.Dynamic;
            }
            else if (_isOnRope)
            {
                collision.transform.parent = null;
                collision.transform.rotation = Quaternion.identity;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
