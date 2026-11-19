public class SM_Base : EnemyStateMachine
{
    SM_Base()
    {
        IdleState = new EnemyIdleState();
        AlertState = new EnemyAlertState();
        RotateState = new EnemyRotateState();
        ChaseState = new EnemyChaseState();
        AttackState = new EnemyAttackState();
        HitState = new EnemyHitState();
    }
}
