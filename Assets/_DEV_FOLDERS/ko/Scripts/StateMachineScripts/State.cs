using UnityEngine;
using UnityEngine.AI;

public abstract class ko_State : MonoBehaviour
{
    [SerializeField] public Material mat;
    public Transform targetPos;
    


    public abstract ko_State RunCurrentState();

}
