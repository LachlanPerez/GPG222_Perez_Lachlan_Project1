using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform PlayerCamera; // Reference to the player's camera
    public Vector2 sensitivities;  // X = horizontal sensitivity, Y = vertical sensitivity
    public float SmoothSpeed = 5f;

    private Vector2 SmoothRotation;
    private Vector2 XYRotation;    // Stores current X and Y rotation

    void Start()
    {
        // Lock the cursor to the center and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Apply sensitivity and invert Y-axis for looking up/down
        XYRotation.x -= mouseY * sensitivities.y;
        XYRotation.y += mouseX * sensitivities.x;

        // Clamp vertical rotation to avoid flipping
        XYRotation.x = Mathf.Clamp(XYRotation.x, -90f, 90f);

        SmoothRotation = Vector2.Lerp(SmoothRotation, XYRotation, SmoothSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0f, SmoothRotation.y, 0f);
        PlayerCamera.localEulerAngles = new Vector3(SmoothRotation.x, 0f, 0f);

    }
}
