using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public sealed class GameInitializator
    {
        public GameInitializator(ControllersManager controllersManager, GameData gameData, PlayerView playerView, 
                    float animationSpeed, float playerMOveSpeed, Transform arm)
        {
            var camera = Camera.main;
            var inputController = new InputController(gameData);
            var playerAnimationsFactory = new PlayerAnimationsFactory(gameData, animationSpeed);
            var animatorController = new SpriteAnimatorController(playerAnimationsFactory);
            var cameraPositionController = new CameraPositionController(camera, playerView.transform);
            var stateController = new StateController(animatorController);
            var playerModel = new PlayerModel(playerMOveSpeed);
            var playerController = new PlayerController(playerView, inputController, stateController, playerModel);
            var armController = new ArmController(arm, inputController, playerView);
            var flipController = new FlipController(armController, playerView, inputController);

            controllersManager.Add(animatorController);
            controllersManager.Add(inputController);
            controllersManager.Add(playerController);
            controllersManager.Add(stateController);
            controllersManager.Add(cameraPositionController);
            controllersManager.Add(armController);
            controllersManager.Add(flipController);
        }
    }
}
