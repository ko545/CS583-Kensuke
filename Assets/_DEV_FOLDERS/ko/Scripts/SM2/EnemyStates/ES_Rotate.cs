using UnityEngine;

public class EnemyRotateState : EnemyBaseState
{
    private Vector3 targetDirection;
    private Quaternion targetRotation;
    private Quaternion objectRotation;
    private readonly float rotationSpeed = 100.0f;
    
    public override void EnterState(EnemyStateMachine context)
    {
        Debug.Log("in ROTATE state");
        context.render.material.color = Color.green;

        //activate attack sensor
        context.HitBox.gameObject.SetActive(false);
        context.AttackRange.gameObject.SetActive(true);
        //play animation
        context.animator.Play("walk");
    }

    public override void UpdateState(EnemyStateMachine context)
    {
        //if got hit, go to hit state
        if (context.HurtBox.playerIsInRange())
        {
            GotHit(context);
        }
        
        //get target's direction
        targetDirection = context.ChaseRange.getTargetPosition() - context.gameObject.transform.position;
        //ignore height
        targetDirection.y = 0.0f;
        
        //turn that direction into a rotation
        targetRotation = Quaternion.LookRotation(targetDirection);
        
        //get this object's rotation
        objectRotation = context.gameObject.transform.rotation;
        
        //rotate this object towards the target
        context.gameObject.transform.rotation = Quaternion.RotateTowards(
            objectRotation, targetRotation, rotationSpeed * Time.deltaTime);
        
        //switch to attack state if player is in attack range
        if (context.AttackRange.playerIsInRange())
        {
            context.SwitchState(context.AttackState);
        }

        //check if still rotating
        if (Mathf.Approximately(objectRotation.y, targetRotation.y))
        {
            //switch to appropriate state once done
            context.SwitchState(context.ChaseRange.playerIsInRange() ? context.ChaseState : context.AlertState);
        }
    }
}