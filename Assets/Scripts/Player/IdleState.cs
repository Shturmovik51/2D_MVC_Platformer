using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class IdleState : IState
    {
        public bool IsGrounded { get; }
        public bool IsRun { get; }
        public bool IsJump { get; }
        public bool IsStay { get; }

        public IdleState()
        {
            IsGrounded = true;
            IsRun = false;
            IsJump = false;
            IsStay = true;
        }

        public void EnterState(ObjectView playerView, SpriteAnimatorController animatorController)
        {
            animatorController.StartAnimation(playerView.SpriteRenderer, AnimationType.Idle);
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