using UnityEngine;

namespace Platformer2D
{
    public sealed class GameInitializator
    {
        public GameInitializator(ControllersManager controllersManager, GameData gameData, StarterGameData starterGameData)
        {
            var camera = Camera.main;
            var inputController = new InputController(gameData);
            var animationsInitialisator = new AnimationsInitializator(gameData, starterGameData);
            var animatorController = new SpriteAnimatorController(animationsInitialisator, starterGameData);
            var cameraPositionController = new CameraPositionController(camera, starterGameData);
            var stateController = new StateController(animatorController);
            var playerModel = new PlayerModel(starterGameData);
            var playerController = new PlayerController(starterGameData, inputController, stateController, playerModel);
            var armController = new ArmController(starterGameData, inputController);
            var flipController = new FlipController(armController, starterGameData, inputController);            
            var shootController = new ShootController(inputController, animatorController, starterGameData, armController);
            var hitController = new HitController(shootController);

            var barrelsInitialisator = new BarrelsInitialisator(starterGameData, hitController);
            var enemiesInitialisator = new EnemiesInitialisator(gameData, starterGameData);
            var healthBarsInitializator = new HealthBarsInitializator(starterGameData, gameData);

            var enemiesPoolController = new EnemiesPoolController(enemiesInitialisator);

            var barrelsController = new BarrelsController(barrelsInitialisator); 
            var enemiesController = new EnemiesController(enemiesPoolController, animatorController, starterGameData);

            var healthBarPoolController = new HealthBarPoolController(healthBarsInitializator, enemiesController);
            var hitableObjectInitializator = new HitableObjectsInitialisator(barrelsInitialisator, barrelsController, 
                                                    enemiesInitialisator, enemiesController, hitController);


            var spawners = Object.FindObjectsOfType<EnemiesSpawner>();
            for (int i = 0; i < spawners.Length; i++)
            {
                spawners[i].InitSpawner(enemiesPoolController, healthBarPoolController);
                controllersManager.Add(spawners[i]);
            }

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
        }
    }
}
