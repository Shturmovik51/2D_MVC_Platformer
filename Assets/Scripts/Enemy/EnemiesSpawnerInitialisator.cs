namespace Platformer2D
{
    public class EnemiesSpawnerInitialisator
    {
        public EnemiesSpawnerInitialisator(StarterGameData starterGameData, EnemiesPoolController enemiesPoolController, 
                                                HealthBarPoolController healthBarPoolController, ControllersManager controllersManager)
        {
            var spawners = starterGameData.SpawnersContainer.GetComponentsInChildren<EnemiesSpawner>();
            for (int i = 0; i < spawners.Length; i++)
            {
                spawners[i].InitSpawner(enemiesPoolController, healthBarPoolController);
                controllersManager.Add(spawners[i]);
            }
        }
    }
}
