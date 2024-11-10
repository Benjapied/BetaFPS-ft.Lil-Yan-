using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed = 10;
                     private float _defaultSpeed;
    [SerializeField] private float _heightJump = 5;
    [SerializeField] private bool _isGrounded;

    PlayerMovementStateMachine _movingStateMachine;
    PlayerActionStateMachine _actionStateMachine;

    public float Speed { get => _speed; set => _speed = value; }
    public float HeightJump { get => _heightJump; set => _heightJump = value; }
    public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }

    private void Awake()
    {
        _defaultSpeed = _speed;
        _isGrounded = false;

        _movingStateMachine = new PlayerMovementStateMachine(this);
        _movingStateMachine.InitState(_movingStateMachine.IdleState);

        _actionStateMachine = new PlayerActionStateMachine(this);
        _actionStateMachine.InitState(_actionStateMachine.IdleState);
    }


    // Update is called once per frame
    void Update()
    {
       
        _movingStateMachine.Update();
        _actionStateMachine.Update();  

    }

    public void ResetSpeed() {  _speed = _defaultSpeed; }

}
