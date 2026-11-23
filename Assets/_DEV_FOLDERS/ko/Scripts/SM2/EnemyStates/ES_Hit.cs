using UnityEngine;

public class EnemyHitState : EnemyBaseState
{
    float wait = 2.0f;
    
    public override void EnterState(EnemyStateMachine context)
    {
        Debug.Log("in HIT state");
        context.render.material.color = Color.turquoise;
        
        context.ChaseRange.gameObject.SetActive(true);
        context.AttackRange.gameObject.SetActive(true);

        wait = 1.0f;
        
        //context.wasHit = false;
        context.gameObject.transform.LookAt(context.ChaseRange.getTargetPosition());
        
        context.animator.Play("hit");
    }

    public override void UpdateState(EnemyStateMachine context)
    {
        //cant get hit again within wait time
        while (wait > 0.0f)
        {
            wait -= Time.deltaTime;
        }
        
        //if got hit, go to hit state
        if (context.HurtBox.playerIsInRange())
        {
            GotHit(context);
        }
        
        //check if animation is done playing
        if (context.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            context.SwitchState(context.AlertState);  //switch to appropriate state once done

    }
    
}