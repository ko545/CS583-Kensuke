using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine context)
    {
        Debug.Log("in IDLE state");
        context.render.material.color = Color.deepSkyBlue;
        
        context.alert = false;
        //deactivate the attack sensor. player is not in view
        context.AttackRange.gameObject.SetActive(false);
        context.ChaseRange.gameObject.SetActive(false);
        //play animation
        context.animator.Play("idle");
    }

    public override void UpdateState(EnemyStateMachine context)
    {
        if (context.HurtBox.playerIsInRange()) { GotHit(context); }

        if (context.ViewRange.playerIsInRange())
        {
            context.SwitchState(context.AlertState);
        }
        
    }
}
