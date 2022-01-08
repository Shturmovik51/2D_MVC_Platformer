using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs /PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private int _playerMaxHealth;
        [SerializeField] private int _playerJumpForce;
        [SerializeField] private float _playerMoveSpeed;

        public GameObject PlayerPrefab => _playerPrefab;
        public int PlayerMaxHealth => _playerMaxHealth;
        public int PlayerJumpForce => _playerJumpForce;
        public float PlayerMoveSpeed => _playerMoveSpeed;
    }
}
