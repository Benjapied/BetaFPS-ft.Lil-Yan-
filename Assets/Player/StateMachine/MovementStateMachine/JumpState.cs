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
        _player.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * _player.HeightJump * 10);

    }
    override public void ExitState() { }
    override public void Update() {

        Rigidbody rb = _player.gameObject.GetComponent<Rigidbody>();

        if (rb.velocity.y < 0)
        {
            GoToFalling();
        }

    }
    override public void OnChangeState() { }

    

}
