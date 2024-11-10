using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : PlayerMovementState
{
    public MovingState(PlayerMovementStateMachine fsm) : base(fsm)
    {

    }

    override public void EnterState() {

        Controller.GetInstance().OnMoveReleased += GoToIdle;
        Controller.GetInstance().OnRun += GoToRun;

    }
    override public void ExitState() {

        Controller.GetInstance().OnMoveReleased -= GoToIdle;
        Controller.GetInstance().OnRun -= GoToRun;

    }
    override public void Update() {

        Vector2 movement = Controller.GetInstance().GetMove() * _player.Speed * Time.deltaTime * 100;

        Vector3 newVelocity = _player.gameObject.transform.forward * movement.y + _player.gameObject.transform.right * movement.x;
        newVelocity += Vector3.up * _player.GetComponent<Rigidbody>().velocity.y;

        _player.GetComponent<Rigidbody>().velocity = newVelocity;

    }
    override public void OnChangeState() { }

    

}
