using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerBody; // Reference to the player's body (the capsule)
    public Camera playerCamera; // Reference to the player's camera

    public float mouseSensitivityX = 100f; // Sensitivity for left/right look
    public float mouseSensitivityY = 100f; // Sensitivity for up/down look
    private float xRotation = 0f; // Rotation around the X-axis

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime; // X-axis rotation
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime; // Y-axis rotation

        // Calculate the X rotation and clamp it to prevent flipping
        xRotation -= mouseY; // Look up and down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit vertical rotation

        // Apply the rotation to the camera's transform
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player's body based on the mouse X input
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
