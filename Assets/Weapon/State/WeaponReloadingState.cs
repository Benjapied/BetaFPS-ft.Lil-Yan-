using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReloadingState : GeneralState
{
    public override void EnterState(IBehaviour iBehaviour)
    {
        Debug.Log("on comence a recharger");
    }
    public override void FrameUpdate(IBehaviour iBehaviour)
    {
        if (iBehaviour is Weapon weapon)
        {
            weapon.TimeInReload += Time.deltaTime;
            //Debug.Log("on recharche");
        }
    }

    public override void ExitState(IBehaviour iBehaviour)
    {
        if (iBehaviour is Weapon weapon)
        {
            weapon.TimeInReload = 0f;
            weapon.NbBalls = weapon.WeaponData._nbBalls;
        }
    }
}
