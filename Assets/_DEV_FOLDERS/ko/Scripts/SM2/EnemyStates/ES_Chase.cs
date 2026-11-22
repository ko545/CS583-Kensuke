using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine context)
    {
        Debug.Log("in CHASE state");
        context.render.material.color = Color.purple;
        
        //activate the attack sensor
        context.HitBox.gameObject.SetActive(false);
        context.AttackRange.gameObject.SetActive(true);
        context.ChaseRange.gameObject.SetActive(true);
        //allow the enemy to move
        context.agent.isStopped = false;
        //play animation
        context.animator.Play("walk");
        context.agent.SetDestination(context.ChaseRange.getTargetPosition());
    }

    public override void UpdateState(EnemyStateMachine context)
    {
        //if got hit, go to hit state
        if (context.HurtBox.playerIsInRange())
        {
            GotHit(context);
        }
        
        //chase player
        context.agent.SetDestination(context.ChaseRange.getTargetPosition());
        
        //switch to attack state if player is in attack range
        if (context.AttackRange.playerIsInRange())
        {
            context.SwitchState(context.AttackState);
        }
        
        // check if agent is still moving
        if (!context.agent.pathPending)
        {
            if (!context.agent.hasPath) // || context.agent.velocity.sqrMagnitude == 0.0f)
            {
                //Debug.Log("why");
                //switch to idle state once done moving
                context.SwitchState(context.AlertState);
            }
        }
    }
}
