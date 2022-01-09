namespace Platformer2D
{
    public class PlayerModel
    {
        public float MoveSpeed { get; }
        public int JumpForce { get; }
        public Health PlayerHealth { get; }

        public bool IsRun;
        public bool IsJump;
        public bool IsStay;

        public PlayerModel(GameData gameData)
        {
            MoveSpeed = gameData.PlayerConfig.PlayerMoveSpeed;
            JumpForce = gameData.PlayerConfig.PlayerJumpForce;
            PlayerHealth = new Health(gameData.PlayerConfig.PlayerMaxHealth, gameData.PlayerConfig.PlayerMaxHealth);
        }
    }
}