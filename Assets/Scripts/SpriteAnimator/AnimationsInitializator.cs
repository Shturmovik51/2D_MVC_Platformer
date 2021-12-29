namespace Platformer2D
{
    public class AnimationsInitializator
    {
        public PlayerAnimationsFactory PlayerAnimationsFactory { get;}
        public WaterAnimationFactory WaterAnimationFactory { get; }
        public EffectsAnimationsFactory EffectsAnimationFactory { get; }
        public EnemyAnimationFactory EnemiesAnimationsFactory { get; }

        public AnimationsInitializator(GameData gameData, StarterGameData starterGameData)
        {
            PlayerAnimationsFactory = new PlayerAnimationsFactory(gameData, starterGameData);
            WaterAnimationFactory = new WaterAnimationFactory(gameData, starterGameData);
            EffectsAnimationFactory = new EffectsAnimationsFactory(gameData, starterGameData);
            EnemiesAnimationsFactory = new EnemyAnimationFactory(gameData, starterGameData);
        }
    }
}
