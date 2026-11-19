using UnityEngine;

public class SM_Boar : EnemyStateMachine
{
    //constructor
    SM_Boar()
    {
        IdleState = new EnemyIdleState();
        AlertState = new EnemyAlertState();
        RotateState = new EnemyRotateState();
        ChaseState = new ES_BoarChase();
        AttackState = new EnemyAttackState();
        HitState = new EnemyHitState();
    }
}
