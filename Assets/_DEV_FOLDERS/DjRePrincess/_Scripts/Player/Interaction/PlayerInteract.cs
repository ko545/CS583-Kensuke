using UnityEngine;

// Purpose: Sees if the Player can interact with an game object
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float rayDistance = 3f;
    [SerializeField] private LayerMask interactableLayer;
    private Camera cam;
    private PromptMessage promptMessageObj;
    
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        promptMessageObj = GetComponent<PromptMessage>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ClearPromptOnScreen();
        Vector3 origin = cam.transform.position;
        Vector3 direction = cam.transform.forward;

        // create a ray 
        Ray ray = new Ray(origin, direction);

        // to see the ray
        Debug.DrawRay(ray.origin, ray.direction * rayDistance);

        // make a variable to store info when a ray hits a collider 
        RaycastHit hitInfo;

        // Physics.raycast() is the one actually making the ray  
        // out means we are returning a value, putting it into hitInfo
        if (Physics.Raycast(ray, out hitInfo, rayDistance, interactableLayer))
        {
            bool objHasInteractableComponent = hitInfo.collider.GetComponent<Interactable>();
            if (objHasInteractableComponent)
            {
                promptMessageObj.UpdateText((hitInfo.collider.GetComponent<Interactable>().promptMessage));
            }
        }
        
    }
    private void ClearPromptOnScreen()
    {
        // clear prompt on screen when not looking at an Interactable obj
        promptMessageObj.UpdateText(string.Empty);
    }
}
