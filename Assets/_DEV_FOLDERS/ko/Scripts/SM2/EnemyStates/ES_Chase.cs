using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine context)
    {
        Debug.Log("in CHASE state");
        context.render.material.color = Color.purple;
        //context.AttackRange.GetComponent<Collider>().enabled = false;
        
        //allow the enemy to move
        context.agent.isStopped = false;
        context.animator.Play("slime_walk");
    }

    public override void UpdateState(EnemyStateMachine context)
    {
        //if got hit, go to hit state
        if (context.HurtBox.playerIsInRange())
        {
            GotHit(context);
        }
        
        //chase player
        context.agent.SetDestination(context.ViewRange.getTargetPosition());
        
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
                //switch to idle state once done moving
                context.SwitchState(context.IdleState);
            }
        }
    }
}
