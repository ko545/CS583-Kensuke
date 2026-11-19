using UnityEngine;

public class ES_SlimeAttack : EnemyAttackState
{
    private bool waitingToExit = false;
        
    public override void EnterState(EnemyStateMachine context)
    {
        Debug.Log("in SLIME ATTACK state");
        context.render.material.color = Color.red;
            
        //redundant but just to make sure this is on
        context.AttackRange.gameObject.SetActive(true);
        //used to trigger the exit condition
        waitingToExit = false;
        //stop the enemy from moving
        context.agent.isStopped = true;
        //play animation
        context.animator.Play("attack");
    }

    public override void UpdateState(EnemyStateMachine context)
    {
        //exit condition was met and waiting for attack_end animation to finish
        if (waitingToExit)
        {
            //check if attack_end animation is done
            if (context.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.2f)
            {
                //switch to appropriate state once done
                context.SwitchState(context.AttackRange.playerIsInRange() ? context.AttackState : context.AlertState);
            }
        }
        else // continue attack animation
        {
            //check if attack animation is done
            if (context.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >  0.8f)
            {
                //if attack is done and player is not in range, play attack_end and start the scene exit
                if (!context.ChaseRange.playerIsInRange())
                {
                    context.animator.Play("attack_end");
                    context.HurtBox.setStatus(false); //dont worry about why this is here :)
                    waitingToExit = true;
                }
            }
            else if (context.HurtBox.playerIsInRange())
            {
                waitingToExit = false;
                GotHit(context);
            }
        }
    }
}