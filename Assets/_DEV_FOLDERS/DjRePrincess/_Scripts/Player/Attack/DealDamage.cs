using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        bool collidedWithEnemy = other.CompareTag("Enemy");
        if (collidedWithEnemy)
        {
            print("dealt dmg to enemy");
        }
    }
}
