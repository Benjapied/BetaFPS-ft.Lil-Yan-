using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyIdleState : EnemyState
{
    public override void EnterState(Enemy enemy)
    {
        NavMeshAgent agent = enemy.gameObject.GetComponent<NavMeshAgent>();
        if ( agent.isOnNavMesh)
        {
            agent.SetDestination(enemy._transform.position);
        }
        else
        {
            //Debug.LogWarning("L'agent n'est pas sur le NavMesh !");
        }
        //agent.SetDestination(enemy._transform.position);


        //Debug.Log("on entre");
    }
    public override void FrameUpdate(Enemy enemy)
    {
        //Debug.Log("on update");
    }

    public override void ExitState(Enemy enemy)
    {

    }
}
