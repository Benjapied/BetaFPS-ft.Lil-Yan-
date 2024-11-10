using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakState : PlayerMovementState
{
    public SneakState(PlayerMovementStateMachine fsm) : base(fsm)
    {

    }

    override public void EnterState() {

        Controller.GetInstance().OnSneakReleased += ChangeState;

        _player.CurrentSpeed = _player.CrouchSpeed;


        Vector3 vector = _player.transform.Find("Head").transform.localPosition;
        vector.y = 0;
        _player.transform.Find("Head").transform.localPosition = vector;


    }
    override public void ExitState() {

        Controller.GetInstance().OnSneakReleased += ChangeState;

        Vector3 vector = _player.transform.Find("Head").transform.localPosition;
        vector.y = 1;
        _player.transform.Find("Head").transform.localPosition = vector;

        _player.CurrentSpeed = _player.DefaultSpeed;

    }
    override public void Update() {

        UpdateMovement();

    }
    override public void OnChangeState() { }

    public void ChangeState()
    {
        Dictionary<string, bool> map = Controller.GetInstance().HoldDownMap;

        if (map["run"])
        {
            GoToRun();
            return;
        }

        if (map["move"])
        {
            GoToMove();
            return;
        }

        GoToIdle();
        return;
            
    }

}
