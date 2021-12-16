namespace Platformer2D
{
    public class JumpState : IState
    {
        public bool IsRun { get; }
        public bool IsJump { get; }
        public bool IsStay { get; }

        public JumpState()
        {
            IsRun = false;
            IsJump = true;
            IsStay = false;
        }

        public void EnterState(ObjectView playerView, SpriteAnimatorController animatorController)
        {
            animatorController.StartAnimation(playerView.SpriteRenderer, AnimationType.Jump);
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
