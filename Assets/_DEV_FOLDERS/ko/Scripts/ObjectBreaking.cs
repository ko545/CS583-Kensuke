using UnityEngine;

public class ObjectBreaking : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;

    void OnTriggerEnter(Collider collider)
    {
        Instantiate(objectToSpawn, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
