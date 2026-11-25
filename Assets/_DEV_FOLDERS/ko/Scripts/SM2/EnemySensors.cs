using System;
using UnityEditor;
using UnityEngine;

public class EnemySensors : MonoBehaviour
{
    private bool isInRange = false;
    private Vector3 targetPos;
    //private Transform targetTransform;

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
        //targetPos = other.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        //isInRange = true;
        targetPos = other.transform.position;
        //targetTransform = other.transform;
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

    public void setStatus(bool status)
    {
        isInRange = status;
    }
    
    // public Transform getTargetTransform()
    // {
    //     return targetTransform;
    // }
    
    
}
