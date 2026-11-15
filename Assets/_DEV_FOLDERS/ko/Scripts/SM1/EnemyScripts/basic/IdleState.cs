using UnityEngine;

public class IdleState : ko_State
{
    public override ko_State RunCurrentState()
    {
        Debug.Log("in idle state");
        mat.color = Color.blue;
        
        return this;
    }
    
}
