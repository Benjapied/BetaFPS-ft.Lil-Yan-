using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class IdleMovementState : BaseState
{

    public IdleMovementState(StateMachine fsm) : base (fsm) { 
        
    }

    override public void EnterState() {

        Controller.GetInstance().OnMove += ChangeStateMove;

    }
    override public void ExitState() { }
    override public void Update() { }
    override public void OnChangeState() { }

    public void ChangeStateMove()
    {
        _stateMachine.ChangeState(((MovementStateMachine)_stateMachine).MovingState);
    }

}
