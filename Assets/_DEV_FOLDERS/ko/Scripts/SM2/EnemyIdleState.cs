using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine context)
    {
        Debug.Log("in IDLE state");
        context.render.material.color = Color.blue;
        //context.AttackRange.enabled = false;
        //context.AttackRange.GetComponent<Collider>().enabled = true;
        
        context.animator.Play("slime_idle");


    }

    public override void UpdateState(EnemyStateMachine context)
    {
        if (context.ViewRange.playerIsInRange())
        {
            context.SwitchState(context.RotateState);
        }
    }
}
