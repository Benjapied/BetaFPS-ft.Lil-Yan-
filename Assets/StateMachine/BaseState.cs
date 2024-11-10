using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    protected StateMachine _stateMachine;
    public StateMachine StateMachine { get => _stateMachine; set => _stateMachine = value; }

    protected BaseState(StateMachine fsm)
    {
        _stateMachine = fsm;
    }

    virtual public void EnterState() { }
    public virtual void ExitState() { }
    public virtual void Update() { }
    public virtual void OnChangeState() { }


}
