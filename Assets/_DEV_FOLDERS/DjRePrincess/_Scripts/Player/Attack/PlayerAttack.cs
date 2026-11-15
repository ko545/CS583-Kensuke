using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private InputAction attackAction;
    private string attackText = "Attack";
    void Start()
    {
        anim = GetComponent<Animator>();
        attackAction = InputSystem.actions.FindAction(attackText);
    }

    // Update is called once per frame
    void Update()
    {
        if (attackAction.triggered)
        {
            anim.SetTrigger(attackText);
        }
    }
}
