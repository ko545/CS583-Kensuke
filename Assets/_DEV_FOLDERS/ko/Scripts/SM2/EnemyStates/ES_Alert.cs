using UnityEngine;

public class EnemyAlertState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine context)
    {
        Debug.Log("in ALERT state");
        context.render.material.color = Color.blue;

        context.alert = true;
        
        //deactivate the attack sensor. player is not in view
        context.ViewRange.gameObject.SetActive(false);
        context.ChaseRange.gameObject.SetActive(true);
        
        //play animation
        context.animator.Play("idle");
    }

    public override void UpdateState(EnemyStateMachine context)
    {
        //if got hit, go to hit state
        if (context.HurtBox.playerIsInRange()) { GotHit(context); }
            
        //if player is in view, go to rotate state
        if (context.ChaseRange.playerIsInRange()) { context.SwitchState(context.RotateState); }
    }
}