using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyStateMachine : MonoBehaviour
{
    //basic states
    [NonSerialized] public EnemyBaseState IdleState;
    [NonSerialized] public EnemyBaseState AlertState;
    [NonSerialized] public EnemyBaseState RotateState;
    [NonSerialized] public EnemyBaseState ChaseState;
    [NonSerialized] public EnemyBaseState AttackState;
    [NonSerialized] public EnemyBaseState HitState;
    
    private EnemyBaseState currentState;
    public bool alert = false;

    [Header("Enemy Health")]
    [SerializeField] public int health = 100;
    
    [Header("Sensors")]
    [SerializeField] public EnemySensors ViewRange;
    [SerializeField] public EnemySensors ChaseRange;
    [SerializeField] public EnemySensors AttackRange;
    [SerializeField] public EnemySensors HurtBox;
    
    [Header("Navigation Agent")]
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] private float agentSpeed = 3.5f;
    
    [Header("Animations")]
    [SerializeField] public Animator animator;

    [Header("Debug Things")]
    [SerializeField] public MeshRenderer render;

    void Start()
    {
        render.material.color = Color.white;
        
        //set agent speed
        agent.speed = agentSpeed;
        
        //setup initial state
        currentState = IdleState; 
        currentState.EnterState(this);
    }

    void Update()
    {
        //disable object if no hp left
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        
        //update current state
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
