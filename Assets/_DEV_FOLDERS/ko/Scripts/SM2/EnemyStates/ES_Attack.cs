using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine context)
    {
        Debug.Log("in ATTACK state");
        context.render.material.color = Color.red;
        
        //redundant but just to make sure this is on
        context.AttackRange.gameObject.SetActive(true);
        //stop the enemy from moving
        context.agent.isStopped = true;
        //play animation
        context.animator.Play("attack");
    }

    public override void UpdateState(EnemyStateMachine context)
    {
        //if got hit, go to hit state
        if (context.HurtBox.playerIsInRange())
        {
            GotHit(context);
        }

        //check if attack animation is done
        if (context.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >  1.2f)
        { 
          //switch to appropriate state once done
          context.SwitchState(context.AlertState);
        }
    }
}
