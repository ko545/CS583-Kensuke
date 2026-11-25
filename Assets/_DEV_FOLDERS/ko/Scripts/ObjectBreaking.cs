using UnityEngine;

public class ObjectBreaking : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;

    void OnTriggerEnter(Collider collider)
    {
        Quaternion temp = this.transform.rotation;
        temp.x = 0;
        
        Instantiate(objectToSpawn, this.transform.position, temp);
        Destroy(this.gameObject);
    }
}
