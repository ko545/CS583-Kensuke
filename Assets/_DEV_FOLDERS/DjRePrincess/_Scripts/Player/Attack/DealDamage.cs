using UnityEngine;

public class DealDamage : MonoBehaviour
{
    //private EnemyStateMachine sm_script;
    private void OnTriggerEnter(Collider other)
    {
        //sm_script = GetComponent<EnemyStateMachine>();

        bool collidedWithEnemy = other.CompareTag("Enemy");

        // how to access the enemy layer 
        // i dont need to access it
        // maybe just access the enemy health, and like decrement that 

        if (collidedWithEnemy)
        {
            print("dealt dmg to enemy");
        }
    }
}
