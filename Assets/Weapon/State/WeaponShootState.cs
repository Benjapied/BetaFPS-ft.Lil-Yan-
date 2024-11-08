using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShootState : GeneralState
{
    public override void EnterState(IBehaviour iBehaviour)
    {
        if (iBehaviour is Weapon weapon)
        {
            weapon.NbBalls = weapon.WeaponData._nbBalls;
        }
            Debug.Log("on comence on a shooter");
        
    }
    public override void FrameUpdate(IBehaviour iBehaviour)
    {
        if(iBehaviour is Weapon weapon)
        {
            weapon.NbBalls--;
            //Debug.Log(weapon.NbBalls);
        }
    }

    public override void ExitState(IBehaviour iBehaviour)
    {
    }
}
