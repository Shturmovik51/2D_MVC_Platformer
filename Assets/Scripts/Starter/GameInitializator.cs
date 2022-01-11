using UnityEngine;

namespace Platformer2D
{
    public sealed class GameInitializator
    {
        public GameInitializator(ControllersManager controllersManager, GameData gameData, StarterGameData starterGameData, GameStarter gameStarter)
        {
            var camera = Camera.main;
            var inputController = new InputController(gameData);
            var animationsInitialisator = new AnimationsInitializator(gameData, starterGameData);
            var animatorController = new SpriteAnimatorController(animationsInitialisator, starterGameData);
            var cameraPositionController = new CameraPositionController(camera, starterGameData);
            var shootEffectsPoolController = new ShootEffectsPoolController(gameData, starterGameData, gameStarter);
            var stateController = new StateController(animatorController);
            var playerModel = new PlayerModel(gameData);
            var playerController = new PlayerController(starterGameData, inputController, stateController, playerModel);
            var armController = new ArmController(starterGameData, inputController);
            var flipController = new FlipController(armController, starterGameData, inputController);            
            var shootController = new ShootController(inputController, animatorController, starterGameData, armController, shootEffectsPoolController);
            var hitController = new HitController(shootController);
            var barrelsInitialisator = new BarrelsInitialisator(starterGameData, hitController);
            var enemiesInitialisator = new EnemiesInitialisator(gameData, starterGameData);
            var healthBarsInitializator = new HealthBarsInitializator(starterGameData, gameData);
            var enemiesPoolController = new EnemiesPoolController(enemiesInitialisator);
            var barrelsController = new BarrelsController(barrelsInitialisator); 
            var enemiesController = new EnemiesController(enemiesPoolController, animatorController, starterGameData);
            var healthBarPoolController = new HealthBarPoolController(healthBarsInitializator, enemiesController);

            new HitableObjectsInitialisator(barrelsInitialisator, barrelsController, enemiesInitialisator, enemiesController, hitController);
            new EnemiesSpawnerInitialisator(starterGameData, enemiesPoolController, healthBarPoolController, controllersManager);

            controllersManager.Add(animatorController);
            controllersManager.Add(inputController);
            controllersManager.Add(playerController);
            controllersManager.Add(stateController);
            controllersManager.Add(cameraPositionController);
            controllersManager.Add(armController);
            controllersManager.Add(flipController);
            controllersManager.Add(shootController);
            controllersManager.Add(hitController);
            controllersManager.Add(enemiesController);
            controllersManager.Add(healthBarPoolController);
        }
    }
}
