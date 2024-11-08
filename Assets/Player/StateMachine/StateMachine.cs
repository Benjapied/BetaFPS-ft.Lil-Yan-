using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    BaseState _currentState;

    virtual public void InitState(BaseState state)
    {
        _currentState = state;
        _currentState.EnterState();
    }

    virtual public void ChangeState(BaseState state)
    {
        _currentState.ExitState();
        _currentState = state;
        _currentState.EnterState();
    }

    virtual public void Update()
    {
        _currentState.Update();
    }
    
}
