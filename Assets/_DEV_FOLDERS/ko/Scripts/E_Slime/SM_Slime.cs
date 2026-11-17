public class SM_Slime : EnemyStateMachine
{
    //constructor
    SM_Slime()
    {
        IdleState = new EnemyIdleState();
        AlertState = new EnemyAlertState();
        RotateState = new EnemyRotateState();
        ChaseState = new EnemyChaseState();
        AttackState = new ES_SlimeAttack();
        HitState = new EnemyHitState();
    }
}
