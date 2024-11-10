using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNumberBall : Condition
{
    public override bool Test(IBehaviour iBehaviour)
    {
        if(iBehaviour is Weapon weapon)
        {
            if (weapon.NbBalls == 0)
            {
                
                return true;
            }
        }
        return false;
    }
}
