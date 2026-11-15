using System;
using UnityEngine;
using UnityEngine.AI;

public class ko_StateMachine : MonoBehaviour
{
    [SerializeField] ko_State currentState;
    private ko_State nextState;
    
    [Header("Sensors")] 
    [SerializeField] private PlayerSensors viewDistance;
    [SerializeField] private PlayerSensors attackDistance;
    [SerializeField] private NavMeshAgent agent;
    
    void FixedUpdate()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        Debug.Log("hi");
        
        nextState = currentState?.RunCurrentState();

        //disable attack sensor if player isnt in view range
        attackDistance.enabled = viewDistance.getStatus();
        
        // go to attack state if in range and not null, else go to chase state
        nextState = attackDistance.getStatus() ? attackDistance?.getState() : viewDistance.getState();
        
        if (nextState) //if not null
        {
            GoToNextState(nextState);
        }
    }

    private void GoToNextState(ko_State goTo)
    {
        goTo.targetPos = viewDistance.getTargetPos();
        currentState = goTo;
    }
}
