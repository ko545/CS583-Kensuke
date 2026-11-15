using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine context)
    {
        Debug.Log("in ATTACK state");
        //stop the enemy from moving
        context.agent.isStopped = true;
        context.mat.color = Color.red;

    }

    public override void UpdateState(EnemyStateMachine context)
    {
        //switch to chase state if player is out of attack range
        if (!context.AttackRange.playerIsInRange())
        {
            context.SwitchState(context.ChaseState);
        }
    }
}
