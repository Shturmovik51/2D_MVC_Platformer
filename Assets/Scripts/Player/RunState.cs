namespace Platformer2D
{
    public class RunState : IState
    {
        public bool IsGrounded { get; }
        public bool IsRun { get; }
        public bool IsJump { get; }
        public bool IsStay { get; }

        public RunState()
        {
            IsRun = true;
            IsJump = false;
            IsStay = false;
            IsGrounded = true;
        }

        public void EnterState(ObjectView playerView, SpriteAnimatorController animatorController)
        {
            animatorController.StartAnimation(playerView.SpriteRenderer, AnimationType.Run);
        }

        public void BeingInState()
        {

        }

        public void ExitState(ObjectView playerView, SpriteAnimatorController animatorController)
        {
            animatorController.StopAnimation(playerView.SpriteRenderer);
        }
    }
}
