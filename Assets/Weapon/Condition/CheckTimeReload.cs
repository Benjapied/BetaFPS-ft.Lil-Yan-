using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTimeReload : Condition
{
    public override bool Test(IBehaviour iBehaviour)
    {
        if (iBehaviour is Weapon weapon)
        {
            if (weapon.TimeInReload >= weapon.WeaponData._timeReloading)
            {
                return true;
            }
        }
        return false;
    }
}
