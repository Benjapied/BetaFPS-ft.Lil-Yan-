using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : Singleton<Controller>
{
    public delegate void Move();
    public event Move OnMove;
    public event Move OnMoveReleased;

    public delegate void Shoot();
    public event Shoot OnShoot;
    public event Shoot OnShootReleased;

    public delegate void Sneak();
    public event Sneak OnSneak;
    public event Sneak OnSneakReleased;

    public delegate void Run();
    public event Run OnRun;
    public event Run OnRunReleased;

    public delegate void Reload();
    public event Reload OnReload;

    public delegate void Throw();
    public event Throw OnThrow;

    public delegate void MouseX();
    public event MouseX onMouseX;

    public delegate void MouseY();
    public event MouseY onMouseY;

    public delegate void Jump();
    public event Jump onJump;   

    private InputSystem _inputSystem;
    private Dictionary<string, bool> _holdDownMap;
    public Dictionary<string, bool> HoldDownMap { get => _holdDownMap; }

    protected override void Awake()
    {
        base.Awake();
        _inputSystem = new();
        _holdDownMap = new();

        _holdDownMap["move"] = false;
        _holdDownMap["sneak"] = false;
        _holdDownMap["run"] = false;
        _holdDownMap["shoot"] = false;

    }

    void Start()
    {
        Enable();
    }

    public void Enable()
    {
        _inputSystem.Enable();
        _inputSystem.Player.Move.started += ctx => MoveEvent();
        _inputSystem.Player.Move.canceled += ctx => MoveReleasedEvent();

        _inputSystem.Player.Shoot.started += ctx => ShootEvent();
        _inputSystem.Player.Shoot.canceled += ctx => ShootReleasedEvent();
        _inputSystem.Player.Sneak.started += ctx => SneakEvent();
        _inputSystem.Player.Sneak.canceled += ctx => SneakReleasedEvent();
        _inputSystem.Player.Run.started += ctx => RunEvent();
        _inputSystem.Player.Run.canceled += ctx => RunReleasedEvent();
        _inputSystem.Player.Throw.started += ctx => ThrowEvent();
        _inputSystem.Player.Reload.started += ctx => ReloadEvent();
        _inputSystem.Player.Jump.started += ctx => JumpEvent(); 

        _inputSystem.Player.MouseX.started += ctx => MouseXEvent();
        _inputSystem.Player.MouseY.started += ctx => MouseYEvent();
    }

    public void Disable()
    {
        _inputSystem.Disable();
        _inputSystem.Player.Move.started -= ctx => MoveEvent();
        _inputSystem.Player.Move.canceled -= ctx => MoveReleasedEvent();

        _inputSystem.Player.Shoot.started -= ctx => ShootEvent();
        _inputSystem.Player.Sneak.started -= ctx => SneakEvent();
        _inputSystem.Player.Run.started -= ctx => RunEvent();
        _inputSystem.Player.Throw.started -= ctx => ThrowEvent();
        _inputSystem.Player.Reload.started -= ctx => ReloadEvent();
        _inputSystem.Player.Jump.started -= ctx => JumpEvent(); 

        _inputSystem.Player.MouseX.started -= ctx => MouseXEvent();
        _inputSystem.Player.MouseY.started -= ctx => MouseYEvent();
    }

    public Vector2 GetMove()
    {
        return _inputSystem.Player.Move.ReadValue<Vector2>();
    }

    public float GetMouseX()
    {
        return _inputSystem.Player.MouseX.ReadValue<float>();
    }

    public float GetMouseY()
    {
        return _inputSystem.Player.MouseY.ReadValue<float>();
    }

    public void MoveEvent()
    {
        _holdDownMap["move"] = true;
        OnMove?.Invoke();
    }
    public void MoveReleasedEvent()
    {
        _holdDownMap["move"] = false;
        OnMoveReleased?.Invoke();
    }
    public void ShootEvent()
    {
        _holdDownMap["shoot"] = true;
        OnShoot?.Invoke();
    }
    public void ShootReleasedEvent() 
    { 
        _holdDownMap["shoot"] = false;
        OnShootReleased?.Invoke();   
    }
    public void SneakEvent()
    {
        _holdDownMap["sneak"] = true;
        OnSneak?.Invoke();
    }
    public void SneakReleasedEvent()
    {
        _holdDownMap["sneak"] = false;
        OnSneakReleased?.Invoke();
    }
    public void RunEvent()
    {
        _holdDownMap["run"] = true;
        OnRun?.Invoke();
    }
    public void RunReleasedEvent()
    {
        _holdDownMap["run"] = false;
        OnRunReleased?.Invoke();
    }
    public void ReloadEvent()
    {
        OnReload?.Invoke();
    }
    public void ThrowEvent()
    {
        OnThrow?.Invoke();
    }
    public void MouseXEvent()
    {
        onMouseX?.Invoke();
    }
    public void MouseYEvent()
    {
        onMouseY?.Invoke();
    }
    public void JumpEvent()
    {
        onJump?.Invoke();
    }

}
