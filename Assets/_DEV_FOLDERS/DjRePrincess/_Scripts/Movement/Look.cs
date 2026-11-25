using UnityEngine;
using UnityEngine.InputSystem;

// Purpose: Handle mouse movement
public class Look : MonoBehaviour
{
    [SerializeField] private float lookSensitivity = 0.2f;
    [SerializeField] private float lookAngleLimit = 90f;
    private Camera mainCamera;
    private float lookAngle = 0.0f;

    void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();

        MakeCursorInvisible();
    }

    void Update()
    {
        // amount the mouse have moved since prev frame
        Vector2 mouseDelta = new Vector2(Mouse.current.delta.x.ReadValue(), Mouse.current.delta.y.ReadValue());
        HandleLooking(mouseDelta);
    }

    private void HandleLooking(Vector2 mouseDelta)
    {
        lookAngle += -mouseDelta.y * lookSensitivity;
        lookAngle = Mathf.Clamp(lookAngle, -lookAngleLimit, lookAngleLimit);

        // rotate camera for up and down movement 
        mainCamera.transform.localRotation = Quaternion.Euler(lookAngle, 0, 0);

        // rotate player for horizontal movement 
        transform.rotation *= Quaternion.Euler(0, mouseDelta.x * lookSensitivity, 0);
    }

    private void MakeCursorInvisible()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
