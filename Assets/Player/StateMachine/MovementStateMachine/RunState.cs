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

        Controller.GetInstance().OnRunReleased += ChangeState;
        Controller.GetInstance().onJump += GoToJump;

        _player.CurrentSpeed = _player.SprintSpeed;

    }
    override public void ExitState() {

        Controller.GetInstance().OnRunReleased -= ChangeState;
        Controller.GetInstance().onJump -= GoToJump;

        _player.CurrentSpeed = _player.DefaultSpeed;

    }
    override public void Update() {

        UpdateMovement();

    }
    override public void OnChangeState() { }

    public void ChangeState()
    {
        Dictionary<string, bool> map = Controller.GetInstance().HoldDownMap;

        if (map["move"])
        {
            GoToMove();
            return;
        }

        GoToIdle();
        return;
    }

}
