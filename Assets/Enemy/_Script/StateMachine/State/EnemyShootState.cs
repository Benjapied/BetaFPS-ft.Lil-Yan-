using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootState : GeneralState
{
    public override void EnterState(IBehaviour iBehaviour)
    {
        if (iBehaviour is Enemy enemy)
        {
            enemy.EnemyAnimator.SetBool("IsShooting", true);
        }
    }
    public override void FrameUpdate(IBehaviour iBehaviour)
    {
        if (iBehaviour is Enemy enemy)
        {
            enemy.RotateEnemy();
        }
            
    }

    public override void ExitState(IBehaviour iBehaviour)
    {
        if (iBehaviour is Enemy enemy)
        {
            enemy.EnemyAnimator.SetBool("IsShooting", false);
        }
    }
}
