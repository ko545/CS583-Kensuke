using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    public readonly EnemyBaseState IdleState = new EnemyIdleState();
    public readonly EnemyBaseState ChaseState = new EnemyChaseState();
    public readonly EnemyBaseState AttackState = new EnemyAttackState();
    
    private EnemyBaseState currentState;
    
    [Header("Sensors")]
    [SerializeField] public EnemySensors ViewRange;
    [SerializeField] public EnemySensors AttackRange;
    
    [Header("Navigation Agent")]
    [SerializeField] public NavMeshAgent agent;

    [Header("Debug Material")]
    [SerializeField] public Material mat;

    void Start()
    {
        mat.color = Color.teal;
        //AttackRange.enabled = false;
        currentState = IdleState; 
        currentState.EnterState(this);
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     currentState.OnCollisionEnter(this, collision);
    // }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
