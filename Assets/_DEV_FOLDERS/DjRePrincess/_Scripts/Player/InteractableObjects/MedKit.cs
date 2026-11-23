using UnityEngine;

// Purpose: What happens when Player interacts with the MedKit obj
public class MedKit : Interactable
{
    private Health healthObj;
    protected override void Interact()
    {
        print("u touched me");
    }
}
