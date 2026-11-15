using UnityEngine;
using UnityEngine.AI;

public class ChaseState : ko_State
{
    //[SerializeField] private Material mat;
    [SerializeField] public NavMeshAgent agent;

    
    public override ko_State RunCurrentState()
    {
        mat.color = Color.purple;
        Debug.Log("in chase state");

        agent.SetDestination(targetPos.position);
        
        
        // transform.parent.parent.position = Vector3.MoveTowards(
        //     this.transform.position, 
        //     targetPos.position, 
        //     25 * Time.deltaTime);
        
        return this;

    }
}
