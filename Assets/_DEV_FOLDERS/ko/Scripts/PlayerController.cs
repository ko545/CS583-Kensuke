using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    //the worse player controller youve ever seen 
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 200.0f;
    [SerializeField] private GameObject attackHitbox;
    private Rigidbody rb;
    
    private KeyControl UP, DOWN, LEFT, RIGHT, JUMP, ATTACK;
    void Start()
    {
        attackHitbox.SetActive(false);
        
        UP = Keyboard.current.wKey;
        DOWN = Keyboard.current.sKey;
        LEFT = Keyboard.current.aKey;
        RIGHT = Keyboard.current.dKey;
        JUMP = Keyboard.current.spaceKey;
        ATTACK = Keyboard.current.leftShiftKey;

        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        if (ATTACK.isPressed)
        {
            attackHitbox.SetActive(true);
        } else attackHitbox.SetActive(false);
        
        if (JUMP.isPressed)
        {
            if (rb.position.y < 10.0f)
                rb.AddForce(Vector3.up * jumpForce);
        }
        if (UP.isPressed)
        {
            rb.linearVelocity = Vector3.forward * speed;
        }
        if (DOWN.isPressed)
        {
            rb.linearVelocity = Vector3.back * speed;
        }
        if (LEFT.isPressed)
        {
            rb.linearVelocity = Vector3.left * speed;
        }
        if (RIGHT.isPressed)
        {
            rb.linearVelocity = Vector3.right * speed;
        }
    }
}
