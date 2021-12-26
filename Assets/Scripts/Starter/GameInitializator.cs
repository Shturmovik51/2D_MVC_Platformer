using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public sealed class GameInitializator
    {
        public GameInitializator(ControllersManager controllersManager, GameData gameData, PlayerView playerView, 
                    float animationSpeed, float playerMOveSpeed, Transform arm, SpriteRenderer[] waterSpriteRenderers,
                        SpriteRenderer[] barrels)
        {
            var camera = Camera.main;
            var inputController = new InputController(gameData);
            var playerAnimationsFactory = new PlayerAnimationsFactory(gameData, animationSpeed);
            var waterAnimationFactory = new WaterAnimationFactory(gameData, animationSpeed);
            var effectsAnimationFactory = new EffectsAnimationsFactory(gameData, animationSpeed);
            var animatorController = new SpriteAnimatorController(playerAnimationsFactory, effectsAnimationFactory, 
                                                                        waterAnimationFactory, waterSpriteRenderers);
            var cameraPositionController = new CameraPositionController(camera, playerView.transform);
            var stateController = new StateController(animatorController);
            var playerModel = new PlayerModel(playerMOveSpeed);
            var playerController = new PlayerController(playerView, inputController, stateController, playerModel);
            var armController = new ArmController(arm, inputController, playerView);
            var flipController = new FlipController(armController, playerView, inputController);
            var shootController = new ShootController(inputController, animatorController, playerView, armController);






            controllersManager.Add(animatorController);
            controllersManager.Add(inputController);
            controllersManager.Add(playerController);
            controllersManager.Add(stateController);
            controllersManager.Add(cameraPositionController);
            controllersManager.Add(armController);
            controllersManager.Add(flipController);
            controllersManager.Add(shootController);
        }
    }
}
