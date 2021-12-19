namespace Platformer2D
{
    public class IdleState : IState
    {
        public bool IsRun { get; }
        public bool IsJump { get; }
        public bool IsStay { get; }

        public IdleState()
        {
            IsRun = false;
            IsJump = false;
            IsStay = true;
        }

        public void EnterState(PlayerView playerView, SpriteAnimatorController animatorController)
        {
            animatorController.StartAnimation(playerView.SpriteRenderer, AnimationType.Idle);
        }

        public void BeingInState()
        {

        }

        public void ExitState(PlayerView playerView, SpriteAnimatorController animatorController)
        {
            animatorController.StopAnimation(playerView.SpriteRenderer);
        }
    }
}