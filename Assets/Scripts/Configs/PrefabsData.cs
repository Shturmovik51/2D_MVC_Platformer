using UnityEngine;

namespace Platformer2D
{
    [System.Serializable]
    public struct PrefabsData
    {
        [SerializeField] private GameObject _healthBarPrefab;
        [SerializeField] private GameObject _hitEffectprefab;
        [SerializeField] private GameObject _bulletShellPrefab;

        public GameObject HealthBarPrefab => _healthBarPrefab;
        public GameObject HitEffectprefab => _hitEffectprefab;
        public GameObject BulletShellPrefab => _bulletShellPrefab;
    }
}
