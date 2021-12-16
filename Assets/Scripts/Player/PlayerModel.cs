namespace Platformer2D
{
    public class PlayerModel
    {
        public float MoveSpeed { get; }

        public bool IsGrounded;
        public bool IsRun;
        public bool IsJump;
        public bool IsStay;
        public bool IsRightDirection;

        public PlayerModel(float moveSpeed)
        {
            MoveSpeed = moveSpeed;
        }
    }
}