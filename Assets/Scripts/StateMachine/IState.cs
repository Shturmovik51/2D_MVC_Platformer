namespace Platformer2D
{
    public interface IState
    {
        public bool IsRun { get; }
        public bool IsJump { get; }
        public bool IsStay { get; }

        public void EnterState(ObjectView playerView, SpriteAnimatorController animatorController);
        public void BeingInState();
        public void ExitState(ObjectView playerView, SpriteAnimatorController animatorController);
    }
}