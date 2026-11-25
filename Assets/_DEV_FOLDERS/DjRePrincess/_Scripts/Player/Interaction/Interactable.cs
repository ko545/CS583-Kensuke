using Unity.VisualScripting;
using UnityEngine;

// Purpose: Template class for any interactable obj that will be in the game. 
public abstract class Interactable : MonoBehaviour
{
    // what the player will see when looking at an interactable object
    public string promptMessage;

    // will be called from player
    public void BaseInteract()
    {
        Interact();
    }
    
    protected virtual void Interact()
    {
        // to be overriden by sub classes 
        // (any scripts that are also interactable, must have an Interact() function, what to do when Player interacts with this obj
    }
}
