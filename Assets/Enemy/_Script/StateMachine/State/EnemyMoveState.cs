using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    

    public override void EnterState(Enemy enemy)
    {
        
        UnityEngine.AI.NavMeshAgent agent = enemy.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent.isOnNavMesh)
        {
            agent.SetDestination(enemy._transform.position);
        }
       
    }
    public override void FrameUpdate(Enemy enemy)
    {
        UnityEngine.AI.NavMeshAgent agent = enemy.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent.isOnNavMesh)
        {
            agent.SetDestination(enemy._transform.position);
        }
        
    }

    public override void ExitState(Enemy enemy)
    {

    }
}
