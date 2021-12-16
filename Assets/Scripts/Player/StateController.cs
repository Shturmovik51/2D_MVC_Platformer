using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
   public class StateController : IFixedUpdatable, IController
   {
        private SpriteAnimatorController _animatorController;
        private IState _idleState;
        private IState _runState;
        private IState _jumpState;
        private IState _currentState;

        public StateController(SpriteAnimatorController animatorController)
        {
            _animatorController = animatorController;
            _idleState = new IdleState();
            _runState = new RunState();
            _jumpState = new JumpState();
        }

        public void LocalFixedUpdate(float fixedDeltatime)
        {
            
        }

        public void SetIdleState(ObjectView playerView, PlayerModel playerModel)   //todo сделать 1 метод на стейты
        {
            if(_currentState != null)
            {
                _currentState.ExitState(playerView, _animatorController);
            }

            _currentState = _idleState;
            SetModelState(playerModel, _currentState);
            _currentState.EnterState(playerView, _animatorController);           

        }

        public void SetRunState(ObjectView playerView, PlayerModel playerModel)
        {
            if (_currentState != null)
            {
                _currentState.ExitState(playerView, _animatorController);
            }

            _currentState = _runState;
            SetModelState(playerModel, _currentState);
            _currentState.EnterState(playerView, _animatorController);
        }
        public void SetJumpState(ObjectView playerView, PlayerModel playerModel)
        {
            if (_currentState != null)
            {
                _currentState.ExitState(playerView, _animatorController);
            }

            _currentState = _jumpState;
            SetModelState(playerModel, _currentState);
            _currentState.EnterState(playerView, _animatorController);
        }



        private void SetModelState(PlayerModel playerModel, IState state)
        {
            playerModel.IsJump = state.IsJump;
            playerModel.IsRun = state.IsRun;
            playerModel.IsStay = state.IsStay;
            playerModel.IsGrounded = state.IsGrounded;
        }
    }
}

