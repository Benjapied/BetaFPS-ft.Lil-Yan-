using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : PlayerMovementState
{
    public FallState(PlayerMovementStateMachine fsm) : base(fsm)
    {

    }

    override public void EnterState() {

        
    }
    override public void ExitState() { }
    override public void Update() {

        if (Controller.GetInstance().HoldDownMap["run"]) { _player.CurrentSpeed = _player.SprintSpeed; }
        else { _player.CurrentSpeed = _player.DefaultSpeed; }

        _player.gameObject.GetComponent<Rigidbody>().velocity += Vector3.up * Time.deltaTime * Physics.gravity.y * _player.FallMultiplier;

        if (_player.IsGrounded) {

            ChangeState();

        }

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
