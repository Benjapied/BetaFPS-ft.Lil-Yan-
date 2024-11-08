using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    MovementStateMachine _movingStateMachine;
    ActionStateMachine _actionStateMachine;

    private void Awake()
    {
        _movingStateMachine = new MovementStateMachine(this);
        _movingStateMachine.InitState(_movingStateMachine.IdleState);

        _actionStateMachine = new ActionStateMachine(this);
        _actionStateMachine.InitState(_actionStateMachine.IdleState);
    }


    // Update is called once per frame
    void Update()
    {
       
        _movingStateMachine.Update();
        _actionStateMachine.Update();  

    }
}
