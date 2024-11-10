using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerMovementState
{
    public JumpState(PlayerMovementStateMachine fsm) : base(fsm)
    {

    }

    override public void EnterState() { 
    
        base.EnterState();
        _player.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * _player.HeightJump, ForceMode.VelocityChange);

    }
    override public void ExitState() { }
    override public void Update() {

        if (Controller.GetInstance().HoldDownMap["run"]) { _player.CurrentSpeed = _player.SprintSpeed; }
        else { _player.CurrentSpeed = _player.DefaultSpeed; }

        Rigidbody rb = _player.gameObject.GetComponent<Rigidbody>();

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - (Time.fixedDeltaTime * 9.8f * 0.5f), rb.velocity.z);


        if (rb.velocity.y < 0)
        {
            GoToFalling();
        }

        UpdateMovement();

    }
    override public void OnChangeState() { }

    

}
