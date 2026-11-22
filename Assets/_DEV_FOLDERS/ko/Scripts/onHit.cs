using System;
using Unity.VisualScripting;
using UnityEngine;

public class onHit : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    private void OnTriggerEnter(Collider collider)
    {
        print("hit hit hit");
        particles.Play();
        FindAnyObjectByType<HitStop>().Stop(0.1f, 0.01f);
    }
}
