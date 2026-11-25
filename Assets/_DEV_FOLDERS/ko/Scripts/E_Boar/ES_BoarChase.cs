using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class ES_BoarChase : EnemyChaseState
{
    Vector3 originalPos;
    Vector3 destinationPos;
    RaycastHit hit;
    float maxRayDist = 16.0f;
    float waitTime = 10.0f;
    
    public override void EnterState(EnemyStateMachine context)
    {
        Debug.Log("in CHASE state");
        context.render.material.color = Color.purple;

        waitTime = 15.0f;
        
        //activate the attack sensor
        context.AttackRange.gameObject.SetActive(true);
        //allow the enemy to move
        context.agent.isStopped = false;
        //play animation
        context.animator.Play("walk");
        
        LayerMask layerMask = LayerMask.GetMask("Default");
        
        //this is all to manually sets the destination point to be on the collision point
        //otherwise the navmesh agent would navigate around the collision point to reach the destination
        //and i dont want that for this enemy
        originalPos = context.gameObject.transform.position;
        destinationPos = context.ChaseRange.getTargetPosition();
        Vector3 direction = (destinationPos - originalPos);
        if (Physics.Raycast(originalPos, context.gameObject.transform.TransformDirection(Vector3.forward) , out hit, maxRayDist, layerMask))
        {
            context.render.material.color = Color.black;
            //Debug.DrawRay(originalPos, context.gameObject.transform.forward* maxRayDist, Color.white);
            Debug.Log("HIT");
        
            direction = Vector3.zero;
            destinationPos = hit.point;
        } else direction *= 2; //make enemy overshoot the destination if no wall was hit
        
        context.agent.SetDestination(destinationPos + direction);
    }

    public override void UpdateState(EnemyStateMachine context)
    {
        //if got hit, go to hit state
        if (context.HurtBox.playerIsInRange()) { GotHit(context); }

        //switch to attack state if player is in attack range
        if (context.AttackRange.playerIsInRange())
        {
            context.SwitchState(context.AttackState);
        }
        
        //check if agent is still moving
        if (!context.agent.pathPending)
        {
            if (!context.agent.hasPath)// || context.agent.velocity.sqrMagnitude == 0.0f)
            {
                //switch to idle state once done moving
                context.SwitchState(context.AlertState);
            }
        }

        //force the enemy into alert state if it gets stuck running into a wall or something
        //maybe change to a raycast actually lmao
        waitTime -= Time.deltaTime;
        if (waitTime <= 0.0f)
        {
            Debug.Log("Chase exit due to timer");
            context.SwitchState(context.AlertState);
        }
    }
}
