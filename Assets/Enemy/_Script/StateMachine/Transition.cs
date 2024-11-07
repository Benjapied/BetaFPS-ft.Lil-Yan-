using Context;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    
    Context.State _targetState;
    List<Condition> _conditions;

    internal State TargetState { get => _targetState; set => _targetState = value; }

    void Start()
    {
        _conditions = new List<Condition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCondition(Condition condition)
    {
        _conditions.Add(condition);
        
    }

    public void Try(Enemy enemy)
    {
        int true_tests = 0;
        foreach (var item in _conditions)
        {
            item.Test(enemy);
            true_tests++;
        }
        if (true_tests != 0 && true_tests == _conditions.Count)
        {
            enemy.State = _targetState;
        }
    }
}
