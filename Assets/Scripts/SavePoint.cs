using UnityEngine;

namespace Platformer2D
{
    public class SavePoint : MonoBehaviour
    {
        [SerializeField] private GameObject _halo;
        [SerializeField] private SpriteRenderer _haloSpriteRenderer;
        [SerializeField] private Transform _transform;

        public SpriteRenderer HaloSpriteRenderer => _haloSpriteRenderer;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerView playerView))
            {               
                _halo.SetActive(true);
                playerView.SetSavePoint(_transform);
            }
        }
    }
}