using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Configs / GameData")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private SpriteAnimationsConfig _playerAnimationsConfig;
        [SerializeField] private SpriteAnimationsConfig _shootAnimationConfig;
        [SerializeField] private SpriteAnimationsConfig _waterAnimationConfig;
        [SerializeField] private InputKeysConfig _userInput;

        public SpriteAnimationsConfig PlayerAnimationsConfig => _playerAnimationsConfig;
        public SpriteAnimationsConfig ShootAnimationConfig => _shootAnimationConfig;
        public SpriteAnimationsConfig WaterAnimationConfig => _waterAnimationConfig;
        public InputKeysConfig UserInput => _userInput;
    }
}