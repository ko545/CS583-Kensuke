using UnityEngine;

public class AttackState : ko_State
{
    //[SerializeField] private Material mat;
    
    public override ko_State RunCurrentState()
    {
        mat.color = Color.red;
        Debug.Log("in attack state");
        
        return this;
    }
}
