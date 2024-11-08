using Context;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition 
{
    
    Context.State _targetState;
    List<Condition> _conditions;

    internal State TargetState { get => _targetState; set => _targetState = value; }

    public Transition()
    {
        _conditions = new List<Condition>();
    }
    

    public void AddCondition(Condition condition)
    {
        _conditions.Add(condition);
        
    }

    public void Try(IBehaviour iBehaviour)
    {
        int true_tests = 0;
        foreach (var item in _conditions)
        {
            if (item.Test(iBehaviour))
            {
                true_tests++;
            }
            
        }
        if (true_tests != 0 && true_tests == _conditions.Count)
        {
            iBehaviour.SetState(_targetState);
        }
    }
}
