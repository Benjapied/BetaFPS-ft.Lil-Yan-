using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStateMachine : PlayerStateMachine
{
    private IdleActionState _idleState;
    private HasWeaponState  _hasWeaponState;
    private GetWeaponState  _getWeaponState;
    private ReloadState     _reloadState;
    private ShootState      _shootState;
    private ThrowState      _throwState;

    public IdleActionState IdleState { get => _idleState; set => _idleState = value; }
    public HasWeaponState HasWeaponState { get => _hasWeaponState; set => _hasWeaponState = value; }
    public GetWeaponState GetWeaponState { get => _getWeaponState; set => _getWeaponState = value; }
    public ReloadState ReloadState { get => _reloadState; set => _reloadState = value; }
    public ShootState ShootState { get => _shootState; set => _shootState = value; }
    public ThrowState ThrowState { get => _throwState; set => _throwState = value; }
    
    public ActionStateMachine(Player p) : base(p)
    {
        _idleState = new(this);
        _hasWeaponState = new(this);
        _getWeaponState = new(this);
        _reloadState = new(this);
        _shootState = new(this);
        _throwState = new(this);
    }

}
