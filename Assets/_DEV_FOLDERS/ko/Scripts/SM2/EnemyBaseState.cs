using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateMachine context);
    public abstract void UpdateState(EnemyStateMachine context);
    public void GotHit(EnemyStateMachine context)
    {
        //reduce enemy hp when hit by player
        context.health -= 25;
        //disable the trigger so next hit counts 
        //this wont be needed once player attack animations exist
        context.HurtBox.setStatus(false);
        //go to enemy hit state
        context.SwitchState(context.HitState);
    }
}
