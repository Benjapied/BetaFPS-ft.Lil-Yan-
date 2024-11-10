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
        Controller.GetInstance().OnSneak += GoToSneak;
        Controller.GetInstance().onJump += GoToJump;
    }
    override public void ExitState() {

        Controller.GetInstance().OnMoveReleased -= GoToIdle;
        Controller.GetInstance().OnRun -= GoToRun;
        Controller.GetInstance().OnSneak -= GoToSneak;
        Controller.GetInstance().onJump -= GoToJump;

    }
    override public void Update() {

        UpdateMovement();

    }
    override public void OnChangeState() { }

}
