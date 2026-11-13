using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5.5f;

    // Look stuff
    [SerializeField] private float lookSensitivity = 0.2f;
    [SerializeField] private float lookAngleLimit = 90f;

    private Camera mainCamera;
    private CharacterController charController;
    private InputAction moveAction;

    private float currentMoveSpeed = 0.0f;
    private Vector3 moveDirection = Vector3.zero;
    private float lookAngle = 0.0f;

    private void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        charController = GetComponent<CharacterController>();

        moveAction = InputSystem.actions.FindAction("Move");

        // make cursor visible on screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentMoveSpeed = walkSpeed;
    }

    private void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();

        // amount the mouse have moved since prev frame
        Vector2 mouseDelta = new Vector2(Mouse.current.delta.x.ReadValue(), Mouse.current.delta.y.ReadValue());
        HandleMovement(moveVector);
        HandleLooking(mouseDelta);
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

    private void HandleLooking(Vector2 mouseDelta)
    {
        // this is the mouse, how do we do the camera
        lookAngle += -mouseDelta.y * lookSensitivity;
        lookAngle = Mathf.Clamp(lookAngle, -lookAngleLimit, lookAngleLimit);

        // rotate camera for up and down movement 
        mainCamera.transform.localRotation = Quaternion.Euler(lookAngle, 0, 0);

        // rotate player for horizontal movement 
        transform.rotation *= Quaternion.Euler(0, mouseDelta.x * lookSensitivity, 0);
    }
}
