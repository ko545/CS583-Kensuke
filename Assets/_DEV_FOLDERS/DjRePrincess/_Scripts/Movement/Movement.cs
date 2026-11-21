using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Purpose: Make the Player move
[RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5.5f;
    private CharacterController charController;
    private InputAction moveAction;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        HandleMovement(moveVector);
    }

    private void HandleMovement(Vector2 moveVector)
    {
        Vector2 scaledMoveVector = moveVector * walkSpeed;

        // wont this be transform.position.y, not moveDirection.y
        float oldY = transform.position.y;

        // if i added y shit to this, its not horizontal motion anymore 
        Vector3 horizontalMotion = transform.TransformDirection(new Vector3(scaledMoveVector.x, 0, scaledMoveVector.y));

        charController.Move(horizontalMotion * Time.deltaTime);
    }

    //private void HandleMovement(Vector2 moveVector)
    //{
    //    // from local to world space
    //    // isnt this the WASD, both vertical and horizontal movement ? 
    //    Vector3 forward = transform.TransformDirection(Vector3.forward);
    //    Vector3 right = transform.TransformDirection(Vector3.right);

    //    float oldY = moveDirection.y;
    //    Vector2 newSpeed = new Vector2(moveVector.y * walkSpeed, moveVector.x * walkSpeed);

    //    moveDirection = (forward * newSpeed.x) + (right * newSpeed.y);
    //    moveDirection.y = oldY;

    //    // move the actual char controller
    //    charController.Move(moveDirection * Time.deltaTime);
    //}
}

