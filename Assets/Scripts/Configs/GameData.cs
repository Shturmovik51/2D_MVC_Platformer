using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Configs /GameData")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private SpriteAnimationsConfig _playerAnimationsConfig;
        [SerializeField] private SpriteAnimationsConfig _shootAnimationConfig;
        [SerializeField] private SpriteAnimationsConfig _waterAnimationConfig;
        [SerializeField] private SpriteAnimationsConfig _enemiesAnimationConfig;
        [SerializeField] private InputKeysConfig _userInput;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] PrefabsData _prefabsData;

        public SpriteAnimationsConfig PlayerAnimationsConfig => _playerAnimationsConfig;
        public SpriteAnimationsConfig ShootAnimationConfig => _shootAnimationConfig;
        public SpriteAnimationsConfig WaterAnimationConfig => _waterAnimationConfig;
        public SpriteAnimationsConfig EnemiesAnimationConfig => _enemiesAnimationConfig;
        public InputKeysConfig UserInput => _userInput;
        public EnemyConfig EnemyConfig => _enemyConfig;
        public PlayerConfig PlayerConfig => _playerConfig;
        public PrefabsData PrefabsData => _prefabsData;
    }
}