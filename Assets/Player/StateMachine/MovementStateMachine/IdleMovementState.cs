using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class IdleMovementState : PlayerMovementState
{

    public IdleMovementState(PlayerMovementStateMachine fsm) : base (fsm) { 
        
    }

    override public void EnterState() {

        _player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Controller.GetInstance().OnMove += GoToMove;
        Controller.GetInstance().onJump += GoToJump;

    }
    override public void ExitState() { }
    override public void Update() { }
    override public void OnChangeState() { }


}
