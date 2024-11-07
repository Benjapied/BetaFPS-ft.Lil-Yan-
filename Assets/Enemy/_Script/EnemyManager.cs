using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform m_transform;
    BehaviourEnemy _behaviour;
    public GameObject prefabEnemy;

    // Start is called before the first frame update
    void Start()
    {
        _behaviour = new BehaviourEnemy();

        EnemyIdleState enemyIdleState = new EnemyIdleState();
        _behaviour.AddState(Context.State.Idle, enemyIdleState);



        //Instantiate(prefabEnemy, transform.position, transform.rotation);

        NavMeshAgent agent =  prefabEnemy.GetComponent<NavMeshAgent>();

        if (NavMesh.SamplePosition(prefabEnemy.transform.position, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            transform.position = hit.position;
            agent.Warp(hit.position); // Place l'agent sur le NavMesh
            Debug.Log(hit.position);
            
        }

        //this.gameObject.AddComponent<Enemy>();


        prefabEnemy.GetComponent<Enemy>()._transform = m_transform;
        prefabEnemy.GetComponent<Enemy>().State = Context.State.Idle;
        prefabEnemy.GetComponent<Enemy>().Behaviour = _behaviour;

        prefabEnemy.GetComponent<Enemy>().SetState(Context.State.Idle);
        
    }

    // Update is called once per frame
    void Update()
    {
        prefabEnemy.GetComponent<Enemy>().UpdateEnemy();
    }
}
