using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateMachine : StateMachine
{

    protected Player _player;
    protected PlayerMovementState _currentState;

    private IdleMovementState _idleState;
    private MovingState _movingState;
    private JumpState _jumpState;
    private RunState _runState;
    private SneakState _sneakState;
    private FallState _fallState;

    public IdleMovementState IdleState { get => _idleState; set => _idleState = value; }
    public MovingState MovingState { get => _movingState; set => _movingState = value; }
    public JumpState JumpState { get => _jumpState; set => _jumpState = value; }
    public RunState RunState { get => _runState; set => _runState = value; }
    public SneakState SneakState { get => _sneakState; set => _sneakState = value; }
    public FallState FallState { get => _fallState; set => _fallState = value; }
    public Player Player { get => _player; set => _player = value; }

    public PlayerMovementStateMachine(Player p)
    {
        _player = p;

        _idleState = new(this);
        _movingState = new(this);
        _jumpState = new(this);
        _runState = new(this);
        _sneakState = new(this);
        _fallState = new(this);
    }
}
