using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : PlayerMovementState
{
    public FallState(PlayerMovementStateMachine fsm) : base(fsm)
    {

    }

    override public void EnterState() {

        //Player p = ((PlayerStateMachine)_stateMachine).Player;

        //p.gameObject.GetComponent<Rigidbody>().velocity = (p.gameObject.GetComponent<Rigidbody>().velocity + Vector3.up * -1) * 1.05f;

    }
    override public void ExitState() { }
    override public void Update() {

        if (_player.IsGrounded) { 
            
            GoToIdle();

        }
    }
    override public void OnChangeState() { }

    

}
