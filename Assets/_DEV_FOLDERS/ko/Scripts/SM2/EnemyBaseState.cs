using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateMachine context);
    public abstract void UpdateState(EnemyStateMachine context);
}
