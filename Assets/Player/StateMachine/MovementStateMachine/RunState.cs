using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RunState : PlayerMovementState
{
    public RunState(PlayerMovementStateMachine fsm) : base(fsm)
    {

    }

    override public void EnterState() {

        Controller.GetInstance().OnMoveReleased += GoToIdle;
        Controller.GetInstance().OnRunReleased += GoToMove;

        _player.Speed = _player.Speed * 1.5f;

    }
    override public void ExitState() {

        Controller.GetInstance().OnMoveReleased -= GoToIdle;
        Controller.GetInstance().OnRunReleased -= GoToMove;

        _player.ResetSpeed();

    }
    override public void Update() {

        Vector2 movement = Controller.GetInstance().GetMove() * _player.Speed * Time.deltaTime * 100;

        _player.GetComponent<Rigidbody>().velocity = _player.gameObject.transform.forward * movement.y + _player.gameObject.transform.right * movement.x;

    }
    override public void OnChangeState() { }

}
