using UnityEngine;

namespace Platformer2D
{
    [System.Serializable]
    public struct PrefabsData
    {
        [SerializeField] private GameObject _healthBarPrefab;

        public GameObject HealthBarPrefab => _healthBarPrefab;
    }
}
