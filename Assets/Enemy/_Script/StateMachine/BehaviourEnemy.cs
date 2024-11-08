using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class BehaviourEnemy
{
    

    Dictionary<Context.State, List<EnemyState>> _enemyStates;
    Dictionary<Context.State, List<Transition>> _transitions;
    
    public BehaviourEnemy() {
        _enemyStates = new Dictionary<Context.State, List<EnemyState>>();
        _transitions = new Dictionary<Context.State, List<Transition>>();

    }
   

    

    public void AddTransition(Context.State key, Transition value)
    {
        if (!_transitions.ContainsKey(key))
        {
            _transitions.Add(key, new List<Transition>());
        }
        _transitions[key].Add(value);
    }

    public void AddState(Context.State key, EnemyState value)
    {
        if( !_enemyStates.ContainsKey(key) )
        {
            _enemyStates.Add(key, new List<EnemyState>());
        }
        _enemyStates[key].Add(value);


    }

    public void StartBehaviour(Enemy enemy)
    {
        foreach(var state in _enemyStates[enemy.State])
        {
            state.EnterState(enemy);
        }
       
    }

    public void UpdateBehaviour(Enemy enemy)
    {
        foreach (var state in _enemyStates[enemy.State])
        {
            state.FrameUpdate(enemy);
        }


        foreach (var transition in _transitions[enemy.State])
        {
            transition.Try(enemy);
        }
        
    }


    public void End(Enemy enemy)
    {
        foreach (var state in _enemyStates[enemy.State])
        {
            state.ExitState(enemy);
        }
    }

}
