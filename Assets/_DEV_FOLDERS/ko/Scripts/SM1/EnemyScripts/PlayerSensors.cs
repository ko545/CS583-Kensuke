using System;
using UnityEditor;
using UnityEngine;

public class PlayerSensors : MonoBehaviour
{
    [Header("States")] 
    [SerializeField] private ko_State onEnter;
    [SerializeField] private ko_State onStay;
    [SerializeField] private ko_State onExit;
    
    private ko_State currentState;
    private bool isInRange = false;
    private Collider col;

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
        col = other;
        currentState = onEnter;
    }
    
    private void OnTriggerStay(Collider other)
    {
        isInRange = true;
        col = other;
        currentState = onStay;
    }
    
    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
        col = other;
        currentState = onExit;
    }

    public ko_State getState()
    {
        return currentState;
    }

    public bool getStatus()
    {
        return isInRange;
    }
    
    public Transform getTargetPos()
    {
        return col.transform;
    }
}
