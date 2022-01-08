using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configs /EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField, Range(10, 300)] private int _enemyMaxHealth;
        [SerializeField, Range(40f, 50f)] private float _enemyMinMoveSpeed;
        [SerializeField, Range(40f, 50f)] private float _enemyMaxMoveSpeed;

        public GameObject EnemyPrefab => _enemyPrefab;
        public int EnemyMaxHealth => _enemyMaxHealth;
        public float EnemyMinMoveSpeed => _enemyMinMoveSpeed;
        public float EnemyMaxMoveSpeed => _enemyMaxMoveSpeed;
    }
}
