using Context;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Context.State _state;
    BehaviourEnemy _behaviour;
    public Transform _transform;

    public BehaviourEnemy Behaviour { get => _behaviour; set => _behaviour = value; }
    internal State State { get => _state; set => _state = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateEnemy()
    {
        _behaviour.UpdateBehaviour(this);
    }

    public void SetState(Context.State new_state)
    {
        _behaviour.End(this);
        _state = new_state;
        _behaviour.StartBehaviour(this);
    }
}
