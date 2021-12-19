namespace Platformer2D
{
    public interface IState
    {
        public bool IsRun { get; }
        public bool IsJump { get; }
        public bool IsStay { get; }

        public void EnterState(PlayerView playerView, SpriteAnimatorController animatorController);
        public void BeingInState();
        public void ExitState(PlayerView playerView, SpriteAnimatorController animatorController);
    }
}