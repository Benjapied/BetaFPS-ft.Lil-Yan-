using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    Player _player;
    public Player Player { get => _player; set => _player = value; }

    protected PlayerStateMachine(Player p)
    {
        _player = p;
    }

}
