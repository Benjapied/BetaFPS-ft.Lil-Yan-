using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Weapon : MonoBehaviour, IBehaviour
{
    [SerializeField] int _nbBalls = 5;
    private int _maxNbBalls = 5;
    [SerializeField] float _timeReloading = 2f;
    private float _timeInReload = 0f;
    Context.State _state;
    BehaviourGeneral _behaviour;

    public int NbBalls { get => _nbBalls; set => _nbBalls = value; }
    public int MaxNbBalls { get => _maxNbBalls; set => _maxNbBalls = value; }
    public float TimeReloading { get => _timeReloading; set => _timeReloading = value; }

    public BehaviourGeneral Behaviour { get => _behaviour; set => _behaviour = value; }
    internal Context.State State { get => _state; set => _state = value; }
    public float TimeInReload { get => _timeInReload; set => _timeInReload = value; }

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
