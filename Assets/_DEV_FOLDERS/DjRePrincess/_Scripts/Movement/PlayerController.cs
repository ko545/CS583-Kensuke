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

    // do we need the actions, or just the actionmap itself
    private InputAction moveInput;

    private float currentMoveSpeed = 0.0f;
    private Vector3 moveDirection = Vector3.zero;
    private float lookAngle = 0.0f;

    private void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        charController = GetComponent<CharacterController>();

        moveInput = InputSystem.actions.FindAction("Move");

        // don't wanna make cursor visible on screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentMoveSpeed = walkSpeed;
    }
}
