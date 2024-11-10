using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Weapon : MonoBehaviour, IBehaviour
{
    private int _nbBalls;
    private float _timeInReload = 0f;
    Context.State _state;
    BehaviourGeneral _behaviour;
    [SerializeField] WeaponData _weaponData;

    public int NbBalls { get => _nbBalls; set => _nbBalls = value; }
    public BehaviourGeneral Behaviour { get => _behaviour; set => _behaviour = value; }
    internal Context.State State { get => _state; set => _state = value; }
    public float TimeInReload { get => _timeInReload; set => _timeInReload = value; }
    public WeaponData WeaponData { get => _weaponData; set => _weaponData = value; }


    private void Start()
    {
        //_nbBalls = _weaponData._nbBalls;
    }

    public void SetState(Context.State new_state)
    {
        _behaviour.End(this);
        _state = new_state;
        _behaviour.StartBehaviour(this);
    }
    public Context.State GetState()
    {
        return State;
    }

    public void UpdateObject()
    {
        _behaviour.UpdateBehaviour(this);
    }


}
