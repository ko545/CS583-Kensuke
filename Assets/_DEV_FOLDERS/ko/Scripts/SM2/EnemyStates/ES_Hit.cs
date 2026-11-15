using UnityEngine;

public class EnemyHitState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine context)
    {
        Debug.Log("in HIT state");
        context.render.material.color = Color.turquoise;
        //context.AttackRange.enabled = false;
        //context.AttackRange.GetComponent<Collider>().enabled = true;
        
        //context.wasHit = false;
        context.gameObject.transform.LookAt(context.ViewRange.getTargetPosition());
        context.animator.Play("slime_hit");
    }

    public override void UpdateState(EnemyStateMachine context)
    {
        //if got hit, go to hit state
        if (context.HurtBox.playerIsInRange())
        {
            GotHit(context);
        }
        
        // if (context.animator.GetCurrentAnimatorStateInfo(0).normalizedTime is > 0.5f and < 1.0f)
        // {
        //     if (context.HurtBox.playerIsInRange())
        //         GotHit(context);
        // }
        // else 
        if (context.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            context.SwitchState(context.IdleState);  //switch to appropriate state once done

    }
    
}