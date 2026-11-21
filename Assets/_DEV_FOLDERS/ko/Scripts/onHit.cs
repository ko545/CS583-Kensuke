using System;
using Unity.VisualScripting;
using UnityEngine;

public class onHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        print("hit hit hit");
        FindAnyObjectByType<HitStop>().Stop(0.1f, 0.01f);
    }
}
