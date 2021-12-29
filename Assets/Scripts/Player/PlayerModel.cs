namespace Platformer2D
{
    public class PlayerModel
    {
        public float MoveSpeed { get; }

        public bool IsRun;
        public bool IsJump;
        public bool IsStay;
        //public bool IsForwardMove;

        public PlayerModel(StarterGameData starterGameData)
        {
            MoveSpeed = starterGameData.PlayerMoveSpeed;
        }
    }
}