using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShootState : GeneralState
{
    public override void EnterState(IBehaviour iBehaviour)
    {
        Debug.Log("on comence on a shooter");
    }
    public override void FrameUpdate(IBehaviour iBehaviour)
    {
        if(iBehaviour is Weapon weapon)
        {
            weapon.NbBalls--;
            //Debug.Log("on shoot");
        }
    }

    public override void ExitState(IBehaviour iBehaviour)
    {
    }
}
