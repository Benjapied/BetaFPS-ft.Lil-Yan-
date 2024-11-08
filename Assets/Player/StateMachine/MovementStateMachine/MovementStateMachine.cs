using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateMachine : PlayerStateMachine
{
    private IdleMovementState _idleState;
    private MovingState _movingState;
    private JumpState _jumpState;
    private RunState _runState;
    private SneakState _sneakState;

    public IdleMovementState IdleState { get => _idleState; set => _idleState = value; }
    public MovingState MovingState { get => _movingState; set => _movingState = value; }
    public JumpState JumpState { get => _jumpState; set => _jumpState = value; }
    public RunState RunState { get => _runState; set => _runState = value; }
    public SneakState SneakState { get => _sneakState; set => _sneakState = value; }
    public MovementStateMachine(Player p) : base(p)
    {
        _idleState = new(this);
        _movingState = new(this);
        _jumpState = new(this);
        _runState = new(this);
        _sneakState = new(this);
    }
}
