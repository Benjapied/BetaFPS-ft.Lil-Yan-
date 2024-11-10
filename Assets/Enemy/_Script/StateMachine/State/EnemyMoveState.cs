using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : GeneralState
{
    

    public override void EnterState(IBehaviour iBehaviour)
    {
        if (iBehaviour is Enemy enemy)
        {
            enemy.EnemyAnimator.SetBool("IsMoving", true);
            UnityEngine.AI.NavMeshAgent agent = enemy.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (agent.isOnNavMesh)
            {
                agent.SetDestination(enemy._transform.position);
            }
        }
    }
    public override void FrameUpdate(IBehaviour iBehaviour)
    {
        if (iBehaviour is Enemy enemy)
        {
            //l'ennemi se tourne vers le joueur
            enemy.RotateEnemy();


            //déplacement vers le joueur
            UnityEngine.AI.NavMeshAgent agent = enemy.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (agent.isOnNavMesh)
            {
                agent.SetDestination(enemy._transform.position);
            }
        }
    }

    public override void ExitState(IBehaviour iBehaviour)
    {
        if (iBehaviour is Enemy enemy)
        {
            enemy.EnemyAnimator.SetBool("IsMoving", false);
            UnityEngine.AI.NavMeshAgent agent = enemy.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (agent.isOnNavMesh)
            {
                agent.SetDestination(enemy.transform.position);
            }

            enemy.RotateEnemy();
        }
            
        
    }
}
