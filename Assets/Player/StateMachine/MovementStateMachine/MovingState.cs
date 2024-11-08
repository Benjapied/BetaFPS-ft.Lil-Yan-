using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : BaseState
{
    public MovingState(StateMachine fsm) : base(fsm)
    {

    }

    override public void EnterState() {

        Controller.GetInstance().OnMoveReleased += GoToIdle;

    }
    override public void ExitState() { }
    override public void Update() {

        Player p = ((PlayerStateMachine)_stateMachine).Player;

        Vector2 movement = Controller.GetInstance().GetMove() * 10 * Time.deltaTime * 10;

        p.GetComponent<Rigidbody>().velocity = new Vector3(movement.x,0,movement.y);

    }
    override public void OnChangeState() { }

    public void GoToIdle()
    {
        _stateMachine.ChangeState(((MovementStateMachine)_stateMachine).IdleState);
    }
    public void GoToJump()
    {

    }
    public void GoToSneak()
    {

    }

}
