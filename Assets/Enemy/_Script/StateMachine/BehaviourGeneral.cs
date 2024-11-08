using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class BehaviourGeneral
{
    

    Dictionary<Context.State, List<GeneralState>> _generalStates;
    Dictionary<Context.State, List<Transition>> _transitions;
    
    public BehaviourGeneral() {
        _generalStates = new Dictionary<Context.State, List<GeneralState>>();
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

    public void AddState(Context.State key, GeneralState value)
    {
        if( !_generalStates.ContainsKey(key) )
        {
            _generalStates.Add(key, new List<GeneralState>());
        }
        _generalStates[key].Add(value);


    }

    public void StartBehaviour(IBehaviour iBehaviour)
    {
        foreach(var state in _generalStates[iBehaviour.GetState()])
        {
            state.EnterState(iBehaviour);
        }
       
    }

    public void UpdateBehaviour(IBehaviour iBehaviour)
    {
        foreach (var state in _generalStates[iBehaviour.GetState()])
        {
            state.FrameUpdate(iBehaviour);
        }


        foreach (var transition in _transitions[iBehaviour.GetState()])
        {
            transition.Try(iBehaviour);
        }
        
    }


    public void End(IBehaviour iBehaviour)
    {
        foreach (var state in _generalStates[iBehaviour.GetState()])
        {
            state.ExitState(iBehaviour);
        }
    }

}
