using UnityEngine;

namespace Platformer2D
{
    [System.Serializable]
    public class PrefabsData
    {
        [SerializeField] private GameObject _healthBarPrefab;
        [SerializeField] private GameObject _hitEffectprefab;
        [SerializeField] private GameObject _bulletShellPrefab;
        [SerializeField] private GameObject _logPrototype;

        public GameObject HealthBarPrefab => _healthBarPrefab;
        public GameObject HitEffectprefab => _hitEffectprefab;
        public GameObject BulletShellPrefab => _bulletShellPrefab;
        public GameObject LogPrototype => _logPrototype;
    }
}
