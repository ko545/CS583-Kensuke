using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    private bool waiting = false;
    
    public void Stop(float stopDuration, float timeScale)
    {
        if (waiting) return;
        
        Time.timeScale = timeScale;
        StartCoroutine(Wait(stopDuration));
    }

    IEnumerator Wait(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        waiting = false;
    }
}
