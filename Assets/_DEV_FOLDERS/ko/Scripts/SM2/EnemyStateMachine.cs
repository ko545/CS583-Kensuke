using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    public readonly EnemyBaseState IdleState = new EnemyIdleState();
    public readonly EnemyBaseState RotateState = new EnemyRotateState();
    public readonly EnemyBaseState ChaseState = new EnemyChaseState();
    public readonly EnemyBaseState AttackState = new EnemyAttackState();

    private EnemyBaseState currentState;
    
    [Header("Sensors")]
    [SerializeField] public EnemySensors ViewRange;
    [SerializeField] public EnemySensors AttackRange;
    
    [Header("Navigation Agent")]
    [SerializeField] public NavMeshAgent agent;
    
    [Header("Animations")]
    [SerializeField] public Animator animator;

    [Header("Debug Things")]
    [SerializeField] public MeshRenderer render;
    //[SerializeField] public Material mat;

    void Start()
    {
        render.material.color = Color.teal;
        //AttackRange.enabled = false;
        currentState = IdleState; 
        currentState.EnterState(this);
        animator.Play("slime_idle");
    }

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
