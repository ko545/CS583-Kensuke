using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] private BoxCollider swordCollider;
    private Animator anim;
    private InputAction attackAction;
    private string attackText = "Attack";
    
    // this is to deactivate the collider when not attacking
    // please so something better this sucks
    [SerializeField] private GameObject collider;
    private float waitTime = 0.45f;
    private float timer = 0.0f;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        attackAction = InputSystem.actions.FindAction(attackText);
        collider.SetActive(false);
    }

    void Update()
    {
        if (attackAction.triggered)
        {
            timer = waitTime;
            collider.SetActive(true);
            //anim.SetTrigger(attackText);
            anim.Play(attackText);
        }

        //if the collider is active, deactivate it after waitTime seconds
        if (collider.activeInHierarchy)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                collider.SetActive(false);
            }
        }
    }


    // These are used by the sword animation events
    // to enable and disable the collider when attacking an enemy
    //private void EnableSwordCollider()
    //{
    //    swordCollider.enabled = true;
    //}

    //private void DisableSwordCollider()
    //{
    //    swordCollider.enabled = false;
    //}
}
