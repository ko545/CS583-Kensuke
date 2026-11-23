using UnityEngine;

// Purpose: What happens when Player interacts with the MedKit obj
public class MedKit : Interactable
{
    protected override void Interact()
    {
        print("u touched me");
    }
}
