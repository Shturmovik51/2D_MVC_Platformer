using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Configs / GameData")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private SpriteAnimationsConfig _playerAnimations;

        public SpriteAnimationsConfig PlayerAnimations => _playerAnimations;
    }
}