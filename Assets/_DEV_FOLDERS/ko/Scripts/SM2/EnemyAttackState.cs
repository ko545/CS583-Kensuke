using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private bool waitingToExit = false;
    public override void EnterState(EnemyStateMachine context)
    {
        Debug.Log("in ATTACK state");
        context.mat.color = Color.red;
        
        //stop the enemy from moving
        waitingToExit = false;
        context.agent.isStopped = true;
        context.animator.Play("slime_attack");
    }

    public override void UpdateState(EnemyStateMachine context)
    {
        if (waitingToExit)
        {
            //check if attack_end animation is done
            if (context.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.2f)
            {
                //switch to appropriate state once done
                context.SwitchState(context.AttackRange.playerIsInRange() ? context.AttackState : context.RotateState);
            }
        }
        else
        {
            //check if attack animation is done
            if (context.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >  2.0f)
            {
                //if attack is done and player is not in range, play attack_end and start the scene exit
                if (!context.AttackRange.playerIsInRange())
                {
                   context.animator.Play("slime_attack_end");
                   waitingToExit = true;
                }
            }
        }
    }
}
