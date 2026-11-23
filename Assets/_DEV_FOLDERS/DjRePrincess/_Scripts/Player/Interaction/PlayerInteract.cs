using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float rayDistance = 3f;
    private Camera cam;
    
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
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
        Physics.Raycast(ray, out hitInfo); ///////////////// not done on this line 
        
    }
}
