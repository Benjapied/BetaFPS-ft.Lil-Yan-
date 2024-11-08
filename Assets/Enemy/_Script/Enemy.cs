using Context;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , IBehaviour
{
    [SerializeField] Animator _enemyAnimator;
    public LayerMask maskObstacle;
    Context.State _state;
    BehaviourGeneral _behaviour;
    public Transform _transform;
    private float _distanceDetection = 8f;
    private float _distanceShoot = 4f;
      
    public float visionAngle = 45f;


    public BehaviourGeneral Behaviour { get => _behaviour; set => _behaviour = value; }
    internal State State { get => _state; set => _state = value; }
    public float DistanceDetection { get => _distanceDetection; set => _distanceDetection = value; }
    public float DistanceShoot { get => _distanceShoot; set => _distanceShoot = value; }
    public Animator EnemyAnimator { get => _enemyAnimator; set => _enemyAnimator = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateObject()
    {
        _behaviour.UpdateBehaviour(this);
    }
    

    public void SetState(Context.State new_state)
    {
        _behaviour.End(this);
        _state = new_state;
        _behaviour.StartBehaviour(this);
    }

    public void RotateEnemy()
    {
        Vector3 directionToPlayer = (_transform.position - gameObject.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, lookRotation, 2.0f * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        Vector3 leftBoundary = Quaternion.Euler(0, -visionAngle / 2, 0) * transform.forward * _distanceDetection;
        Vector3 rightBoundary = Quaternion.Euler(0, visionAngle / 2, 0) * transform.forward * _distanceDetection;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }

    public Context.State GetState()
    {
        return State;
    }
}
