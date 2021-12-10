using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public sealed class GameInitializator
    {
        public GameInitializator(ControllersManager controllersManager, GameData gameData, ObjectView playerView)
        {
            var spriteAnimatorController = new SpriteAnimatorController(gameData.PlayerAnimations);
            spriteAnimatorController.StartAnimation(playerView.SpriteRenderer, AnimationType.Run, true, 15);

            controllersManager.Add(spriteAnimatorController);
        }
    }
}
