using System;
using UnityEditor;
using UnityEngine;

public class EnemySensors : MonoBehaviour
{

    
    private ko_State currentState;
    private bool isInRange = false;
    private Vector3 targetPos;

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
        //targetPos = other.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        targetPos = other.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
        //targetPos = other.transform.position;
    }
    
    public bool playerIsInRange()
    {
        return isInRange;
    }
    
    public Vector3 getTargetPosition()
    {
        return targetPos;
    }
}
