using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public sealed class GameInitializator
    {
        public GameInitializator(ControllersManager controllersManager, GameData gameData, ObjectView playerView)
        {
            var camera = Camera.main;
            var inputController = new InputController(gameData);

            var spriteAnimatorController = new SpriteAnimatorController(gameData.PlayerAnimations);
            spriteAnimatorController.StartAnimation(playerView.SpriteRenderer, AnimationType.Run, true, 15);

            var playerController = new PlayerController(playerView, inputController);
            var cameraPositionController = new CameraPositionController(camera, playerView.transform);


            controllersManager.Add(spriteAnimatorController);
            controllersManager.Add(inputController);
            controllersManager.Add(playerController);
            controllersManager.Add(cameraPositionController);
        }
    }
}
