using UnityEngine;

public class Block : MonoBehaviour
{
    private Health healthObj;
    private MyInput myInput;
    private bool isBlocking = false;

    private void Start()
    {
        healthObj = GetComponent<Health>();
        
    }

    private void Update()
    {
        IsPlayerBlocking();
    }

    // the attack range objs are triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "AttackHitbox")
        {
            if (isBlocking)
            {
                // will this skip to next update() frame?
                return;
            }
            else
            {
                healthObj.TakeDamage();
            }
            
        }
        //print(other.name);

    }

    private void IsPlayerBlocking()
    {
        // see if player is holding down right mouse button
        isBlocking = myInput.Player.Block.ReadValue<float>() > 0;
        //print(isBlocking);
    }

    // ----------
    // Input instantiation 

    private void Awake()
    {
        myInput = new MyInput();
    }

    private void OnEnable()
    {
        myInput.Enable();
    }

    private void OnDisable()
    {
        myInput.Disable();
    }
}
