using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Configs / GameData")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private SpriteAnimationsConfig _playerAnimations;
        [SerializeField] private InputKeysConfig _userInput;

        public SpriteAnimationsConfig PlayerAnimations => _playerAnimations;
        public InputKeysConfig UserInput => _userInput;
    }
}