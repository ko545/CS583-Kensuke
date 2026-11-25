using System;
using Unity.VisualScripting;
using UnityEngine;

public class onHit : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private ParticleSystem particles2;
    private void OnTriggerEnter(Collider collider)
    {
        print("hit hit hit");
        particles2.Play();
        particles.Play();
        FindAnyObjectByType<HitStop>().Stop(0.1f, 0.01f);
    }
}
