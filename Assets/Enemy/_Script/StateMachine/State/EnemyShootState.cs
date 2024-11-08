using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootState : EnemyState
{
    public override void EnterState(Enemy enemy)
    {
        Debug.Log("on entre dans le shoot");
        
    }
    public override void FrameUpdate(Enemy enemy)
    {
        Debug.Log("on update dans le shoot");
    }

    public override void ExitState(Enemy enemy)
    {
        Debug.Log("on exit dans le shoot");
    }
    
}
