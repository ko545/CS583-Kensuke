using System.Runtime.CompilerServices;
using UnityEngine;

// Purpose: What happens when Player interacts with the MedKit obj
public class MedKit : Interactable
{
    // make sure the player name is accurate, on what is on the scene
    [Header("Important")] [SerializeField] private string playerObjName = "Player Variant";
    private Health healthObj;
    
    private int healthAmount = 20;
    protected override void Interact()
    {
        print("u touched me");

        // get the healthobj from player
        healthObj = GameObject.Find(playerObjName).GetComponent<Health>();
        HealPlayer();
        DeleteMedKit();
        
    }

    private void HealPlayer()
    {
        healthObj.Heal(healthAmount);
    }

    private void DeleteMedKit()
    {
        Destroy(gameObject);
    }
}
