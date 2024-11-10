using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Speed")]

                     private float _currentSpeed = 10;
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private float _crouchSpeed;

    [Header("Jump")]

    [SerializeField] private float _heightJump;
    [SerializeField] private float _fallMultiplier;
    [SerializeField] private float _jumpMultiplier;
                     private bool _isGrounded;

    [Header("Crouch")]

    [SerializeField] private float _heightPlayer, _defaultHeightPlayer;

    PlayerMovementStateMachine _movingStateMachine;
    PlayerActionStateMachine _actionStateMachine;

    public float CurrentSpeed { get => _currentSpeed; set => _currentSpeed = value; }
    public float DefaultSpeed { get => _defaultSpeed;}
    public float SprintSpeed { get => _sprintSpeed; set => _sprintSpeed = value; }
    public float HeightJump { get => _heightJump; set => _heightJump = value; }
    public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }
    public float HeightPlayer { get => _heightPlayer; set => _heightPlayer = value; }
    public float DefaultHeightPlayer { get => _defaultHeightPlayer; set => _defaultHeightPlayer = value; }
    public float CrouchSpeed { get => _crouchSpeed; set => _crouchSpeed = value; }
    public float FallMultiplier { get => _fallMultiplier; set => _fallMultiplier = value; }
    public float JumpMultiplier { get => _jumpMultiplier; set => _jumpMultiplier = value; }

    private void Awake()
    {
        _defaultSpeed = _currentSpeed;
        _isGrounded = false;

        _defaultHeightPlayer = gameObject.transform.localScale.y;
        _heightPlayer = _defaultHeightPlayer;

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

    public void ResetSpeed() {  _currentSpeed = _defaultSpeed; }
    public void ResetHeight() { _heightPlayer = _defaultHeightPlayer; }

}
