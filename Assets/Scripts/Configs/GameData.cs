using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Configs / GameData")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private SpriteAnimationsConfig _playerAnimationsConfig;
        [SerializeField] private InputKeysConfig _userInput;

        public SpriteAnimationsConfig PlayerAnimationsConfig => _playerAnimationsConfig;
        public InputKeysConfig UserInput => _userInput;
    }
}