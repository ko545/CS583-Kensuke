using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5.5f;
    
    private CharacterController charController;
    private InputAction moveAction;

    private float currentMoveSpeed = 0.0f;
    private Vector3 moveDirection = Vector3.zero;
    

    private void Start()
    {
        charController = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        currentMoveSpeed = walkSpeed;
    }

    private void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        HandleMovement(moveVector);
    }

    private void HandleMovement(Vector2 moveVector)
    {
        // from local to world space
        // isnt this the WASD, both vertical and horizontal movement ? 
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float oldY = moveDirection.y;

        // i can just say explicitly that walkSpeed is always our current move speed
        Vector2 newSpeed = new Vector2(moveVector.y * currentMoveSpeed, moveVector.x * currentMoveSpeed);

        moveDirection = (forward * newSpeed.x) + (right * newSpeed.y);
        moveDirection.y = oldY;

        // move the actual char controller
        charController.Move(moveDirection * Time.deltaTime);
    }
}

