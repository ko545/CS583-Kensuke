using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateMachine context);
    public abstract void UpdateState(EnemyStateMachine context);
    public void GotHit(EnemyStateMachine context)
    {
        context.HitBox.gameObject.SetActive(false);
        //reduce enemy hp when hit by player
        context.health -= 25;
        //disable the trigger so next hit counts 
        //this probably wont be needed once player attack animations exist
        context.HurtBox.setStatus(false);
        
        //go to appropriate state
        if (context.health <= 0) context.DieState();
        else context.SwitchState(context.HitState);
    }
}
