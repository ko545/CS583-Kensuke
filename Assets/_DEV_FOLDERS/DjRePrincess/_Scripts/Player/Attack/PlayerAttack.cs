using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] private BoxCollider swordCollider;
    private Animator anim;
    private InputAction attackAction;
    private string attackText = "Attack";
    void Start()
    {
        anim = GetComponent<Animator>();
        attackAction = InputSystem.actions.FindAction(attackText);
    }

    void Update()
    {
        if (attackAction.triggered)
        {
            //anim.SetTrigger(attackText);
            anim.Play(attackText);
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
