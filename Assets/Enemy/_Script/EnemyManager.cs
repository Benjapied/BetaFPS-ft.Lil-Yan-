using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    BehaviourEnemy _behaviour;
    Enemy _enemy;
    // Start is called before the first frame update
    void Start()
    {
        _behaviour = new BehaviourEnemy();

        EnemyIdleState enemyIdleState = new EnemyIdleState();
        _behaviour.AddState(Context.State.Idle, enemyIdleState);
        //AddedComponent(_enemy);
        //AddComponent();
        this.gameObject.AddComponent<Enemy>();
        //_enemy = new Enemy();
        gameObject.GetComponent<Enemy>().State = Context.State.Idle;
        gameObject.GetComponent<Enemy>().Behaviour = _behaviour;

        gameObject.GetComponent<Enemy>().SetState(Context.State.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Enemy>().UpdateEnemy();
    }
}
