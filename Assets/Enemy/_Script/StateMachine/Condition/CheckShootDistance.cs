using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckShootDistance : Condition
{
    public override bool Test(IBehaviour iBehaviour)
    {
        //iBehaviour.

        if (iBehaviour is Enemy enemy)
        {
            float dist = Vector3.Distance(enemy.transform.position, enemy._transform.position);
            if (dist < enemy.DistanceShoot)
            {
                Debug.Log("on test");
                return true;
            }
        }
        return false;
    }
}

public class CheckMoveDistance : Condition
{
    public override bool Test(IBehaviour iBehaviour)
    {
        if (iBehaviour is Enemy enemy)
        {
            float dist = Vector3.Distance(enemy.transform.position, enemy._transform.position);
            if (dist > enemy.DistanceShoot)
            {
                Debug.Log("on test");
                return true;
            }
        }
            
        return false;
    }
}
