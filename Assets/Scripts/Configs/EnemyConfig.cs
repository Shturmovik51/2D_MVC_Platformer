using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configs /EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private int _enemyMaxHealth;

        public GameObject EnemyPrefab => _enemyPrefab;
        public int EnemyMaxHealth => _enemyMaxHealth;
    }
}
