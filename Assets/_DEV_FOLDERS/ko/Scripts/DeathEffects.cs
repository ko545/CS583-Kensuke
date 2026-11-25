using System;
using UnityEngine;

public class DeathEffects : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private ParticleSystem E1;
    [SerializeField] private ParticleSystem E2;
    void Start()
    {
        E1.Play();
        E2.Play();
    }

    private void Update()
    {
        if (this.transform.childCount <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
