namespace Platformer2D
{
    public class EnemyModel : IEnemyModel
    {
        public Health ZombieHealth { get; }

        public EnemyModel(GameData gameData)
        {
            ZombieHealth = new Health(gameData.EnemyConfig.EnemyMaxHealth, gameData.EnemyConfig.EnemyMaxHealth);
        }
    }
}
