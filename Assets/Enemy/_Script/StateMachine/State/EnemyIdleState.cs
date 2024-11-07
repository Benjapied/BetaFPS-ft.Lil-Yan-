using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public override void EnterState(Enemy enemy)
    {
        Debug.Log("on entre");
    }
    public override void FrameUpdate(Enemy enemy)
    {
        Debug.Log("on update");
    }

    public override void ExitState(Enemy enemy)
    {

    }
}
