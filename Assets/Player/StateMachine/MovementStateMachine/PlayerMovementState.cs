using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : BaseState
{
    protected Player _player;
    new protected PlayerMovementStateMachine _stateMachine;

    protected PlayerMovementState(PlayerMovementStateMachine fsm) : base(fsm)
    {
        _player = fsm.Player;
        _stateMachine = fsm;
    }
    public void GoToIdle()
    {
        _stateMachine.ChangeState(_stateMachine.IdleState);
    }

    public void GoToMove()
    {
        _stateMachine.ChangeState(_stateMachine.MovingState);
    }

    public void GoToFalling()
    {
        _stateMachine.ChangeState(_stateMachine.FallState);
    }

    public void GoToJump()
    {
        if (!_player.IsGrounded)
        {
            return;
        }

        _stateMachine.ChangeState(_stateMachine.JumpState);
    }

    public void GoToSneak()
    {
        _stateMachine.ChangeState(_stateMachine.SneakState);
    }

    public void GoToRun()
    {
        _stateMachine.ChangeState(_stateMachine.RunState);
    }

    public void UpdateMovement()
    {
        Vector2 movement = Controller.GetInstance().GetMove() * _player.CurrentSpeed * Time.deltaTime * 100;

        Vector3 newVelocity = _player.gameObject.transform.forward * movement.y + _player.gameObject.transform.right * movement.x;
        newVelocity += Vector3.up * _player.GetComponent<Rigidbody>().velocity.y;

        _player.GetComponent<Rigidbody>().velocity = newVelocity;
    }

}
