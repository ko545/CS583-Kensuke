using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Health health_obj;

    private void Start()
    {
        health_obj = GetComponent<Health>();
    }

    // the attack range objs are triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "AttackRange")
        {
            health_obj.TakeDamage();
        }
        print(other.name);

    }
}
